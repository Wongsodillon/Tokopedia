<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Layout.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Pattern_Software_Design_Qualification.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-4">
        <div class="card">
            <h4 class="card-header bg-success text-white">Profile Info</h4>
            <div class="d-flex">
                <img src="../Assets/profile.jpg" class="profile-pic"/>
                <div class="card-body">
                    <h3 class="text-success"><%= user.Username %></h3>
                    <div class="d-flex gap-4">
                        <p><%= user.UserEmail %></p>
                        <p><%= user.UserPhoneNumber %></p>
                    </div>
                    <div class="d-flex gap-4 mb-3 align-items-center">
                        <h5>Home Address</h5>
                        <asp:Button ID="UpdateAddressButton" runat="server" Text="Update Address" CssClass="btn-primary btn"/>
                    </div>
                    <asp:TextBox ID="AddressField" runat="server" CssClass="w-75 form-control"></asp:TextBox>
                    <br />
                    <asp:LinkButton ID="Logout" runat="server" CssClass="btn btn-danger" OnClick="LogoutButton_Click">Logout</asp:LinkButton>
                </div>
            </div>
        </div>
        <br />
        <asp:Panel ID="ShopPanel" runat="server" Visible="false">
            <div class="d-flex bg-success gap-3 align-items-center w-100 px-3 py-2 rounded" style="height: 70px;">
                <img src="../Assets/shop.png" class="rounded h-100"/>
                <h5 class="text-white"><%= shop.ShopName %></h5>
                <asp:LinkButton ID="ManageShopButton" runat="server" CssClass="btn-primary btn" OnClick="ManageShopButton_Click">Manage Shop</asp:LinkButton>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
