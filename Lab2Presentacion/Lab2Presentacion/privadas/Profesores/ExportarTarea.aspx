<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExportarTarea.aspx.vb" Inherits="Lab2Presentacion.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

         <section style="background-color:lightgray;">

        <div style="text-align:right;">
            <asp:LinkButton ID="LinkButton1" runat="server">Cerrar sesión</asp:LinkButton>

        </div>
        
        <div  style="text-align:center;">
            
            <h2>PROFESOR</h2>
            
            <h2>EXPORTAR TAREAS GENERICAS</h2>
        </div>
        </section>
        <div>
            <h5>Seleccionar asignatura a Exportar:</h5>
        </div>



        <div>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="EXPORTAR XML" />
        <asp:Button ID="Button2" runat="server" Text="EXPORTAR JSON" />
         <br />
         <br />
        <br />
         &nbsp;<asp:LinkButton ID="LinkButton2" runat="server">Menú profesor</asp:LinkButton>
             <br />
    </form>
</body>
</html>
