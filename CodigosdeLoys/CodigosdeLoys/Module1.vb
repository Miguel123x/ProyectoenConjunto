Imports System.Data.Sql
Imports System.Data.SqlClient

Module Conexion
    Public conexion As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader


    ''procedimiento abrir
    Sub abrir()
        Try
            ''cadena de conexion 
            conexion = New SqlConnection("Data Source=.;Initial Catalog=Login;Integrated Security=True")
            ''abriendo la conexion y mensaje de conectado
            conexion.Open()
            MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("No se pudo conectar" + ex.ToString) '' el + ex.ToString es para que me diga por que no se pudo conectar 
        End Try
    End Sub

    ''funcion que me evalua si el usuario esta o no registrado 
    Function usuarioRegistrado(ByVal nombreUsuario As String) As Boolean
        Dim resultado As Boolean = False
        Try
            ''ejecutando el comando select en la tabla usuarios consulta
            enunciado = New SqlCommand("Select * from Usuarios where Usuarios='" & nombreUsuario & "'", conexion)
            respuesta = enunciado.ExecuteReader

            '' si en la consulta encuentra un registo con lo ingresado en los texbox se ejecuta el sigunete if
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    ''evaluar la contrasena del usaurio en la tabla usaurio 
    Function contrasena(ByVal nombreUsuario As String) As String
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select Contrasena from Usuarios where Usuarios='" & nombreUsuario & "'", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Contrasena")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

End Module
