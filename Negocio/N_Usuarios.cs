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
        D_Usuario objDato = new D_Usuario();

        public DataTable LoginUser(E_Usuarios usuarios)
        {
            return objDato.LoginUser(usuarios);
        }
    }
}
