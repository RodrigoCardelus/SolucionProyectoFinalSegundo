<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 95%;
            height: 539px;
        }
        .auto-style3 {
            width: 359px;
            text-align: center;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style7 {
            width: 359px;
            font-size: medium;
        }
        .auto-style8 {
            font-size: large;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style12 {
            text-align: center;
            height: 30px;
        }
        .auto-style13 {
            height: 30px;
        }
        .auto-style14 {
            width: 359px;
            text-align: left;
            height: 30px;
        }
        .auto-style15 {
            width: 385px;
        }
        .auto-style16 {
            height: 30px;
            width: 385px;
        }
        .auto-style17 {
            width: 385px;
            text-align: left;
        }
        .auto-style18 {
            width: 359px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style8" Text="Default"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">a) Se desplegaran todas las Jugadas Realizadas.</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:GridView ID="GvJugadas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="199px" Width="419px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td id="GvJugadas" class="auto-style17">
                    <a href="Default.aspx">Default.aspx</a></td>
                <td>&nbsp;</td>
                <td>
                    <asp:GridView ID="GvJuegos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="99px" Width="241px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="unUsuario.UsuarioLog" HeaderText="UsuarioLog" />
                            <asp:BoundField DataField="Dificultad" HeaderText="Dificultad" />
                            <asp:BoundField DataField="Fechac" HeaderText="Fechac" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td id="GvJugadas" class="auto-style17">
                    Filtros:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">1) Filtra las jugadas por Nombre de Jugador</td>
                <td class="auto-style4">&nbsp;</td>
                <td id="GvJugadas" class="auto-style18">
                    <asp:TextBox ID="txtUsuarioLogueo" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnFiltrarNombre" runat="server" OnClick="btnFiltrarNombre_Click" Text="Filtrar" Width="71px" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">2) Fitra Por Tipo de Dificultad de Juego Realizado.</td>
                <td class="auto-style4">&nbsp;</td>
                <td id="GvJugadas" class="auto-style18">
                    <asp:TextBox ID="txtDificultad" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnFiltrarDificultad" runat="server" Height="26px" OnClick="btnFiltrarDificultad_Click" Text="Filtrar Dificultad" Width="132px" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">3) Se ordena por dificultad y dentro de esta por puntaje</td>
                <td class="auto-style12"></td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtPuntaje" runat="server" Height="19px" Width="151px"></asp:TextBox>
&nbsp;<asp:Button ID="btnFiltroDificultadPuntaje" runat="server" Height="25px" OnClick="btnFiltroDificultadPuntaje_Click" Text="Ordenar" Width="95px" />
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style12"></td>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style16">b) La Pagina debe tener acceso directo al Logueo al Sistema</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style14">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style9" NavigateUrl="~/Logueo.aspx">Logueo</asp:HyperLink>
                </td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">c) La Pagina debera tener un acceso directo a la Pagina de Jugar.</td>
                <td class="auto-style13"></td>
                <td class="auto-style13">
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style9" NavigateUrl="~/Jugar.aspx">Jugar</asp:HyperLink>
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
