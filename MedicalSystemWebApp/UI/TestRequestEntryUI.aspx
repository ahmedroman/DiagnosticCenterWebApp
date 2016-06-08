<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.TestRequestEntryUI" %>

<%@ Register Src="~/Controls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Request</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <link href="../Style/style.css" rel="stylesheet" />
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
    <div id="body">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div id="page">
            <form id="form1" runat="server">
            <fieldset>
            <legend>Test Request Entry</legend>
            <div>
            <table>
                <tr>
                    <td>Patient Name : </td>
                    <td><asp:TextBox runat="server" ID="patientNameTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Date of Birth : </td>
                    <td><asp:TextBox runat="server" ID="DOBTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Mobile : </td>
                    <td><asp:TextBox runat="server" ID="patientMobileTextBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Select Test : </td>
                    <td><asp:DropDownList runat="server" ID="testDropDownList"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Fee : </td>
                    <td><asp:Label runat="server" ID="feeLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td><Input type="button" id="addTestButton" value="Add Test" /></td>
                </tr>
            </table>
            <asp:Label runat="server" ID="messageLabel"></asp:Label>
            <div id="addedTestDiv">
                <table id="testTable" class="gridViewBorder">
                    <thead>
                        <tr>
                        <th>SL</th>
                        <th>Test</th>
                        <th>Fee</th>
                    </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td></td>
                            <td>Total : </td>
                            <td><asp:Label runat="server" ID="totalFeeLabel"></asp:Label></td>
                        </tr>
                    </tfoot>
                    <tbody>

                    </tbody>
                </table>
                <asp:Button runat="server" ID="saveTestsButton" Text="Save" OnClick="saveTestsButton_Click"></asp:Button>
            </div>
            </div>
            </fieldset>
                <asp:HiddenField ID="allTestHiddenField" runat="server" />
                <asp:HiddenField ID="addedTestHiddenField" runat="server" />
                <asp:HiddenField ID="totalFeeHiddenField" runat="server" />
            </form>
        </div>
    </div>
    <uc1:Footer runat="server" ID="Footer" />
    
    <script src="../Scripts/jquery-1.6.4.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script src="../Scripts/script.js"></script>
</body>
</html>
