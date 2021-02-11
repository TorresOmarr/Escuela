using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAl;

namespace Escuela_BLL
{
    class MateriaFacultadBLL
    {

        public void agregarMateriaFAcultad(MateriaFacultad materia)
        {
            MateriaFacultadDAL agregarMateria = new MateriaFacultadDAL();
            agregarMateria.agregarMateriaFacultad(materia);
        }

        public void eliminarMateriaFAcultad(int materia)
        {
            MateriaFacultadDAL agregarMateria = new MateriaFacultadDAL();
            agregarMateria.eliminarMaterias(materia);
        }

    }
}
