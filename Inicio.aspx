<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="LibrosCrudWebform.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                <asp:LinkButton ID="lnkBorrar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("LibroID") %>' Text="Eliminar" OnClick="lnkBorrar_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
       </Columns>
      </asp:GridView>



</form>
</body>
</html>
