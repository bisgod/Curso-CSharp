using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip=  0, [FromQuery] int take = 10)
        {
            //http://localhost:5209/filme?skip=0&take=2
            return filmes.Skip(skip).Take(take);
        }
        
        [HttpGet("{id}")]
        public Filme? RecuperaFilmePorId(int id)
        {
                return filmes.FirstOrDefault(filme => filme.Id == id);
        }
    }
}