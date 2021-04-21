<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="Lab2Presentacion.WebForm1" %>

<%@ Register src="../../UsuariosLogueados.ascx" tagname="UsuariosLogueados" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 63px;
            width: 378px;
        }
        .auto-style3 {
            width: 100%;
            height: 592px;
        }
        .auto-style4 {
            height: 63px;
            width: 735px;
        }
    </style>
</head>
<body style="height: 637px">
    <form id="form1" runat="server">
    <table class="auto-style3">
        <tr>
            <td class="auto-style2" style="background-color:papayawhip; border:outset" >
                <div>
                    <asp:Panel ID="Panel4" runat="server">
                        <asp:LinkButton ID="LinkButton4" runat="server">Cerrar Sesión</asp:LinkButton>
                    </asp:Panel>
                </div>
                <hr/>
                <div>
                <label><a href='TareasProfesor.aspx'>Tareas</a></label>
                </div>
                <hr/>
                <div>
                <label>Grupos</label>
                </div>
                <hr/>
                <div>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/privadas/Profesores/ImportarXMLDocument.aspx" Enabled="False" Visible="False">Importar v. XMLDocument</asp:LinkButton>
                    </asp:Panel>
                </div>
                <hr/>
                <div>
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/privadas/Profesores/ExportarTarea.aspx" Enabled="False" Visible="False">Exportar</asp:LinkButton>
                    </asp:Panel>
                </div>
                <hr/>
                <div>
                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <asp:LinkButton ID="LinkButton3" runat="server" Enabled="False" PostBackUrl="~/privadas/admin/ModificarRol.aspx" Visible="False">Modificar Rol</asp:LinkButton>
                    </asp:Panel>
                </div>
                <hr/>
                <div>


                    <asp:Panel ID="Panel5" runat="server">
                        <asp:LinkButton ID="LinkButton5" runat="server" Enabled="False" PostBackUrl="~/privadas/coordinador/coordinador.aspx" Visible="False">Coordinador</asp:LinkButton>
                    </asp:Panel>


                </div>

            </td>
            <td class="auto-style4" style="text-align: center; background-color: azure; border:outset">
                <label>Gestion web de tareas de dedicacionabel>
                <hr/>
                <label>Profesores</label>

            </td>
            
        </tr>
    </table>
        <uc1:UsuariosLogueados ID="UsuariosLogueados1" runat="server" />
    </form>
</body>
</html>
