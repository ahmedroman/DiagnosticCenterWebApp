<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEntryUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.TestEntryUI" %>

<%@ Register Src="~/Controls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Entry</title>
    <link href="../Style/style.css" rel="stylesheet" />
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
    <div id="body">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div id="page">
            <form id="form1" runat="server">
            <fieldset>
            <legend>Test Setup</legend>
            <div>
            <table>
                <tr>
                    <td>Test Name : </td>
                    <td><asp:TextBox runat="server" ID="testNameTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Fee : </td>
                    <td><asp:TextBox runat="server" ID="testFeeTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Test Type : </td>
                    <td><asp:DropDownList runat="server" ID="testTypeDropDownList"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="saveTestButton" Text="Save" OnClick="saveTestButton_Click"></asp:Button></td>
                </tr>
            </table>
        
            <asp:Label runat="server" ID="messageLabel"></asp:Label>
            <asp:GridView runat="server" ID="showAllTestGridView" AutoGenerateColumns="false" CssClass="gridViewBorder">
                <Columns>
                    <asp:TemplateField HeaderText="SL" HeaderStyle-Width="">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Name" HeaderStyle-Width="">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("TestName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Fee" HeaderStyle-Width="">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Fee") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Type Name" HeaderStyle-Width="">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("TestTypeName") %>'></asp:Label>
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

