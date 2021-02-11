using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Escuela_DAl;

namespace Escuela_BLL
{
    public class UsuarioBLL
    {
        public DataTable consultarUsuario(string nombre, string contra)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.consultarUsuario(nombre, contra);
        }
    }
}
