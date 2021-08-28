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
    public class N_Productos
    {
        D_Productos objDatos = new D_Productos();

        public DataTable listadoProductos()
        {
            return objDatos.getAllProducts();
        }

        public DataTable ComboBoxCategorias()
        {
            return objDatos.cargarCategoriasProductos();
        }

        public void RegistrarProducto(E_Productos pro)
        {
            objDatos.RegistrarProducto(pro);
        }

        public void ActualizarProducto(E_Productos pro)
        {
            objDatos.ActualizarProducto(pro);
        }
    }
}
