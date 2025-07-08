<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductoOferta.ascx.cs" Inherits="Parcial_Nº2___Almacen.ProductoOferta" %>
<div class="ui card">
    <div class="content">
        <div class="header"><%# Eval("Nombre") %></div>
        <div class="meta">$ <%# Eval("Precio", "{0:0.00}") %></div>
        <div class="description">
            <%# Eval("Descripcion") %>
        </div>
    </div>
</div>