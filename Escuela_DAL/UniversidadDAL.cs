using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAl
{
   public class UniversidadDAl
    {
        EscuelaEntities modelo;
        public UniversidadDAl()
        {
            modelo = new EscuelaEntities();
        }
        public List<Universidad> cargarUniversidades()
        {
            var universidad = from muniversidad in modelo.Universidad
                              select muniversidad;
           

            return universidad.ToList();
        }
    }
}
