using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAl;

namespace Escuela_BLL
{
    public class MateriaBLL
    {
        public List<Materia> cargarMaterias()
        {
            MateriaDAL materias = new MateriaDAL();
           return  materias.cargarMaterias();
        }
    }
}
