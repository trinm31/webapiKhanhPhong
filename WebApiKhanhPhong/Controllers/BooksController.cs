using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiKhanhPhong.Authorization;
using WebApiKhanhPhong.Dtos;
using WebApiKhanhPhong.Models;
using WebApiKhanhPhong.Services.IServices;

namespace WebApiKhanhPhong.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    //https:localhost:5001/api/books/
    public class BooksController:ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        //https:localhost:5001/api/books
        public async Task<IList<Book>> GetAll()
        {
            return await _bookService.GetAll();
        }

        [HttpGet("{id:int}")]
        //https:localhost:5001/api/books/{id}
        public async Task<Book> GetById([FromRoute] int id)
        {
            return await _bookService.GetById(id);
        }

        [HttpPost]
        //https:localhost:5001/api/books
        public async Task<IActionResult> Create(UpsertBookDtos bookInput)
        {
            var book = _mapper.Map<Book>(bookInput);
            await _bookService.Create(book);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        //https:localhost:5001/api/books/{id}
        public async Task<IActionResult> Update([FromRoute] int id, UpsertBookDtos bookInput)
        {
            var book = _mapper.Map<Book>(bookInput);
            await _bookService.Update(id, book);
            return StatusCode(200);
        }

        [HttpDelete("{id:int}")]
        //https:localhost:5001/api/books/{id}
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _bookService.Delete(id);
            return StatusCode(200);
        }
    }
}