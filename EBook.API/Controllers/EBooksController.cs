namespace EBook.API.Controllers
{
    using AutoMapper;
    using EBook.API.Models;
    using EBook.API.Models.Dto;
    using EBook.Domain;
    using EBook.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]PostBookDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // @TODO:
            // - move this logic elsewhere
            var filePath = Path.Combine("wwwroot/ebooks", model.File.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.File.CopyTo(fileStream);
            }

            var book = _mapper.Map<Book>(model);
            book.File.Path = filePath;

            var createdBook = await _eBookServices.RepositoryService.Create(book);

            var bookDto = _mapper.Map<BookDto>(createdBook);

            return Ok(bookDto);
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

            // @TODO:
            // - Fix mapper
            foreach (var book in books.Items)
                book.File.Content = string.Empty;

            return Ok(books);
        }

    }
}