<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_d.aspx.cs" Inherits="Escuela.Facultades.facultad_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>

        <tr>
            <td>ID: </td>
            <td> 
                <asp:Label ID="lblID_Facultad" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Codigo: </td>
            <td> 
                <asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Nombre: </td>
            <td> 
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Fecha de Creacion: </td>
            <td> 
                <asp:Label ID="lblFechaCreacion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Universidad: </td>
            <td> 
                <asp:DropDownList ID="ddlUniversidad" runat="server" CssClass="lista" Enabled="false" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td>Pais: </td>
            <td> 
                <asp:DropDownList ID="ddlPais"  runat="server" CssClass="lista" Enabled="false"></asp:DropDownList>                
            </td>
        </tr>
        <tr>           
            <td>Estado: </td>
            <td> 
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="lista"  Enabled="false"></asp:DropDownList>                
            </td>
        </tr>
        <tr>           
            <td>Ciudad: </td>
            <td> 
                <asp:DropDownList ID="ddlCiudad"  runat="server" CssClass="lista" Enabled="false"></asp:DropDownList>                
            </td>
        </tr>
        <tr>
            <td></td>
                <td>
                    <asp:ListBox ID="ListBoxMaterias" SelectionMode="Multiple" CssClass="lista" Width="150px" runat="server" Visible="false"></asp:ListBox>
                </td>
        </tr>
        <tr>
            <td></td>
            <td> 
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
            </td>
        </tr>

    </table>

    <script type="text/javascript">

        $(document).ready(function () {
                $(".lista").chosen();
        });

    </script>


</asp:Content>
