Imports DevExpress.XtraEditors.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditViewInfo
		Inherits TokenEditViewInfo

		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
			checkBoxBounds = New Dictionary(Of TokenEditToken, Rectangle)()
		End Sub

		Private ReadOnly checkBoxBounds As Dictionary(Of TokenEditToken, Rectangle)
		Protected Overrides Function CalcBounds(ByVal topPt As Point, ByVal token As TokenEditToken) As Rectangle
			Dim rect As Rectangle = MyBase.CalcBounds(topPt, token)
			Dim temp As Rectangle = CalcGlyphBounds(token, rect)
			checkBoxBounds(token) = New Rectangle(rect.Right, temp.Top, temp.Width, temp.Height)
			rect.Width += CalcGlyphWidth(token) + ItemContentMargin
			Return rect
		End Function

		Protected Overrides Sub UpdateTokenState(ByVal tokenInfo As TokenEditTokenInfo)
			MyBase.UpdateTokenState(tokenInfo)
			If Not Item.ReadOnly Then
				Dim pt As Point = If(OwnerControl IsNot Nothing, OwnerControl.PointToClient(Control.MousePosition), MousePosition)
				Dim info As CustomTokenEditTokenInfo = TryCast(tokenInfo, CustomTokenEditTokenInfo)
				If info.CheckBoxGlyphBounds.Contains(pt) Then
					info.CheckBoxState = ObjectState.Hot
					If (Control.MouseButtons And MouseButtons.Left) <> 0 Then
						info.CheckBoxState = info.CheckBoxState Or ObjectState.Pressed
					End If
				Else
					info.CheckBoxState = ObjectState.Normal
				End If
			End If
		End Sub

		Protected Friend Sub InvalidateCheckBox()
			DoInvalidate()
		End Sub

		Protected Overrides Function CreateTokenEditTokenInfo(ByVal token As TokenEditToken) As TokenEditTokenInfo
			Dim info As New CustomTokenEditTokenInfo(token, checkBoxBounds, Me)
			Return info
		End Function

		Protected Overrides Function CreateHitInfo(ByVal p As Point) As EditHitInfo
			Return New CustomTokenEditHitInfo(p)
		End Function

		Public Overrides Function CalcHitInfo(ByVal pt As Point) As EditHitInfo
			Dim hi As CustomTokenEditHitInfo = TryCast(CreateHitInfo(pt), CustomTokenEditHitInfo)
			If Not Bounds.Contains(pt) Then
				Return hi
			End If
			For Each tokenInfo As CustomTokenEditTokenInfo In VisibleItems
				If tokenInfo.Bounds.Contains(pt) Then
					hi.ResetHitObject(tokenInfo)
					hi.ResetHitTest(TokenEditHitTest.Link)
					hi.InCheckBox(False)

					If tokenInfo.CheckBoxGlyphBounds.Contains(pt) Then
						hi.InCheckBox(True)
					End If
					If tokenInfo.GlyphBounds.Contains(pt) Then
						hi.ResetHitTest(TokenEditHitTest.Glyph)
					End If
					Return hi
				End If
			Next tokenInfo
			If ContentRect.Contains(pt) Then
				hi.ResetHitTest(TokenEditHitTest.EditorRect)
			End If

			Return hi
		End Function
	End Class
End Namespace
