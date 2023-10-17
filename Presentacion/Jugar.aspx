<%@ Page Language="C#"  MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="Jugar.aspx.cs" Inherits="Jugar" %>

                                                                                                                        
  
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 72%;
            height: 423px;
        }
        .auto-style2 {
            height: 41px;
        }
        .auto-style3 {
            height: 41px;
            width: 72px;
        }
        .auto-style4 {
            width: 72px;
            font-size: medium;
        }
        .auto-style5 {
            font-size: large;
        }
        .auto-style7 {
            height: 41px;
            text-align: center;
        }
        .auto-style9 {
            text-align: center;
            width: 137px;
        }
        .auto-style10 {
            width: 137px;
        }
        .auto-style11 {
            height: 41px;
            width: 159px;
        }
        .auto-style12 {
            text-align: center;
            width: 159px;
        }
        .auto-style14 {
            text-align: left;
        }
        .auto-style15 {
            width: 137px;
            height: 39px;
        }
        .auto-style20 {
            font-size: small;
        }
        .auto-style21 {
            width: 125%;
            height: 443px;
        }
        .auto-style22 {
            height: 41px;
        }
        .auto-style23 {
            height: 41px;
            text-align: left;
        }
        .auto-style24 {
            width: 137px;
            height: 41px;
        }
        .auto-style25 {
            text-align: center;
            height: 41px;
            width: 137px;
        }
        .auto-style26 {
            height: 41px;
            text-align: left;
            width: 137px;
        }
    </style>
        <table class="auto-style21">
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style24"></td>
                <td class="auto-style11">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style4" Text="Jugar"></asp:Label>
                </td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label2" runat="server" Text="Codigo"></asp:Label>
                </td>
                <td class="auto-style25">
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td class="auto-style12"></td>
                <td class="auto-style12"></td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label3" runat="server" Text="UsuarioLogueo"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtUsuarioLogueo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style15">
                    &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:Label ID="Label4" runat="server" Text="Dificultad"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:TextBox ID="txtDificultad" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    </td>
                <td class="auto-style22"></td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style22"></td>
                <td class="auto-style24">
                    <asp:Button ID="btnJugar" runat="server" Text="Jugar" OnClick="btnJugar_Click" Height="31px" Width="110px" />
                </td>
                <td class="auto-style7">
                </td>
                <td class="auto-style22"></td>
                <td class="auto-style22"></td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:Label ID="Label5" runat="server" Text="Pregunta: "></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:Label ID="lblPregunta" runat="server"></asp:Label>
                </td>
                <td class="auto-style7">
                    </td>
                <td class="auto-style22"></td>
                <td class="auto-style22"></td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Respuesta:  "></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:RadioButtonList ID="rdbListRespuestas" runat="server" OnSelectedIndexChanged="rdbListRespuestas_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style23">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="btnSiguiente" runat="server" Height="33px" OnClick="btnSiguiente_Click" Text="Siguiente" Width="117px" />
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="lblError" runat="server" CssClass="auto-style20"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    

    </asp:Content>

