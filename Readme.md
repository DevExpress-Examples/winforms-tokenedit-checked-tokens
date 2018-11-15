<!-- default file list -->
*Files to look at*:

* **[CustomTokenEdit.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEdit.cs)**
* [CustomTokenEditCheckedItemCollection.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditCheckedItemCollection.cs)
* [CustomTokenEdithandler.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEdithandler.cs)
* [CustomTokenEditHitInfo.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditHitInfo.cs)
* [CustomTokenEditPainter.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditPainter.cs)
* [CustomTokenEditSelectedItemCollection.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditSelectedItemCollection.cs)
* [CustomTokenEditToken.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditToken.cs)
* [CustomTokenEditTokenInfo.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditTokenInfo.cs)
* [CustomTokenEditValidationController.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditValidationController.cs)
* [CustomTokenEditViewInfo.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/CustomTokenEditViewInfo.cs)
* [RepositoryItemCustomTokenEdit.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/RepositoryItemCustomTokenEdit.cs)
* [TokenCheckedChangedEventArgs.cs](./CS/TokenEdit_Glyph_InEndOfToken/CustomTokenEdit/TokenCheckedChangedEventArgs.cs)
* [Form1.cs](./CS/TokenEdit_Glyph_InEndOfToken/Form1.cs)
* [Program.cs](./CS/TokenEdit_Glyph_InEndOfToken/Program.cs)
<!-- default file list end -->
# TokenEdit - How to add a check box to a token


<p><br>This example demonstrates how to add a check box to the end of a token.</p>
<br><img src="https://raw.githubusercontent.com/DevExpress-Examples/tokenedit-how-to-add-a-check-box-to-a-token-t315168/15.1.8+/media/f444211d-abe7-11e5-80bf-00155d62480c.png"><br><br>
<p>The <strong>CustomTokenEdit</strong> editor implemented in this example enhances the <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17088"><strong>TokenEdit</strong></a><strong> </strong>editor functionality.<br>If you have already used <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17088"><strong>TokenEdit</strong></a><strong> </strong>and would like to get such a functionality in your project, you can simply substitute  <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17088"><strong>TokenEdit</strong></a><strong> </strong>with <strong>CustomTokenEdit</strong>.<br><br><br></p>
<p>The <strong>CustomTokenEdit </strong>editor as well as its predecessor <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17088"><strong>TokenEdit</strong></a><strong> </strong><strong> </strong>can also be used in In-place mode:</p>
<img src="https://raw.githubusercontent.com/DevExpress-Examples/tokenedit-how-to-add-a-check-box-to-a-token-t315168/15.1.8+/media/836600b8-abed-11e5-80bf-00155d62480c.png"><br><br><br>
<p>Tokens of the <strong>CustomTokenEdit </strong>editor have the <strong>CustomTokenEditToken </strong>type, which enhances the default <strong>TokenEditToken </strong>implementation with the <strong>Checked</strong> property that can be used to check / uncheck this token from code or determine whether a token is checked or not. When a token is checked / unchecked, the <strong>RepositoryItemCustomTokenEdit.TokenCheckedChanged </strong>event is raised. You can handle this event in order to notify related objects of this change. The event handler receives an argument of the <strong>TokenCheckedChangedEventArgs </strong>type containing data related to this event. </p>
<br><br>See also:<br><a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17088">Token Edit Control</a><br><a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument4716">Custom Editors</a><br><a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument745">In-place Editors Overview</a>

<br/>


