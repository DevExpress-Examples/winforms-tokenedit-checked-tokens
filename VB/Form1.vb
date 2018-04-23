Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions
Imports Example.CustomTokenEdit

Namespace Example
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			InitToken()
			InitGridControl()
		End Sub


		Private Sub InitToken()
			AddHandler tokenEdit1.Properties.ValidateToken, AddressOf tokenEdit1_ValidateToken
			tokenEdit1.EditValue = "test@mail.com,test@test.com,test@microsoft.com"
			AddHandler tokenEdit1.Properties.TokenCheckedChanged, AddressOf TokenCheckedChanged
		End Sub

		Private Sub InitGridControl()
			Dim edit As New RepositoryItemCustomTokenEdit()
			edit.Separators.AddRange(New String() { "," })
			edit.EditMode = TokenEditMode.Manual
			AddHandler edit.ValidateToken, AddressOf tokenEdit1_ValidateToken
			AddHandler edit.TokenCheckedChanged, AddressOf TokenCheckedChanged

			Dim lst As New List(Of Test)()
			For i As Integer = 0 To 9
				lst.Add(New Test() With {.Token = String.Format("test{0}@mail.com", i)})
			Next i
			gridControl1.DataSource = lst
			gridControl1.RepositoryItems.Add(edit)
			gridView1.Columns(0).ColumnEdit = edit
		End Sub

		Private ReadOnly MailRegex As New Regex("^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$", RegexOptions.Compiled)
		Private Sub tokenEdit1_ValidateToken(ByVal sender As Object, ByVal e As TokenEditValidateTokenEventArgs)
			e.IsValid = MailRegex.IsMatch(e.Description)
		End Sub

		Private Sub TokenCheckedChanged(ByVal sender As Object, ByVal e As TokenCheckedChangedEventArgs)
			XtraMessageBox.Show(String.Format("{0} {1} Checked: {2}", e.Token.Description, e.Token.Value, e.Token.Checked))
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			If tokenEdit1.CheckedItem IsNot Nothing Then
				tokenEdit1.CheckedItem.Checked = Not tokenEdit1.CheckedItem.Checked
			End If
		End Sub

		Private Class Test
			Public Property Token() As Object
		End Class


	End Class
End Namespace
