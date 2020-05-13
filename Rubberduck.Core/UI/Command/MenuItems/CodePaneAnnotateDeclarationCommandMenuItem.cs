﻿using Rubberduck.Parsing.VBA;
using Rubberduck.UI.Command.MenuItems.ParentMenus;
using Rubberduck.UI.Command.Refactorings;

namespace Rubberduck.UI.Command.MenuItems
{
    public class CodePaneAnnotateDeclarationCommandMenuItem : CommandMenuItemBase
    {
        public CodePaneAnnotateDeclarationCommandMenuItem(CodePaneAnnotateDeclarationCommand command)
            : base(command)
        { }

        public override string Key => "RefactorMenu_AnnotateDeclaration";
        public override int DisplayOrder => (int)RefactoringsMenuItemDisplayOrder.AnnotateDeclaration;

        public override bool EvaluateCanExecute(RubberduckParserState state)
        {
            return state != null && Command.CanExecute(null);
        }
    }
}