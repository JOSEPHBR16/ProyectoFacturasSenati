using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_DetalleVentas
    {
        private int _idVenta;
        private int _idProducto;
        private int _cantidad;

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    }
}
