using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela_DAl;

namespace Escuela_BLL
{
    public class EstadoBLL
    {
        public List<Estado> cargarEstados(Pais pais)
        {
            EstadoDAL estado = new EstadoDAL();
            return estado.CargarEstado(pais);
        }

        
    }
}
