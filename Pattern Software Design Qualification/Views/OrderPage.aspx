<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex gap-4" style="padding-inline: 4rem; padding-block: 2rem;">
        <div stlye="width: 60%">
            <% foreach (var cart in Carts) { %>
                <div class="d-flex mw-100">
                    <div class="d-flex border rounded w-100">
                        <div class="d-flex align-items-center justify-content-center" style="max-height: 225px">
                            <img src="<%= cart.Product.ProductImageUrl %>" class="h-100 w-100" style="min-width: 250px;"/>
                        </div>
                        <div class="d-flex flex-column border w-100">
                            <div class="py-2 px-4">
                                <div class="d-flex justify-content-between py-2">
                                    <h4><%= cart.Product.ProductName %></h4>
                                </div>
                                <h4 class="text-success">Rp. <%= cart.Product.ProductPrice %></h4>
                                <h5 class="text-primary">Stock: <%= cart.Product.ProductStock %> Left</h5>
                                <h5>Date Added: <%= cart.DateAdded.ToString("dd MMM yyyy") %></h5>
                            </div>
                            <div class="py-2 px-4 d-flex bg-light gap-4 justify-content-between">
                                <h4 class="text-success">Quantity: <%= cart.Quantity %> Item(s)</h4>
                            </div>
                        </div>
                    </div> 
                </div>
                <br />
            <% } %>
        </div>
        <div class="card h-25" style="width: 40%">
            <div class="card-header">
                Total Price
            </div>
            <div class="card-body">
                <h5>Order Address: </h5>
                <asp:TextBox ID="AddressField" runat="server" CssClass="w-100 form-control" EnableViewState="true"></asp:TextBox>
            </div>
            <div class="card-footer">
                <asp:LinkButton ID="OrderButton" runat="server" CssClass="btn btn-success" OnClick="OrderButton_Click">Order</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
