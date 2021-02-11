using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL.Facultades;

namespace Escuela.Facultades
{
    public partial class facultad_s : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    grd_Facultades.DataSource = MostrarFacultadesf();
                    grd_Facultades.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void grd_Facultades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Facultades/facultad_u.aspx?pID_Facultad=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Facultades/facultad_d.aspx?pID_Facultad=" + e.CommandArgument);
            }
        }

        protected void btnAgregar(object sender, EventArgs e)
        {
            Response.Redirect("~/Facultades/facultad_i.aspx");
        }


        #endregion

        #region Metodos

        public List<object> MostrarFacultadesf()
        {
            FacultadesBLL FacuBLL = new FacultadesBLL();
            List<object> listFacultad = new List<object>();

            listFacultad = FacuBLL.MostrarFacultadesf();
            
            return listFacultad;
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