using Bogus;

namespace BookStoreTestingApp.Models;

public class BookFaker : Faker<Book>
{
    public BookFaker(string locale = "en", double reviews = 1.0, double likes = 1.0, int seed = 1 )
    {
        Locale = locale;
        Randomizer randomizer = new Randomizer(seed);
        RuleFor(b => b.Title, f => f.Lorem.Sentence(3));
        RuleFor(b => b.ISBN, f => f.Random.Guid().ToString());
        RuleFor(b => b.Publisher, f => f.Company.CompanyName()); 
        RuleFor(b => b.Authors, f => new AuthorFaker(locale).Generate(f.Random.Int(1, 2)));
        RuleFor(b => b.Reviews, f => new ReviewFaker(locale).Generate(RandomWithFractions(randomizer, reviews)));
        RuleFor(b => b.Likes, f => RandomWithFractions(randomizer, likes));
        RuleFor(b => b.ImageUrl, f => f.Image.PicsumUrl()); 
    }
    
    private int RandomWithFractions(Randomizer randomizer, double maxCount)
    {
        int wholePart = (int)Math.Floor(maxCount);
        double fractionalPart = maxCount - wholePart;
        if (fractionalPart == 0)
        {
            return wholePart;
        }
        int result = wholePart;
        if (randomizer.Double() < fractionalPart)
        {
            result++;
        }
        return result;
    }
}