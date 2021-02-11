using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        EscuelaEntities modelo;

        public FacultadDAL()
        {
            modelo = new EscuelaEntities();
        }


        public List<Facultad> cargarFacultades()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select mFacultades;

            return facultades.ToList();
            
        }

        public DataTable cargarAlumno(int matricula)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=SALA-PC\SQLEXPRESS;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumnoPorMatricula";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", matricula);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumno = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumno);

            connection.Close();

            return dtAlumno;

        }
    }
}
