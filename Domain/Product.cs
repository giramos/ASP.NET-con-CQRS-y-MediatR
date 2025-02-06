namespace Domain;

public class Product
{
    public int ProductId { get; set; }
    // public string Description { get; set; } = default!;
        public string Description { get; set; } = string.Empty; // Cambia "nvarchar(max)" automáticamente a "TEXT" en SQLite

    public double Price { get; set; }
}