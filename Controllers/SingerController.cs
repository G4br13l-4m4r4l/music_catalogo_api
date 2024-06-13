using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Context;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public SingerController(AppDbContext appDbContext)
        {
               _appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Singer>> PegarTodos()
        {
            var singers = _appDbContext.Singers.Include(s=>s.Musicas).Where(c=>c.SingerId <=6).AsNoTracking().ToList();
            if(singers is null)
            {
                return NotFound();
            }

            return singers;
        }

        [HttpGet("{id:int}",Name ="ObterSinger")]
        public ActionResult<Singer> PegarUm(int id) {
            var singer = _appDbContext.Singers.AsNoTracking().FirstOrDefault(singer => singer.SingerId == id);
            if (singer is null)
            {
                return NotFound();
            }

            return singer;
        }

        [HttpPost]
        public ActionResult CriarSinger(Singer singer)
        {
            if (singer is null)
                return BadRequest();

            _appDbContext.Singers.Add(singer);
            _appDbContext.SaveChanges();

            return new CreatedAtRouteResult("ObterSinger", new {id = singer.SingerId }, singer);
        }

        [HttpPut("{id:int}")]
        public ActionResult AtualizarSinger(int id, Singer singer)
        {
            if(id!= singer.SingerId)
                return BadRequest();

            _appDbContext.Entry(singer).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return Ok(singer);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletarSinger(int id)
        {
            var singerParaDeletar = _appDbContext.Singers.FirstOrDefault(s => s.SingerId == id);

            if(singerParaDeletar is null)
                return NotFound("Singer não encontrado");

            _appDbContext.Singers.Remove(singerParaDeletar);
            _appDbContext.SaveChanges();

            return Ok(singerParaDeletar);
        }
    }
}
