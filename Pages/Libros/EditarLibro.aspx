<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarLibro.aspx.vb" Inherits="LibrosCrudWebform.EditarLibro" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Editar Libro</title>
    <link rel="stylesheet" href="~/Content/bootstrap/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <h2>Editar libro</h2>
        <div>
            <label for="txtTitulo">Título:</label>
            <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox><br />

            <label for="txtAutor">Autor:</label>
            <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox><br />

            <label for="txtISBN">ISBN:</label>
            <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox><br />

            <label for="ddlTipo">Tipo:</label>
            <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList><br />

            <label for="ddlTematica">Temática:</label>
            <asp:DropDownList ID="ddlTematica" runat="server"></asp:DropDownList><br />

            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />

            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
        <uc1:Footer runat="server" ID="Footer" />
    </form>
    <script src="~/Content/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>
</html>
