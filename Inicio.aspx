<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="LibrosCrudWebform.Inicio" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <link rel="stylesheet" href="~/Content/bootstrap/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" id="Header" />
      <div>
          <asp:Button ID="btnIrAAgregarLibro" runat="server" Text="Agregar Libro" OnClick="btnIrAAgregarLibro_Click" />
      </div>>
       <br />
       <br />
       <asp:GridView ID="GridViewLibros" runat="server" AutoGenerateColumns="False">
         <Columns>
            <asp:BoundField DataField="Titulo" HeaderText="Título" SortExpression="Titulo" />
            <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
            <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo" SortExpression="DescripcionTipo" />
            <asp:BoundField DataField="DescripcionTematica" HeaderText="Temática" SortExpression="DescripcionTematica" />
         <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:HyperLink ID="hlEditar" runat="server" 
                               NavigateUrl='<%# "Pages/Libros/EditarLibro.aspx?id=" + Convert.ToString(Eval("LibroID")) %>' 
                               Text="Editar"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Borrar">
            <ItemTemplate>
                <asp:LinkButton ID="lnkBorrar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("LibroID") %>' Text="Eliminar" OnClick="lnkEliminar_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
       </Columns>
      </asp:GridView>
        <uc1:Footer runat="server" id="Footer" />
</form>
    <script src="~/Content/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>
</html>
