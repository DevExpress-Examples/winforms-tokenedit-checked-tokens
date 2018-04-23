using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenEdit_Glyph_InEndOfToken.CustomTokenEdit
{
    public class TokenCheckedChangedEventArgs : EventArgs
    {
        public TokenCheckedChangedEventArgs(CustomTokenEditToken _token)
        {
            Token = _token;
        }
         
        public CustomTokenEditToken Token { get; private set; }
    }
}
