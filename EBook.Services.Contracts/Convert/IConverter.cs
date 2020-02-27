namespace EBook.Services.Contracts.Convert
{
    using System.Threading.Tasks;

    public interface IConverter<TIn, TOut>
    {
        Task<TOut> Convert(TIn data);
    }
}
