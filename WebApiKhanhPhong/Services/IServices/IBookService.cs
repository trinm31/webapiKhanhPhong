using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiKhanhPhong.Models;

namespace WebApiKhanhPhong.Services.IServices
{
    public interface IBookService
    {
        Task<IList<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Create(Book input);
        Task Update(int id, Book input);
        Task Delete(int id);
    }
}