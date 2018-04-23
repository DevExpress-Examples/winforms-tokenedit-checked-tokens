using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEdithandler : TokenEditHandler
    {
        public CustomTokenEdithandler(TokenEdit tokenEdit) : base(tokenEdit) { }

        protected override void OnTokenClick(TokenEditHitInfo hitInfo)
        {
            ChangeCheckedIfRequired(hitInfo);
            base.OnTokenClick(hitInfo);
        }

        private void ChangeCheckedIfRequired(TokenEditHitInfo hitInfo)
        {
            CustomTokenEditHitInfo hInfo = hitInfo as CustomTokenEditHitInfo;
            if (hInfo.IsInCheckBox)
                (hitInfo.HitObject as CustomTokenEditTokenInfo).ChangeChecked();
        }
    }
}
