namespace EBook.Services.Contracts.Query
{
    public interface IEBookSearchOptions
    {
        string Title { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        string Language { get; set; }
        string Category { get; set; }
    }
}
