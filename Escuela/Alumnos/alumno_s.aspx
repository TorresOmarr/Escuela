<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumno_s.aspx.cs" Inherits="Escuela.Alumnos.Alumno_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grd_Alumnos" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_Alumnos_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/bc8e82b39024140b782f9c1bd5efaf44.png" Height="20px" Width="20px"
                         CommandName="Editar" CommandArgument='<%# Eval("Matricula") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/images.png" Height="20px" Width="20px"
                         CommandName="Eliminar" CommandArgument='<%# Eval("Matricula") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText ="Matricula" DataField = "Matricula" />
            <asp:BoundField HeaderText ="Nombre" DataField = "Nombre" />
            <asp:BoundField HeaderText ="Fecha de Nacimiento" DataField = "FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText ="Semestre" DataField = "Semestre" />
            <asp:BoundField HeaderText ="Facultad" DataField = "nombreFacultad" />
            <asp:BoundField HeaderText ="Ciudad" DataField = "nombreCiudad" />

        </Columns>        
    </asp:GridView>
  
    <script type="text/javascript">

        $(document).ready(function () {

            $.ajax({
                type: "GET",
                url: '<%= ResolveUrl("~/ServicioWeb/Controllers/FacultadController.cs/consultaFacultad")%>',                
                success: function (data) {
                    console.log("¡Llamada de AJAX exitosa!");
                    console.log(data);
                },

                error: function (e) {
                    console.log("Llamada con error");
                    console.log(e);
                },

            });

        });

    </script>

</asp:Content>
