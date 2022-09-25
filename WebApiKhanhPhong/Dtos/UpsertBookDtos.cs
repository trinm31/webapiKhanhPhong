using System.ComponentModel.DataAnnotations;

namespace WebApiKhanhPhong.Dtos
{
    public class UpsertBookDtos
    {
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Author { get; set; }
        [Required] 
        public int PageNumber { get; set; }
    }
}