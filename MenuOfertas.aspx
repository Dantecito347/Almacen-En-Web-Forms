<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuOfertas.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuOfertas" %>
<%@ Register Src="~/ProductoOferta.ascx" TagPrefix="uc" TagName="ProductoOferta" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div class="ui container">
            <h2 class="ui dividing header">Recomendaciones para vos</h2>
            <div class="ui cards" style="display:flex; flex-wrap: wrap;">
                <asp:Repeater ID="rptRecomendaciones" runat="server">
                    <ItemTemplate>
                        <uc:ProductoOferta runat="server" ID="ProductoOferta" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
