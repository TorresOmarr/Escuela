using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Escuela_DAL;
using System.Web;
using System.Configuration;


namespace Escuela 
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicesWCFAlumnos  
    {
        EscuelaEntities modelo;

        public ServicesWCFAlumnos()
        {
            modelo = new EscuelaEntities();
        }

        [WebGet]
        [OperationContract]
        public string consultaAlumnosJSON()
        {

            var alumnos = from mAlumnos in modelo.Alumno
                          select new
                          {
                              matricula = mAlumnos.matricula,
                              nombre = mAlumnos.nombre
                          };

            return (new JavaScriptSerializer().Serialize(alumnos.AsEnumerable<object>().ToList()));

        }



        // Agregue aquí más operaciones y márquelas con [OperationContract]
    }
}

