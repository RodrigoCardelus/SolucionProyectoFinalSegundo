<%@ Page Language="C#"  MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ABMCategorias.aspx.cs" Inherits="ABMCategorias" %>



   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <style type="text/css">
    <style type="text/css">
        .auto-style1 {
            width: 82%;
            height: 375px;
        }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            text-align: center;
            width: 203px;
        }
        .auto-style5 {
            height: 37px;
            text-align: left;
            width: 203px;
        }
        .auto-style6 {
            width: 236px;
        }
        .auto-style8 {
            width: 124px;
        }
        .auto-style9 {
            height: 37px;
            width: 124px;
            text-align: left;
        }
        .auto-style10 {
            width: 203px;
        }
        .auto-style11 {
            width: 124px;
            text-align: center;
        }
        .auto-style12 {
            width: 124px;
            height: 36px;
            text-align: center;
        }
        .auto-style13 {
            width: 236px;
            height: 36px;
            text-align: center;
        }
        .auto-style14 {
            width: 203px;
            height: 36px;
        }
        .auto-style15 {
            height: 36px;
        }
        .auto-style16 {
            text-align: left;
        }
        .auto-style18 {
            width: 236px;
            text-align: center;
        }
        .auto-style19 {
            width: 124px;
            height: 34px;
        }
        .auto-style20 {
            width: 236px;
            height: 34px;
        }
        .auto-style21 {
            width: 203px;
            height: 34px;
        }
        .auto-style22 {
            height: 34px;
        }
         .auto-style23 {
             height: 37px;
               text-align: left;
           }
         .auto-style24 {
             width: 236px;
             text-align: left;
         }
         .auto-style25 {
             width: 124px;
             text-align: left;
         }
    .auto-style26 {
        width: 74%;
        height: 416px;
    }
           .auto-style27 {
               text-align: left;
               width: 203px;
           }
    </style>
        <table class="auto-style26">
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="ABM Categorias"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label2" runat="server" Text="CodigoC"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCodigoC" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style23">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" style="height: 29px" />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style25">
                    <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style20"></td>
                <td class="auto-style21"></td>
                <td class="auto-style22"></td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                </td>
                <td class="auto-style13">
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td class="auto-style14"></td>
                <td class="auto-style15"></td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                </td>
                <td class="auto-style18">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
   
   </asp:Content>