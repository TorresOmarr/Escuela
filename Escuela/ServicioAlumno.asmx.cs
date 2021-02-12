using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServiciosWeb.Datos;
using Escuela_DAL;

namespace Escuela
{
    /// <summary>
    /// Descripción breve de ServicioAlumno
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioAlumno : System.Web.Services.WebService
    {
        EscuelaEntities BD = new EscuelaEntities();

        [WebMethod]
        public List<Object> obtenerAlumnos()
        {
            var alumnos = from mAlumnos in BD.Alumno
                          select new
                          {
                              matricula = mAlumnos.matricula,
                              nombre = mAlumnos.nombre,
                              fechaNacimiento = mAlumnos.fechaNacimiento,
                              semestre = mAlumnos.semestre,
                              nombreFacultad = mAlumnos.Facultad1.nombre,
                              nombreCiudad = mAlumnos.Ciudad1.Nombre,
                          };
            return alumnos.AsEnumerable<object>().ToList();
        }
    }
}
