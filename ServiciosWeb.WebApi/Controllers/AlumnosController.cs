using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ServiciosWeb.Datos.Modelo;

namespace ServiciosWeb.WebApi.Controllers
{
    public class AlumnosController : ApiController
    {
        EscuelaEntities BD = new EscuelaEntities();
        public IEnumerable<object> Get()
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
