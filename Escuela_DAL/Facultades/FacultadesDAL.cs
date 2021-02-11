using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL.Facultades
{
    public class FacultadesDAL
    {
        EscuelaEntities modelo;

        public FacultadesDAL()
        {
            modelo = new EscuelaEntities();
        }
        

        public List<object> MostrarFacultadesf()
        {
            var facultad = from mFacultad in modelo.Facultad
                           select new
                           {
                               ID_Facultad = mFacultad.ID_Facultad,
                               codigo = mFacultad.codigo,
                               nombre = mFacultad.nombre,
                               fechaCreacion = mFacultad.fechaCreacion,
                               nombreUniversidad = mFacultad.Universidad1.nombre,
                               nombreCiudad = mFacultad.Ciudad1.Nombre,
                               nombreEstado = mFacultad.Ciudad1.Estado1.Nombre,
                               nombrePais = mFacultad.Ciudad1.Estado1.Pais1.nombre,
                           };
            return facultad.AsEnumerable<object>().ToList();
        }

        public void agregarFacultad(Facultad facultad)
        {
            modelo.Facultad.Add(facultad);
            modelo.SaveChanges();
        }

        public Facultad cargarFacultad(int ID_Facultad)
        {
            var facultad = (from mFacultad in modelo.Facultad
                           where mFacultad.ID_Facultad == ID_Facultad
                           select mFacultad).FirstOrDefault();

            return facultad;
        }

        public void modificarFacultad(Facultad pfacultad)
        {
            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.ID_Facultad == pfacultad.ID_Facultad
                            select mFacultad).FirstOrDefault();
            
            facultad.codigo = pfacultad.codigo;
            facultad.nombre = pfacultad.nombre;
            facultad.fechaCreacion = pfacultad.fechaCreacion;
            facultad.universidad = pfacultad.universidad;
            facultad.Ciudad1.Estado1.Pais1.nombre = pfacultad.Ciudad1.Estado1.Pais1.nombre;
            facultad.Ciudad1.Estado1.Nombre = pfacultad.Ciudad1.Estado1.Nombre;
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
        public DataTable comprobarCodigo(string Codigo)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"COMPAQ\SQLEXPRESS01;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_comprobarCodigo";
            command.Connection = connection;

            command.Parameters.AddWithValue("pCodigo", Codigo);


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCodigo = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCodigo);

            connection.Close();

            return dtCodigo;

        }
    }
}
