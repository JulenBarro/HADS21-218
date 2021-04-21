Public Class coordinador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label3.Text = "***"

        'Servicio con localhost
        'Dim serv As New MediaHorasDedicacion.Service1Client

        'Servicio en azure
        Dim serv As New ServiceReference1.Service1Client

        TextBox1.Text = serv.GetMediaHoras(DropDownList1.SelectedValue)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Label3.Text = DropDownList1.SelectedValue

        'Servicio con localhost
        'Dim serv As New MediaHorasDedicacion.Service1Client

        'Servicio en azure
        Dim serv As New ServiceReference1.Service1Client

        TextBox1.Text = serv.GetMediaHoras(DropDownList1.SelectedValue)
    End Sub
End Class