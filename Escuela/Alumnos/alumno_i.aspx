<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumno_i.aspx.cs" Inherits="Escuela.Alumnos.Alumno_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  
            <table>
                <tr>
                    <td>Matricula: </td>
                    <td> 
                        <asp:TextBox ID="txtMatricula" runat="server" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Matricula" runat="server"  ControlToValidate="txtMatricula"
                            ErrorMessage="La matricula es requerida" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_Matricula" runat="server" ControlToValidate="txtMatricula"
                            ValidationExpression="^[0-9]+$" ValidationGroup="vlg1" Display="Dynamic"
                            ErrorMessage="Solo se aceptan numeros enteros"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre: </td>
                    <td> 
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server"  ControlToValidate="txtNombre"
                            ErrorMessage="El nombre es requerido" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Nacimiento: </td>
                    <td> 
                        <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_FechaNacimiento" runat="server"  ControlToValidate="txtFechaNacimiento"
                            ErrorMessage="La fecha es requerida" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_Fecha" runat="server" ControlToValidate="txtFechaNacimiento"
                            Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1"
                            ErrorMessage="Formato incorrecto (dd/mm/yyyy) o (mm/dd/yyyy)" Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Semestre: </td>
                    <td> 
                        <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Semestre" runat="server"  ControlToValidate="txtSemestre"
                            ErrorMessage="El semestre es requerido" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_Semestre" runat="server" ControlToValidate="txtSemestre"
                             Type="Integer" MinimumValue="1" MaximumValue="12" ValidationGroup="vlg1" Display="Dynamic"
                            ErrorMessage="El semestre debe ser un valor entero entre 1 y 12"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>Facultad: </td>
                    <td> 
                        <asp:DropDownList ID="ddlFacultad" CssClass="lista" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_Facultad" runat="server"  ControlToValidate="ddlFacultad" Display="Dynamic"
                            ErrorMessage="La facultad es requerida" InitialValue="0" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Estado: </td>
                    <td> 
                        <asp:DropDownList ID="ddlEstado" CssClass="lista" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>                
                    </td>
                </tr>
                <tr>
                    <tr>
                    <td>Ciudad: </td>
                    <td> 
                        <asp:DropDownList ID="ddlCiudad" CssClass="lista" runat="server"></asp:DropDownList>                
                    </td>
                </tr>
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:GridView ID="grd_Alumnos" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText ="Matricula" DataField="matricula" />
            <asp:BoundField HeaderText ="Nombre" DataField="nombre" />
        </Columns>
    </asp:GridView>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#MainContent_txtFechaNacimiento").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy",
            });

            $(".lista").chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {

            $("#MainContent_txtFechaNacimiento").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy",
            });

            $(".lista").chosen();

        });

    </script>

</asp:Content>
