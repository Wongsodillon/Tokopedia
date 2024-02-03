<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tokopedia</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <style>
        form {
            max-width: 400px;
            margin: auto;
        }
    </style>
</head>
<body class="py-4">
    <h1 class="text-center">Register</h1>
    <br />
    <form id="form1" runat="server" class="d-flex flex-column border rounded p-4">
        <div class="form-group">
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameField" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailField" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordField" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="ConfirmLabel" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmField" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="PhoneLabel" runat="server" Text="Phone Number"></asp:Label>
            <div class="input-group">
                <div class="input-group-prepend">
                    <div class="input-group-text">+62</div>
                </div>
                <asp:TextBox ID="PhoneField" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="AddressLabel" runat="server" Text="Home Address"></asp:Label>
            <asp:TextBox ID="AddressField" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="Label" Visible="false" CssClass="text-center"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="false" CssClass="mb-4 text-center"></asp:Label>
        <div class="d-flex flex-column align-items-center gap-3">
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" CssClass="btn btn-success"/>
            <asp:Label ID="NotHaveAccountLabel" runat="server" Text="Already have an account?"></asp:Label>
            <asp:Button ID="LoginButton" runat="server" Text="Login"  CssClass="btn btn-outline-success" OnClick="LoginButton_Click"/>
        </div>
    </form>
</body>
</html>
