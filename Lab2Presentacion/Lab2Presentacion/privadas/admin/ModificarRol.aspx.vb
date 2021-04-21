Public Class ModificarRol
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (StrComp(TextBox1.Text, "", CompareMethod.Text) <> 0) Then
            If (RadioButton1.Checked) Then
                Dim aux = ln.cambiarRol(TextBox1.Text, "Alumno")
                Label4.Text = aux.st
                Label4.Visible = True
            ElseIf RadioButton2.Checked Then
                Dim aux = ln.cambiarRol(TextBox1.Text, "Profesor")
                Label4.Text = aux.st
                Label4.Visible = True
            ElseIf RadioButton3.Checked Then
                Dim aux = ln.cambiarRol(TextBox1.Text, "Admin")
                Label4.Text = aux.st
                Label4.Visible = True
            Else
                Label4.Text = "Selecciona una opción."
                Label4.Visible = True
            End If
        Else
            Label4.Text = "Introduce el email."
            Label4.Visible = True
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/privadas/Profesores/Profesor.aspx")
    End Sub
End Class