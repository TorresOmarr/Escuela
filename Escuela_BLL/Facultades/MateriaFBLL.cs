using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using Escuela_DAL.Facultades;

namespace Escuela_BLL.Facultades
{
    public class MateriaFBLL
    {
        public List<Materia> cargarMaterias()
        {
            MateriaFDAL materias = new MateriaFDAL();
            return materias.cargarMaterias();
        }

    }
}
