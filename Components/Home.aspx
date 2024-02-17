<%@ Page Title="" Language="C#" MasterPageFile="~/Components/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="E_commerce.Components.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <a href="Carrello.aspx" class="cart-button">
    <i class="fas fa-shopping-cart cart-icon"></i>
</a>
        <div id="RowCards" class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3" runat="server">
            <div class="col">
                <div class="card h-100">
                  <img src="..." class="card-img-top" alt="...">
                  <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
