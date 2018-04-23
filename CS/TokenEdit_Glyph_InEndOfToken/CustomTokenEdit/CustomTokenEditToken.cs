using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class CustomTokenEditToken : TokenEditToken
    {
        public CustomTokenEditToken()  {  }
        public CustomTokenEditToken(object value) : base(value)  { }
        public CustomTokenEditToken(string description, object value, RepositoryItemCustomTokenEdit _Properties)
            : base(description, value) { Properties = _Properties; }

        readonly RepositoryItemCustomTokenEdit Properties;
        protected bool _checked;
        protected internal bool needRepaint = true;

        public bool Checked
        {
            get {   return _checked; }
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    OnCheckedChanged();
                }
            }
        }

        void OnCheckedChanged()
        {
            Properties.OnTokenCheckedChanged(this, needRepaint);
            needRepaint = true;
        }
    }
}
