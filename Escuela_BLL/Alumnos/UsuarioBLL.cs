using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL.Alumnos;

namespace Escuela_BLL.Alumnos
{
    public class UsuarioBLL
    {
        public DataTable ConsultarUsuario(string nombre, string contraseña)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.ConsultarUsuario(nombre, contraseña);
        }
    }
}
