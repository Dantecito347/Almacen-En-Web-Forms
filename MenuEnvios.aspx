<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuEnvios.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuEnvios" %>
<%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
    <div style="max-width: 900px; margin: 0 auto;">
    <h2 style="text-align:center; margin-bottom:20px; color:#222;">Lista de Repartidores</h2>
    <asp:GridView ID="gvRepartidores" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="PersonaID" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Celular" HeaderText="Celular" />
            <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
            <asp:BoundField DataField="TipoDeVehiculo" HeaderText="Vehículo" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
