namespace EBook.API.Controllers
{
    using AutoMapper;
    using EBook.API.Models.Dto;
    using EBook.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly List<LanguageDto> _languages;
        
        private readonly IMapper _mapper;
        private readonly IEBooksService _eBooksService;

        public LanguagesController(IMapper mapper, IEBooksService eBooksService)
        {
            _mapper = mapper;
            _eBooksService = eBooksService;

            _languages = new List<LanguageDto>
            {
                new LanguageDto { Id = 1, Name = "English" },
                new LanguageDto { Id = 2, Name = "Serbian" }
            };
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            foreach (var lang in _languages)
                lang.EBooks = _mapper.Map<IEnumerable<BookDto>>(await _eBooksService.SearchByLanguage(lang.Name));

            return Ok(_languages);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var languages = _languages.FindAll(lang => lang.Id == id);

            foreach(var lang in languages)
                lang.EBooks = _mapper.Map<IEnumerable<BookDto>>(await _eBooksService.SearchByLanguage(lang.Name));

            return Ok(languages);
        }

    }
}