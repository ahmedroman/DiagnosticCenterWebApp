<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="MedicalSystemWebApp.UI.PaymentUI" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    <link href="../Style/style.css" rel="stylesheet" />
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
    <div id="body">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div id="page">
   
            <form id="form1" runat="server">
            <fieldset>
            <legend>Payment</legend>
            <div>
            <asp:RadioButton runat="server" ID="billNoRadiBbutton" Text="Bill No" GroupName="searchGroup"></asp:RadioButton>
            &nbsp;
            <asp:RadioButton runat="server" ID="mobileRadioButton" Text="Mobile" GroupName="searchGroup"></asp:RadioButton>
            &nbsp;
            <asp:RadioButton runat="server" ID="nameRadioButton" Text="Name" GroupName="searchGroup"></asp:RadioButton>
            <br/>
                <br/>
            <asp:TextBox runat="server" ID="searchTextBox"></asp:TextBox>
            <br/>
                <br/>
            <asp:Button runat="server" ID="searchButton" Text="Search" OnClick="searchButton_Click"></asp:Button>
            <br/><br/>
            <asp:Label runat="server" ID="messageLabel"></asp:Label>
            <asp:GridView runat="server" ID="showAllInfoGridView" AutoGenerateColumns="false" CssClass="gridViewBorder">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Patient Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("PatientName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Patient Mobile">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date of Birth">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("DOB","{0:dd MMMM, yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bill No">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("BillNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Entry Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("EntryDate","{0:dd MMMM, yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Due Amount">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("TotalFee") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("PayBillUI.aspx?id={0}",Eval("OrderId")) %>' Text="Pay"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </form>
        </fieldset>
    </div>
    </div>
    <uc1:Footer runat="server" ID="Footer" />
</body>
</html>

