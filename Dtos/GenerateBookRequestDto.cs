namespace BookStoreTestingApp.Dtos;

public class GenerateBookRequestDto
{
    public string Language { get; set; } = "en_US";
    public int Seed {get;set;}
    public double Likes { get; set; }
    public double Reviews { get; set; }
    public int NumberOfBooks { get; set; }
    public int LastRowId{ get; set; } = 0;
}