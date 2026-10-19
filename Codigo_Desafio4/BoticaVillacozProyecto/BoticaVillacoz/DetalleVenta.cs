namespace BoticaVillacoz
{
    class DetalleVenta
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get { return PrecioUnitario * Cantidad; } }
    }
}
