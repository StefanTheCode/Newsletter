namespace CleanCodeBestPractices;

public class AvoidTooManyParameters
{
    //Don't do this
    public void AddAddress(string streetName, string streetNumber, string postalCode, string country, string city, string region)
    {
        //Do something
    }

    //Do this
    public void AddAddress(Address address)
    {
        //Do something
    }
}

public class Address
{
    public string StreetName { get; set; } = string.Empty;
    public string StreetNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
}