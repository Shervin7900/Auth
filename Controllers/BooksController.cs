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
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibContext _context;

        public BooksController(LibContext context)
        {
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

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBook()
        {
            var books = await _context.Books.ToListAsync();
            if(books == null) { return NotFound(); }
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookbyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid Model");
           
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(book);
                }
            
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            
                var Updatebook = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync<Book>();
            if (Updatebook != null)
            {
                Updatebook.Id = book.Id;
                Updatebook.bookName = book.bookName;

                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
                return Ok(Updatebook);
            
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            
            
                _context.Books.Add(book);
               
                await _context.SaveChangesAsync();
           
                return Ok(book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            
                var DeleteBook = _context.Books.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
                _context.Remove(DeleteBook);
                await _context.SaveChangesAsync();
                _context.Entry(DeleteBook).State = EntityState.Deleted;
            
            return Ok();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
