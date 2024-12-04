using ProjectApi.models;

namespace ProjectApi.Services
{
    public class SongService : ISongService
    {
        private static readonly List<Song> AllSongs = new();
        private static int _lastUsedID = 0;

        public Task CreateSong(Song song)
        {
            AllSongs.Add(song);
            song.Id = ++_lastUsedID;
            return Task.CompletedTask;
        }

        public Task<Song?> UpdateSong(int id, Song item)
        {
            var song = AllSongs.FirstOrDefault(x => x.Id == id);
            if (song != null)
            {
                song.Title = item.Title;
                song.ReleaseYear = item.ReleaseYear;
                song.Image = item.Image;
            }

            return Task.FromResult(song);
        }

        public Task<Song?> GetSong(int id)
        {
            return Task.FromResult(AllSongs.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Song>> GetAllSongs()
        {
            return Task.FromResult(AllSongs);
        }

        public Task DeleteSong(int id)
        {
            var song = AllSongs.FirstOrDefault(x => x.Id == id);
            if (song != null)
            {
                AllSongs.Remove(song);
            }

            return Task.CompletedTask;
        }
    }
}
