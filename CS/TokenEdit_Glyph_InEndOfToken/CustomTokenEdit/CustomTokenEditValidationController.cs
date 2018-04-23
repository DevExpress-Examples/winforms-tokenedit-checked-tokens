using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditValidationController : TokenEditValidationController
    {
        public CustomTokenEditValidationController(RepositoryItemTokenEdit properties) : base(properties) { }

        protected override TokenEditToken CreateToken(string description, object value)
        {
            CustomTokenEditToken token = new CustomTokenEditToken(description, value, Properties as RepositoryItemCustomTokenEdit);
            return token;
        }
    }
}
