Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditValidationController
		Inherits TokenEditValidationController

		Public Sub New(ByVal properties As RepositoryItemTokenEdit)
			MyBase.New(properties)
		End Sub

		Protected Overrides Function CreateToken(ByVal description As String, ByVal value As Object) As TokenEditToken
			Dim token As New CustomTokenEditToken(description, value, TryCast(Properties, RepositoryItemCustomTokenEdit))
			Return token
		End Function
	End Class
End Namespace
