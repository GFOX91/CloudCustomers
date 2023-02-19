namespace CloudCustomers.Api.Models;

/// <summary>
/// This model hold all data related to a user
/// </summary>
public class User
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the user 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The email address of the user
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// The current address of the user
    /// </summary>
    public Address Address { get; set; }
}

