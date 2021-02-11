using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela_DAl;

namespace Escuela_BLL
{
    public class Universidad_BLL
    {

        public List<Universidad> cargarUniversidades()
        {
            UniversidadDAl universidad = new UniversidadDAl();
            return universidad.cargarUniversidades();
        }
    }
}
