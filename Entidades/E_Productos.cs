using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Productos
    {
        private int _idProducto;
        private string _nombre;
        private decimal _precioUnitario;
        private int _stock;
        private int _idCategoria;

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
    }
}
