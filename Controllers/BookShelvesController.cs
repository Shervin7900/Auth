#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lib.Models;

namespace Lib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShelvesController : ControllerBase
    {
        private readonly LibContext _context;

        public BookShelvesController(LibContext context)
        {
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

        // GET: api/BookShelves
        [HttpGet]
        public async Task<ActionResult<List<BookShelf>>> GetBookShelf()
        {
            var bookshelf = await _context.BookShelves.ToListAsync();
            if(bookshelf == null) { return NotFound(); }
            return Ok(bookshelf);
        }

        // GET: api/BookShelves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookShelf>> GetBookShelfbyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            
                var bookshelf = await _context.BookShelves.SingleOrDefaultAsync(x=>x.Id == id);
                if(bookshelf == null)
                {
                    return NotFound();
                }
                return Ok(bookshelf);

           
            
        }

        // PUT: api/BookShelves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<BookShelf>> PutBookShelf(int id, BookShelf bookShelf)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            
                var updatebookshelf = await _context.BookShelves.Where(x => x.Id == id).FirstOrDefaultAsync<BookShelf>();
                if(updatebookshelf != null)
                {
                     updatebookshelf.Id= bookShelf.Id;
                     updatebookshelf.Name= bookShelf.Name;
                     updatebookshelf.shelfid= bookShelf.shelfid;
                     updatebookshelf.Userid = bookShelf.Userid;

                     await _context.SaveChangesAsync();


                }
                else
                {
                    return NotFound();
                }
                return Ok(updatebookshelf);
            

        }



        // POST: api/BookShelves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookShelf>> PostBookShelf(BookShelf bookShelf)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            
                _context.BookShelves.Add(bookShelf);
                await _context.SaveChangesAsync();
           
                return Ok(bookShelf);
        }

        // DELETE: api/BookShelves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookShelf>> DeleteBookShelf(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            
                var deleteBookshelf = _context.BookShelves.FirstOrDefaultAsync(x => x.Id == id);
                _context.Remove(deleteBookshelf);
                await _context.SaveChangesAsync();
                _context.Entry(deleteBookshelf).State = EntityState.Deleted;
            
                return Ok();
        }

        private bool BookShelfExists(int id)
        {
            return _context.BookShelves.Any(e => e.Id == id);
        }
    }
}
