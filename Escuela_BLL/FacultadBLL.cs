using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela_DAl;
using System.Transactions;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public List<object> CargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.CargarFacultades();
        }

        public void AgregarFacultad(Facultad paramfacultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            Facultad facu = new Facultad();
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();

            facu = cargarCodigo(paramfacultad.codigo);
            if(facu != null)
            {
                throw new Exception("El codigo de facultad ya existe en la base de datos");
            }
            else
            {
                int fecha = DateTime.Now.Year - paramfacultad.fechaCreacion.Year;
                if(fecha > 121)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900");
                }else if(fecha < 11)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha menor a 2010");
                }
                else
                {             
                       
                    
                    using (TransactionScope ts = new TransactionScope())
                    {
                        facultad.AgregarFacultad(paramfacultad);
                        ts.Complete();
                    }
                      
                  }
           
            }
        }

        public void agregarMaterias(List<MateriaFacultad> listMaterias)
        {
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();
            using (TransactionScope ts = new TransactionScope())
            {
      
                foreach (MateriaFacultad materia in listMaterias)
                {
                    matFacuBLL.agregarMateriaFAcultad(materia);
                }
                ts.Complete();
            }
        }

        public Facultad cargarID_FAcultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarID_FAcultad(ID_Facultad);
        }

        public Facultad cargarCodigo(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargar_codigo(codigo);
        }

        public void EditarFacultad(Facultad paramfacultad, List<MateriaFacultad> listMaterias)
        {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();

            using(TransactionScope ts = new TransactionScope())
            {
                facultad.EditarFacultad(paramfacultad);
                matFacuBLL.eliminarMateriaFAcultad(paramfacultad.ID_Facultad);
                foreach(MateriaFacultad materia in listMaterias)
                {
                    matFacuBLL.agregarMateriaFAcultad(materia);
                }
                ts.Complete();
            }        
        }

        public void eliminarFacultad(int ID_Facultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL matFacu = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                matFacu.eliminarMateriaFAcultad(ID_Facultad);
                facultad.eliminarFacultad(ID_Facultad);
                ts.Complete();
            }
                
        }
    }
}
