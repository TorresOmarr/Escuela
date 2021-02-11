using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Escuela_DAl
{
    public class CiudadDAL
    {
        EscuelaEntities modelo;

        public CiudadDAL() { 
            modelo = new EscuelaEntities(); 
        }
            
        public List<Ciudad> CargarCiudadesPorEstado(Estado estado)
        {
            var ciudades = from mCiudades in modelo.Ciudad
                           where mCiudades.estado == estado.ID_Estado
                           select mCiudades;

            

            return ciudades.ToList();

        }

    }
}
