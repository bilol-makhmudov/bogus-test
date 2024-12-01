using Bogus;

namespace BookStoreTestingApp.Models;

public class ReviewFaker : Faker<Review>
{
    public ReviewFaker(string locale = "en")
    {
        Locale = locale;
        RuleFor(a => a.Content, f => f.Lorem.Sentence());
        RuleFor(a => a.CompanyName, f => f.Company.CompanyName());
        RuleFor(a => a.Reviewer, f => f.Person.FullName);
    }
}