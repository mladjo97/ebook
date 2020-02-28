namespace EBook.Services.Contracts.Query
{
    public interface IElasticQueryable<T> : IPaginable<T> where T : class
    {
    }
}
