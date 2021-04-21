' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.
Imports System.Data.SqlClient
Imports System.Data

Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function GetMediaHoras(ByVal asignatura As String) As Integer Implements IService1.GetMediaHoras
        Try
            Dim conexion As New SqlConnection(“Server=tcp:hads21-212.database.windows.net,1433;Initial Catalog=HADS21-212;Persist Security Info=False;User ID=barromjulen@outlook.com@hads21-212;Password=LiveLife8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            conexion.Open()
            Dim st = "select AVG(EstudiantesTareas.HReales) from TareasGenericas inner join EstudiantesTareas on TareasGenericas.Codigo = EstudiantesTareas.CodTarea where TareasGenericas.CodAsig = '" & asignatura & "'"
            Dim comando = New SqlCommand(st, conexion)
            Dim datos = comando.ExecuteScalar
            conexion.Close()
            Return datos
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

End Class
