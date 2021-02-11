using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL.Alumnos;

namespace Escuela_BLL.Alumnos
{
    public class EstadoBLL
    {

        public DataTable cargarEstados()
        {
            EstadoDAL estado = new EstadoDAL();
            return estado.cargarEstados();
        }

    }
}
