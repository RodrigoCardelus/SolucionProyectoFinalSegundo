<%@ Page Language="C#"  MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="ABMJuegos.aspx.cs" Inherits="ABMJuegos" %>


 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
        .auto-style1 {
            width: 81%;
            height: 379px;
        }
        .auto-style2 {
            width: 222px;
        }
        .auto-style3 {
            width: 146px;
        }
        .auto-style5 {
            width: 146px;
            height: 37px;
        }
        .auto-style6 {
            width: 222px;
            height: 37px;
        }
        .auto-style7 {
            height: 37px;
        }
        .auto-style8 {
            width: 146px;
            height: 32px;
        }
        .auto-style10 {
            height: 32px;
        }
        .auto-style11 {
            width: 222px;
            }
        .auto-style12 {
            width: 146px;
            }
    .auto-style13 {
        width: 264%;
        height: 401px;
    }
    .auto-style17 {
        width: 35px;
    }
    .auto-style18 {
        height: 32px;
        width: 35px;
    }
    .auto-style19 {
        height: 37px;
        width: 35px;
    }
    .auto-style20 {
        width: 29px;
    }
    .auto-style21 {
        height: 32px;
        width: 29px;
    }
    .auto-style22 {
        height: 37px;
        width: 29px;
    }
        .auto-style24 {
            text-align: center;
            width: 222px;
            height: 34px;
        }
        .auto-style25 {
            width: 146px;
            height: 34px;
        }
        .auto-style26 {
            height: 34px;
        }
        .auto-style27 {
            height: 34px;
            width: 29px;
        }
        .auto-style28 {
            height: 34px;
            width: 35px;
        }
         .auto-style29 {
             margin-left: 0px;
         }
    .auto-style31 {
        width: 222px;
        text-align: left;
    }
    .auto-style32 {
        width: 146px;
        height: 48px;
        text-align: left;
    }
    .auto-style33 {
        width: 146px;
        height: 27px;
    }
    .auto-style34 {
        width: 222px;
        height: 27px;
    }
    .auto-style35 {
        height: 27px;
    }
    .auto-style36 {
        width: 29px;
        height: 27px;
    }
    .auto-style37 {
        width: 35px;
        height: 27px;
    }
    .auto-style38 {
        width: 146px;
        height: 25px;
    }
    .auto-style39 {
        width: 222px;
        height: 25px;
    }
    .auto-style40 {
        height: 25px;
    }
    .auto-style41 {
        width: 29px;
        height: 25px;
    }
    .auto-style42 {
        width: 35px;
        height: 25px;
    }
    .auto-style44 {
        text-align: left;
    }
         .auto-style45 {
             width: 222px;
             text-align: center;
         }
         .auto-style46 {
             width: 146px;
             height: 48px;
             text-align: center;
         }
    </style>

        <table class="auto-style13">
            <tr>
                <td class="auto-style25"></td>
                <td class="auto-style24">
                    <asp:Label ID="Label7" runat="server" Text="ABM Juegos"></asp:Label>
                </td>
                <td class="auto-style26">
                </td>
                <td class="auto-style27"></td>
                <td class="auto-style28"></td>
                <td class="auto-style26"></td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="Label8" runat="server" Text="Codigo"></asp:Label>
                </td>
                <td class="auto-style31">
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="auto-style29" Height="22px" Width="174px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="Label4" runat="server" Text="Dificultad"></asp:Label>
                </td>
                <td class="auto-style44">
                    <asp:TextBox ID="txtDificultad" runat="server" Height="20px" Width="180px"></asp:TextBox>
                </td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">
                    &nbsp;</td>
                <td class="auto-style31">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style46">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" style="height: 29px" />
                </td>
                <td class="auto-style45">
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td>&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                </td>
                <td class="auto-style21"></td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style33">
                    &nbsp;</td>
                <td class="auto-style34">
                    &nbsp;</td>
                <td class="auto-style35"></td>
                <td class="auto-style36"></td>
                <td class="auto-style37"></td>
                <td class="auto-style35"></td>
            </tr>
            <tr>
                <td class="auto-style38">
                    &nbsp;</td>
                <td class="auto-style39">
                    &nbsp;</td>
                <td class="auto-style40"></td>
                <td class="auto-style41"></td>
                <td class="auto-style42"></td>
                <td class="auto-style40"></td>
            </tr>
            <tr>
                <td class="auto-style12">
                    &nbsp;</td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7"></td>
                <td class="auto-style22"></td>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style17">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
  
    </asp:Content>

