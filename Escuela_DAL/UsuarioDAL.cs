using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Escuela_DAl
{
    public class UsuarioDAL
    {

        public DataTable consultarUsuario(string nombre,string contra)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=COMPAQ\SQLEXPRESS01;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_consultarUsuario";
            command.Connection = connection;

            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pContrasena", contra);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsiario = new DataTable();

            connection.Open();
            adapter.SelectCommand = command;
            adapter.Fill(dtUsiario);
            connection.Close();

            return dtUsiario;
        }

    }
}
