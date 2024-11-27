using ProjectApi.models;

namespace ProjectApi.Services
{
    public interface IArtistService
    {
        Task CreateArtist(Artist artist);
        Task DeleteArtist(int id);
        Task<List<Artist>> GetAllArtists();
        Task<Artist?> GetArtist(int id);
        Task<Artist?> UpdateArtist(int id, Artist item);
    }
}