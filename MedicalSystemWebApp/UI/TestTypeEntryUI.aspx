<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeEntryUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.TestTypeEntryUI" %>

<%@ Register Src="~/Controls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type Entry</title>
    <link href="../Style/style.css" rel="stylesheet" />
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
    <div id="body">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div id="page">
            <form id="form1" runat="server">
            <fieldset>
            <legend>Test Type Setup</legend>
            <div>
                <table>
                    <tr>
                        <td>TestType Name : </td>
                        <td><asp:TextBox runat="server" ID="testTypeTextBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button runat="server" ID="saveButton" Text="Save" OnClick="saveButton_Click"></asp:Button></td>
                    </tr>
                </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
                <asp:GridView runat="server" ID="showAlltestTypeGridView" AutoGenerateColumns="false" CssClass="gridViewBorder">
                    <Columns>
                        <asp:TemplateField HeaderText="SL" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<% #Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TestType" HeaderStyle-Width="80%">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<% #Eval("Name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </fieldset>
            </form>
        </div>
    </div>
    <uc1:Footer runat="server" ID="Footer" />
</body>
</html>
