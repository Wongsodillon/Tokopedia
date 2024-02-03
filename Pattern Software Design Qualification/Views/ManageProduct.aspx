<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.ManageProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg justify-content-between navbar-light bg-light p-4">
            <asp:Button ID="BackProfile" runat="server" CssClass="btn btn-outline-success" OnClick="BackProfile_Click" Text="Back to Profile" />  
            <h2 class="text-success"><%= shop.ShopName %></h2>
            <asp:Button ID="CreateProduct" runat="server" CssClass="btn btn-success" OnClick="CreateProduct_Click" Text="Create Product" />
        </nav>
        <div class="row" style="padding-inline: 8rem; padding-block: 2rem;">
            <% for (int i = 0; i < Products.Count; i++) { %>
                <div class="col-md-3 mb-4">
                    <div class="card mb-4 h-100 d-flex flex-column">
                        <img class="card-img-top mb-1" src="<%= Products[i].ProductImageUrl %>" alt="Card image cap">
                        <div class="card-body flex-grow-1">
                            <h4 class="card-title"><%= Products[i].ProductName %></h4>
                            <h5 class="text-success">Rp. <%= Products[i].ProductPrice %></h5>
                            <p class="card-text"><%=Products[i].ProductDescription %></p>
                        </div>
                        <div class="card-footer">
                            <a href="/Views/UpdateProduct.aspx?Id=<%= Products[i].ProductID %>" class="btn-primary btn">Edit</a>
                            <a href="/Views/DeleteProduct.aspx?Id=<%= Products[i].ProductID %>" class="btn btn-danger">Delete</a>
                        </div>
                    </div>
                </div>
                <% if ((i + 1) % 4 == 0 || (i + 1) == Products.Count) { %>
                    <div class="w-100 d-none d-md-block"></div>
                <% } %>
            <% } %>
        </div>
    </form>
    <script type="text/javascript">
        function setHiddenField(productId) {
            let hiddenField = document.getElementById(`HiddenID`);
            if (hiddenField != null) {
                hiddenField.value = productId;
            }
        }
    </script>

</body>
</html>
