<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarraDeNavegacion.ascx.cs" Inherits="Parcial_Nº2___Almacen.BarraDeNavegacion" %>
<nav class="navbar navbar-expand-lg bg-white border-bottom fixed-top py-2">
  <div class="container-fluid">
    <a class="navbar-brand fw-bold" href="/MenuPrincipal.aspx">Almacén - Lo de Juan</a>

    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
      <li class="nav-item">
        <a class="nav-link active" aria-current="page" href="../MenuProductos.aspx">Productos</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="../MenuEnvios.aspx">Envíos</a>
      </li>
      <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" id="otrosDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
          Otros
        </a>
        <ul class="dropdown-menu" aria-labelledby="otrosDropdown">
          <li><a class="dropdown-item" href="#">Ofertas (Próximamente)</a></li>
          <li><a class="dropdown-item" href="../MenuCarrito.aspx">Carrito</a></li>
          <li><hr class="dropdown-divider"></li>
<li><a class="dropdown-item" href="https://maps.app.goo.gl/dKHxwz8oXwsP7RAJA" target="_blank" rel="noopener">Ubicación</a></li>
        </ul>
      </li>
    </ul>
  </div>
</nav>
