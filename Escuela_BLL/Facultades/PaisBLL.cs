using System;
using System.Data;
using Escuela_DAL.Facultades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL.Facultades
{
    public class PaisBLL
    {
        public DataTable cargarPaises()
        {
            PaisDAL pais = new PaisDAL();
            return pais.cargarPaises();
        }
    }
}
