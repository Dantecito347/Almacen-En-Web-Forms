<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuProductos.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="max-width: 900px; margin: 0 auto;">
    <h2 style="text-align:center; margin-bottom:20px; color:#222;">Seleccione los productos que desea comprar</h2>
    <div style="text-align:right; margin-bottom:15px;">
        <asp:Button ID="btnVolver" runat="server" Text="Volver al menú" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
    </div>  
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvProductos_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdProducto" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre del producto" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Stock" HeaderText="Stock disponible" />

        <asp:TemplateField HeaderText="Cantidad">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" Width="80px" TextMode="Number" Min="1" Max='<%# Eval("Stock") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:Button ID="btnComprar" runat="server" CommandName="Comprar" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-success" Text="Comprar" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        
        <h3 style="text-align:center; margin-top:30px; color:#222;">Bebidas</h3>
<asp:GridView ID="gvBebidas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre de la bebida" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Stock" HeaderText="Stock disponible" />
        <asp:TemplateField HeaderText="Cantidad">
    <ItemTemplate>
        <asp:TextBox ID="txtCantidadBebida" runat="server" CssClass="form-control" Width="80px" TextMode="Number" Min="1" Max='<%# Eval("Stock") %>'></asp:TextBox>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acción">
    <ItemTemplate>
        <asp:Button ID="btnComprarBebida" runat="server" CommandName="ComprarBebida" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" Text="Comprar" />
    </ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>


<h3 style="text-align:center; margin-top:30px; color:#222;">Lácteos</h3>
<asp:GridView ID="gvLacteos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre del lácteo" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Stock" HeaderText="Stock disponible" />
         <asp:TemplateField HeaderText="Cantidad">
     <ItemTemplate>
         <asp:TextBox ID="txtCantidadLacteo" runat="server" CssClass="form-control" Width="80px" TextMode="Number" Min="1" Max='<%# Eval("Stock") %>'></asp:TextBox>
     </ItemTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Acción">
     <ItemTemplate>
         <asp:Button ID="btnComprarLacteo" runat="server" CommandName="ComprarLacteo" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" Text="Comprar" />
     </ItemTemplate>
 </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>
