using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit {
    [UserRepositoryItem("Register")]
    public class RepositoryItemCustomTokenEdit : RepositoryItemTokenEdit {
        static RepositoryItemCustomTokenEdit() { Register(); }
        public RepositoryItemCustomTokenEdit() { checkBoxCollection = GetCheckBoxImages(); }

        internal const string EditorName = "CustomTokenEdit";
        public static void Register() {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(CustomTokenEdit),
                typeof(RepositoryItemCustomTokenEdit), typeof(CustomTokenEditViewInfo),
                new CustomTokenEditPainter(), true, null));
        }
        public override string EditorTypeName { get { return EditorName; } }

        readonly SkinElement checkBoxCollection;
        public SkinElement CheckBoxSkinElement { get { return checkBoxCollection; } }

        protected virtual SkinElement GetCheckBoxImages() {
            Skin skin = EditorsSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            SkinElement skinElement = skin["CheckBox"];
            if (skinElement == null)
                return null;
            return skinElement;
        }

        protected override TokenEditCheckedItemCollection CreateCheckedItemCollection() {
            return new CustomTokenEditCheckedItemCollection(this);
        }

        protected override TokenEditSelectedItemCollection CreateSelectedItemCollection() {
            return new CustomTokenEditSelectedItemCollection(this);
        }

        protected override TokenEditToken CreateTokenInstance(string description, object value, bool autoPopulated) {
            CustomTokenEditToken token = new CustomTokenEditToken(description, value, this as RepositoryItemCustomTokenEdit);
            return token;
        }

        public event EventHandler<TokenCheckedChangedEventArgs> TokenCheckedChanged;
        protected internal void OnTokenCheckedChanged(CustomTokenEditToken token, bool repaint) {
            RepaintEditIfRequired(repaint);
            RaiseTokenCheckedChanged(token);
        }

        private void RaiseTokenCheckedChanged(CustomTokenEditToken token) {
            EventHandler<TokenCheckedChangedEventArgs> handler = TokenCheckedChanged;
            if (handler != null)
                handler(this, new TokenCheckedChangedEventArgs(token));
        }

        private void RepaintEditIfRequired(bool repaint) {
            CustomTokenEdit edit = OwnerEdit as CustomTokenEdit;
            if (repaint && edit != null)
                edit.Repaint();
        }
    }
}
