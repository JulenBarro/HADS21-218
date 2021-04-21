Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class WebForm4
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio
    Public Shared dataSet As New DataSet
    Public Shared dataAdapter As New SqlDataAdapter()

    Public Shared dataSet2 As New DataSet
    Public Shared dataAdapter2 As New SqlDataAdapter()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dataSet = Session("dS")
            dataAdapter = Session("dA")
        Else
            Dim aux = ln.asignaturasProfe(Session("email"))

            dataSet = aux.ds
            dataAdapter = aux.da

            DropDownList1.DataTextField = dataSet.Tables("Asignaturas").Columns("codigoasig").ToString()
            DropDownList1.DataValueField = dataSet.Tables("Asignaturas").Columns("codigoasig").ToString()
            DropDownList1.DataSource = dataSet.Tables("Asignaturas")
            DropDownList1.DataBind()
            Dim asginatura = DropDownList1.SelectedValue
            Dim dt As New DataTable
            dt.Columns.Add("Codigo")
            dt.Columns.Add("Desc.")
            dt.Columns.Add("Horas")
            dt.Columns.Add("Tipo")
            Dim dataRow As DataRow

            For Each dataRow In dataSet.Tables("TareasGenericas").Rows
                If StrComp(dataRow("CodAsig"), asginatura, CompareMethod.Text) = 0 Then
                    dt.Rows.Add(dataRow("Codigo"), dataRow("Descripcion"), dataRow("HEstimadas"), dataRow("TipoTarea"))
                End If
            Next
            GridView1.DataSource = dt
            GridView1.DataBind()
            Session("dS") = dataSet
            Session("dA") = dataAdapter
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim aux = ln.asignaturasAuxProfesor(DropDownList1.SelectedValue)

            dataSet2 = aux.ds
            dataAdapter2 = aux.da

            dataSet2.DataSetName = "tareas"
            dataSet2.Namespace = "http://ji.ehu.es/has"
            dataSet2.Tables("tarea").Columns("codigo").ColumnMapping = MappingType.Attribute
            dataSet2.WriteXml(Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml"))
            Label1.Text = "Operación completada con éxito!"
            Label1.Visible = True
        Catch ex As Exception
            Label1.Text = "Error, No se ha podido completar la operación."
            Label1.Visible = True
        End Try


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Debug.WriteLine("Cambio")
        Dim asginatura = DropDownList1.SelectedValue
        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Desc.")
        dt.Columns.Add("Horas")
        dt.Columns.Add("Tipo")
        Dim dataRow As DataRow

        For Each dataRow In dataSet.Tables("TareasGenericas").Rows
            If StrComp(dataRow("CodAsig"), asginatura, CompareMethod.Text) = 0 Then
                dt.Rows.Add(dataRow("Codigo"), dataRow("Descripcion"), dataRow("HEstimadas"), dataRow("TipoTarea"))
            End If
        Next
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Application("contProfesores") = Application("contProfesores") - 1
        Dim secuenciaProfe As New List(Of String)
        secuenciaProfe = Application("secuenciaProfe")
        secuenciaProfe.Remove(Session("email"))
        Application("secuenciaProfe") = secuenciaProfe
        Response.Redirect("~/publicas/Inicio.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Response.Redirect("~/privadas/Profesores/Profesor.aspx")
    End Sub
End Class