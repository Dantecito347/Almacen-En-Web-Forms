<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuGestionarRepartidor.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuGestionarRepartidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <h2>Agregar Nuevo Repartidor</h2>

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

            <p><asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" /></p>
            <p><asp:TextBox ID="txtApellido" runat="server" Placeholder="Apellido" /></p>
            <p><asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" /></p>
            <p><asp:TextBox ID="txtCelular" runat="server" Placeholder="Celular" /></p>
            <p><asp:TextBox ID="txtLocalidad" runat="server" Placeholder="Localidad" /></p>
            <p><asp:TextBox ID="txtVehiculo" runat="server" Placeholder="Tipo de Vehículo" /></p>

            <p><asp:Button ID="btnAgregar" runat="server" Text="Agregar Repartidor" OnClick="btnAgregar_Click" /></p>


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
    </form>
</body>
</html>
