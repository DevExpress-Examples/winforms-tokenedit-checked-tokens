using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.Utils.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditViewInfo : TokenEditViewInfo
    {
        public CustomTokenEditViewInfo(RepositoryItem item) : base(item)
        {
            checkBoxBounds = new Dictionary<TokenEditToken, Rectangle>();
        }

        readonly Dictionary<TokenEditToken, Rectangle> checkBoxBounds;
        protected override Rectangle CalcBounds(Point topPt, TokenEditToken token)
        {
            Rectangle rect = base.CalcBounds(topPt, token);
            Rectangle temp = CalcGlyphBounds(token, rect);
            checkBoxBounds[token] = new Rectangle(rect.Right, temp.Top, temp.Width, temp.Height);
            rect.Width += CalcGlyphWidth(token) + ItemContentMargin;
            return rect;
        }

        protected override void UpdateTokenState(TokenEditTokenInfo tokenInfo)
        {
            base.UpdateTokenState(tokenInfo);
            if (!Item.ReadOnly)
            {
                Point pt = OwnerControl != null ? OwnerControl.PointToClient(Control.MousePosition) : MousePosition;
                CustomTokenEditTokenInfo info = tokenInfo as CustomTokenEditTokenInfo;
                if (info.CheckBoxGlyphBounds.Contains(pt))
                {
                    info.CheckBoxState = ObjectState.Hot;
                    if ((Control.MouseButtons & MouseButtons.Left) != 0) info.CheckBoxState |= ObjectState.Pressed;
                }
                else
                {
                    info.CheckBoxState = ObjectState.Normal;
                }
            }
        }

        protected internal void InvalidateCheckBox()
        {
            DoInvalidate();
        }

        protected override TokenEditTokenInfo CreateTokenEditTokenInfo(TokenEditToken token)
        {
            CustomTokenEditTokenInfo info = new CustomTokenEditTokenInfo(token, checkBoxBounds, this);
            return info;
        }

        protected override EditHitInfo CreateHitInfo(Point p)
        {
            return new CustomTokenEditHitInfo(p);
        }

        public override EditHitInfo CalcHitInfo(Point pt)
        {
            CustomTokenEditHitInfo hi = CreateHitInfo(pt) as CustomTokenEditHitInfo;
			if(!Bounds.Contains(pt)) return hi;
			foreach(CustomTokenEditTokenInfo tokenInfo in VisibleItems) 
            {
				if(tokenInfo.Bounds.Contains(pt)) 
                {
					hi.ResetHitObject(tokenInfo);
					hi.ResetHitTest(TokenEditHitTest.Link);
                    hi.InCheckBox(false);

                    if (tokenInfo.CheckBoxGlyphBounds.Contains(pt)) hi.InCheckBox(true);
					if(tokenInfo.GlyphBounds.Contains(pt)) hi.ResetHitTest(TokenEditHitTest.Glyph);
					return hi;
				}
			}
			if(ContentRect.Contains(pt)) hi.ResetHitTest(TokenEditHitTest.EditorRect);

            return hi;
        }
    }
}
