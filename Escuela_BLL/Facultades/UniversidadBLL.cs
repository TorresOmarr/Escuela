using System;
using System.Data;
using Escuela_DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL.Facultades;

namespace Escuela_BLL.Facultades
{
    public class UniversidadBLL
    {
        public List<Universidad> cargarUniversidades()
        {
            UniversidadDAL universidad = new UniversidadDAL();
            return universidad.cargarUniversidades();
        }



    }
}
