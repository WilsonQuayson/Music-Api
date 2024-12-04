using Microsoft.AspNetCore.Mvc;
using ProjectApi.models;
using ProjectApi.Services;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _albumService.GetAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpGet("{id}/image")]
        public async Task<ActionResult<string>> GetAlbumImage(int id)
        {
            var album = await _albumService.GetAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album.Image);
        }


        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAllAlbums()
        {
            var albums = await _albumService.GetAllAlbums();
            return Ok(albums);
        }

        [HttpPost]
        public async Task<ActionResult<Album>> CreateArtist(Album album)
        {
            await _albumService.CreateAlbum(album);

            return CreatedAtAction(nameof(GetAlbum), new { id = album.Id }, album);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlbum(int id, Album album)
        {
            if (id != album.Id)
            {
                return BadRequest();
            }
            var updatedAlbum = await _albumService.UpdateAlbum(id, album);
            if (updatedAlbum == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _albumService.GetAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            await _albumService.DeleteAlbum(id);
            return NoContent();
        }
    }
}
