namespace CloudCustomers.Api.Models;

/// <summary>
/// This model holds all data related to an address 
/// </summary>
public class Address
{
    /// <summary>
    /// The 1st line of the address 
    /// </summary>
    public string Street { get; set; }
    /// <summary>
    /// The City of the address
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// The postcode of the address
    /// </summary>
    public string PostCode { get; set; }
}

