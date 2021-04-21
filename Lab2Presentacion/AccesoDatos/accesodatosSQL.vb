Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.VisualBasic.Strings
Public Class accesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = �Server=tcp:hads21-212.database.windows.net,1433;Initial Catalog=HADS21-212;Persist Security Info=False;User ID=barromjulen@outlook.com@hads21-212;Password=LiveLife8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXI�N: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numbconfir As Integer, ByVal confirmado As Boolean, ByVal tipo As String, ByVal pass As String, ByVal codpass As Integer) As String

        Dim st = "insert into Usuarios (email,nombre,apellidos, numconfir, confirmado, tipo, pass, codpass) values ('" & email & " ','" & nombre & " ','" & apellidos & " ', '" & numbconfir & " ','" & confirmado & " ','" & tipo & " ','" & pass & " ','" & codpass & " ')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (numregs & " registro(s) insertado(s) en la BD ")
    End Function

    Public Shared Function emailycodigoCorrectos(ByVal emailto As String, ByVal codigo As String) As Boolean
        Try
            Dim st = "select * from Usuarios"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            Dim confirmar As Boolean = False
            While datos.Read
                Dim emailespacio As String = emailto + " "
                If ((String.Compare(emailespacio, datos.Item("email")) = 0) And (String.Compare(codigo, datos.Item("numconfir").ToString) = 0)) Then
                    confirmar = True
                End If
            End While
            Return confirmar
        Catch ex As SqlException
            Console.WriteLine("SQL error.")
            Return False
        Catch ex As Exception
            Console.WriteLine("Exception")
            Return False
        Finally
            Console.WriteLine("Finally")
        End Try
    End Function

    Public Shared Function cambioConfirmado(ByVal email As String) As Boolean
        Try
            Dim tr As Boolean = True
            Dim st2 = "update Usuarios set confirmado = '" & tr & " ' where email = '" & email & " '"
            comando = New SqlCommand(st2, conexion)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function codigoContrase�a(ByVal email As String, ByVal codigo As Integer) As Boolean
        Try
            Dim st2 = "update Usuarios set codpass = '" & codigo & " ' where email = '" & email & " '"
            comando = New SqlCommand(st2, conexion)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function existeEmailConfirmado(ByVal emailto As String) As Boolean
        Try
            Dim conf As Boolean = True
            Dim st = "select * from Usuarios where confirmado = '" & conf & " '"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            Dim confirmar As Boolean = False
            While datos.Read
                Dim emailespacio As String = emailto + " "
                If ((String.Compare(emailespacio, datos.Item("email")) = 0) Or (String.Compare(emailto, datos.Item("email")) = 0)) Then
                    confirmar = True
                End If
            End While
            Return confirmar
        Catch ex As Exception
            Console.WriteLine("Exception")
            Return False
        End Try
    End Function

    Public Shared Function existeEmail(ByVal emailto As String) As Boolean
        Try
            Dim st = "select * from Usuarios"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            Dim existe As Boolean = False
            While datos.Read
                Dim emailespacio As String = emailto + " "
                If ((String.Compare(emailespacio, datos.Item("email")) = 0)) Then
                    existe = True
                End If
            End While
            Return existe
        Catch ex As Exception
            Console.WriteLine("Exception")
            Return False
        End Try
    End Function

    Public Shared Function codigoContrase�aGet(ByVal emailto As String) As (numero As Integer, confir As Boolean)
        Try
            Dim emailespacio As String = emailto + " "
            Dim st = "select * from Usuarios where email = '" & emailto & "'"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            Dim numero As Integer = -1
            While datos.Read
                numero = datos.Item("codpass")
            End While
            Return (numero, True)
        Catch ex As Exception
            Console.WriteLine("Exception")
            Return (-1, False)
        End Try
    End Function

    Public Shared Function cambiarContrase�a(ByVal email As String, ByVal pass As String) As Boolean
        Try
            Dim st2 = "update Usuarios set pass = '" & pass & " ' where email = '" & email & " '"
            comando = New SqlCommand(st2, conexion)
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function emailContrase�a(ByVal emailto As String, ByVal pass As String) As Boolean
        Try
            Dim st = "select * from Usuarios where email = '" & emailto & "'"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            Dim passconespacio As String = pass + " "
            While datos.Read
                If ((String.Compare(passconespacio, datos.Item("pass")) = 0) Or (String.Compare(pass, datos.Item("pass")) = 0)) Then
                    Return True
                End If
            End While
            Return False
        Catch ex As Exception
            Console.WriteLine("Exception")
            Return False
        End Try
    End Function
    'Devuelve true si es alumno y false si es profesor
    Public Shared Function esAlumno(ByVal emailto As String) As Boolean
        Try
            Dim st = "select * from Usuarios where email = '" & emailto & "'"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            While datos.Read
                If ((String.Compare("Alumno", datos.Item("tipo")) = 0)) Then
                    Return True
                Else
                    Return False
                End If
            End While
            Return False
        Catch ex As Exception
            Console.WriteLine("Exception")
            Return False
        End Try
    End Function

    Public Shared Function asignaturasAlumno(ByVal email As String) As (ds As DataSet, da As SqlDataAdapter)
        Dim dataAdapter As New SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim dataTable As New DataTable
        Try
            dataAdapter = New SqlDataAdapter("select distinct GruposClase.codigoasig from EstudiantesGrupo inner join GruposClase on EstudiantesGrupo.Grupo = 
        GruposClase.codigo where EstudiantesGrupo.Email = @email", conexion)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@email", email)
            dataAdapter.Fill(dataSet, "Asignaturas")

            dataAdapter = New SqlDataAdapter("select * from TareasGenericas where TareasGenericas.Codigo NOT IN (select EstudiantesTareas.CodTarea 
        from EstudiantesTareas) and TareasGenericas.Explotacion = @true", conexion)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@true", True)
            dataAdapter.Fill(dataSet, "TareasGenericas")

            dataAdapter = New SqlDataAdapter("select * from EstudiantesTareas where EstudiantesTareas.Email = @email", conexion)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@email", email)
            Dim bldMbrs As New SqlCommandBuilder(dataAdapter)
            dataAdapter.Fill(dataSet, "EstudiantesTareas")
        Catch ex As Exception
            Debug.WriteLine("Error.")
        End Try


        Return (dataSet, dataAdapter)
    End Function

    Public Shared Function datosParaImportXMLProfesor(ByVal email As String) As (ds As DataSet, da As SqlDataAdapter)
        Dim dataAdapter As New SqlDataAdapter()
        Dim dataSet As New DataSet

        dataAdapter = New SqlDataAdapter("select distinct GruposClase.codigoasig from ProfesoresGrupo inner join GruposClase on
ProfesoresGrupo.codigogrupo = GruposClase.codigo where ProfesoresGrupo.email = @email", conexion)
        dataAdapter.SelectCommand.Parameters.AddWithValue("@email", email)
        dataAdapter.Fill(dataSet, "ProfeAsig")

        dataAdapter = New SqlDataAdapter("select * from TareasGenericas", conexion)
        Dim bldMbrs As New SqlCommandBuilder(dataAdapter)
        dataAdapter.Fill(dataSet, "TareasGenericas")

        Return (dataSet, dataAdapter)
    End Function

    Public Shared Function asignaturasProfe(ByVal email As String) As (ds As DataSet, da As SqlDataAdapter)
        Dim dataAdapter As New SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim dataTable As New DataTable

        dataAdapter = New SqlDataAdapter("SELECT distinct codigoasig FROM ProfesoresGrupo  JOIN GruposClase  on ProfesoresGrupo.codigogrupo = GruposClase.codigo where email= @email", conexion)


        dataAdapter.SelectCommand.Parameters.AddWithValue("@email", email)
        dataAdapter.Fill(dataSet, "Asignaturas")

        dataAdapter = New SqlDataAdapter("select * from TareasGenericas  ", conexion)
        'dataAdapter.SelectCommand.Parameters.AddWithValue("@true", True)
        dataAdapter.Fill(dataSet, "TareasGenericas")

        dataAdapter = New SqlDataAdapter("select * from EstudiantesTareas where EstudiantesTareas.Email = @email", conexion)
        dataAdapter.SelectCommand.Parameters.AddWithValue("@email", email)
        Dim bldMbrs As New SqlCommandBuilder(dataAdapter)
        dataAdapter.Fill(dataSet, "EstudiantesTareas")

        Return (dataSet, dataAdapter)
    End Function



    Public Shared Function asignaturasAuxProfesor(ByVal codigo As String) As (ds As DataSet, da As SqlDataAdapter)
        Dim dataAdapter2 As New SqlDataAdapter()
        Dim dataSet2 As New DataSet
        Dim dataTable2 As New DataTable

        dataAdapter2 = New SqlDataAdapter("SELECT t.Codigo as codigo, t.Descripcion as descripcion, t.HEstimadas as hestimadas,
        t.Explotacion as explotacion, t.TipoTarea as tipotarea FROM TareasGenericas as t where @codigo = CodAsig", conexion)
        dataAdapter2.SelectCommand.Parameters.AddWithValue("@codigo", codigo)
        dataAdapter2.Fill(dataSet2, "tarea")

        Return (dataSet2, dataAdapter2)
    End Function

    Public Shared Function getRol(ByVal emailto As String) As (bol As Boolean, st As String)
        Try
            Dim st = "select * from Usuarios where email = '" & emailto & "'"
            comando = New SqlCommand(st, conexion)
            Dim datos As SqlDataReader
            datos = comando.ExecuteReader()
            Dim aux
            While datos.Read
                aux = datos.Item("tipo")
            End While
            Return (True, aux)
        Catch ex As Exception
            Return (False, "Error. No se ha podido obtener el rol del usuario.")
        End Try

    End Function

    Public Shared Function cambiarRol(ByVal emailto As String, ByVal rol As String) As (bool As Boolean, st As String)
        Try
            Dim st2 = "update Usuarios set tipo = '" & rol & " ' where email = '" & emailto & " '"
            comando = New SqlCommand(st2, conexion)
            comando.ExecuteNonQuery()
            Return (True, "Actualizado correctamente")
        Catch ex As Exception
            Return (False, "Error. No se ha podido realizar el cambio.")
        End Try
    End Function
End Class
