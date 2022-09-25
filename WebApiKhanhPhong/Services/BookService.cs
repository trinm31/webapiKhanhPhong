using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiKhanhPhong.DbContext;
using WebApiKhanhPhong.Models;
using WebApiKhanhPhong.Services.IServices;

namespace WebApiKhanhPhong.Services
{
    public class BookService: IBookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IList<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await GetBookById(id);
        }

        public async Task Create(Book input)
        {
            await _db.Books.AddAsync(input);
            await _db.SaveChangesAsync();
        }

        public async Task Update(int id, Book input)
        {
            var book = await GetBookById(id);

            book.Name = input.Name;
            book.Author = input.Author;
            book.PageNumber = input.PageNumber;
            
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await GetBookById(id);
            _db.Remove(book);
            await _db.SaveChangesAsync();
        }

        private async Task<Book> GetBookById(int id)
        {
            return await _db.Books.FindAsync(id);
        }
    }
}