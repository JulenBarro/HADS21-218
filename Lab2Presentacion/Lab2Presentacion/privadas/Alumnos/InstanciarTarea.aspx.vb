Imports System.Data.SqlClient

Public Class InstanciarTarea
    Inherits System.Web.UI.Page
    Public Shared DataSet
    Public Shared dataAdapter As New SqlDataAdapter()
    Dim h As Int32
    Public Shared dt As New DataTable
    Public Shared ln As New LogicaNegocio.LogicaNegocio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim email As String = Request.QueryString("mbr")
        Dim tarea As String = Request.QueryString("tarea")
        Dim horas As String = Request.QueryString("horas")
        h = Convert.ToInt32(horas)

        TextBox1.Text = email
        TextBox2.Text = tarea
        TextBox3.Text = h

        DataSet = Session("dataSet")
        dataAdapter = Session("dataAdapter")

        'dt.Columns.Add("Email")
        'dt.Columns.Add("CodTarea")
        'dt.Columns.Add("HEstimadas")
        'dt.Columns.Add("HReales")

        dt = DataSet.Tables("EstudiantesTareas")



        'For Each dataRow In DataSet.Tables("EstudiantesTareas").Rows
        'dt.Rows.Add(dataRow("Email"), dataRow("CodTarea"), dataRow("HEstimadas"), dataRow("HReales"))
        'Next
        GridView1.DataSource = dt
        GridView1.DataBind()
        Session("dataSet") = DataSet

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/privadas/Alumnos/TareasAlumno.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dt = DataSet.Tables("EstudiantesTareas")
            Dim rowMbrs As DataRow = dt.NewRow()

            rowMbrs("Email") = TextBox1.Text
            rowMbrs("CodTarea") = TextBox2.Text
            rowMbrs("HEstimadas") = h
            rowMbrs("HReales") = Convert.ToInt32(TextBox4.Text)

            dt.Rows.Add(rowMbrs)
            GridView1.DataSource = dt
            GridView1.DataBind()
            dataAdapter = Session("dataAdapter")
            dataAdapter.Update(DataSet, "EstudiantesTareas")
            DataSet.AcceptChanges()
            Session("dataSet") = DataSet
            Session("dataAdapter") = dataAdapter
            Button1.Enabled = False
            Label1.Text = "Datos insertados correctamente."
            Label1.Visible = True
        Catch ex As Exception
            Label1.Text = "Error! Los datos no han podido ser insertados."
            Label1.Visible = True
        End Try

    End Sub
End Class