namespace EBook.API.Models.Dto
{
    using System.Collections.Generic;

    public class EBookElasticQueryableDto
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public IEnumerable<HighlightableBookDto> Items { get; set; }
    }
}
