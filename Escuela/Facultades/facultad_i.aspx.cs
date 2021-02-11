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

namespace Escuela.Facultades
{
    public partial class facultad_i : TemaEscuela ,IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (sesionIniciada())
                {
                    cargarUniversidades();
                    cargarPaises();
                    cargarEstados();
                    cargarCiudades();
                    cargarTabla();
                    cargarMaterias();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(codigoinvalido())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('El código de la facultad ya existe,introduce un código diferente.')", true);
                
            }
            else
            {
                agregarFacultad();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('Facultad agregada exitosamente.')", true);
            }
            
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPais.SelectedIndex != 0)
            {
                ddlEstado.Items.Clear();
                cargarEstados();
            }
            else
            {
                ddlEstado.Items.Clear();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedIndex != 0)
            {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            }
            else
            {
                ddlCiudad.Items.Clear();
            }
        }
        #endregion

        #region Metodos
        public void agregarFacultad()
        {            
            FacultadesBLL facuBLL = new FacultadesBLL();
            Facultad facu = new Facultad();

            facu.codigo = txtCodigo.Text;
            facu.nombre = txtNombre.Text;
            facu.fechaCreacion = Convert.ToDateTime(txtFechaCreacion.Text);
            facu.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facu.Ciudad1.Estado1.Pais = int.Parse(ddlPais.SelectedValue);
            facu.Ciudad1.estado = int.Parse(ddlEstado.SelectedValue);
            facu.ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {
                MateriaFacultad materiaFacultad;
                List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();

                facuBLL.agregarFacultadPorID(facu);
                

                foreach (ListItem item in ListBoxMaterias.Items)
                {
                    if (item.Selected)
                    {
                        materiaFacultad = new MateriaFacultad();
                        materiaFacultad.materia = int.Parse(item.Value);
                        materiaFacultad.facultad = facu.ID_Facultad;
                        listMaterias.Add(materiaFacultad);
                    }
                }

                facuBLL.agregarFacultad(facu,listMaterias);
                limpiarCampos();                
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('"+ ex.Message+"')", true);
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

        public void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtFechaCreacion.Text = "";
            ddlUniversidad.SelectedIndex = 0;
        }

        public void cargarTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("codigo");
            dt.Columns.Add("nombre");

            ViewState["tablaFacultad"] = dt;
        }

        public bool codigoinvalido()
        {
            bool repetido = false;

            FacultadesBLL codigoBLL = new FacultadesBLL();
            DataTable dtCodigo = new DataTable();

            dtCodigo = codigoBLL.comprobarCodigo(txtCodigo.Text);

            if (dtCodigo.Rows.Count > 0)
            {                
                repetido = true;
            }
            return repetido;
        }

        public void cargarPaises()
        {
            PaisBLL pais = new PaisBLL();
            DataTable dtPaises = new DataTable();

            dtPaises = pais.cargarPaises();

            ddlPais.DataSource = dtPaises;
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
            CiudadBLL ciudad = new CiudadBLL();
            DataTable dtCiudades = new DataTable();

            dtCiudades = ciudad.cargarCiudadesPorEstados(int.Parse(ddlEstado.SelectedValue));

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