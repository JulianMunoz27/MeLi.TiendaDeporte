namespace MeLi.TiendaDeporte.Domain.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
    }
}
