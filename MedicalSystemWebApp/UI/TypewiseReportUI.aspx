<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false"  CodeBehind="TypewiseReportUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.TypewiseReportUI" %>

<%@ Register Src="~/Controls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Typewise Report</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <link href="../Style/style.css" rel="stylesheet" />
</head>
<body>
    <uc1:Header runat="server" ID="header" />     
    <div id="body">
        <uc1:Navigation runat="server" ID="navigation" />
        <div id="page">
            <form id="form1" runat="server">
            <fieldset>
            <legend>Type wise Report</legend>
            <div>
            <table runat="server" id="dateTable">
                <tr>
                    <td>From Date</td>
                    <td><asp:TextBox runat="server" ID="fromDateTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td><asp:TextBox runat="server" ID="toDateTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="showButton" Text="Show" OnClick="showButton_Click"></asp:Button></td>
                </tr>
            </table>
                <asp:Label runat="server" ID="messageLabel"></asp:Label>
                <br/>
            <asp:GridView runat="server" ID="showAllTestGridview" CssClass="gridViewBorder" AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="showAllTestGridview_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Type">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("TestTypeName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TotalTest">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Count")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <b>Total : </b>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Amount">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="feeLabel" Text='<%#Eval("TotalFee")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <b><asp:Label runat="server" ID="totalAmountLabel"></asp:Label></b>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button runat="server" ID="pdfButton" Text="PDF" OnClick="pdfButton_Click"></asp:Button>
            </div>
            </fieldset>
            </form>
        </div>
    </div>
    <uc1:Footer runat="server" ID="footer" />

    <script src="../Scripts/jquery-1.6.4.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script src="../Scripts/dateTimeScript.js"></script>
</body>
</html>
