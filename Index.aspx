<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PropuestaLegislativaXML.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TAREA 1 ALEJANDRO RIVERA</title>
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            width: 368px;
        }
        .auto-style3 {
            margin-left: 0px;
        }
        .auto-style4 {
            width: 359px;
        }
        .auto-style5 {
            width: 369px;
            height: 30px;
        }
        .auto-style6 {
            width: 359px;
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="color:blue">UNIVERSIDAD ESTATAL A DISTANCIA</h1>
            <h2 style="color:blue">Estudiante: Alejandro Rivera Herrera</h2>
            <h3 style="color:blue">Propuesta Legislativa</h3>

            <table style="width: 100%;">
                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Tipo de documento: </p>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLTipoId" runat="server" CssClass="auto-style3" Height="16px" Width="200px">
                            <asp:ListItem Selected="True" Value="CedulaIdentidad"> Cédula de Identidad </asp:ListItem>
                            <asp:ListItem Value="CedulaResidencia"> Cédula de Residencia </asp:ListItem>
                            </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Número de Identidad:</p>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TxtIdentificacion" runat="server" MinLength="10" MaxLength="11"  Width="193px"></asp:TextBox>
                        Ejemplo: 0111111111 
                    </td>
                    
                </tr>

                <tr>
                    <td class="auto-style6">
                        <p class="auto-style2">Nombre: </p>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TxtNombre" runat="server" Width="193px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Primer Apellido: </p>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtApellido1" runat="server" Width="193px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Segundo Apellido: </p>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtApellido2" runat="server" Width="193px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Teléfono: </p>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtTelefono" runat="server" MinLength="8" MaxLength="8" Width="193px"></asp:TextBox>
                        Ejemplo: 55555555
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Correo Electrónico: </p>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCorreo" runat="server" Width="193px"></asp:TextBox>
                        

                       
                        &nbsp;Ejemplo: usuario@dominio.com<br />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style4">
                        <p class="auto-style2">Provincia: </p>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLProvincia" runat="server" Height="19px" Width="200px" OnSelectedIndexChanged="DDLProvincia_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Selected="True" Value="SanJose"> San José </asp:ListItem>
                            <asp:ListItem Value="Alajuela"> Alajuela </asp:ListItem>
                            <asp:ListItem Value="Heredia"> Heredia </asp:ListItem>
                            <asp:ListItem Value="Cartago"> Cartago </asp:ListItem>
                            <asp:ListItem Value="Guanacaste"> Guanacaste </asp:ListItem>
                            <asp:ListItem Value="Puntarenas"> Puntarenas </asp:ListItem>
                            <asp:ListItem Value="Limon"> Limón </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style6">
                        <p class="auto-style2">Cantón: </p>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DDLCanton" runat="server" Height="16px" Width="200px">
                            
                        </asp:DropDownList>
                    </td>
                </tr>

                  <tr>
                    <td class="auto-style6">
                        <p class="auto-style2">Propuesta: </p>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TxtPropuesta" runat="server" Width="498px" Height="100px" MinLength="50" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                       La propuesta debe tener entre 50 y 200 carácteres<br />
                    </td>
                </tr>

            </table>

        </div>
        <div>
            <table>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="LblMensaje" runat="server" Text="" ForeColor="BlueViolet"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnLimpiar" runat="server" Text=" Limpiar" OnClick="BtnLimpiar_Click" />
                    </td>
                </tr>
            </table>           
        </div>
        <div>
            <asp:Label ID="LblErrores" runat="server" Text="" ForeColor="Red" Font-Size="XXLarge"></asp:Label>
        </div>
        
    </form>
</body>
</html>
