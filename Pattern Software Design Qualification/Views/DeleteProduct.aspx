<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/ShopHeader.Master" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.DeleteProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 class="text-center">Are you sure you want to delete <%= product.ProductName %>?</h2>
    <br />
    <div class="card mb-4 h-100 d-flex flex-column w-25" style="margin: auto;">
        <asp:Image ID="ProductImage" runat="server" CssClass="card-img-top mb-1"/>
        <div class="card-body d-flex flex-column">
            <asp:Label ID="NameLabel" runat="server" CssClass="card-title h4"></asp:Label>
            <asp:Label ID="PriceLabel" runat="server" CssClass="h5 text-success"></asp:Label>
            <asp:Label ID="DescLabel" runat="server" CssClass="card-text"></asp:Label>
        </div>
        <div class="card-footer">
            <asp:LinkButton ID="DeleteButton" runat="server" CssClass="btn btn-danger" OnClick="DeleteButton_Click">Delete</asp:LinkButton>       
        </div>
    </div>
</asp:Content>
