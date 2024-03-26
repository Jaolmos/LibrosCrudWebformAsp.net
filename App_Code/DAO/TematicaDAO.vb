Imports System.Data.SqlClient

Public Class TematicaDAO
    Public Function ObtenerTematicas() As List(Of Tematica)
        Dim listaTematicas As New List(Of Tematica)

        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()

                Dim consulta As String = "SELECT TematicaID, Descripcion FROM Tematica"
                Using comando As New SqlCommand(consulta, conexion)
                    Using reader As SqlDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim tematica As New Tematica With {
                                .TematicaID = Convert.ToInt32(reader("TematicaID")),
                                .Descripcion = Convert.ToString(reader("Descripcion"))
                            }
                            listaTematicas.Add(tematica)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al obtener temáticas: {ex.Message}")
        End Try

        Return listaTematicas
    End Function
End Class
