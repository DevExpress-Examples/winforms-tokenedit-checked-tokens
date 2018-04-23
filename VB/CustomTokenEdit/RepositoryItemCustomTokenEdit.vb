Imports DevExpress.Skins
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Reflection

Namespace Example.CustomTokenEdit
    <UserRepositoryItem("Register")>
    Public Class RepositoryItemCustomTokenEdit
        Inherits RepositoryItemTokenEdit

        Shared Sub New()
            Register()
        End Sub
        Public Sub New()
            checkBoxCollection_Renamed = GetCheckBoxImages()
        End Sub

        Friend Const EditorName As String = "CustomTokenEdit"
        Public Shared Sub Register()
            Dim img As Image = Nothing
            Try
                img = Bitmap.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"))
            Catch
            End Try
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(CustomTokenEdit), GetType(RepositoryItemCustomTokenEdit), GetType(CustomTokenEditViewInfo), New CustomTokenEditPainter(), True, img))
        End Sub
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return EditorName
            End Get
        End Property

        'INSTANT VB NOTE: The variable checkBoxCollection was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private ReadOnly checkBoxCollection_Renamed As ImageCollection
        Public ReadOnly Property CheckBoxCollection() As ImageCollection
            Get
                Return checkBoxCollection_Renamed
            End Get
        End Property

        Protected Overridable Function GetCheckBoxImages() As ImageCollection
            Dim skin As Skin = EditorsSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default)
            Dim skinElement As SkinElement = skin("CheckBox")
            If skinElement Is Nothing Then
                Return Nothing
            End If
            Return skinElement.Image.GetImages()
        End Function

        Protected Overrides Function CreateValidationController() As TokenEditValidationController
            Return New CustomTokenEditValidationController(Me)
        End Function

        Protected Overrides Function CreateCheckedItemCollection() As TokenEditCheckedItemCollection
            Return New CustomTokenEditCheckedItemCollection(Me)
        End Function

        Protected Overrides Function CreateSelectedItemCollection() As TokenEditSelectedItemCollection
            Return New CustomTokenEditSelectedItemCollection(Me)
        End Function

        Public Event TokenCheckedChanged As EventHandler(Of TokenCheckedChangedEventArgs)
        Protected Friend Sub OnTokenCheckedChanged(ByVal token As CustomTokenEditToken, ByVal repaint As Boolean)
            RepaintEditIfRequired(repaint)
            RaiseTokenCheckedChanged(token)
        End Sub

        Private Sub RaiseTokenCheckedChanged(ByVal token As CustomTokenEditToken)
            Dim handler As EventHandler(Of TokenCheckedChangedEventArgs) = TokenCheckedChangedEvent
            If handler IsNot Nothing Then
                TokenCheckedChangedEvent(Me, New TokenCheckedChangedEventArgs(token))
            End If
        End Sub

        Private Sub RepaintEditIfRequired(ByVal repaint As Boolean)
            Dim edit As CustomTokenEdit = TryCast(OwnerEdit, CustomTokenEdit)
            If repaint AndAlso edit IsNot Nothing Then
                edit.Repaint()
            End If
        End Sub
    End Class
End Namespace
