﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Vbe.Interop;
using Rubberduck.Common;
using Rubberduck.Parsing;
using Rubberduck.Parsing.Nodes;
using Rubberduck.Parsing.VBA;
using Rubberduck.Settings;
using Rubberduck.ToDoItems;
using Rubberduck.UI.Command;
using Rubberduck.VBEditor.VBEInterfaces.RubberduckCodePane;

namespace Rubberduck.UI.ToDoItems
{
    public class ToDoExplorerViewModel : ViewModelBase
    {
        private readonly RubberduckParserState _state;
        private readonly IEnumerable<ToDoMarker> _markers;
        private ObservableCollection<ToDoItem> _toDos; 
        public ToDoExplorerViewModel(RubberduckParserState state, IGeneralConfigService configService)
        {
            _state = state;
            _markers = configService.GetDefaultConfiguration().UserSettings.ToDoListSettings.ToDoMarkers;
            
            ToDos = new ObservableCollection<ToDoItem>();
        }

        public ObservableCollection<ToDoItem> ToDos {
            get { return _toDos; }
            set
            {
                _toDos = value;
                OnPropertyChanged();
            }
        } 

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand != null)
                {
                    return _refreshCommand;
                }
                return _refreshCommand = new DelegateCommand(_ =>
                {
                    _state.StateChanged += State_StateChanged;
                    _state.OnParseRequested();
                });
            }
        }

        private async void State_StateChanged(object sender, Parsing.VBA.ParserStateEventArgs e)
        {
            var results = await GetItems();
            ToDos = new ObservableCollection<ToDoItem>();
            ToDos.AddRange(results);
        }

        public ToDoItem SelectedToDo { get; set; }

        private ICommand _clear;
        public ICommand Clear
        {
            get
            {
                if (_clear != null)
                {
                    return _clear;
                }
                return _clear = new DelegateCommand(_ =>
                {
                    var module = SelectedToDo.GetSelection().QualifiedName.Component.CodeModule;

                    var oldContent = module.Lines[SelectedToDo.LineNumber, 1];
                    var newContent =
                        oldContent.Remove(SelectedToDo.GetSelection().Selection.StartColumn - 1);

                    module.ReplaceLine(SelectedToDo.LineNumber, newContent);

                    RefreshCommand.Execute(null);
                });
            }
        }

        private ICommand _navigateToToDo;
        public ICommand NavigateToToDo
        {
            get
            {
                if (_navigateToToDo != null)
                {
                    return _navigateToToDo;
                }
                return _navigateToToDo = new NavigateCommand();
            }
        }

        private IEnumerable<ToDoItem> GetToDoMarkers(CommentNode comment)
        {
            return _markers.Where(marker => !string.IsNullOrEmpty(marker.Text)
                && comment.Comment.ToLowerInvariant().Contains(marker.Text.ToLowerInvariant()))
                .Select(marker => new ToDoItem(marker.Priority, comment));
        }

        private async Task<IOrderedEnumerable<ToDoItem>> GetItems()
        {
            var markers = _state.AllComments.SelectMany(GetToDoMarkers).ToList();
            var sortedItems = markers.OrderByDescending(item => item.Priority)
                                   .ThenBy(item => item.ProjectName)
                                   .ThenBy(item => item.ModuleName)
                                   .ThenBy(item => item.LineNumber);

            return sortedItems;
        }
    }
}
