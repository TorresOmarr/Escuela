using System;
using System.Data;
using System.Data.SqlClient;
using Escuela_DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL
{
    public class Facultad_BLL
    {
        public List<Facultad> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }
    }
}
