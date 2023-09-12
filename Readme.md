<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128623480/18.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T315168)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms TokenEdit - Create checked tokens

This example creates a custom token editor (`CustomTokenEdit`) that displays a checkbox in tokens.

![WinForms TokenEdit - Display a checkbox in a token](https://raw.githubusercontent.com/DevExpress-Examples/tokenedit-how-to-add-a-check-box-to-a-token-t315168/15.1.8+/media/f444211d-abe7-11e5-80bf-00155d62480c.png)

You can use the custom token editor as a standalone editor or as a cell editor in data-aware controls (for example, Data Grid, TreeList).

![Custom Token Cell Editor - WinForms Data Grid](https://raw.githubusercontent.com/DevExpress-Examples/tokenedit-how-to-add-a-check-box-to-a-token-t315168/15.1.8+/media/836600b8-abed-11e5-80bf-00155d62480c.png)

Tokens are of the `CustomTokenEditToken` type. This class inherits base functionality from the [TokenEditToken]() class and introduces a new `Checked` property. When the checked state of a token changes, the editor raises the `RepositoryItemCustomTokenEdit.TokenCheckedChanged` event.


## Files to Review

* [CustomTokenEdit.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEdit.cs)
* [CustomTokenEditCheckedItemCollection.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditCheckedItemCollection.cs)
* [CustomTokenEdithandler.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEdithandler.cs)
* [CustomTokenEditHitInfo.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditHitInfo.cs)
* [CustomTokenEditPainter.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditPainter.cs)
* [CustomTokenEditSelectedItemCollection.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditSelectedItemCollection.cs)
* [CustomTokenEditToken.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditToken.cs)
* [CustomTokenEditTokenInfo.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditTokenInfo.cs)
* [CustomTokenEditViewInfo.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditViewInfo.cs)
* [RepositoryItemCustomTokenEdit.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/RepositoryItemCustomTokenEdit.cs)
* [TokenCheckedChangedEventArgs.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/TokenCheckedChangedEventArgs.cs)
* [Form1.cs](./CS/TokenEdit_Glyph_InEndOfToken/Form1.cs)


## See Also

* [Token Edit Control](https://docs.devexpress.com/WindowsForms/17088/controls-and-libraries/editors-and-simple-controls/token-edit-control)
* [Custom Editors](https://docs.devexpress.com/WindowsForms/4716/controls-and-libraries/editors-and-simple-controls/common-editor-features-and-concepts/custom-editors)
* [In-place Editors Overview](https://docs.devexpress.com/WindowsForms/753/controls-and-libraries/data-grid/data-editing-and-validation/modify-and-validate-cell-values)
