<%@ Page Language="C#"  MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="AltaPreguntas.aspx.cs" Inherits="AltaPreguntas" %>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table class="auto-style5">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="Label1" runat="server" Text="Alta Preguntas"></asp:Label>
                </td>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label2" runat="server" Text="CodigoP"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtCodigoP" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label3" runat="server" Text="CodigoC"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtCodigoC" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label4" runat="server" Text="Texto"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtTexto" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label5" runat="server" Text="Puntaje"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtPuntaje" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style26"></td>
                <td class="auto-style4"></td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style21"></td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label6" runat="server" Text="ListadoRespuestas"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:GridView ID="GvRespuestas" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CodigoInterno" HeaderText="CodigoInterno" />
                            <asp:BoundField DataField="TextoR" HeaderText="TextoR" />
                            <asp:BoundField DataField="Resultado" HeaderText="Resultado" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style15">
                    &nbsp;</td>
                <td class="auto-style16"></td>
                <td class="auto-style4"></td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" style="height: 29px" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style25">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style4 {
        width: 32px;
    }
    .auto-style5 {
        width: 59%;
        height: 48px;
    }
        .auto-style6 {
            text-align: left;
        }
        .auto-style7 {
            width: 32px;
            text-align: left;
        }
        .auto-style8 {
            width: 32px;
            text-align: center;
        }
    </style>
</asp:Content>


