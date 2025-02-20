using MeLi.TiendaDeporte.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace MeLi.TiendaDeporte.Data.Mappings
{
    public class ProductosMap : EntityTypeConfiguration<Productos>
    {
        public ProductosMap()
        {
            //Primary Key
            HasKey(t => t.Id);

            //Table
            ToTable("Productos");

            //Property
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Stock).HasColumnName("Stock");
            this.Property(t => t.Brand).HasColumnName("Brand");

        }
    }
}
