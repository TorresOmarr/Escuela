using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
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

            if (alum != null)
            {
                throw new Exception("La matricula ya existe en la base de datos");
            }
            else
            {
                int edad = DateTime.Now.Year - paramAlumno.fechaNacimiento.Year;

                if (edad > 80)
                {
                    throw new Exception("El alumno es demasiado viejo. Ingresa otra edad.");
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
        public void  moificarAlumno(Alumno paramAlumno, List<MateriaAlumno> listMaterias)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            MateriaAlumnoBLL matAlumnoBLL = new MateriaAlumnoBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                alumno.moificarAlumno(paramAlumno);

                matAlumnoBLL.eliminarMateriaAlumno(paramAlumno.matricula);

                foreach(MateriaAlumno materia in listMaterias)
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

            using(TransactionScope ts = new TransactionScope())
            {
                matAlumno.eliminarMateriaAlumno(matricula);
                alumno.eliminarAlumno(matricula);

                ts.Complete();
            }
            

        }
    }
}
