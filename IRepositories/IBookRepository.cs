using BookStoreTestingApp.Models;
using BookStoreTestingApp.ViewModels;

namespace BookStoreTestingApp.IRepositories;

public interface IBookRepository
{
    IEnumerable<Book> GenerateBooks(string language, int seed, double likes, double reviews, int numberOfBooks, int lastRowId);
}