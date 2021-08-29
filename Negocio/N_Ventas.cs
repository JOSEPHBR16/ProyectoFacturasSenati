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
    public class N_Ventas
    {
        readonly D_Ventas objVentas = new D_Ventas();

        public DataTable ListadoVentas()
        {
            return objVentas.getAllVentas();
        }

        public static string InsertarVentas(E_Ventas ventas, DataTable DtDetalleVenta)
        {
            D_Ventas objVentas = new D_Ventas();
            List<E_DetalleVentas> detalles = new List<E_DetalleVentas>();
            foreach(DataRow row in DtDetalleVenta.Rows)
            {
                E_DetalleVentas detalleVentas = new E_DetalleVentas
                {
                    Cantidad = Convert.ToInt32(row["Cantidad"].ToString()),
                    IdProducto = Convert.ToInt32(row["IdProducto"].ToString()),
                };
                detalles.Add(detalleVentas);
            }
            return objVentas.InsertarVentas(ventas, detalles);
        } 

        public void AnularVenta(E_Ventas ventas)
        {
            objVentas.AnularVenta(ventas);
        }
    }
}
