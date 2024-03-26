Imports System.Data.SqlClient

Public Class LibroDAO
    Private Property ConexionBD As ConexionBD

    Public Sub New(conexionBD As ConexionBD)
        Me.ConexionBD = conexionBD
    End Sub

    Public Sub AgregarLibro(libro As Libro)
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "INSERT INTO Libros (Titulo, Autor, ISBN, TipoID, TematicaID) VALUES (@Titulo, @Autor, @ISBN, @TipoID, @TematicaID)"

                Using comando As New SqlCommand(consulta, conexion)
                    With comando
                        .Parameters.AddWithValue("@Titulo", libro.Titulo)
                        .Parameters.AddWithValue("@Autor", libro.Autor)
                        .Parameters.AddWithValue("@ISBN", libro.ISBN)
                        .Parameters.AddWithValue("@TipoID", libro.TipoID)
                        .Parameters.AddWithValue("@TematicaID", libro.TematicaID)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al agregar libro: {ex.Message}")
        End Try
    End Sub

    Public Function ObtenerTodosLosLibros() As List(Of Libro)
        Dim listaLibros As New List(Of Libro)

        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "SELECT Libros.LibroID, Libros.Titulo, Libros.Autor, Libros.ISBN, Libros.TipoID, Libros.TematicaID, Tipo.Descripcion AS DescripcionTipo, Tematica.Descripcion AS DescripcionTematica FROM Libros INNER JOIN Tipo ON Libros.TipoID = Tipo.TipoID INNER JOIN Tematica ON Libros.TematicaID = Tematica.TematicaID"

                Using comando As New SqlCommand(consulta, conexion)
                    Using reader As SqlDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim libro As New Libro With {
                                .LibroID = Convert.ToInt32(reader("LibroID")),
                                .Titulo = Convert.ToString(reader("Titulo")),
                                .Autor = Convert.ToString(reader("Autor")),
                                .ISBN = Convert.ToString(reader("ISBN")),
                                .TipoID = Convert.ToInt32(reader("TipoID")),
                                .TematicaID = Convert.ToInt32(reader("TematicaID")),
                                .DescripcionTipo = Convert.ToString(reader("DescripcionTipo")),
                                .DescripcionTematica = Convert.ToString(reader("DescripcionTematica"))
                            }
                            listaLibros.Add(libro)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al obtener todos los libros: {ex.Message}")
        End Try

        Return listaLibros
    End Function

    Public Function ObtenerLibroPorId(ByVal libroId As Integer) As Libro
        Dim libro As Libro = Nothing

        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "SELECT LibroID, Titulo, Autor, ISBN, TipoID, TematicaID FROM Libros WHERE LibroID = @LibroID"

                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@LibroID", libroId)
                    Using reader As SqlDataReader = comando.ExecuteReader()
                        If reader.Read() Then
                            libro = New Libro With {
                                .LibroID = Convert.ToInt32(reader("LibroID")),
                                .Titulo = Convert.ToString(reader("Titulo")),
                                .Autor = Convert.ToString(reader("Autor")),
                                .ISBN = Convert.ToString(reader("ISBN")),
                                .TipoID = Convert.ToInt32(reader("TipoID")),
                                .TematicaID = Convert.ToInt32(reader("TematicaID"))}
                            ' Nota: Aquí no estamos cargando DescripcionTipo ni DescripcionTematica porque requeriría un JOIN adicional

                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al obtener el libro con ID {libroId}: {ex.Message}")
        End Try

        Return libro
    End Function

    Public Sub ActualizarLibro(libro As Libro)
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, ISBN = @ISBN, TipoID = @TipoID, TematicaID = @TematicaID WHERE LibroID = @LibroID"

                Using comando As New SqlCommand(consulta, conexion)
                    With comando
                        .Parameters.AddWithValue("@LibroID", libro.LibroID)
                        .Parameters.AddWithValue("@Titulo", libro.Titulo)
                        .Parameters.AddWithValue("@Autor", libro.Autor)
                        .Parameters.AddWithValue("@ISBN", libro.ISBN)
                        .Parameters.AddWithValue("@TipoID", libro.TipoID)
                        .Parameters.AddWithValue("@TematicaID", libro.TematicaID)
                        .ExecuteNonQuery()
                    End With
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al actualizar el libro: {ex.Message}")
        End Try
    End Sub


    Public Sub EliminarLibro(ByVal libroId As Integer)
        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()
                Dim consulta As String = "DELETE FROM Libros WHERE LibroID = @LibroID"

                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@LibroID", libroId)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al eliminar el libro: {ex.Message}")
        End Try
    End Sub


End Class
