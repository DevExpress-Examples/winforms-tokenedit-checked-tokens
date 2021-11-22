﻿using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit {
    public class CustomTokenEditPainter : TokenEditPainter {
        CustomTokenEdit editor;
        public void SetEditor(CustomTokenEdit _editor) {
            editor = _editor;
        }

        protected override void DoDrawGlyph(ControlGraphicsInfoArgs info, TokenEditTokenInfo tokenInfo) {
            base.DoDrawGlyph(info, tokenInfo);

            if (editor.Properties.CheckBoxSkinElement != null) {
                int index = 0;
                CustomTokenEditTokenInfo customTokenInfo = tokenInfo as CustomTokenEditTokenInfo;
                int offset = customTokenInfo.Checked == true ? 4 : 0;
                Rectangle rect = customTokenInfo.CheckBoxGlyphBounds;
                Rectangle r = new Rectangle(rect.X + (int)info.Graphics.ClipBounds.X, rect.Y + (int)info.Graphics.ClipBounds.Y, rect.Width, rect.Height);
                SkinElementInfo skinElementInfo = new SkinElementInfo(editor.Properties.CheckBoxSkinElement, r);
                switch (customTokenInfo.CheckBoxState) {
                    case ObjectState.Normal:
                        index = offset;
                        break;
                    case ObjectState.Hot:
                        index = offset + 1;
                        break;
                    case ObjectState.Hot | ObjectState.Pressed:
                        index = offset + 2;
                        break;
                }
                skinElementInfo.ImageIndex = index;


                ImageCollection imageCollection = editor.Properties.CheckBoxSkinElement.Image.GetImages();
                info.Graphics.DrawImage(imageCollection.Images[index], new Rectangle(rect.X + (int)info.Graphics.ClipBounds.X, rect.Y + (int)info.Graphics.ClipBounds.Y, rect.Width, rect.Height));
                ObjectPainter.DrawObject(info.Cache, SkinElementPainter.Default, skinElementInfo);
            }
        }
    }
}
