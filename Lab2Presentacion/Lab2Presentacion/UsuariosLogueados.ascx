<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UsuariosLogueados.ascx.vb" Inherits="Lab2Presentacion.UsuariosLogueados" %>
<style type="text/css">
    .auto-style1 {
        height: 190px;
        width: 793px;
    }
</style>

<div class="auto-style1">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="4000">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="300" DynamicLayout="true">
                        <ProgressTemplate>
                            Buscando...
                            <br />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="USUARIOS LOGUEADOS:"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Alumno/s"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" Text="y"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Profe/s"></asp:Label>
    <asp:ListBox ID="ListBox3" runat="server" Width="234px"></asp:ListBox>
&nbsp;&nbsp;
    <asp:ListBox ID="ListBox2" runat="server" Width="234px"></asp:ListBox>
            <br />
        </ContentTemplate>
        
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</div>

