Imports DevExpress.XtraEditors.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditHitInfo
		Inherits TokenEditHitInfo

		Public Sub New()
		End Sub
		Public Sub New(ByVal pt As Point)
			MyBase.New(pt)
		End Sub


		Public Sub ResetHitTest(ByVal ht As TokenEditHitTest)
			SetHitTest(ht)
		End Sub

		Public Sub ResetHitObject(ByVal obj As TokenEditTokenInfo)
			SetHitObject(obj)
		End Sub

		Private privateIsInCheckBox As Boolean
		Public Property IsInCheckBox() As Boolean
			Get
				Return privateIsInCheckBox
			End Get
			Private Set(ByVal value As Boolean)
				privateIsInCheckBox = value
			End Set
		End Property
		Public Sub InCheckBox(ByVal val As Boolean)
			IsInCheckBox = val
		End Sub
	End Class
End Namespace
