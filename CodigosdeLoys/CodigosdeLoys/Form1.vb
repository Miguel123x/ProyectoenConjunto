Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ''comprobacion los dato del texbox en la tabla en BD
            If usuarioRegistrado(txtUsuario.Text) = True Then ''evalua user

                Dim contra As String = contrasena(txtUsuario.Text)
                If contra.Equals(txtContrasena.Text) = True Then ''evalua contrasena
                    FrmPrincipal.ShowDialog() ''llamar el formulario principal

                Else
                    MsgBox("Contraseña Invalida", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("El Usuario: " + txtUsuario.Text + " no se encuentra registrado")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
