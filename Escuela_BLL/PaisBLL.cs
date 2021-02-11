using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela_DAl;

namespace Escuela_BLL
{
    public class PaisBLL

    {
        public List<Pais> cargarPais()
        {
            PaisDAL pais = new PaisDAL();
            return pais.CargarPais();
        }
    }
}
