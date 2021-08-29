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
    public class N_Clientes
    {
        D_Clientes objDatos = new D_Clientes();

        public List<E_Clientes> generarReportes { get; private set; }

        public DataTable ListadoClientes()
        {
            return objDatos.getAllClients();
        }

        public void RegistrarCliente(E_Clientes clientes)
        {
            objDatos.RegistrarCliente(clientes);
        }

        public void ActualizarCliente(E_Clientes clientes)
        {
            objDatos.ActualizarCliente(clientes);
        }

        public void EliminarCliente(E_Clientes clientes)
        {
            objDatos.EliminarCliente(clientes);
        }
    }
}
