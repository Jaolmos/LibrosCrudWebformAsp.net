<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Header.ascx.vb" Inherits="LibrosCrudWebform.Header" %>
<link rel="stylesheet" href="~/Content/bootstrap/css/bootstrap.min.css" />
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">BookKeeper</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <asp:HyperLink ID="HyperLinkInicio" runat="server" NavigateUrl="~/Inicio.aspx" CssClass="nav-link">Inicio</asp:HyperLink>
        </li>
        <li class="nav-item">
          <asp:HyperLink ID="HyperLinkAgregarLibro" runat="server" NavigateUrl="~/Pages/Libros/AgregarLibro.aspx" CssClass="nav-link">Agregar Libro</asp:HyperLink>
        </li>
      </ul>
    </div>
  </div>
</nav>
