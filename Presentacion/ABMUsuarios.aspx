<%@ Page Language="C#"  MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ABMUsuarios.aspx.cs" Inherits="ABMUsuarios" %>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        }
        .auto-style5 {
            font-size: large;
        }
        .auto-style7 {
            height: 41px;
            text-align: center;
        }
        .auto-style8 {
            height: 41px;
            text-align: center;
            width: 137px;
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
            text-align: center;
            width: 159px;
        }
        .auto-style12 {
            text-align: center;
            width: 159px;
        }
        .auto-style13 {
            width: 159px;
        }
        .auto-style14 {
            text-align: left;
        }
        .auto-style15 {
            width: 137px;
            height: 39px;
        }
        .auto-style16 {
            width: 159px;
            height: 39px;
        }
        .auto-style17 {
            height: 39px;
        }
        .auto-style18 {
            width: 72px;
            height: 39px;
        }
    .auto-style19 {
        width: 96%;
        height: 405px;
    }
    </style>

        <table class="auto-style19">
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style11"></td>
                <td class="auto-style7">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style5" Text="ABM Usuarios"></asp:Label>
                </td>
                <td class="auto-style3"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label2" runat="server" Text="UsuarioLogueo"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtUsuarioLogueo" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label3" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label4" runat="server" Text="NombreCompleto"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtNombreCompleto" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                </td>
                <td class="auto-style12">
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                </td>
                <td class="auto-style12">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style16"></td>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
                <td class="auto-style17"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>


    </asp:Content>

