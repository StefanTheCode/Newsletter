namespace SingleResponsibility.Warehouse;

public class Book
{
    public string ISBN { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
    public double Price { get; set; }
    public DateTime Published { get; set; }

    //Important for warehouse team
    public double Weight { get; set; }
    public double BuyIndex { get; set; }
    public string ShelfPosition { get; set; } = default!;
    public string Size { get; set; } = default!;
}