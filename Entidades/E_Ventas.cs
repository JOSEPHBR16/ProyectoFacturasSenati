using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Ventas
    {
        private int _idVenta;
        private int _idCliente;
        private int _idUsuario;
        private decimal _montoBase;
        private decimal _igv;
        private decimal _montoTotal;

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public decimal MontoBase { get => _montoBase; set => _montoBase = value; }
        public decimal Igv { get => _igv; set => _igv = value; }
        public decimal MontoTotal { get => _montoTotal; set => _montoTotal = value; }
    }
}
