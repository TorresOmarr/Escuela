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
    
    public partial class facultad_u : TemaEscuela, IAcceso
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
                    cargarPaises();
                    cargarEstados();
                    cargarCiudades();
                    cargarFacultad(ID_Facultad);                   
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (codigoinvalido())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('El código de la facultad ya existe,introduce un código diferente')", true);

            }
            else
            {
                modificarFacultad();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert ('Facultad editada exitosamente.')", true);
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
        public void cargarFacultad(int ID_Facultad)
        {
            FacultadesBLL facuBLL = new FacultadesBLL();
            Facultad facultad = new Facultad();

            facultad = facuBLL.cargarFacultad(ID_Facultad);

            
                lblID_Facultad.Text = facultad.ID_Facultad.ToString();
                txtCodigo.Text = facultad.codigo.ToString();
                txtNombre.Text = facultad.nombre.ToString();
                txtFechaCreacion.Text = facultad.fechaCreacion.ToString().Substring(0, 10);
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

        public void modificarFacultad()
        {
            FacultadesBLL facuBLL = new FacultadesBLL();
            Facultad facu = new Facultad();

            facu.ID_Facultad = int.Parse(lblID_Facultad.Text);       
            facu.codigo = txtCodigo.Text;
            facu.nombre = txtNombre.Text;
            facu.fechaCreacion = Convert.ToDateTime(txtFechaCreacion.Text);
            facu.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facu.Ciudad1.Estado1.Pais = int.Parse(ddlPais.SelectedValue);
            facu.Ciudad1.estado = int.Parse(ddlEstado.SelectedValue);
            facu.ciudad = int.Parse(ddlCiudad.SelectedValue);

            MateriaFacultad materiaFacu;
            List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();

            foreach (ListItem item in ListBoxMaterias.Items)
            {
                if (item.Selected)
                {
                    materiaFacu = new MateriaFacultad();
                    materiaFacu.materia = int.Parse(item.Value);
                    materiaFacu.facultad = facu.ID_Facultad;
                    listMaterias.Add(materiaFacu);
                }
            }
            facuBLL.modificarFacultad(facu, listMaterias);                
            
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