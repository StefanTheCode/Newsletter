namespace NullableReference;

public class CustomerWithNullableWarning
{

#nullable disable
    public string Name { get; set; }

#nullable enable
    public string Address { get; set; }
    public string Email { get; set; }
}