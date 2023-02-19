using CloudCustomers.Api.Models;

namespace CloudCustomers.UnitTests.Fixtures;

/// <summary>
/// Used to set up user related fixtures to be utilized in unit tests and conform to DRY 
/// </summary>
public static class UsersFixture
{
    /// <summary>
    /// Return a static list of users 
    /// </summary>
    public static List<User> GetTestUsers() => new() {
            new User
            {
                Name = "Test User 1",
                Email = "testuser1@email.com",
                Address = new Address
                {
                    Street = "123 Fake Street",
                    City = "Somewhere",
                    PostCode = "12234"
                }
            },
            new User
            {
                Name = "Test User 2",
                Email = "testuser2@email.com",
                Address = new Address
                {
                    Street = "567 Fake Street",
                    City = "Somewhere else",
                    PostCode = "333332"
                }
            },
             new User
            {
                Name = "Test User 3",
                Email = "testuser3@email.com",
                Address = new Address
                {
                    Street = "8910 Fake Street",
                    City = "Another Place",
                    PostCode = "233455"
                }
            },
        };
}

