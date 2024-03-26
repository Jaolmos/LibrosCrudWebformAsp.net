Public Class AgregarLibro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarTipos()
            CargarTematicas()
        End If
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim nuevoLibro As New Libro()

        With nuevoLibro
            .Titulo = txtTitulo.Text
            .Autor = txtAutor.Text
            .ISBN = txtISBN.Text
            .TipoID = Integer.Parse(ddlTipo.SelectedValue)
            .TematicaID = Integer.Parse(ddlTematica.SelectedValue)
        End With

        Dim conexionBD As New ConexionBD()
        Dim libroDao As New LibroDAO(conexionBD)
        libroDao.AgregarLibro(nuevoLibro)

        Response.Redirect("/inicio.aspx")
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

End Class
