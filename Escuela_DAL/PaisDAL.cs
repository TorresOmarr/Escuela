using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Escuela_DAl
{
    public class PaisDAL
    {
        EscuelaEntities modelo;

        public PaisDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Pais> CargarPais()


        {

            var paises = from mPaises in modelo.Pais
                         select mPaises;

            return paises.ToList();

        }
    }
}
