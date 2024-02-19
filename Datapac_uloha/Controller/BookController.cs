using Microsoft.AspNetCore.Mvc;
using Datapac_uloha.Service;
using Datapac_uloha.Models;

namespace Datapac_uloha.Controller
{
    [Route("api/[controller]")]
    //[Route("api")]
    [ApiController]
    public class BookController : ControllerBase
	{

        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        /********************** Vytvorenie knihy **********************/
        //http://localhost:5019/api/Book/CreateNewBook/Nova Kniha/Jozef Nejaky/BH7R5N
        [HttpPost]
        [Route("CreateNewBook/{nazov}/{aut}/{isbn}")]
        public IActionResult CreateNewBook(String nazov, String aut, String isbn)
        {
            _bookService.CreateBook(nazov, aut, isbn);
            return Ok("Nová kniha bola úspešne vytvorená.");
        }

        /********************** Najdenie knihy **********************/
        //http://localhost:5019/api/Book/GetBook/1
        [HttpGet]
        [Route("GetBook/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                // Zavolanie metódy servisu pre získanie knihy podľa ID
                var book = await _bookService.GetBookByIdAsync(id);
                return Ok($"Detail knihy: {book.nazov}"); // Vrátiť nájdenú knihu v odpovedi 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nastala chyba pri získavaní knihy: {ex.Message}");
            }
        }

        /********************** Update knihy **********************/
        [HttpPut]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            bool result = await _bookService.UpdateBookAsync(id, updatedBook);

            if (!result)
            {
                return NotFound(); // Knihu s daným ID sa nepodarilo nájsť
            }

            return Ok(); // Aktualizácia knihy bola úspešná
        }

        /********************** Delete knihy **********************/
        //http://localhost:5019/api/Book/DeleteBook/222
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (await _bookService.DeleteBookAsync(id))
            {
                return NoContent();
            }
            else {
                return NotFound();
            }
        }
    }
}
