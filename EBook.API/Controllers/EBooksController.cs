namespace EBook.API.Controllers
{
    using AutoMapper;
    using EBook.API.Models;
    using EBook.API.Models.Dto;
    using EBook.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class EBooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEBookServicesWrapper _eBookServices;

        public EBooksController(IMapper mapper, IEBookServicesWrapper eBookServices)
        {
            _mapper = mapper;
            _eBookServices = eBookServices;
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromQuery]EBookFilterOptions options, [FromQuery]bool fuzzy = false)
        {
            if (options == null)
                return BadRequest();

            // @TODO:
            // - Replace if statement with a map
            var books = fuzzy
                ? await _eBookServices.FilterService.FuzzyFilter(options)
                : await _eBookServices.FilterService.Filter(options);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksDto);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery]EBookSearchOptions options, [FromQuery]bool fuzzy = false)
        {
            if (options == null)
                return BadRequest();

            // @TODO:
            // - Replace if statement with a map
            var books = fuzzy
                ? await _eBookServices.SearchService.FuzzySearch(options)
                : await _eBookServices.SearchService.Search(options);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksDto);
        }

    }
}