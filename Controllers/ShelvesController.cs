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
    public class ShelvesController : ControllerBase
    {
        private readonly LibContext _context;

        public ShelvesController(LibContext context)
        {
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

        // GET: api/Shelves
        [HttpGet]
        public async Task<ActionResult<List<Shelf>>> GetShelf()
        {  
            var shelfs = await _context.Shelves.ToListAsync();
            if(shelfs == null) { return NotFound(); }
            return Ok(shelfs);
        }

        // GET: api/Shelves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelf>> GetShelfbyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

                var existingshelf =await _context.Shelves.AsNoTracking().FirstOrDefaultAsync(x=>x.shelfId == id);
                if (existingshelf == null)
                {
                    return NotFound();
                }
                return Ok(existingshelf);
            
        }

        // PUT: api/Shelves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Shelf>> PutShelf(int id, Shelf shelf)
        {
            if (!ModelState.IsValid)
                   { return BadRequest("Not a valid model"); }
            
                var shelfs = await _context.Shelves.FirstOrDefaultAsync<Shelf>(x=>x.shelfId == id);
                if (shelfs != null)
                {
                    shelfs.shelfId = shelf.shelfId;
                    shelfs.shelfName = shelf.shelfName;
                    shelfs.books = shelf.books;
                    shelfs.BookStatus = shelf.BookStatus;
                     

                    await _context.SaveChangesAsync();
                    
                }
                else
                {
                    return NotFound(id);
                }
                return Ok(shelf);
                
           
        }

        // POST: api/Shelves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shelf>> PostShelf(Shelf shelf)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            
            _context.Shelves.Add(shelf);
            await _context.SaveChangesAsync();
            
            return Ok(shelf);
        }

        // DELETE: api/Shelves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shelf>> DeleteShelf(int id)
        {
            if (id <= 0)
                {return BadRequest("Not a valid student id");}
            
                var shelf = await _context.Shelves.AsNoTracking().SingleOrDefaultAsync(x=>x.shelfId == id);
                _context.Remove(shelf);
                await _context.SaveChangesAsync();


                return Ok(shelf);
        }

        private bool ShelfExists(int id)
        {
            return _context.Shelves.Any(e => e.shelfId == id);
        }
    }
}
