using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShelfController : ControllerBase
    {
        IBookshelfService _bookshelfService;
        LibContext _context;


        public BookShelfController(IBookshelfService service, LibContext context)
        {
            _bookshelfService = service;
            _context = context;
        }
        public static List<BookShelf> bookShelves = new List<BookShelf>()
        {
            new BookShelf(){Id = 1, Name ="Bookshelf1" , shelfid = 1, Userid = 1},
            new BookShelf(){Id = 2, Name ="Bookshelf2" , shelfid = 1, Userid = 2},
            new BookShelf(){Id = 3, Name ="Bookshelf3" , shelfid = 2, Userid = 2},
            new BookShelf(){Id = 4, Name ="Bookshelf4" , shelfid = 3, Userid = 3},
            new BookShelf(){Id = 5, Name ="Bookshelf5" , shelfid = 3, Userid = 4},
            new BookShelf(){Id = 6, Name ="Bookshelf6" , shelfid = 4, Userid = 5},
            new BookShelf(){Id = 7, Name ="Bookshelf7" , shelfid = 5, Userid = 1},
        };

        /// <summary>
        /// get all bookshelf by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBookShelf(int Id)
        {
            try
            {
                var bookshelf = _bookshelfService.GetBookShelf(Id);
                if (bookshelf == null) return NotFound();
                return Ok(bookshelf);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// edit bookshelf
        /// </summary>
        /// <param name="bookshelf"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult PutBookShelf(BookShelf bookshelf)
        {
            try
            {
                var model = _bookshelfService.PutBookShelf(bookshelf);
                _context.Update(model);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// delete bookshelf
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteBookShelf(int id)
        {
            try
            {
                var model = _bookshelfService.DeleteBookShelf(id);
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
