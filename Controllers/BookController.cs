using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
            IBookService _bookService;
            LibContext _context;


            public BookController(IBookService service, LibContext context)
            {
                _bookService = service;
                _context = context;
            }
            public static List<Book> books = new List<Book>()
            {
                new Book(){Id = 1, bookName ="book1"},
                new Book(){Id = 2, bookName ="book2"},
                new Book(){Id = 3, bookName ="book3"},
                new Book(){Id = 4, bookName ="book4"},
                new Book(){Id = 5, bookName ="book5"},
            };

        /// <summary>
        /// get all books by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        
        [Authorize]
        [HttpGet]
            [Route("[action]/{id}")]
            public IActionResult GetBook(int Id)
            {
                try
                {
                    var books = _bookService.GetBook(Id);
                    if (books == null) return NotFound();
                    return Ok(books);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }


            /// <summary>
            /// edit books
            /// </summary>
            /// <param name="book"></param>
            /// <returns></returns>
            [HttpPost]
            [Route("[action]")]
            public IActionResult PutBook(Book book)
            {
                try
                {
                    var model = _bookService.PutBook(book);
                _context.Update(model);
                    return Ok(model);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }


        /// <summary>
        /// delete book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
            [Route("[action]")]
            public IActionResult DeleteBook(int id)
            {
                try
                {
                    var model = _bookService.DeleteBook(id);
                    _context.Remove(model);
                    return Ok(model);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

        }
    }

