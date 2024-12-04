using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProjectApi.models;
using ProjectApi.Services;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetSong(int id)
        {
            var song = await _songService.GetSong(id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        [HttpGet("{id}/image")]
        public async Task<ActionResult<string>> GetSongImage(int id)
        {
            var song = await _songService.GetSong(id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song.Image);
        }

        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllSongs()
        {
            var songs = await _songService.GetAllSongs();
            return Ok(songs);
        }

        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(Song song)
        {
            await _songService.CreateSong(song);

            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }
            var updatedSong = await _songService.UpdateSong(id, song);
            if (updatedSong == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _songService.GetSong(id);
            if (song == null)
            {
                return NotFound();
            }

            await _songService.DeleteSong(id);
            return NoContent();
        }



    }
}
