using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditCheckedItemCollection : TokenEditCheckedItemCollection
    {
        public CustomTokenEditCheckedItemCollection(RepositoryItemTokenEdit properties)
            : base(properties) { }

        public CustomTokenEditToken this[int index] { get { return (CustomTokenEditToken)InnerList[index]; } }
    }
}
