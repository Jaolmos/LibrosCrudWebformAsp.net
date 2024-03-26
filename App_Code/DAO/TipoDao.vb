Imports System.Data.SqlClient

Public Class TipoDAO
    Public Function ObtenerTipos() As List(Of Tipo)
        Dim listaTipos As New List(Of Tipo)

        Try
            Using conexion As SqlConnection = ConexionBD.ObtenerConexion()
                conexion.Open()

                Dim consulta As String = "SELECT TipoID, Descripcion FROM Tipo"
                Using comando As New SqlCommand(consulta, conexion)
                    Using reader As SqlDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim tipo As New Tipo With {
                                .TipoID = Convert.ToInt32(reader("TipoID")),
                                .Descripcion = Convert.ToString(reader("Descripcion"))
                            }
                            listaTipos.Add(tipo)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Error al obtener tipos: {ex.Message}")
        End Try

        Return listaTipos
    End Function
End Class
