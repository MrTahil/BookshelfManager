using BookshelfManager.Models;
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
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            try
            {
                var list = await _context.Books.Where(x => x.Id == id).ToListAsync();
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
    }
}
