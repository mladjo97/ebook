namespace EBook.Services.Models
{
    using EBook.Domain;
    using EBook.Services.Contracts.Query;
    using System.Collections.Generic;

    public class HighlightableEBook : Book, IHighlightable
    {
        public IReadOnlyDictionary<string, IReadOnlyCollection<string>> Highlights { get; set; }
    }


}
