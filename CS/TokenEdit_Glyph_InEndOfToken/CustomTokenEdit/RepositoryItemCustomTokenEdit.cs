using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    [UserRepositoryItem("Register")]
    public class RepositoryItemCustomTokenEdit : RepositoryItemTokenEdit
    {
        static RepositoryItemCustomTokenEdit() {  Register(); }
        public RepositoryItemCustomTokenEdit() { checkBoxCollection = GetCheckBoxImages(); }

        internal const string EditorName = "CustomTokenEdit";
        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(CustomTokenEdit),
                typeof(RepositoryItemCustomTokenEdit), typeof(CustomTokenEditViewInfo),
                new CustomTokenEditPainter(), true, null));
        }
        public override string EditorTypeName { get { return EditorName; } }

        readonly ImageCollection checkBoxCollection;
        public ImageCollection CheckBoxCollection{ get { return checkBoxCollection; }  }

        protected virtual ImageCollection GetCheckBoxImages()
        {
            Skin skin = EditorsSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            SkinElement skinElement = skin["CheckBox"];
            if (skinElement == null)
                return null;
            return skinElement.Image.GetImages();
        }

        protected override TokenEditValidationController CreateValidationController()
        {
            return new CustomTokenEditValidationController(this);
        }

        protected override TokenEditCheckedItemCollection CreateCheckedItemCollection()
        {
            return new CustomTokenEditCheckedItemCollection(this);
        }

        protected override TokenEditSelectedItemCollection CreateSelectedItemCollection()
        {
            return new CustomTokenEditSelectedItemCollection(this);
        }

        public event EventHandler<TokenCheckedChangedEventArgs> TokenCheckedChanged;
        protected internal void OnTokenCheckedChanged(CustomTokenEditToken token, bool repaint)
        {
            RepaintEditIfRequired(repaint);
            RaiseTokenCheckedChanged(token);
        }

        private void RaiseTokenCheckedChanged(CustomTokenEditToken token)
        {
            EventHandler<TokenCheckedChangedEventArgs> handler = TokenCheckedChanged;
            if (handler != null)
                handler(this, new TokenCheckedChangedEventArgs(token));
        }

        private void RepaintEditIfRequired(bool repaint)
        {
            CustomTokenEdit edit = OwnerEdit as CustomTokenEdit;
            if (repaint && edit != null)
                edit.Repaint();
        }        
    }
}
