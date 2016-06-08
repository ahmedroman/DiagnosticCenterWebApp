<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayBillUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.PayBillUI" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Pay</title>
    <link href="../Style/style.css" rel="stylesheet" />
</head>
<body>
    <uc1:Header runat="server" id="Header" />
    <div id="body">
        <uc1:Navigation runat="server" id="Navigation" />
        <div id="page">
        
            <form id="form1" runat="server">
            <fieldset>
            <legend>Bill Payment</legend>
            <div>
            <table>
                <tr>
                    <td>Patient Name : </td>
                    <td><asp:Label runat="server" ID="patientNameLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td>Date of Birth : </td>
                    <td><asp:Label runat="server" ID="DOBLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td>Mobile : </td>
                    <td><asp:Label runat="server" ID="patientMobileLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td>Days Passed :</td>
                    <td><asp:Label runat="server" ID="dayPassedLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td>Due Amount : </td>
                    <td><asp:Label runat="server" ID="dueAmountLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td>Pay : </td>
                    <td><asp:TextBox runat="server" ID="payBillTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="payButton" Text="Pay" OnClick="payButton_Click"></asp:Button></td>
                </tr>
            </table>
                <br/>
            <asp:Label runat="server" ID="messageLabel"></asp:Label>
            </div>
            </fieldset>
            </form>
        </div>
    </div>
    <uc1:Footer runat="server" id="Footer" />
</body>
</html>

