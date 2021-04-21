Public Class WebForm1
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim aux = ln.getRol(Session("email"))

        If StrComp(Session("email"), "vadillo@ehu.es", CompareMethod.Text) = 0 Then
            Panel1.Visible = True
            Panel3.Visible = True
            LinkButton1.Visible = True
            LinkButton1.Enabled = True
            LinkButton2.Visible = True
            LinkButton2.Enabled = True
            Panel5.Visible = True
            LinkButton5.Visible = True
            LinkButton5.Enabled = True
        End If

        If aux.bol And StrComp(aux.st, "Admin", CompareMethod.Text) = 0 Then
            LinkButton3.Visible = True
            Panel2.Visible = True
            LinkButton3.Enabled = True
        End If
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Application("contProfesores") = Application("contProfesores") - 1
        Dim secuenciaProfe As New List(Of String)
        secuenciaProfe = Application("secuenciaProfe")
        secuenciaProfe.Remove(Session("email"))
        Application("secuenciaProfe") = secuenciaProfe
        Response.Redirect(“~/publicas/Inicio.aspx")
    End Sub
End Class