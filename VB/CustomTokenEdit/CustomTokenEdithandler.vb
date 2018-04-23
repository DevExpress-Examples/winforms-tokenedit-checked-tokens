Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Example.CustomTokenEdit
	Public Class CustomTokenEdithandler
		Inherits TokenEditHandler

		Public Sub New(ByVal tokenEdit As TokenEdit)
			MyBase.New(tokenEdit)
		End Sub

		Protected Overrides Sub OnTokenClick(ByVal hitInfo As TokenEditHitInfo)
			ChangeCheckedIfRequired(hitInfo)
			MyBase.OnTokenClick(hitInfo)
		End Sub

		Private Sub ChangeCheckedIfRequired(ByVal hitInfo As TokenEditHitInfo)
			Dim hInfo As CustomTokenEditHitInfo = TryCast(hitInfo, CustomTokenEditHitInfo)
			If hInfo.IsInCheckBox Then
				TryCast(hitInfo.HitObject, CustomTokenEditTokenInfo).ChangeChecked()
			End If
		End Sub
	End Class
End Namespace
