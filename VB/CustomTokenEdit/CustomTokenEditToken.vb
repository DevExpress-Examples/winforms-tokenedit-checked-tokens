Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditToken
		Inherits TokenEditToken

		Public Sub New()
		End Sub
		Public Sub New(ByVal value As Object)
			MyBase.New(value)
		End Sub
		Public Sub New(ByVal description As String, ByVal value As Object, ByVal _Properties As RepositoryItemCustomTokenEdit)
			MyBase.New(description, value)
		Properties = _Properties
		End Sub

		Private ReadOnly Properties As RepositoryItemCustomTokenEdit
		Protected _checked As Boolean
		Protected Friend needRepaint As Boolean = True

		Public Property Checked() As Boolean
			Get
				Return _checked
			End Get
			Set(ByVal value As Boolean)
				If _checked <> value Then
					_checked = value
					OnCheckedChanged()
				End If
			End Set
		End Property

		Private Sub OnCheckedChanged()
			Properties.OnTokenCheckedChanged(Me, needRepaint)
			needRepaint = True
		End Sub
	End Class
End Namespace
