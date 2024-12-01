using Bogus;

namespace BookStoreTestingApp.Models;

public class AuthorFaker : Faker<Author>
{
    public AuthorFaker(string locale = "en")
    {
        Locale = locale;
        RuleFor(a => a.FirstName, f => f.Name.FirstName());
        RuleFor(a => a.LastName, f => f.Name.LastName());
    }
}