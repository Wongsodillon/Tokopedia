<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/ShopHeader.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="max-width: 425px; margin: auto;" class="border rounded p-4 mt-4 d-flex flex-column">
        <div class="form-group">
            <asp:Label ID="NameLabel" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="NameField" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="PriceLabel" runat="server" Text="Product Price"></asp:Label>
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon1">Rp.</span>
                </div>
                <asp:TextBox ID="PriceField" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="StockLabel" runat="server" Text="Product Stock"></asp:Label>
            <asp:TextBox ID="StockField" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="ImageLabel" runat="server" Text="Product Image" CssClass=""></asp:Label>
            <div class="custom-file py-2">
                <asp:FileUpload ID="ImageField" runat="server" CssClass="custom-file-input"/>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="DescLabel" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="DescField" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text="Error Label" CssClass="text-danger text-center" Visible="false"></asp:Label>
        <br />
        <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-success" OnClick="UpdateButton_Click">Update</asp:LinkButton>
    </div>
    <br />
</asp:Content>
