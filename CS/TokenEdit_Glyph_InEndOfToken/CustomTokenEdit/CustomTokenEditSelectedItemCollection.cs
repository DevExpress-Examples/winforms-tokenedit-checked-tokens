using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditSelectedItemCollection : TokenEditSelectedItemCollection
    {
        public CustomTokenEditSelectedItemCollection(RepositoryItemTokenEdit properties) : base(properties) { }

        public new CustomTokenEditToken this[int index] { get { return (CustomTokenEditToken)InnerList[index]; } }
    }
}
