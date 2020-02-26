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
    public class CategoriesController : ControllerBase
    {
        private readonly List<CategoryDto> _categories;

        private readonly IMapper _mapper;
        private readonly IEBooksSearchService _eBooksService;

        public CategoriesController(IMapper mapper, IEBooksSearchService eBooksService)
        {
            _mapper = mapper;
            _eBooksService = eBooksService;

            _categories = new List<CategoryDto>
            {
                new CategoryDto { Id = 1, Name = "Drama" },
                new CategoryDto { Id = 2, Name = "War" },
                new CategoryDto { Id = 3, Name = "Fantasy" }
            };
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            foreach (var category in _categories)
                category.EBooks = _mapper.Map<IEnumerable<BookDto>>(
                    await _eBooksService.Search(
                            new EBookSearchOptions { Category = category.Name }
                        )
                    );

            return Ok(_categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categories = _categories.FindAll(cat => cat.Id == id);

            foreach (var category in categories)
                category.EBooks = _mapper.Map<IEnumerable<BookDto>>(
                    await _eBooksService.Search(
                            new EBookSearchOptions { Category = category.Name }
                        )
                    );

            return Ok(categories);
        }

    }
}