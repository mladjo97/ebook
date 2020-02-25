namespace EBook.API.Controllers
{
    using EBook.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class EBooksController : ControllerBase
    {
        private readonly IEBooksService _eBooksService;

        public EBooksController(IEBooksService eBooksService)
            => _eBooksService = eBooksService;

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchByTitle([FromQuery]string title)
        {
            if (string.IsNullOrEmpty(title))
                return BadRequest();

            var books = await _eBooksService.SearchByTitle(title);

            return Ok(books);
        }
    }
}