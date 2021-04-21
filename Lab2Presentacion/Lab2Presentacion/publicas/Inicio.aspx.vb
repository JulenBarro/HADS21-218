Public Class Inicio
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Web.Security.FormsAuthentication.SignOut()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RequiredFieldValidator1.Validate()
        RequiredFieldValidator2.Validate()

        If (ln.existeEmailConfirmado(TextBox1.Text)) Then
            If (ln.emailContraseña(TextBox1.Text, TextBox2.Text)) Then 'Si la contraseña corresponde al email introducido
                Session("email") = TextBox1.Text
                If ln.esAlumno(TextBox1.Text) Then
                    System.Web.Security.FormsAuthentication.SetAuthCookie("Alumno", False)

                    Application("contAlumnos") = Application("contAlumnos") + 1
                    Dim secuenciaAlumno As New List(Of String)
                    secuenciaAlumno = Application("secuenciaAlumno")
                    secuenciaAlumno.Add(Session("email"))
                    Application("secuenciaAlumno") = secuenciaAlumno

                    Response.Redirect(“~/privadas/Alumnos/Alumno.aspx")
                Else
                    Application("contProfesores") = Application("contProfesores") + 1

                    Dim secuenciaProfe As New List(Of String)
                    secuenciaProfe = Application("secuenciaProfe")
                    secuenciaProfe.Add(Session("email"))
                    Application("secuenciaProfe") = secuenciaProfe

                    If StrComp("vadillo@ehu.es", TextBox1.Text, CompareMethod.Text) = 0 Then
                        System.Web.Security.FormsAuthentication.SetAuthCookie("Vadillo", False)
                    ElseIf StrComp("admin@ehu.es", TextBox1.Text, CompareMethod.Text) = 0 Then
                        System.Web.Security.FormsAuthentication.SetAuthCookie("Admin", False)
                    Else
                        System.Web.Security.FormsAuthentication.SetAuthCookie("Profesor", False)
                    End If
                    Response.Redirect(“~/privadas/Profesores/Profesor.aspx")
                End If

            Else
                Label4.Visible = True
                Label4.Text = "Contraseña Erronea."
            End If
        Else
            Label4.Visible = True
            Label4.Text = "El email es erroneo."
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect(“registro.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect(“CambiarPassword.aspx")
    End Sub
End Class