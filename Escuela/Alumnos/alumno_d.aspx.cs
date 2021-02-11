using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_BLL.Alumnos;
using Escuela_DAL;

namespace Escuela
{
    public partial class alumno_d : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(sesionIniciada())
                {
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarFacultades();
                    cargarAlumno(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('Alumno eliminado exitosamente')", true);
        }

        #endregion

        #region Metodos
        
        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = alumno.matricula.ToString();
            lblNombre.Text = alumno.nombre;
            lblFechaNacimiento.Text = alumno.fechaNacimiento.ToString().Substring(0, 10);
            lblSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue = alumno.facultad.ToString();

        }

        public void cargarFacultades()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=SALA-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultades";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultades = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultades);

            connection.Close();

            ddlFacultad.DataSource = dtFacultades;
            ddlFacultad.DataTextField = "Nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();
            ddlFacultad.Items.Insert(0, new ListItem("---Seleccione Facultad---", "0"));
        }


        public void eliminarAlumno()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=SALA-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_eliminarAlumno";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", int.Parse(lblMatricula.Text));
            
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
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