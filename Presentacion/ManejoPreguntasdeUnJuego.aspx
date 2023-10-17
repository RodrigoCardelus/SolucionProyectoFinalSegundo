<%@ Page Language="C#"  MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ManejoPreguntasdeUnJuego.aspx.cs" Inherits="ManejoPreguntasdeUnJuego" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
        .auto-style1 {
            width: 97%;
            height: 473px;
        }
        .auto-style2 {
            width: 1007px;
            height: 23px;
        }
        .auto-style3 {
            text-align: center;
            width: 394px;
        }
        .auto-style4 {
            width: 251px;
            text-align: left;
        }
        .auto-style6 {
             width: 156px;
         }
        .auto-style8 {
             width: 156px;
             text-align: center;
         }
        .auto-style9 {
            width: 156px;
            text-align: center;
            height: 40px;
        }
        .auto-style10 {
            width: 169px;
            height: 40px;
             text-align: left;
         }
        .auto-style11 {
            text-align: left;
            width: 251px;
            height: 40px;
        }
        .auto-style12 {
            height: 40px;
        }
        .auto-style13 {
            width: 156px;
            text-align: center;
            height: 35px;
        }
        .auto-style14 {
            width: 169px;
            height: 35px;
             text-align: left;
         }
        .auto-style15 {
            width: 251px;
            text-align: left;
            height: 35px;
        }
        .auto-style16 {
            height: 35px;
        }
        .auto-style17 {
            width: 156px;
            text-align: center;
            height: 37px;
        }
        .auto-style18 {
            width: 169px;
            height: 37px;
             text-align: left;
         }
        .auto-style19 {
            width: 251px;
            text-align: left;
            height: 37px;
        }
        .auto-style20 {
            height: 37px;
        }
        .auto-style21 {
            width: 156px;
            height: 34px;
        }
        .auto-style23 {
            width: 251px;
            text-align: left;
            height: 34px;
        }
        .auto-style24 {
            height: 34px;
        }
        .auto-style25 {
            width: 93px;
        }
        .auto-style26 {
            height: 40px;
            width: 93px;
        }
        .auto-style27 {
            height: 35px;
            width: 93px;
        }
        .auto-style28 {
            height: 37px;
            width: 93px;
        }
        .auto-style29 {
            height: 34px;
            width: 93px;
        }
         .auto-style30 {
             text-align: left;
             width: 169px;
         }
         .auto-style32 {
             width: 156px;
             height: 48px;
             text-align: center;
         }
         .auto-style33 {
             width: 251px;
             height: 48px;
             text-align: center;
         }
         .auto-style34 {
             width: 251px;
         }
         .auto-style35 {
             text-align: center;
             height: 23px;
             width: 845px;
         }
    </style>


        <table>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style33">
                    <asp:Label ID="Label1" runat="server" Text="Manejo Preguntas de un Juego"></asp:Label>
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="Label2" runat="server" Text="Codigo"></asp:Label>
                </td>
                <td class="auto-style30">
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label3" runat="server" Text="UsuarioLogueo"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtUsuarioLogueo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11"></td>
                <td class="auto-style26"></td>
                <td class="auto-style12"></td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="Label4" runat="server" Text="Dificultad"></asp:Label>
                </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtDificultad" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style15"></td>
                <td class="auto-style27"></td>
                <td class="auto-style16"></td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style17">
                    &nbsp;</td>
                <td class="auto-style18">
                    &nbsp;</td>
                <td class="auto-style19">
                    &nbsp;</td>
                <td class="auto-style28"></td>
                <td class="auto-style20"></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style23"></td>
                <td class="auto-style29">
                    &nbsp;</td>
                <td class="auto-style24"></td>
                <td class="auto-style24"></td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="btnAgregar" runat="server" Text="AgregarPreguntas" OnClick="btnAgregar_Click" Height="26px" Width="161px" />
                </td>
                <td class="auto-style30">
                    <asp:TextBox ID="txtCodigoP" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style33">
                    <asp:GridView ID="GVPreguntas" runat="server" AutoGenerateColumns="False"   OnSelectedIndexChanged="GVPreguntas_SelectedIndexChanged1"> 
                        <Columns>
                            <asp:BoundField DataField="CodigoP" HeaderText="CodigoP" />
                            <asp:BoundField DataField="Texto" HeaderText="Texto" />
                            <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                            <asp:CommandField HeaderText="Eliminar" ShowCancelButton="False" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                </td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style33">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div class="auto-style35">
    
    </div>


  </asp:Content>

