using ProjectApi.models;

namespace ProjectApi.Services
{
    public interface ISongService
    {
        Task CreateSong(Song song);
        Task DeleteSong(int id);
        Task<List<Song>> GetAllSongs();
        Task<Song?> GetSong(int id);
        Task<Song?> UpdateSong(int id, Song item);
    }
}