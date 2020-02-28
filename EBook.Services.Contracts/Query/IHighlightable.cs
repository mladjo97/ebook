namespace EBook.Services.Contracts.Query
{
    using System.Collections.Generic;

    public interface IHighlightable
    {
        IReadOnlyDictionary<string, IReadOnlyCollection<string>> Highlights { get; set; }
    }
}
