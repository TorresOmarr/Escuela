<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_s.aspx.cs" Inherits="Escuela.Facultades.facultad_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_Facultades" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_Facultades_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/bc8e82b39024140b782f9c1bd5efaf44.png" Height="20px" Width="20px"
                         CommandName="Editar" CommandArgument='<%# Eval("ID_Facultad") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/images.png" Height="20px" Width="20px"
                         CommandName="Eliminar" CommandArgument='<%# Eval("ID_Facultad") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText ="ID" DataField = "ID_Facultad" />
            <asp:BoundField HeaderText ="Codigo" DataField = "Codigo" />
            <asp:BoundField HeaderText ="Nombre" DataField = "Nombre" />
            <asp:BoundField HeaderText ="Fecha de Creacion" DataField = "FechaCreacion" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText ="Universidad" DataField = "nombreUniversidad" />
            <asp:BoundField HeaderText ="Pais" DataField = "nombrePais" />
            <asp:BoundField HeaderText ="Estado" DataField = "nombreEstado" />
            <asp:BoundField HeaderText ="Ciudad" DataField = "nombreCiudad" />
            
            

        </Columns>
        
    </asp:GridView>
    <asp:LinkButton runat="server" OnClick="btnAgregar">Agregar Facultad</asp:LinkButton>
</asp:Content>
