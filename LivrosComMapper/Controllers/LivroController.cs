using AutoMapper;
using LivrosComMapper.Dtos;
using LivrosComMapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrosComMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly IMapper _mapper;
        public List<LivroModel> livros = new List<LivroModel>
        {
            new LivroModel
            {
                Id = 1,
                Titulo = "Livro 1",
                Autor = "Autor A",
                ISBN = "ISB123456",
                DataCadastro = new DateTime(2024, 02, 05)
            },
            new LivroModel
            {
                Id = 2,
                Titulo = "Livro 2",
                Autor = "Autor B",
                ISBN = "ISB123457",
                DataCadastro = new DateTime(2023, 03, 07)
            },
            new LivroModel
            {
                Id = 3,
                Titulo = "Livro 3",
                Autor = "Autor C",
                ISBN = "ISB123458",
                DataCadastro = new DateTime(2024, 05, 25)
            },
            new LivroModel
            {
                Id = 4,
                Titulo = "Livro 4",
                Autor = "Autor D",
                ISBN = "ISB123459",
                DataCadastro = new DateTime(2022, 02, 15)
            },
        };

        public LivroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("BuscaLivrosSemAutoMapper")]
        public ActionResult<List<LivroModel>> BuscaLivrosSemMapper()
        {
            return Ok(livros);
        }

        [HttpGet("BuscaLivrosComAutoMapper")]
        public ActionResult<List<LivroModel>> BuscaLivrosComMapper()
        {
            var livrosDto = _mapper.Map<List<LivroVisualizacaoDto>>(livros);
            return Ok(livrosDto);
        }

        [HttpPost("CriarLivros")]
        public ActionResult<List<LivroModel>> CriarLivros(LivroCriacaoDto livro)
        {
            var livroModel = _mapper.Map<LivroModel>(livro);
            livroModel.Id = livros.Last().Id + 1;

            livros.Add(livroModel);
            return Ok(livros);
        }
    }
}
