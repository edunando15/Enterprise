using Esame_Enterprise.Application.Abstractions.Services;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Models.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/library")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookController : ControllerBase
    {

        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpPost]
        [Route("GetBooks")]
        public IActionResult GetBooks(GetBooksRequest booksRequest)
        {
            int TotalCount = 0;
            return Ok(_bookService.GetBooks(booksRequest.From, booksRequest.Num, booksRequest.OrderBy, out TotalCount, booksRequest.Name, booksRequest.Author, booksRequest.Publisher, booksRequest.PublicationDate, booksRequest.Category));
        }

        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(ActionBookRequest book)
        {
            if (_bookService.AddBook(new BookDto(book))) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            if (_bookService.DeleteBook(bookId)) return Ok();
            return BadRequest();
        }

        [HttpPut]
        [Route("ModifyBook")]
        public IActionResult ModifyBook(int id, ActionBookRequest book)
        {
            var realBook = new BookDto(book);
            realBook.Id = id;
            _bookService.ModifyBook(realBook);
            return Ok();
        }
    }
}
