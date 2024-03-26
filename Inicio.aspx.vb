Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarLibros()
        End If
    End Sub

    Protected Sub btnIrAAgregarLibro_Click(sender As Object, e As EventArgs) Handles btnIrAAgregarLibro.Click
        Response.Redirect("~/Pages/Libros/AgregarLibro.aspx")
    End Sub

    Private Sub CargarLibros()
        Dim conexioBD As New ConexionBD()
        Dim libroDao As New LibroDAO(conexioBD)
        Dim listaLibros As List(Of Libro) = libroDao.ObtenerTodosLosLibros()

        GridViewLibros.DataSource = listaLibros
        GridViewLibros.DataBind()

    End Sub

    Protected Sub lnkBorrar_Click(sender As Object, e As EventArgs)
        Dim lnkButton As LinkButton = CType(sender, LinkButton)
        Dim libroId As Integer = Convert.ToInt32(lnkButton.CommandArgument)

        Dim conexionBD As New ConexionBD()
        Dim libroDao As New LibroDAO(conexionBD)
        libroDao.EliminarLibro(libroId)

        CargarLibros()
    End Sub



End Class