<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuGestionarRepartidor.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuGestionarRepartidor" %>
 <%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
         <link href="~/styles/styles.css" rel="stylesheet" type="text/css" />
         <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css"/>
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css"/>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"/>

</head>
            <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
<body>
    <form id="form1" runat="server" class="ui form">
        <div class="ui container" style="margin-top: 30px;">
            <h2 class="ui header">Agregar Nuevo Repartidor</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="ui red message" Visible="false" />

            <div class="field">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="ui input" />
            </div>

            <div class="field">
                <label>Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="ui input" />
            </div>

            <div class="field">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="ui input" TextMode="Email" />
            </div>

            <div class="field">
                <label>Celular</label>
                <asp:TextBox ID="txtCelular" runat="server" CssClass="ui input" />
            </div>

            <div class="field">
                <label>Localidad</label>
                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="ui input" />
            </div>

            <div class="field">
                <label>Tipo de Vehículo</label>
                <asp:TextBox ID="txtVehiculo" runat="server" CssClass="ui input" />
            </div>

            <div class="field">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Repartidor" CssClass="ui primary button" OnClick="btnAgregar_Click" />
            </div>                   
        </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/semantic-ui@2.5.0/dist/semantic.min.js"></script>
</body>

</html>

