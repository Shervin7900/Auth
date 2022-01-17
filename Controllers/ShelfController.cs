using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        IShelfService _shelfService;
        LibContext _context;


        public ShelfController(IShelfService service, LibContext context)
        {
            _shelfService = service;
            _context = context;
        }
        public static List<Shelf> shelfs = new List<Shelf>()
        {
            new Shelf(){ shelfId = 1 , shelfName = "shelf1" , UserId = 1 , books = "book1" , BookStatus = true },
            new Shelf(){ shelfId = 2 , shelfName = "shelf2" , UserId = 2 , books = "book2" , BookStatus = false },
            new Shelf(){ shelfId = 3 , shelfName = "shelf3" , UserId = 3 , books = "book3" , BookStatus = false },
            new Shelf(){ shelfId = 4 , shelfName = "shelf4" , UserId = 1 , books = "book4" , BookStatus = true },
            new Shelf(){ shelfId = 5 , shelfName = "shelf5" , UserId = 2 , books = "book5" , BookStatus = true },
            new Shelf(){ shelfId = 6 , shelfName = "shelf6" , UserId = 5 , books = "book6" , BookStatus = true },
        };
        /// <summary>
        /// get all shelfs by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetShelf (int Id)
        {
            try
            {
                var shelfs = _shelfService.GetShelf(Id);
                if (shelfs == null) return NotFound();
                return Ok(shelfs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// edit shelfs
        /// </summary>
        /// <param name="shelf"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult PutShelf(Shelf shelf)
        {
            try
            {
                var model = _shelfService.PutShelf(shelf);
                _context.Update(model);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// delete shelf
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteShelf(int id)
        {
            try
            {
                var model = _shelfService.DeleteShelf(id);
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
