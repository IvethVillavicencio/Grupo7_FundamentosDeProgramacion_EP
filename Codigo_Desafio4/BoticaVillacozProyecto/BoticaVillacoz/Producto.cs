namespace BoticaVillacoz
{
    class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"Codigo: {Codigo} | Nombre: {Nombre} | Categoria: {Categoria} | Precio: S/ {Precio:F2} | Stock: {Stock}";
        }
    }
}
