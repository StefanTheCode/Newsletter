namespace SingleResponsibility.Sales;

public class Book
{
    public string ISBN { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
    public double Price { get; set; }
    public DateTime Published { get; set; }

    //Important for Sales team
    public string Color { get; set; } = default!;
    public bool HasPhotos { get; set; }
    public string FontSize { get; set; } = default!;
    public int NumberOfPages { get; set; }
    public bool IsHardback { get; set; }
}