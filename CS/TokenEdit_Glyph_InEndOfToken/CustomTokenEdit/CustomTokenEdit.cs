using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    [ToolboxItem(true)]
    public class CustomTokenEdit : TokenEdit
    {
        static CustomTokenEdit()
        {
            RepositoryItemCustomTokenEdit.Register();
        }
        public CustomTokenEdit()
        {
            (Painter as CustomTokenEditPainter).SetEditor(this);
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemCustomTokenEdit.EditorName; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomTokenEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomTokenEdit; }
        }

        public void Repaint()
        {
            base.LayoutChanged();
        }

        protected override TokenEditHandler CreateHandler()
        {
            return new CustomTokenEdithandler(this);
        }

       public CustomTokenEditToken CheckedItem { get { return base.CheckedItem as CustomTokenEditToken;} }
       public CustomTokenEditCheckedItemCollection CheckedItems { get { return base.CheckedItems as CustomTokenEditCheckedItemCollection; } }
       public CustomTokenEditSelectedItemCollection SelectedItems { get { return base.SelectedItems as CustomTokenEditSelectedItemCollection; } }
    }
}
