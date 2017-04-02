//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Dev\Rubberduck\Rubberduck.Parsing\Preprocessing\VBAConditionalCompilationParser.g4 by ANTLR 4.3

// Unreachable code detected

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace Rubberduck.Parsing.PreProcessing {
    /// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="VBAConditionalCompilationParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public interface IVBAConditionalCompilationParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcBlock([NotNull] VBAConditionalCompilationParser.CcBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.typeHint"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeHint([NotNull] VBAConditionalCompilationParser.TypeHintContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.hashIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHashIf([NotNull] VBAConditionalCompilationParser.HashIfContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] VBAConditionalCompilationParser.LiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.hashConst"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHashConst([NotNull] VBAConditionalCompilationParser.HashConstContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.statementKeyword"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementKeyword([NotNull] VBAConditionalCompilationParser.StatementKeywordContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.foreignName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForeignName([NotNull] VBAConditionalCompilationParser.ForeignNameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.intrinsicFunctionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntrinsicFunctionName([NotNull] VBAConditionalCompilationParser.IntrinsicFunctionNameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.markerKeyword"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMarkerKeyword([NotNull] VBAConditionalCompilationParser.MarkerKeywordContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.keyword"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKeyword([NotNull] VBAConditionalCompilationParser.KeywordContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccEndIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcEndIf([NotNull] VBAConditionalCompilationParser.CcEndIfContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.nameValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNameValue([NotNull] VBAConditionalCompilationParser.NameValueContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccEol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcEol([NotNull] VBAConditionalCompilationParser.CcEolContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccIfBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcIfBlock([NotNull] VBAConditionalCompilationParser.CcIfBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.intrinsicFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntrinsicFunction([NotNull] VBAConditionalCompilationParser.IntrinsicFunctionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.foreignIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForeignIdentifier([NotNull] VBAConditionalCompilationParser.ForeignIdentifierContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.hashElse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHashElse([NotNull] VBAConditionalCompilationParser.HashElseContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.hashEndIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHashEndIf([NotNull] VBAConditionalCompilationParser.HashEndIfContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcExpression([NotNull] VBAConditionalCompilationParser.CcExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccElseIfBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcElseIfBlock([NotNull] VBAConditionalCompilationParser.CcElseIfBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.compilationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompilationUnit([NotNull] VBAConditionalCompilationParser.CompilationUnitContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcIf([NotNull] VBAConditionalCompilationParser.CcIfContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccElseIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcElseIf([NotNull] VBAConditionalCompilationParser.CcElseIfContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccElseBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcElseBlock([NotNull] VBAConditionalCompilationParser.CcElseBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitName([NotNull] VBAConditionalCompilationParser.NameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccVarLhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcVarLhs([NotNull] VBAConditionalCompilationParser.CcVarLhsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccElse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcElse([NotNull] VBAConditionalCompilationParser.CcElseContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComment([NotNull] VBAConditionalCompilationParser.CommentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.hashElseIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHashElseIf([NotNull] VBAConditionalCompilationParser.HashElseIfContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.physicalLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPhysicalLine([NotNull] VBAConditionalCompilationParser.PhysicalLineContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="VBAConditionalCompilationParser.ccConst"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCcConst([NotNull] VBAConditionalCompilationParser.CcConstContext context);
}
} // namespace Rubberduck.Parsing
