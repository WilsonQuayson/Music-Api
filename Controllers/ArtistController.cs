using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProjectApi.models;
using ProjectApi.Services;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artistService.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet("{id}/image")]
        public async Task<ActionResult<string>> GetArtistImage(int id)
        {
            var artist = await _artistService.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist.Image);
        }


        [HttpGet]
        public async Task<ActionResult<List<Artist>>> GetAllArtist()
        {
            var artists = await _artistService.GetAllArtists();
            return Ok(artists);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
        {
            await _artistService.CreateArtist(artist);

            return CreatedAtAction(nameof(GetArtist), new {id = artist.Id}, artist);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArtist(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }
            var updatedArtist = await _artistService.UpdateArtist(id, artist);
            if (updatedArtist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artistService.DeleteArtist(id);
            return NoContent();
        }



    }
}
