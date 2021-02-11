using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Escuela_DAl
{
    public class FacultadDAL
    {
        EscuelaEntities modelo;

        public FacultadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<object> CargarFacultades()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select new
                             {
                                 ID_facultad = mFacultades.ID_Facultad,
                                 codigo = mFacultades.codigo,
                                 nombre = mFacultades.nombre,
                                 fechaCreacion = mFacultades.fechaCreacion,
                                 nombreUniversidad = mFacultades.Universidad1.nombre,
                                 nombreCiudad = mFacultades.Ciudad1.Nombre,
                             };

            return facultades.AsEnumerable<object>().ToList();

        }

        public void AgregarFacultad(Facultad facultad)
        {
            modelo.Facultad.Add(facultad);
            modelo.SaveChanges();
        }

        public Facultad cargarID_FAcultad(int ID_Facultad)
        {

            var facultad = (from mFacultad in modelo.Facultad
                              where mFacultad.ID_Facultad == ID_Facultad
                              select mFacultad).FirstOrDefault();
            return facultad;
        }

        public Facultad cargar_codigo(string codigo)
        {
            var codigoF = (from mFacultad in modelo.Facultad
                            where mFacultad.codigo == codigo
                            select mFacultad).FirstOrDefault();
            return codigoF;


        }

        public void EditarFacultad(Facultad pfacultad)
        {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.ID_Facultad == pfacultad.ID_Facultad
                            select mFacultad).FirstOrDefault();

            facultad.codigo = pfacultad.codigo;
            facultad.nombre = pfacultad.nombre;
            facultad.fechaCreacion = pfacultad.fechaCreacion;
            facultad.universidad = pfacultad.universidad;
            facultad.ciudad = pfacultad.ciudad;
            

            modelo.SaveChanges();
            
        }

        public void eliminarFacultad(int ID_Facultad)
        {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.ID_Facultad == ID_Facultad
                            select mFacultad).FirstOrDefault();

            modelo.Facultad.Remove(facultad);
            modelo.SaveChanges();
        }
    }
}
