using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL.Facultades;
using Escuela_DAL;
using Escuela_BLL.Facultades;
using Escuela_BLL;
using System.Transactions;


namespace Escuela_BLL.Facultades
{
    public class FacultadesBLL
    {
        public List<object> MostrarFacultadesf()
        {
            FacultadesDAL facultad = new FacultadesDAL();
            return facultad.MostrarFacultadesf();
        }

        public void agregarFacultadPorID(Facultad paramFacultad)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                FacultadesDAL facuDAL = new FacultadesDAL();
                facuDAL.agregarFacultad(paramFacultad);
                ts.Complete();
            }
        }

        public void agregarFacultad(Facultad paramFacultad, List<MateriaFacultad> listMaterias)
        {
            FacultadesDAL facultad = new FacultadesDAL();
            Facultad facu = new Facultad();
            MateriasFacultadBLL matFacuBLL = new MateriasFacultadBLL();

            facu = cargarFacultad(paramFacultad.ID_Facultad);

            if (facu != null)
            {
                throw new Exception("Facultad agregada exitosamente.");
            }
            else
            {            
                int año = paramFacultad.fechaCreacion.Year;
                if (año < 1900)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900");
                }
                else if (año > 2010)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha menor a 2010");
                }
                else
                {

                    using (TransactionScope ts = new TransactionScope())
                    {
                        facultad.agregarFacultad(paramFacultad);
                        foreach (MateriaFacultad materia in listMaterias)
                        {
                            matFacuBLL.agregarMateriaFacultad(materia);                            
                        }
                        ts.Complete();
                    }
                
                }
            }
                
        }

        public Facultad cargarFacultad(int ID_Facultad)
        {
            FacultadesDAL facultad = new FacultadesDAL();
            return facultad.cargarFacultad(ID_Facultad);
        }
        public void modificarFacultad(Facultad paramFacultad, List<MateriaFacultad> listMaterias)
        {
            FacultadesDAL facultad = new FacultadesDAL();
            MateriasFacultadBLL matFacultadBLL = new MateriasFacultadBLL();     
            
            using (TransactionScope ts = new TransactionScope())
            {
                facultad.modificarFacultad(paramFacultad);
                matFacultadBLL.eliminarMaterias(paramFacultad.ID_Facultad);
                foreach (MateriaFacultad materia in listMaterias)
                {
                    matFacultadBLL.agregarMateriaFacultad(materia);
                }
                ts.Complete();
            }
            
            
        }
        public void eliminarFacultad(int ID_Facultad)
        {
            FacultadesDAL facultad = new FacultadesDAL();
            facultad.eliminarFacultad(ID_Facultad);
        }
        public DataTable comprobarCodigo(string Codigo)
        {
            FacultadesDAL codigo = new FacultadesDAL();
            return codigo.comprobarCodigo(Codigo);
        }
    }
}
