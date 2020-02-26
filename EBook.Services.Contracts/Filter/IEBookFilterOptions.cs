namespace EBook.Services.Contracts.Filter
{
    public interface IEBookFilterOptions
    {
        string Title { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        string Language { get; set; }
        string Category { get; set; }
    }
}
