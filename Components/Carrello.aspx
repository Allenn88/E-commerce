<%@ Page Title="" Language="C#" MasterPageFile="~/Components/Site1.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="E_commerce.Components.Carrello" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2>Carrello</h2>
    <asp:Repeater ID="RptCarrello" runat="server">
        <ItemTemplate>
            <div class="cart-item">
                <img src='<%# Eval("Foto") %>' alt='<%# Eval("Marca") %>' style="max-width: 100px; max-height: 100px;" />
                <span><%# DataBinder.Eval(Container, "DataItem.Marca") %></span>
                <span><%# Eval("Prezzo", "{0} euro") %></span>
<asp:Button runat="server" Text="Elimina" OnClick="BtnDelete_Click" CommandArgument='<%# Eval("IDProdotto") %>' CssClass="delete-button">
</asp:Button>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="cart-total">
        <a class="btn btn-primary" href="Home.aspx">Home</a>
        <strong>Totale:</strong>
        <asp:Label ID="LblTotale" runat="server" Text="0.00" />
    </div>
</asp:Content>
