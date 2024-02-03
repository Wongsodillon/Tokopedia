<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <link rel="stylesheet" href="../Styles/Styles.css"/>
    <style>
        form {
            max-width: 350px;
            margin: auto;
        }
    </style>
</head>
<body class="py-4">
    <h1 class="text-center">Login</h1>
    <br />
    <form id="form1" runat="server" class="d-flex flex-column border rounded p-4">
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
        <div>
            <asp:CheckBox ID="rememberBox" runat="server" Text="Remember me"/>
        </div>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="Label" Visible="false" CssClass="mb-4 text-center"></asp:Label>
        <div class="d-flex flex-column align-items-center gap-3">
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" CssClass="btn btn-primary bg-success"/>
            <asp:Label ID="NotHaveAccountLabel" runat="server" Text="Not have an account?"></asp:Label>
            <asp:Button ID="RegisterButton" runat="server" Text="Register"  CssClass="btn btn-outline-success" OnClick="RegisterButton_Click"/>
        </div>
    </form>
</body>
</html>
