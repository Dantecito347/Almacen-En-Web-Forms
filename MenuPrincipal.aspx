<%@ Page Title="" Language="C#" MasterPageFile="~/MPIndex.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Parcial_Nº2___Almacen.MenuPrincipal" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="carousel-container">
  <!-- Overlay con título -->
  <div class="hero-overlay">
    <h1 class="title is-2 has-text-white">¡Bienvenido a Lo de Juan!</h1>
    <p class="subtitle is-4 has-text-white">Productos frescos, ofertas increíbles y más 🍞🧀🥩</p>
  </div>

  <!-- Carrusel Swiper -->
  <div class="swiper">
    <div class="swiper-wrapper">
      <div class="swiper-slide">
        <img src="https://source.unsplash.com/1200x400/?groceries" alt="Groceries">
      </div>
      <div class="swiper-slide">
        <img src="https://source.unsplash.com/1200x400/?market" alt="Market">
      </div>
      <div class="swiper-slide">
        <img src="https://source.unsplash.com/1200x400/?food" alt="Food">
      </div>
      <div class="swiper-slide">
        <img src="https://source.unsplash.com/1200x400/?vegetables" alt="Vegetables">
      </div>
    </div>
  </div>
</div>
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
