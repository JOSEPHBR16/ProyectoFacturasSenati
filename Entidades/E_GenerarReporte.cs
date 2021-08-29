using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_GenerarReporte
    {
        private int idVenta;
        private string codigoVenta;
        private DateTime fechaVenta;
        private decimal montoBase;
        private decimal igv;
        private decimal montoTotal;
        private string nombreCliente;
        private string direccion;
        private string correo;
        private string telefono;
        private int idDetalleVenta;
        private int cantidad;
        private string nombreProducto;
        private decimal precioUnitario;

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string CodigoVenta { get => codigoVenta; set => codigoVenta = value; }
        public DateTime FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public decimal MontoBase { get => montoBase; set => montoBase = value; }
        public decimal Igv { get => igv; set => igv = value; }
        public decimal MontoTotal { get => montoTotal; set => montoTotal = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int IdDetalleVenta { get => idDetalleVenta; set => idDetalleVenta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
    }
}
