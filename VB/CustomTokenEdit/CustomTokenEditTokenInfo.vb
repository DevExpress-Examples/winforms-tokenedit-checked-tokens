Imports DevExpress.XtraEditors.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Namespace Example.CustomTokenEdit
	Public Class CustomTokenEditTokenInfo
		Inherits TokenEditTokenInfo

		Public Sub New(ByVal token As TokenEditToken)
			MyBase.New(token)
		End Sub
		Public Sub New(ByVal token As TokenEditToken, ByVal _checkBoxBounds As Dictionary(Of TokenEditToken, Rectangle), ByVal _viewInfo As CustomTokenEditViewInfo)
			MyBase.New(token)
			checkBoxBounds = _checkBoxBounds
			viewInfo = _viewInfo
		End Sub

		Public ReadOnly Property CustomToken() As CustomTokenEditToken
			Get
				Return TryCast(MyBase.Token, CustomTokenEditToken)
			End Get
		End Property

		Private ReadOnly checkBoxBounds As Dictionary(Of TokenEditToken, Rectangle)
		Public ReadOnly Property CheckBoxGlyphBounds() As Rectangle
			Get
				Return checkBoxBounds(CustomToken)
			End Get
		End Property
		Private ReadOnly viewInfo As CustomTokenEditViewInfo

		Public ReadOnly Property Checked() As Boolean
			Get
				Return CustomToken.Checked
			End Get
		End Property
		Public Sub ChangeChecked()
			CustomToken.needRepaint = False
			CustomToken.Checked = Not CustomToken.Checked
		End Sub


        Private _checkBoxState As ObjectState
        Public Property CheckBoxState() As ObjectState
            Get
                Return _checkBoxState
            End Get
            Set(ByVal value As ObjectState)
                If _checkBoxState <> value Then
                    _checkBoxState = value
                    OnCheckBoxStateChanged()
				End If
			End Set
		End Property

		Private Sub OnCheckBoxStateChanged()
			viewInfo.InvalidateCheckBox()
		End Sub
	End Class
End Namespace
