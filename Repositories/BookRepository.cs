using BookStoreTestingApp.IRepositories;
using BookStoreTestingApp.Models;

namespace BookStoreTestingApp.Repositories
{
    public class BookRepository : IBookRepository
    { 
        public IEnumerable<Book> GenerateBooks(string language, int seed, double likes, double reviews, int numberOfBooks, int lastRowId)
        {
            var faker = new BookFaker(locale: language,reviews: reviews, likes: likes, seed: seed).UseSeed(seed);
            var books = faker.Generate(numberOfBooks).Select((book, index) =>
            {
                book.Id = lastRowId + index + 1;
                return book;
            });
            return books;
        }
    }
}