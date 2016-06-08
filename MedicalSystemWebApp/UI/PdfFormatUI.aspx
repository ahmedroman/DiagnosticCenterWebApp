<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfFormatUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.PdfFormatUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PDF Format</title>
    <link href="../Style/pdfFormatStyle.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server">
    <div id="main">
    <div id="pdfFormatheader">
        <asp:Label runat="server" ID="billNoLabel" Text="Bill"></asp:Label>
        <br/>
        <asp:Label runat="server" ID="dateLabel" Text="Date"></asp:Label>
    <br />
        <br />
    </div>
    <div id="pdfFormatheadermainBody">
    <table id="patienInfoTable">
        <tr>
            <td>Patient Name : </td>
            <td><asp:Label runat="server" ID="patientNameLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Patient Date of Birth : </td>
            <td><asp:Label runat="server" ID="DOBLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>Patient Mobile : </td>
            <td><asp:Label runat="server" ID="patientMobileLabel"></asp:Label></td>
        </tr>
    </table>
        <br/>
    <asp:GridView ID="testGridView" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="testGridView_RowDataBound"  >
        <Columns>
            <asp:TemplateField HeaderText="SL" ItemStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Test Name" ItemStyle-Width="40%">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
				<b><asp:Label Text="Total" runat="server" /></b>
			 </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee" ItemStyle-Width="40%">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblqty" Text='<%#Eval("Fee") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
				<b><asp:Label ID="lblTotalqty" runat="server" /><b/>
			 </FooterTemplate>
            </asp:TemplateField>
            
        </Columns>
        
    </asp:GridView>
        <br/>
        <br/>
        <asp:Button runat="server" ID="generatePdfButton" Text="Print" OnClick="generatePdfButton_Click"></asp:Button>
    </div>
    </div>
            
    </form>
</body>
</html>

