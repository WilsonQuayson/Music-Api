using ProjectApi.models;

namespace ProjectApi.Services
{
    public interface IAlbumService
    {
        Task CreateAlbum(Album album);
        Task DeleteAlbum(int id);
        Task<Album?> GetAlbum(int id);
        Task<List<Album>> GetAllAlbums();
        Task<Album?> UpdateAlbum(int id, Album item);
    }
}