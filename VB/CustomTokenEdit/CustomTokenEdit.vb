Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq

Namespace Example.CustomTokenEdit
	<ToolboxItem(True)>
	Public Class CustomTokenEdit
		Inherits TokenEdit

		Shared Sub New()
			RepositoryItemCustomTokenEdit.Register()
		End Sub
		Public Sub New()
			TryCast(Painter, CustomTokenEditPainter).SetEditor(Me)
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemCustomTokenEdit.EditorName
			End Get
		End Property
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public Shadows ReadOnly Property Properties() As RepositoryItemCustomTokenEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemCustomTokenEdit)
			End Get
		End Property

		Public Sub Repaint()
			MyBase.LayoutChanged()
		End Sub

		Protected Overrides Function CreateHandler() As TokenEditHandler
			Return New CustomTokenEdithandler(Me)
		End Function

	   Public ReadOnly Overloads Property CheckedItem() As CustomTokenEditToken
		   Get
			   Return TryCast(MyBase.CheckedItem, CustomTokenEditToken)
		   End Get
	   End Property
	   Public ReadOnly Overloads Property CheckedItems() As CustomTokenEditCheckedItemCollection
		   Get
			   Return TryCast(MyBase.CheckedItems, CustomTokenEditCheckedItemCollection)
		   End Get
	   End Property
	   Public ReadOnly Overloads Property SelectedItems() As CustomTokenEditSelectedItemCollection
		   Get
			   Return TryCast(MyBase.SelectedItems, CustomTokenEditSelectedItemCollection)
		   End Get
	   End Property
	End Class
End Namespace
