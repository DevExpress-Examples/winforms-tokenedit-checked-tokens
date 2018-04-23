using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TokenEdit_Glyph_InEndOfToken.CustomTokenEdit;

namespace TokenEdit_Glyph_InEndOfToken
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            InitToken();
            InitGridControl();
        }


        private void InitToken()
        {
            tokenEdit1.Properties.ValidateToken += tokenEdit1_ValidateToken;
            tokenEdit1.EditValue = "test@mail.com,test@test.com,test@microsoft.com";
            tokenEdit1.Properties.TokenCheckedChanged += TokenCheckedChanged;
        }

        private void InitGridControl()
        {
            RepositoryItemCustomTokenEdit edit = new RepositoryItemCustomTokenEdit();
            edit.Separators.AddRange(new string[] { "," });
            edit.EditMode = TokenEditMode.Manual;
            edit.ValidateToken += tokenEdit1_ValidateToken;
            edit.TokenCheckedChanged += TokenCheckedChanged;

            List<Test> lst = new List<Test>();
            for (int i = 0; i < 10; i++)
                lst.Add(new Test() { Token = string.Format("test{0}@mail.com", i) });
            gridControl1.DataSource = lst;
            gridControl1.RepositoryItems.Add(edit);
            gridView1.Columns[0].ColumnEdit = edit;
        }

        readonly Regex MailRegex = new Regex(@"^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$", RegexOptions.Compiled);
        private void tokenEdit1_ValidateToken(object sender, TokenEditValidateTokenEventArgs e)
        {
            e.IsValid = MailRegex.IsMatch(e.Description);
        }

        private void TokenCheckedChanged(object sender, TokenCheckedChangedEventArgs e)
        {
            XtraMessageBox.Show(string.Format("{0} {1} Checked: {2}", e.Token.Description, e.Token.Value, e.Token.Checked));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (tokenEdit1.CheckedItem != null)
                tokenEdit1.CheckedItem.Checked = !tokenEdit1.CheckedItem.Checked;
        }

        class Test
        {
            public object Token { get; set; }
        }
        

    }
}
