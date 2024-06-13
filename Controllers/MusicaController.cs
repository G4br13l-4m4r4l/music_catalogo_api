using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Context;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public MusicaController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Musica>> PegarTodos() {
            var musicas = _appDbContext.Musicas.AsNoTracking().ToList();

            if (musicas is null)
                return NotFound();

            return musicas;
        }

        [HttpGet("{id:int}", Name ="PegarMusica")]
        public ActionResult<Musica> PegarUm(int id) { 
            var musica = _appDbContext.Musicas.AsNoTracking().FirstOrDefault(m=> m.MusicaId == id);

            if (musica is null) return NotFound();

            return musica;
        }
        [HttpPost]
        public ActionResult CadastrarMusica(Musica musica) { 
        
            if(musica is null) return BadRequest();

            _appDbContext.Musicas.Add(musica);
            _appDbContext.SaveChanges();

            return new CreatedAtRouteResult("PegarMusica", new { id = musica.MusicaId }, musica);
        }

        [HttpPut("{id:int}")]
        public ActionResult AtualizarMusica(int id, Musica musica)
        {
            if(id != musica.MusicaId) return BadRequest();

            _appDbContext.Entry(musica).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return Ok(musica);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletarMusica(int id)
        {
            var musicaParaDeletar = _appDbContext.Musicas.FirstOrDefault(m=>m.MusicaId == id);
            if(musicaParaDeletar is null) return NotFound();

            _appDbContext.Musicas.Remove(musicaParaDeletar);
            _appDbContext.SaveChanges();

            return Ok(musicaParaDeletar);
        }

    }
}
