using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela_DAl;

namespace Escuela_BLL
{
    public class CiudadBLL
    {
        public List<Ciudad> cargarCiudadesPorEstado(Estado estado)
        {
            CiudadDAL ciudad = new CiudadDAL();
            return ciudad.CargarCiudadesPorEstado(estado);
        }
    }
}
