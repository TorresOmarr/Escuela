using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Escuela_DAL.Facultades
{
    public class MateriaFDAL
    {
        EscuelaEntities modelo;

        public MateriaFDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Materia> cargarMaterias()
        {

            var materias = from mMaterias in modelo.Materia
                           select mMaterias;

            return materias.ToList();
        }

    }
}
