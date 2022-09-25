using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiKhanhPhong.DbContext;
using WebApiKhanhPhong.Models;

namespace WebApiKhanhPhong.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //https:localhost:5001/api/books/
    public class BooksController:ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        //https:localhost:5001/api/books
        public IList<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        [HttpGet("{id:int}")]
        //https:localhost:5001/api/books/{id}
        public Book GetById([FromRoute] int id)
        {
            return _db.Books.Find(id);
        }

        [HttpPost]
        //https:localhost:5001/api/books
        public IActionResult Create(Book bookInput)
        {
            _db.Books.Add(bookInput);
            _db.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        //https:localhost:5001/api/books/{id}
        public IActionResult Update([FromRoute] int id, Book bookInput)
        {
            var book = _db.Books.Find(id);

            book.Name = bookInput.Name;
            book.Author = bookInput.Author;
            book.PageNumber = bookInput.PageNumber;

            _db.Books.Update(book);
            _db.SaveChanges();

            return StatusCode(200);
        }

        [HttpDelete("{id:int}")]
        //https:localhost:5001/api/books/{id}
        public IActionResult Delete([FromRoute] int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();

            return StatusCode(200);
        }
    }
}