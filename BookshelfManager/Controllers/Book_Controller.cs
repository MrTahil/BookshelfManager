using BookshelfManager.Models;
using BookshelfManager.Modelsűusing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookshelfManager.Controllers
{
    [Route("Books")]
    [ApiController]
    public class Book_Controller : Controller
    {
        private readonly LibraryContext _context;
        public Book_Controller(LibraryContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<Book>> GetAllBooks()
        {
            try
            {

            
            return StatusCode(418, await _context.Books.ToListAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetBookById{Id}")]
        public async Task<ActionResult<Book>> GetBookById(int Id)
        {
            try
            {
                var list = await _context.Books.Where(x => x.Id == Id).ToListAsync();
                if (list != null) {
                    return StatusCode(418, list);
                }
                else {return BadRequest(); }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("DeleteById/{Id}")]
        public async Task<ActionResult<Book>> DeleteBookById(int Id)
        {
            var valami = await _context.Books.FirstOrDefaultAsync(x => x.Id == Id);
            if (valami != null)
            {
                _context.Books.Remove(valami);
                await _context.SaveChangesAsync();
                return StatusCode(418, valami);
            }
            return BadRequest();
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<Book>> CreateBook(CreateBookDto crtdto)
        {
            var valami = new Book
            {
                Author = crtdto.Author,
                Price = crtdto.Price,
                PublishedYear = crtdto.PublishedYear,
                Genre = crtdto.Genre,
                Title = crtdto.Title

            };
            if (valami != null) { 
            _context.Books.Add(valami);
                await _context.SaveChangesAsync();
                return StatusCode(418,valami);
            }
            return BadRequest();
        }

        [HttpPost("EditBookById/{Id}")]
        public async Task<ActionResult<Book>> EditBook(int Id,EditBook eddto)
        {
            var valami = await _context.Books.FirstOrDefaultAsync(x => x.Id ==Id) ;
            if (valami != null) { 
            valami.Author = eddto.Author;
            valami.Price = eddto.Price;
                valami.PublishedYear = eddto.PublishedYear;
                valami.Genre = eddto.Genre;
                valami.Title = eddto.Title;

                _context.Books.Update(valami);
                await _context.SaveChangesAsync();
                return StatusCode(418, valami);
            }
            return BadRequest();
            
        }
    }
}
