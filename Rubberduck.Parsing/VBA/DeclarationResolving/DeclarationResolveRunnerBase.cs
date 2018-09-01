﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Antlr4.Runtime.Tree;
using NLog;
using Rubberduck.Parsing.Symbols;
using Rubberduck.Parsing.VBA.ComReferenceLoading;
using Rubberduck.VBEditor;
using Rubberduck.VBEditor.SafeComWrappers.Abstract;

namespace Rubberduck.Parsing.VBA.DeclarationResolving
{
    public abstract class DeclarationResolveRunnerBase : IDeclarationResolveRunner
    {
        protected readonly ConcurrentDictionary<string, Declaration> _projectDeclarations = new ConcurrentDictionary<string, Declaration>();
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected readonly RubberduckParserState _state;
        protected readonly IParserStateManager _parserStateManager;
        private readonly IProjectReferencesProvider _projectReferencesProvider;

        protected DeclarationResolveRunnerBase(
            RubberduckParserState state,
            IParserStateManager parserStateManager,
            IProjectReferencesProvider projectReferencesProvider)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            if (parserStateManager == null)
            {
                throw new ArgumentNullException(nameof(parserStateManager));
            }
            if (projectReferencesProvider == null)
            {
                throw new ArgumentNullException(nameof(projectReferencesProvider));
            }

            _state = state;
            _parserStateManager = parserStateManager;
            _projectReferencesProvider = projectReferencesProvider;
        }


        public abstract void ResolveDeclarations(IReadOnlyCollection<QualifiedModuleName> modules, CancellationToken token);


        protected void ResolveDeclarations(QualifiedModuleName module, IParseTree tree, CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var projectDeclaration = GetOrCreateProjectDeclaration(module);

                Logger.Debug("Creating declarations for module {0}.", module.Name);

                var declarationsListener = new DeclarationSymbolsListener(_state, module, _state.GetModuleAnnotations(module), _state.GetModuleAttributes(module), _state.GetMembersAllowingAttributes(module), projectDeclaration);
                ParseTreeWalker.Default.Walk(declarationsListener, tree);
                foreach (var createdDeclaration in declarationsListener.CreatedDeclarations)
                {
                    _state.AddDeclaration(createdDeclaration);
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception, "Exception thrown acquiring declarations for '{0}' (thread {1}).", module.Name, Thread.CurrentThread.ManagedThreadId);
                _parserStateManager.SetModuleState(module, ParserState.ResolverError, token);
            }
            stopwatch.Stop();
            Logger.Debug("{0}ms to resolve declarations for component {1}", stopwatch.ElapsedMilliseconds, module.Name);
        }

        private Declaration GetOrCreateProjectDeclaration(QualifiedModuleName module)
        {
            if (_projectDeclarations.TryGetValue(module.ProjectId, out var projectDeclaration))
            {
                return projectDeclaration;

            }
            var project = _state.ProjectsProvider.Project(module.ProjectId);
            projectDeclaration = CreateProjectDeclaration(project);

            if (projectDeclaration.ProjectId != module.ProjectId)
            {
                Logger.Error($"Inconsistent projectId between QualifiedModuleName {module} (projectID {module.ProjectId}) and its project (projectId {projectDeclaration.ProjectId})");
                throw new ArgumentException($"Inconsistent projectID on {nameof(module)}");
            }

            _projectDeclarations.AddOrUpdate(module.ProjectId, projectDeclaration, (s, c) => projectDeclaration);
            _state.AddDeclaration(projectDeclaration);

            return projectDeclaration;
        }

        private Declaration CreateProjectDeclaration(IVBProject project)
        {
            var qualifiedModuleName = new QualifiedModuleName(project);
            var qualifiedName = qualifiedModuleName.QualifyMemberName(project.Name);
            var projectId = qualifiedModuleName.ProjectId;
            var projectDeclaration = new ProjectDeclaration(qualifiedName, qualifiedName.MemberName, true, project);
            var references = ProjectReferences(projectId);

            AddReferences(projectDeclaration, references);

            return projectDeclaration;
        }

        private static void AddReferences(ProjectDeclaration projectDeclaration, List<ReferencePriorityMap> references)
        {
            var projectId = projectDeclaration.ProjectId;
            foreach (var reference in references)
            {
                int priority = reference[projectId];
                projectDeclaration.AddProjectReference(reference.ReferencedProjectId, priority);
            }
        }

        private List<ReferencePriorityMap> ProjectReferences(string projectId)
        {
            var references = new List<ReferencePriorityMap>();
            foreach (var item in _projectReferencesProvider.ProjectReferences)
            {
                if (item.ContainsKey(projectId))
                {
                    references.Add(item);
                }
            }

            return references;
        }
    }
}
