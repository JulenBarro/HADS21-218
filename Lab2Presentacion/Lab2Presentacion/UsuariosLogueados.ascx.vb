Public Class UsuariosLogueados
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        contadores()
        listas()
    End Sub

    Protected Sub contadores()
        Label2.Text = Application("contAlumnos")
        Label5.Text = Application("contProfesores")
    End Sub

    Protected Sub listas()
        Dim secuencia As New List(Of String)
        secuencia = Application("secuenciaAlumno")
        ListBox3.DataSource = secuencia
        ListBox3.DataBind()

        secuencia = Application("secuenciaProfe")
        ListBox2.DataSource = secuencia
        ListBox2.DataBind()
    End Sub


    Public Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        System.Threading.Thread.Sleep(2000)
        contadores()
        listas()
    End Sub
End Class