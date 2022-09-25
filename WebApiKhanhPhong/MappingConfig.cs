using AutoMapper;
using WebApiKhanhPhong.Dtos;
using WebApiKhanhPhong.Models;

namespace WebApiKhanhPhong
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UpsertBookDtos, Book>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}