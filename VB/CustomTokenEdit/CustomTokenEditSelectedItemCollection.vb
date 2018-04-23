Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditSelectedItemCollection
		Inherits TokenEditSelectedItemCollection

		Public Sub New(ByVal properties As RepositoryItemTokenEdit)
			MyBase.New(properties)
		End Sub

		Default Public ReadOnly Property Item(ByVal index As Integer) As CustomTokenEditToken
			Get
				Return DirectCast(InnerList(index), CustomTokenEditToken)
			End Get
		End Property
	End Class
End Namespace
