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
    public class N_GenerarReporte
    {
        public List<E_GenerarReporte> generarReportes { get; private set; }

        public void GenerarReporte(int idVenta)
        {
            var reporte = new D_GenerarReporte();
            var resultado = reporte.GenerarComprobante(idVenta);

            generarReportes = new List<E_GenerarReporte>();

            foreach(DataRow fila in resultado.Rows)
            {
                var detallesComprobantes = new E_GenerarReporte()
                {
                    IdVenta = Convert.ToInt32(fila[0]),
                    CodigoVenta = fila[1].ToString(),
                    FechaVenta = Convert.ToDateTime(fila[2]),
                    MontoBase = Convert.ToDecimal(fila[3]),
                    Igv = Convert.ToDecimal(fila[4]),
                    MontoTotal = Convert.ToDecimal(fila[5]),
                    NombreCliente = fila[6].ToString(),
                    Direccion = fila[7].ToString(),
                    Correo = fila[8].ToString(),
                    Telefono = fila[9].ToString(),
                    IdDetalleVenta = Convert.ToInt32(fila[10]),
                    Cantidad = Convert.ToInt32(fila[11]),
                    NombreProducto = fila[12].ToString(),
                    PrecioUnitario = Convert.ToDecimal(fila[13])
                };
                generarReportes.Add(detallesComprobantes);
            }
            
        }
    }
}
