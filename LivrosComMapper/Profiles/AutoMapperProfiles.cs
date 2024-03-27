using AutoMapper;
using LivrosComMapper.Dtos;
using LivrosComMapper.Models;

namespace LivrosComMapper.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LivroModel, LivroVisualizacaoDto>();
            CreateMap<LivroCriacaoDto, LivroModel>();
        }
    }
}
