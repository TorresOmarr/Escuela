using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using Escuela_BLL.Alumnos;
using System.Transactions;

namespace Escuela_BLL
{
    public class AlumnoBLL
    {

        public List<object> cargarAlumnos()
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumnos();
        }
        public void agregarAlumno(Alumno paramAlumno, List<MateriaAlumno> listMaterias)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            Alumno alum = new Alumno();
            MateriaAlumnoBLL matAlumBLL = new MateriaAlumnoBLL();

            alum = cargarAlumno(paramAlumno.matricula);

            if(alum != null)
            {
                throw new Exception("La matricula ya existe.");
            }
            else
            {
                int edad = DateTime.Now.Year - paramAlumno.fechaNacimiento.Year;

                if (edad > 80)
                {
                    throw new Exception("El alumno es demasiado viejo. Ingresa otra edad");                    
                }
                else
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        alumno.agregarAlumno(paramAlumno);

                        foreach(MateriaAlumno materia in listMaterias)
                        {
                            matAlumBLL.agregarMateriaAlumno(materia);
                        }
                        ts.Complete();
                    }
                }
            }

            
        }
        public Alumno cargarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumno(matricula);
        }
        public void modificarAlumno(Alumno paramAlumno, List<MateriaAlumno> listMaterias)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            MateriaAlumnoBLL matAlumnoBLL = new MateriaAlumnoBLL();
            using (TransactionScope ts = new TransactionScope())
            {
                alumno.modificarAlumno(paramAlumno);
                matAlumnoBLL.eliminarMaterias(paramAlumno.matricula);

                foreach (MateriaAlumno materia in listMaterias)
                {
                    matAlumnoBLL.agregarMateriaAlumno(materia);
                }
                ts.Complete();
            }
        }
        public void eliminarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            MateriaAlumnoBLL matAlumno = new MateriaAlumnoBLL();
            using (TransactionScope ts = new TransactionScope())
            {
                matAlumno.eliminarMaterias(matricula);
                alumno.eliminarAlumno(matricula);

                ts.Complete();
            }
        }
    }
}
