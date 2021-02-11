using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Escuela_DAl
{
    public class EstadoDAL

    {
        EscuelaEntities modelo;

        public EstadoDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Estado> CargarEstado(Pais pais)
        {
            var estados = from mEstados in modelo.Estado
                          where mEstados.Pais == pais.ID_Pais
                          select mEstados;
           
            return estados.ToList();

           

        }

    
    }
}
