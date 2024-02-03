<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (NoCart)
        {  %>
        <div class="d-flex justify-content-between" style="margin-inline: 4rem; margin-block: 2rem;">
            <h1 class="text-success">No Items found in your cart</h1>
        </div>
    <% } %>
    <% else { %>
        <div class="d-flex justify-content-between" style="margin-inline: 4rem; margin-block: 2rem;">
            <h3 class="text-success">Your Cart</h3>
            <asp:LinkButton ID="AddToOrders" runat="server" CssClass="btn btn-success px-4" OnClick="AddToOrders_Click">Order your cart</asp:LinkButton>
        </div>
    <% } %>
    <asp:Repeater ID="CartRepeater" runat="server">
        <ItemTemplate>
            <div class="d-flex mw-100" style="margin-inline: 4rem; margin-block: 2rem;">
                <div class="d-flex border rounded w-100">
                    <div class="d-flex align-items-center justify-content-center" style="max-height: 225px">
                        <img src="<%# Eval("Product.ProductImageUrl") %>" class="h-100 w-100" style="min-width: 250px"/>
                    </div>
                    <div class="d-flex flex-column border w-100">
                        <div class="py-2 px-4">
                            <div class="d-flex justify-content-between py-2">
                                <h4><%# Eval("Product.ProductName") %></h4>
                                <asp:LinkButton ID="RemoveButton" runat="server" CommandArgument='<%# Eval("CartID") %>' CssClass="btn btn-danger" OnClick="RemoveButton_Click">Remove</asp:LinkButton>
                            </div>
                            <h4 class="text-success">Rp. <%# Eval("Product.ProductPrice") %></h4>
                            <h5 class="text-primary">Stock: <%# Eval("Product.ProductStock") %> Left</h5>
                            <h5>Date Added: <%# Convert.ToDateTime(Eval("DateAdded")).ToString("dd MMM yyyy") %></h5>
                        </div>
                        <div class="py-2 px-4 d-flex bg-light gap-4 justify-content-between">
                            <h4 class="text-success">Quantity: <%# Eval("Quantity") %></h4>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
