<%@ Page Title="" Language="C#" MasterPageFile="~/Components/Site1.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="E_commerce.Components.Details" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 id="TtlName" runat="server"></h2>
    <h3 id="LblCategory" runat="server"></h3>
    <img id="ImgProduct" runat="server" style="max-width: 100px; max-height: 100px;" />
    <p id="ParContent" runat="server"></p>
    <a class="btn btn-primary" href="Home.aspx">Home</a>
 
       <a id="BtnCarrello" class="btn btn-primary" runat="server" href="">Vai al Carrello</a>
    <asp:Button ID="BtnAdd" class="btn btn-success" runat="server" OnClick="BtnAdd_Click" Text="Aggingi al Carrello">
    </asp:Button >
    
</asp:Content>
