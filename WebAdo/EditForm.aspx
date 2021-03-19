<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditForm.aspx.cs" Inherits="WebAdo.EditForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit database data</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--br /-->
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label1" runat="server" Text="Customer ID"></asp:Label>
                </div>
                <div class="col-sm-3" style="background-color: white;">
                    <asp:TextBox ID="txtCID" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-1" style="background-color: white;">
                    <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
                </div>
            </div>
            <!--br /-->
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtCompN" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label3" runat="server" Text="Contact Name"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtContN" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label4" runat="server" Text="Contact Title"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtContT" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtAddr" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtCit" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label7" runat="server" Text="Region"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtReg" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label8" runat="server" Text="Postal Code"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtPstCode" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label9" runat="server" Text="Country"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtCntry" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label10" runat="server" Text="Phone"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2" style="background-color: white;">
                    <asp:Label ID="Label11" runat="server" Text="Fax"></asp:Label>
                </div>
                <div class="col-sm-2" style="background-color: white;">
                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
            <br />
            * To find an existing customer, enter their customer ID and press Find.<br />
&nbsp;&nbsp; If the customer exists, the fields will be populated where applicable.<br />
            * To either create a new record, or update an existing record, fill out <br />
&nbsp;&nbsp; the customer&#39;s details and press Update. If that customer ID exists,
            <br />
&nbsp;&nbsp; then that customer will be updated, otherwise a new record will be created.</div>
    </form>
</body>
</html>
