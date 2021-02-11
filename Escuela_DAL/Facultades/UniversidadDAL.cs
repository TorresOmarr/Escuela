using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL.Facultades
{
    public class UniversidadDAL
    {

        EscuelaEntities modelo;

        public UniversidadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Universidad> cargarUniversidades()
        {
            var Universidades = from mUniversidades in modelo.Universidad
                                select mUniversidades;

            return Universidades.ToList();
        }

    }
}
