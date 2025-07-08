<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuProductos.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuProductos" %>
 <%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
<%@ Register Src="/Subtitulos.ascx" TagName="Subtitulos" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
    <div style="max-width: 900px; margin: 0 auto;">
        <uc:Subtitulos ID="Subtitulo1" runat="server" Texto="Seleccione los productos que desea comprar" />
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvProductos_RowCommand"  DataKeyNames="ID,Precio">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
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
                <asp:Button ID="btnComprar" runat="server" CommandName="Comprar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" Text="Comprar" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        <uc:Subtitulos ID="Subtitulos2" runat="server" Texto="Bebidas" />
<asp:GridView ID="gvBebidas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="ID,Precio" OnRowCommand="gvBebidas_RowCommand">
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

<uc:Subtitulos ID="Subtitulos3" runat="server" Texto="Lácteos" />
<asp:GridView ID="gvLacteos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="ID,Precio" OnRowCommand="gvLacteos_RowCommand">
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
        </div>
</asp:Content>
