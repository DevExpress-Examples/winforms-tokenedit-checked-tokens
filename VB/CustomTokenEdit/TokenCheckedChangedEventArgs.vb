Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Example.CustomTokenEdit
	Public Class TokenCheckedChangedEventArgs
		Inherits EventArgs

		Public Sub New(ByVal _token As CustomTokenEditToken)
			Token = _token
		End Sub

		Private privateToken As CustomTokenEditToken
		Public Property Token() As CustomTokenEditToken
			Get
				Return privateToken
			End Get
			Private Set(ByVal value As CustomTokenEditToken)
				privateToken = value
			End Set
		End Property
	End Class
End Namespace
