using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL.Alumnos
{
    public class UsuarioDAL
    {
        public DataTable ConsultarUsuario(string nombre, string contraseña)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=COMPAQ\SQLEXPRESS01;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_ConsultarUsuario";
            command.Connection = connection;

            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pContrasena", contraseña);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsuario = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtUsuario);

            connection.Close();

            return dtUsuario;

        }





    }
}
