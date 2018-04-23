Imports DevExpress.Skins
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditPainter
		Inherits TokenEditPainter

		Private editor As CustomTokenEdit
		Public Sub SetEditor(ByVal _editor As CustomTokenEdit)
			editor = _editor
		End Sub

		Protected Overrides Sub DoDrawGlyph(ByVal info As ControlGraphicsInfoArgs, ByVal tokenInfo As TokenEditTokenInfo)
			MyBase.DoDrawGlyph(info, tokenInfo)
			If editor.Properties.CheckBoxCollection.Images.Count <> 0 Then
				Dim index As Integer = 0
				Dim customTokenInfo As CustomTokenEditTokenInfo = TryCast(tokenInfo, CustomTokenEditTokenInfo)
				Dim offset As Integer = If(customTokenInfo.Checked = True, 4, 0)
				Select Case customTokenInfo.CheckBoxState
						Case ObjectState.Normal
							index = offset
						Case ObjectState.Hot
							index = offset + 1
						Case ObjectState.Hot Or ObjectState.Pressed
							index = offset + 2
				End Select
				Dim rect As Rectangle = customTokenInfo.CheckBoxGlyphBounds
				info.Graphics.DrawImage(editor.Properties.CheckBoxCollection.Images(index), New Rectangle(rect.X + CInt(Fix(info.Graphics.ClipBounds.X)), rect.Y + CInt(Fix(info.Graphics.ClipBounds.Y)), rect.Width, rect.Height))
			End If
		End Sub
	End Class
End Namespace
