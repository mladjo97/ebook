namespace EBook.Services.Contracts.Query
{
    using EBook.Domain;
    
    public interface IEBookElasticQueryable : IElasticQueryable<Book>
    {
    }
}
