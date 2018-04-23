using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditHitInfo : TokenEditHitInfo
    {
        public CustomTokenEditHitInfo() {     }
        public CustomTokenEditHitInfo(Point pt) : base(pt) { }


        public void ResetHitTest(TokenEditHitTest ht )
        {
            SetHitTest(ht);
        }

        public void ResetHitObject(TokenEditTokenInfo obj)
        {
            SetHitObject(obj);
        }

        public bool IsInCheckBox { get; private set; }
        public void InCheckBox(bool val)
        {
            IsInCheckBox = val;
        }
    }
}
