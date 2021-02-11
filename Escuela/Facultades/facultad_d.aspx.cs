using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL.Facultades;
using Escuela_DAL;
using Escuela_DAL.Facultades;
using Escuela_BLL;

namespace Escuela.Facultades
{
    public partial class facultad_d : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int ID_Facultad = int.Parse(Request.QueryString["pID_Facultad"]);

                    cargarUniversidades();
                    cargarFacultad(ID_Facultad);
                    cargarPaises();
                    cargarCiudades();
                    cargarEstados();                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarMaterias();
            eliminarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('Facultad eliminada exitosamente.')", true);
        }

        #endregion

        #region Metodos
        public void cargarFacultad(int ID_Facultad)
        {
            FacultadesBLL facuBLL = new FacultadesBLL();
            Facultad facultad = new Facultad();

            facultad = facuBLL.cargarFacultad(ID_Facultad);


            lblID_Facultad.Text = facultad.ID_Facultad.ToString();
            lblCodigo.Text = facultad.codigo.ToString();
            lblNombre.Text = facultad.nombre.ToString();
            lblFechaCreacion.Text = facultad.fechaCreacion.ToString().Substring(0, 10);
            ddlUniversidad.SelectedValue = facultad.universidad.ToString();

            cargarPaises();
            ddlPais.SelectedValue = facultad.Ciudad1.Estado1.Pais.ToString();

            cargarEstados();
            ddlEstado.SelectedValue = facultad.Ciudad1.estado.ToString();

            cargarCiudades();
            ddlCiudad.SelectedValue = facultad.ciudad.ToString();

            cargarMaterias();
            List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();
            listMaterias = facultad.MateriaFacultad.ToList();

            foreach (MateriaFacultad materiaFacu in listMaterias)
            {
                ListBoxMaterias.Items.FindByValue(materiaFacu.materia.ToString()).Selected = true;
            }
        }

        public void cargarUniversidades()
        {
            UniversidadBLL uniBLL = new UniversidadBLL();
            List<Universidad> listUniversidad = new List<Universidad>();

            listUniversidad = uniBLL.cargarUniversidades();

            ddlUniversidad.DataSource = listUniversidad;
            ddlUniversidad.DataTextField = "Nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();
            ddlUniversidad.Items.Insert(0, new ListItem("---Seleccione Universidad--", "0"));

        }
        public void eliminarFacultad()
        {
            FacultadesBLL facuBLL = new FacultadesBLL();
            MateriasFacultadBLL matFacu = new MateriasFacultadBLL();

            int ID_Facultad = int.Parse(lblID_Facultad.Text);
            
            facuBLL.eliminarFacultad(ID_Facultad);                    
        }

        public void eliminarMaterias()
        {
            MateriasFacultadBLL matFacu = new MateriasFacultadBLL();
            int ID_Facultad = int.Parse(lblID_Facultad.Text);
            matFacu.eliminarMaterias(ID_Facultad);
        }
        public void cargarPaises()
        {
            PaisBLL paisBLL = new PaisBLL();
            DataTable dtPais = new DataTable();

            dtPais = paisBLL.cargarPaises();

            ddlPais.DataSource = dtPais;
            ddlPais.DataTextField = "Nombre";
            ddlPais.DataValueField = "ID_Pais";
            ddlPais.DataBind();
            ddlPais.Items.Insert(0, new ListItem("---Seleccione Pais---", "0"));
        }

        public void cargarEstados()
        {

            EstadoBLL estado = new EstadoBLL();
            DataTable dtEstados = new DataTable();

            dtEstados = estado.cargarEstados(int.Parse(ddlPais.SelectedValue));

            ddlEstado.DataSource = dtEstados;
            ddlEstado.DataTextField = "Nombre";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("---Seleccione Estado---", "0"));
        }

        public void cargarCiudades()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=SALA-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarCiudad";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCiudades = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCiudades);

            connection.Close();

            ddlCiudad.DataSource = dtCiudades;
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("---Seleccione Ciudad---", "0"));
        }

        public void cargarMaterias()
        {
            MateriaFBLL materia = new MateriaFBLL();
            List<Materia> listMaterias = new List<Materia>();

            listMaterias = materia.cargarMaterias();

            ListBoxMaterias.DataSource = listMaterias;
            ListBoxMaterias.DataTextField = "nombre";
            ListBoxMaterias.DataValueField = "ID_Materia";
            ListBoxMaterias.DataBind();
        }

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        
    }
}