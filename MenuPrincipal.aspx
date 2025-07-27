<%@ Page Title="" Language="C#" MasterPageFile="/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuPrincipal" %>
    <%@ Register Src="/BarraDeNavegacion.ascx" TagName="BarraDeNavegacion" TagPrefix="uc" %>
    <%@ Register Src="/CartaImagen.ascx" TagName="CartaImagen" TagPrefix="uc" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <uc:BarraDeNavegacion ID="NavBar1" runat="server" />
        <div class="carousel-container">
  <div class="hero-overlay">
      

    <h1 class="title is-2 has-text-white">¡Bienvenido a Lo de Juan!</h1>
    <p class="subtitle is-4 has-text-white">Somos un emprendimiento familiar joven, 
        en constante crecimiento pero con corazón de almacén de barrio.
Cada día trabajamos para sumar nuevos productos, con buenos precios y una atención personalizada.</p>
  </div>

<div class="swiper-wrapper">
  <div class="swiper-slide">
    <img src="~/img/presentacion1.jpg" runat="server" />
  </div>
  <div class="swiper-slide">
    <img src="~/img/presentacion2.jpg" runat="server" />
  </div>
  <div class="swiper-slide">
    <img src="~/img/presentacion3.jpg" runat="server" />
  </div>
  <div class="swiper-slide">
    <img src="~/img/presentacion4.jpg" runat="server" />
  </div>
  <div class="swiper-slide">
    <img src="~/img/presentacion5.jpg" runat="server" />
  </div>
</div>
</div>

        <uc:CartaImagen ID="CartaImagen" runat="server" />
  <script src="https://cdn.jsdelivr.net/npm/swiper/swiper-bundle.min.js"></script>
  <script>
const swiper = new Swiper('.swiper', {
  loop: true,
  autoplay: {
    delay: 3500,
    disableOnInteraction: false,
  },
  speed: 1000,
  effect: 'slide',
});
  </script>
         </asp:Content>
