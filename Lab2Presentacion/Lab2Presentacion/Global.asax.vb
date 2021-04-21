Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Application("contProfesores") = 0
        Application("contAlumnos") = 0
        Dim secuenciaProfe As New List(Of String)
        Dim secuenciaAlumno As New List(Of String)
        Application("secuenciaAlumno") = secuenciaAlumno
        Application("secuenciaProfe") = secuenciaProfe
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        Application("contProfesores") = 0
        Application("contAlumnos") = 0
        Application("secuenciaAlumno") = Nothing
        Application("secuenciaProfe") = Nothing
    End Sub

End Class