<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 71%;
            height: 328px;
        }
        .auto-style9 {
            width: 136px;
            text-align: center;
        }
        .auto-style10 {
            width: 136px;
        }
        .auto-style11 {
            width: 188px;
            text-align: center;
        }
        .auto-style12 {
            width: 188px;
        }
        .auto-style14 {
            width: 188px;
            height: 40px;
        }
        .auto-style15 {
            width: 136px;
            height: 40px;
        }
        .auto-style18 {
            width: 124px;
        }
        .auto-style19 {
            width: 124px;
            height: 40px;
        }
        .auto-style20 {
            width: 167px;
            text-align: center;
        }
        .auto-style21 {
            width: 167px;
            height: 40px;
        }
        .auto-style22 {
            width: 167px;
        }
        .auto-style23 {
            width: 1052px;
            height: 26px;
        }
    </style>
</head>
<body style="width: 1053px; height: 353px">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style20">
                    <asp:Label ID="Label1" runat="server" Text="Logueo"></asp:Label>
                </td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label2" runat="server" Text="UsuarioLogueo"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtUsuarioLogueo" runat="server" Height="20px" Width="174px"></asp:TextBox>
                </td>
                <td class="auto-style9">
                    <asp:Button ID="btnLogueo" runat="server" OnClick="btnLogueo_Click" Text="Logueo" />
                </td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label3" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtContraseña" runat="server" Height="20px" Width="174px" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style14"></td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style21"></td>
                <td class="auto-style21"></td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
        </table>
    <div class="auto-style23">
    
    </div>
    </form>
</body>
</html>
