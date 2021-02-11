using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL.Facultades;

namespace Escuela_BLL.Facultades
{
    public class EstadoBLL
    {

        public DataTable cargarEstados(int Pais)
        {
            EstadoDAL estado = new EstadoDAL();
            return estado.cargarEstados(Pais);
        }

    }
}
