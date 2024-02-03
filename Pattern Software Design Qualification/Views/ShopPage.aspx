<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="ShopPage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.ShopPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row p-4">
        <h2 class="text-success mb-4"><%= shop.ShopName %></h2>
        <% for (int i = 0; i < Products.Count; i++) { %>
            <div class="col-md-3 mb-4">
                <div class="card mb-4 h-100 d-flex flex-column">
                    <img class="card-img-top mb-1" src="<%= Products[i].ProductImageUrl %>" alt="Card image cap" onclick="redirectToProductDetail('<%= Products[i].ProductID %>')">
                    <div class="card-body flex-grow-1">
                        <h4 class="card-title"><%= Products[i].ProductName %></h4>
                        <h5 class="text-success">Rp. <%= Products[i].ProductPrice %></h5>
                        <p class="card-text"><%= Products[i].ProductDescription %></p>
                    </div>
                </div>
            </div>
            <% if ((i + 1) % 4 == 0 || (i + 1) == Products.Count) { %>
                <div class="w-100 d-none d-md-block"></div>
            <% } %>
        <% } %>
    </div>
    <script type="text/javascript">
        function redirectToProductDetail(productID) {
            window.location.href = '/Views/ProductDetailPage.aspx?Id=' + productID;
        }
    </script>
</asp:Content>
