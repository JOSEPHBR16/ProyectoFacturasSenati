using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Usuarios
    {
        D_Usuario objDatos = new D_Usuario();

        public DataTable LoginUser(E_Usuarios usuarios)
        {
            return objDatos.LoginUser(usuarios);
        }

        public void RegistrarUsuarios(E_Usuarios usuarios)
        {
            objDatos.RegistrarUsuario(usuarios);
        }
    }
}
