using System;
using Datapac_uloha.Data;
using Datapac_uloha.Models;

namespace Datapac_uloha.Service
{
    public class BookService
    {

        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public String CreateBook(String nazov, String aut, String isbn)
        {
            // Vytvorenie nového záznamu
            var newBook = new Book
            {
                nazov = nazov,
                autor = aut,
                isbn = isbn
            };

            // Pridanie nového záznamu do kontextu
            _context.kniha.Add(newBook);

            // Uloženie zmien do databázy
            _context.SaveChanges();

            return "Nová kniha bola úspešne vytvorený.";
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _context.kniha.FindAsync(id);

                if (book == null)
                {
                    throw new Exception($"Kniha s ID {id} nebola nájdená.");
                }

                return book;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nastala chyba.");
            }
        }

        public async Task<bool> UpdateBookAsync(int id, Book updatedBook)
        {
            try
            {
                var existingBook = await _context.kniha.FindAsync(id);

                if (existingBook == null)
                {
                    return false; // Knihu s daným ID sa nepodarilo nájsť
                }

                existingBook.nazov = updatedBook.nazov;
                existingBook.autor = updatedBook.autor;
                existingBook.isbn = updatedBook.isbn;

                _context.kniha.Update(existingBook);
                await _context.SaveChangesAsync();

                return true; // Aktualizácia knihy úspešná
            }
            catch (Exception)
            {
                return false; // Nastala chyba pri aktualizácii knihy
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var bookToDelete = await _context.kniha.FindAsync(id);

            if (bookToDelete == null)
            {
                // Kniha s daným ID nebola nájdená, vrátime false
                return false;
            }

            try
            {
                _context.kniha.Remove(bookToDelete);
                await _context.SaveChangesAsync();
                // Vrátime true, čo znamená, že vymazanie prebehlo úspešne
                return true;
            }
            catch (Exception)
            {
                // Ak sa vyskytne chyba pri vymazávaní, vrátime false
                return false;
            }
        }
    }
}

