<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AgregarLibro.aspx.vb" Inherits="LibrosCrudWebform.AgregarLibro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="form-group">
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

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
</div>

    </form>
</body>
</html>
