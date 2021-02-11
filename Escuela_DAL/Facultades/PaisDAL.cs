using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL.Facultades
{
    public class PaisDAL
    {

        public DataTable cargarPaises()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=COMPAQ\SQLEXPRESS01;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarPaises";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtPaises = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtPaises);

            connection.Close();

            return dtPaises;
        }

    }
}
