<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuCarrito.aspx.cs" Inherits="Parcial_Nº2___Almacen.WebForm1" %>
 <%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
<div class="ui container" style="margin-top: 20px;">
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

            <asp:TemplateField HeaderText="Modificar Cantidad">
  <ItemTemplate>
    <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' CssClass="ui input mini" />
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
      CommandName="ModificarCantidad"
      CommandArgument='<%# Eval("ID") %>'
      CssClass="ui blue mini button" />
  </ItemTemplate>
</asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="ui clearing segment">
    <h3 class="ui right floated header">Total: 
    <asp:Label ID="lblTotal" runat="server" CssClass="ui teal circular label massive" />
    <asp:Label ID="lblRepartidor" runat="server" CssClass="ui teal large label" />
</h3>
    </div>
        <div class="ui buttons">
<asp:Button ID="btnDescargarRecibo" runat="server" 
    Text="Descargar Recibo" 
    CssClass="ui primary button"
    OnClick="btnDescargarRecibo_Click" />

<asp:Button ID="btnFinalizarCompra" runat="server" 
    Text="Finalizar Compra" 
    CssClass="ui primary positive button" 
    OnClick="btnFinalizarCompra_Click" />
</div>
    <div style="display: none;">
            <asp:Button ID="btnConfirmarFinalizar" runat="server" OnClick="btnConfirmarFinalizar_Click" />
        </div>

   </div>

    <div class="ui mini modal" id="modalFinalizar">
        <div class="header">
            Confirmar Compra
        </div>
        <div class="content">
            <p>¿Estás seguro de que deseas finalizar tu compra?</p>
        </div>
        <div class="actions">
            <div class="ui negative button" id="btnNoFinalizar">No</div>
            <div class="ui positive right labeled icon button" id="btnSiFinalizar">
                Sí, finalizar
                <i class="checkmark icon"></i>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            // --- Lógica para el modal de Finalizar Compra ---
            // El botón "Sí" del modal hace clic en el botón oculto de ASP.NET
            $('#btnSiFinalizar').on('click', function () {
                $('#<%= btnConfirmarFinalizar.ClientID %>').click();
            });
            // El botón "No" simplemente cierra el modal
            $('#btnNoFinalizar').on('click', function () {
                $('#modalFinalizar').modal('hide');
            });

 
        });
    </script>
</asp:Content>

