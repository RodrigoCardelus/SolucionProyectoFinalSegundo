<%@ Page Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ListadoSinAsignacion.aspx.cs" Inherits="ListadoSinAsignacion" %>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
        .auto-style4 {
            text-align: center;
            width: 108px;
        }
        .auto-style5 {
            width: 187px;
            text-align: center;
        }
        .auto-style7 {
            width: 187px;
        }
        .auto-style8 {
            width: 947px;
            height: 745px;
        }
        .auto-style9 {
            width: 108px;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style12 {
            width: 272px;
            text-align: center;
        }
        .auto-style13 {
            width: 272px;
        }
         .auto-style14 {
             width: 272px;
             height: 26px;
         }
         .auto-style15 {
             width: 187px;
             height: 26px;
         }
         .auto-style16 {
             width: 108px;
             height: 26px;
         }
         .auto-style17 {
             height: 26px;
         }
    </style>


        <table class="auto-style8">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label1" runat="server" Text="Listado Sin Asignacion"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">1) Listado Juegos Nunca Usados</td>
                <td class="auto-style5">
                    <asp:GridView ID="GvJuegosNuncaUsados" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="unUsuario.UsuarioLog" HeaderText="UsuarioLog" />
                            <asp:BoundField DataField="Dificultad" HeaderText="Dificultad" />
                            <asp:BoundField DataField="FechaC" HeaderText="FechaC" />
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
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">2) Listado Preguntas Nunca Usadas</td>
                <td class="auto-style7">
                    <asp:GridView ID="GvPreguntasNuncaUsadas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CodigoP" HeaderText="CodigoP" />
                            <asp:BoundField DataField="unaCategoria.CodigoC" HeaderText="CodigoC" />
                            <asp:BoundField DataField="Texto" HeaderText="Texto" />
                            <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
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
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14"></td>
                <td class="auto-style15"></td>
                <td class="auto-style16"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style13">3) Listado Juegos Vacios</td>
                <td class="auto-style5">
                    <asp:GridView ID="GvListadoJuegosVacios" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="136px" Width="294px">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="unUsuario.UsuarioLog" HeaderText="UsuarioLog" />
                            <asp:BoundField DataField="Dificultad" HeaderText="Dificultad" />
                            <asp:BoundField DataField="FechaC" HeaderText="FechaC" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </asp:Content>
