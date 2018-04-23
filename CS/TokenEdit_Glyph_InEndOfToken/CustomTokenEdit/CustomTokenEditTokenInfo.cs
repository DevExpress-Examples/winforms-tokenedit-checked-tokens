using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.Utils.Drawing;
namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditTokenInfo : TokenEditTokenInfo
    {
        public CustomTokenEditTokenInfo(TokenEditToken token) : base(token) { }
        public CustomTokenEditTokenInfo(TokenEditToken token, Dictionary<TokenEditToken, Rectangle> _checkBoxBounds, CustomTokenEditViewInfo _viewInfo) : base(token) 
        { 
            checkBoxBounds = _checkBoxBounds;
            viewInfo = _viewInfo;
        }

        public CustomTokenEditToken CustomToken { get { return base.Token as CustomTokenEditToken; } }

        readonly Dictionary<TokenEditToken, Rectangle> checkBoxBounds;
        public Rectangle CheckBoxGlyphBounds { get { return checkBoxBounds[CustomToken]; } }
        readonly CustomTokenEditViewInfo viewInfo;

        public bool Checked { get { return CustomToken.Checked; } }
        public void ChangeChecked()
        {
            CustomToken.needRepaint = false;
            CustomToken.Checked = !CustomToken.Checked;
        }

        ObjectState checkBoxState;
        public ObjectState CheckBoxState
        {
            get
            {
                return checkBoxState;
            }
            set
            {
                if (checkBoxState != value)
                {
                    checkBoxState = value;
                    OnCheckBoxStateChanged();
                }
            }
        }

        void OnCheckBoxStateChanged()
        {
            viewInfo.InvalidateCheckBox();
        }
    }
}
