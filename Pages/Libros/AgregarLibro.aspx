<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AgregarLibro.aspx.vb" Inherits="LibrosCrudWebform.AgregarLibro" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar Libro</title>
    <link rel="stylesheet" href="~/Content/bootstrap/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <h2 class="text-center mb-4">Agrega Nuevo Libro</h2>
                    <div class="form-group">
                        <label for="txtTitulo">Título:</label>
                        <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtAutor">Autor:</label>
                        <asp:TextBox ID="txtAutor" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtISBN">ISBN:</label>
                        <asp:TextBox ID="txtISBN" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipo">Tipo:</label>
                        <asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="ddlTematica">Temática:</label>
                        <asp:DropDownList ID="ddlTematica" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="text-center mt-4">
                        <asp:Button ID="btnAgregar" CssClass="btn btn-primary px-5" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <uc1:Footer runat="server" ID="Footer" />
    </form>
    <script src="~/Content/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>
</html>
