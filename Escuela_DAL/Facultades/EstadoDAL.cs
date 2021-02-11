using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL.Facultades
{
    public class EstadoDAL
    {

        public DataTable cargarEstados(int Pais)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=COMPAQ\SQLEXPRESS01;Database=Escuela;Trusted_connection=true;";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarEstadosPorPais";
            command.Connection = connection;

            command.Parameters.AddWithValue("pPais", Pais);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtEstados = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtEstados);

            connection.Close();

            return dtEstados;
        }


    }
}
