<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuCarrito.aspx.cs" Inherits="Parcial_Nº2___Almacen.WebForm1" %>
 <%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
<div>
    <h1>Carrito de Compras</h1>
    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    CommandName="EliminarItem" 
                    CommandArgument='<%# Eval("ID") %>' 
                    CssClass="btn btn-danger btn-sm" /> <%-- Clases de Bootstrap opcionales para estilo --%>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h3>Total: <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h3>
    <asp:Button ID="btnDescargarRecibo" runat="server" Text="Descargar Recibo" OnClick="btnDescargarRecibo_Click" />

   </div>
</asp:Content>
