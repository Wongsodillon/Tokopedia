<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="ProductDetailPage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.ProductDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-group gap-4 p-4">
        <div class="card border border-success rounded p-4">
            <img class="card-img-top" src="<%= product.ProductImageUrl %>" alt="Card image cap">
        </div>
        <div class="card border border-success rounded p-4">
            <h2><%= product.ProductName %></h2>
            <h3 class="text-success">Rp. <%= product.ProductPrice %></h3>
            <h4 class="">Description</h4>
            <h5><%= product.ProductDescription %></h5>
            <asp:LinkButton ID="ViewShop" runat="server" OnClick="ViewShop_Click">View Shop</asp:LinkButton>
        </div>
        <div class="d-flex flex-column gap-4 border border-success rounded p-4" style="min-width: 300px;">
            <div class="form-group">
                <asp:Label ID="Label" runat="server" Text="Quantity" CssClass="col-sm-2 col-form-label" Visible="false"></asp:Label>
                <asp:TextBox ID="QuantityField" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
            </div>
            <asp:LinkButton ID="AddToCartButton" runat="server" CssClass="btn btn-outline-success" OnClick="AddCartButton_Click" Visible="false">Add to Cart</asp:LinkButton>
            <asp:LinkButton ID="EditButton" runat="server" CssClass="btn-primary btn" Visible="false" OnClick="EditButton_Click">Edit</asp:LinkButton>
            <asp:LinkButton ID="DeleteButton" runat="server" CssClass="btn btn-danger" Visible="false" OnClick="DeleteButton_Click">Delete</asp:LinkButton>
            <asp:Label ID="ErrorLabel" runat="server" Text="" Visible="true"></asp:Label>
        </div>
    </div>
</asp:Content>
