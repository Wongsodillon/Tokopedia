<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if(NoTransaction) { %>
        <h1 class="p-4">No Transaction History</h1>
    <% } %>
    <% else { %>
        <div style="padding-inline: 4rem; padding-block: 2rem;">
            <% foreach (var transaction in transactions) {  %>
                <div class="card">
                    <div class="card-header bg-success d-flex justify-content-between">
                        <h2 class="text-white"><%= transaction.TransactionDate.ToString("dd-MMM-yyyy") %></h2>
                        <h2 class="text-white">to <%= transaction.TransactionAddress %></h2>
                    </div>
                    <div class="card-body px-4">
                        <h3>Product Details</h3>
                        <% foreach (var product in transaction.TransactionDetails) { %>
                            <div class="d-flex border rounded w-100 mb-4">
                                <div class="" style="max-height: 250px;">
                                    <img src="<%= product.Product.ProductImageUrl %>" class="h-100 w-100" style="max-width: 350px; min-width: 300px;"/>
                                </div>
                                <div class="d-flex flex-column justify-content-between border w-100">
                                    <div class="px-4 py-2">
                                        <h2><%= product.Product.ProductName %></h2>
                                        <h2 class="text-success">Rp. <%= product.Product.ProductPrice %></h2>
                                        <h4 class="text-primary"><%= product.Quantity %> item(s)</h4>
                                    </div>
                                    <div class="py-2 px-4 d-flex bg-light gap-4 justify-content-between">
                                        <h3 class="text-success">Subtotal: Rp. <%= product.Quantity * product.Product.ProductPrice %></h3>
                                    </div>
                                </div>
                            </div>     
                        <% } %>
                    </div>
                </div>
                <br />
            <% } %>
        </div>
    <% } %>
</asp:Content>
