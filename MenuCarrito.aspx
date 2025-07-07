<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuCarrito.aspx.cs" Inherits="Parcial_Nº2___Almacen.WebForm1" %>
 <%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
<div>
    <h1>Carrito de Compras</h1>
    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False"
    CssClass="ui celled striped table"
    DataKeyNames="ID" OnRowCommand="gvCarrito_RowCommand">

        <Columns>
            <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    CommandName="EliminarProductoDelCarrito" 
                    CommandArgument='<%# Eval("ID") %>' 
                    CssClass="ui red mini button" /> <%%>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h3 class="ui header">Total: 
    <asp:Label ID="lblTotal" runat="server" CssClass="ui teal label" />
</h3>

<asp:Button ID="btnDescargarRecibo" runat="server" 
    Text="Descargar Recibo" 
    CssClass="ui primary button"
    OnClick="btnDescargarRecibo_Click" />

   </div>
</asp:Content>
