<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_i.aspx.cs" Inherits="Escuela.Facultades.facultad_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


         
            <table>                
                <tr>
                    <td>Codigo: </td>
                    <td> 
                        <asp:TextBox ID="txtCodigo" runat="server" MaxLength="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Codigo" runat="server" ControlToValidate="txtCodigo"
                            ErrorMessage="Este campo es necesario" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCodigo"
                             ValidationExpression="^[A-Z]{4}[\d]{2}$"
                             ErrorMessage="Formato incorrecto, deben ser 4 letras y 2 numeros (AAAA00)" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre: </td>
                    <td> 
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ControlToValidate="txtNombre"
                            ErrorMessage="Este campo es necesario" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Creacion: </td>
                    <td> 
                        <asp:TextBox ID="txtFechaCreacion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_FechaCreacion" runat="server" ControlToValidate="txtFechaCreacion"
                            ErrorMessage="Este campo es necesario" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_Fecha" runat="server" ControlToValidate="txtFechaCreacion"
                             Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1" Display="Dynamic"
                            ErrorMessage="Formato incorrecto, debe ser [dd/mm/yyyy]"></asp:CompareValidator>
                    </td>
                </tr>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <tr>
                    <td>Universidad: </td>
                    <td> 
                        <asp:DropDownList ID="ddlUniversidad" runat="server" CssClass="lista"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_Universidad" runat="server" ControlToValidate="ddlUniversidad"
                            ErrorMessage="Este campo es necesario" InitialValue="0"  ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                <td>Pais: </td>
                    <td> 
                        <asp:DropDownList ID="ddlPais"  runat="server" CssClass="lista" AutoPostBack="true" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_Pais" runat="server" ControlToValidate="ddlPais"
                            ErrorMessage="Este campo es necesario" InitialValue="0"  ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>           
                    <td>Estado: </td>
                    <td> 
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="lista" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_Estado" runat="server" ControlToValidate="ddlEstado"
                            ErrorMessage="Este campo es necesario" InitialValue="0"  ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>           
                    <td>Ciudad: </td>
                    <td> 
                        <asp:DropDownList ID="ddlCiudad"  runat="server" CssClass="lista"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_Ciudad" runat="server" ControlToValidate="ddlCiudad"
                            ErrorMessage="Este campo es necesario" InitialValue="0"  ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                </ContentTemplate>
    </asp:UpdatePanel>
                <tr>
                <td>Materias: </td>
                    <td>
                        <asp:ListBox ID="ListBoxMaterias" SelectionMode="Multiple" CssClass="lista" Width="150px" runat="server"></asp:ListBox>
                    </td>
                </tr>                
                <tr>
                    <td></td>
                    <td> 
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="vlg1"/>
                    </td>
                </tr>
            </table>
        

    <asp:GridView ID="grd_Facultades" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText ="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText ="Nombre" DataField="Nombre" />
        </Columns>
    </asp:GridView>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#MainContent_txtFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy",
            });

            $(".lista").chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {

            $("#MainContent_txtFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy",
            });

            $(".lista").chosen();

        });
    </script>

</asp:Content>
