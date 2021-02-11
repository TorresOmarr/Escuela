using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using Escuela_DAL.Facultades;

namespace Escuela_BLL.Facultades
{
    public class MateriasFacultadBLL
    {

        public void agregarMateriaFacultad(MateriaFacultad materia)
        {
            MateriasFacultadDAL matFacultad = new MateriasFacultadDAL();
            matFacultad.agregarMateriaFacultad(materia);
        }

        public void eliminarMaterias(int ID_Facultad)
        {
            MateriasFacultadDAL matFacultad = new MateriasFacultadDAL();
            matFacultad.eliminarMaterias(ID_Facultad);
        }

    }
}
