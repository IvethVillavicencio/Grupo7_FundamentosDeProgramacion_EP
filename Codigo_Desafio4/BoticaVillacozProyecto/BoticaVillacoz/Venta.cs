using System;
using System.Collections.Generic;

namespace BoticaVillacoz
{
    class Venta
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public decimal Total
        {
            get
            {
                decimal t = 0;
                foreach (var d in Detalles) t += d.Subtotal;
                return t;
            }
        }
    }
}
