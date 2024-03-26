Public Class EditarLibro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim libroId As Integer = If(Request.QueryString("id") IsNot Nothing, Convert.ToInt32(Request.QueryString("id")), 0)

            If libroId > 0 Then
                ' Cargar datos del libro para editar
                CargarTipos()
                CargarTematicas()
                CargarDatosLibro(libroId) ' Asegúrate de implementar este método.
            End If
        End If
    End Sub

    Private Sub CargarDatosLibro(ByVal libroId As Integer)
        Dim conexioBd As New ConexionBD()
        Dim libroDao As New LibroDAO(conexioBd)
        Dim libro As Libro = libroDao.ObtenerLibroPorId(libroId)

        If libro IsNot Nothing Then
            txtTitulo.Text = libro.Titulo
            txtAutor.Text = libro.Autor
            txtISBN.Text = libro.ISBN
            ddlTipo.SelectedValue = libro.TipoID.ToString()
            ddlTematica.SelectedValue = libro.TematicaID.ToString()
        End If
    End Sub

    Private Sub CargarTipos()
        Dim tipoDao As New TipoDAO()
        Dim listaTipos As List(Of Tipo) = tipoDao.ObtenerTipos()

        ddlTipo.DataSource = listaTipos
        ddlTipo.DataTextField = "Descripcion"
        ddlTipo.DataValueField = "TipoID"
        ddlTipo.DataBind()

        ddlTipo.Items.Insert(0, New ListItem("-- Seleccione Tipo --", "0"))
    End Sub

    Private Sub CargarTematicas()
        Dim tematicaDao As New TematicaDAO()
        Dim listaTematicas As List(Of Tematica) = tematicaDao.ObtenerTematicas()

        ddlTematica.DataSource = listaTematicas
        ddlTematica.DataTextField = "Descripcion"
        ddlTematica.DataValueField = "TematicaID"
        ddlTematica.DataBind()

        ddlTematica.Items.Insert(0, New ListItem("-- Seleccione Temática --", "0"))
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click, btnCancelar.Click
        Dim libroId As Integer = If(Request.QueryString("id") IsNot Nothing, Convert.ToInt32(Request.QueryString("id")), 0)

        If libroId > 0 Then
            Dim libroActualizado As New Libro() With {
                .LibroID = libroId,
                .Titulo = txtTitulo.Text,
                .Autor = txtAutor.Text,
                .ISBN = txtISBN.Text,
                .TipoID = Integer.Parse(ddlTipo.SelectedValue),
                .TematicaID = Integer.Parse(ddlTematica.SelectedValue)
            }

            Dim conexionBD As New ConexionBD()
            Dim libroDao As New LibroDAO(conexionBD)
            libroDao.ActualizarLibro(libroActualizado)

            Response.Redirect("/inicio.aspx")
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("/inicio.aspx")
    End Sub
End Class