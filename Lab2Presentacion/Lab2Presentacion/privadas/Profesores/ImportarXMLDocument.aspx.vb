Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class ImportarXMLDocument
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio
    Public Shared dataSet As New DataSet
    Public Shared dataAdapter As New SqlDataAdapter()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dataSet = Session("PAsigDS")
            dataAdapter = Session("PAsigDA")
        Else
            Try
                Dim aux = ln.datosParaImportXMLProfesor(Session("email"))
                dataSet = aux.ds
                dataAdapter = aux.da
                Session("PAsigDS") = dataSet
                Session("PAsigDA") = dataAdapter
                DropDownList1.DataTextField = dataSet.Tables("ProfeAsig").Columns("codigoasig").ToString()
                DropDownList1.DataValueField = dataSet.Tables("ProfeAsig").Columns("codigoasig").ToString()
                DropDownList1.DataSource = dataSet.Tables("ProfeAsig")
                DropDownList1.DataBind()
                If File.Exists(Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
                    Label1.Visible = False
                    Xml1.DocumentSource = Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")
                    Xml1.TransformSource = Server.MapPath("~/App_Data/VerTablaTareas.xsl")
                End If
            Catch ex As Exception
                Debug.WriteLine("Error. No se ha podido acceder al path App_Data")
                Response.Redirect("~/privadas/Profesores/Profesor.aspx")
            End Try
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            If File.Exists(Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
                Label1.Visible = False
                Xml1.DocumentSource = Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml")
                Xml1.TransformSource = Server.MapPath("~/App_Data/VerTablaTareas.xsl")
            Else
                Label1.Text = "No existe el xml de la asignatura seleccionada"
                Label1.Visible = True
            End If
        Catch ex As Exception
            Debug.WriteLine("Error. No se ha podido acceder al path App_Data")
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim docxml As XmlDocument
            docxml = New XmlDocument()
            Dim nodelist As XmlNodeList
            Dim node As XmlNode

            Dim dt As New DataTable
            dt = dataSet.Tables("TareasGenericas")

            'Cargamos el archivo XML
            docxml.Load(Server.MapPath("~/App_Data/" & DropDownList1.SelectedValue & ".xml"))
            'Obtenemos la lista de los nodos "tarea"
            nodelist = docxml.SelectNodes("/tareas/tarea")
            'Iniciamos el ciclo de lectura
            For Each node In nodelist
                'Obtenemos el atributo del codigo
                Dim codigo = node.Attributes.GetNamedItem("codigo").Value
                'Obtenemos el Elemento descripcion
                Dim descripcion = node.ChildNodes.Item(0).InnerText
                'y obtenemos los demás de la misma manera
                Dim hestimadas = node.ChildNodes.Item(1).InnerText
                Dim explotacion = node.ChildNodes.Item(2).InnerText
                Dim tipotarea = node.ChildNodes.Item(3).InnerText
                dt.Rows.Add(codigo, descripcion, DropDownList1.SelectedValue, hestimadas, explotacion, tipotarea)
            Next
            dataAdapter.Update(dataSet, "TareasGenericas")
            dataSet.AcceptChanges()
            Session("PAsigDS") = dataSet
            Session("PAsigDA") = dataAdapter
            Label1.Text = "Tareas IMPORTADAS del fichero " & DropDownList1.SelectedValue & ".xml"
            Label1.Visible = True
        Catch ex As Exception
            Label1.Text = "Error! No se han podido IMPORTAR tareas del fichero " & DropDownList1.SelectedValue & ".xml"
            Debug.WriteLine("Error importando TareasGenericas XMLDocument.")
            Label1.Visible = True
        End Try


    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/privadas/Profesores/Profesor.aspx")
    End Sub
End Class