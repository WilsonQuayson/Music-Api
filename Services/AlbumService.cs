using ProjectApi.models;

namespace ProjectApi.Services
{
    public class AlbumService : IAlbumService
    {
        private static readonly List<Album> AllAlbums = new();
        private static int _lastUsedID = 0;

        public Task CreateAlbum(Album album)
        {
            AllAlbums.Add(album);
            album.Id = ++_lastUsedID;
            return Task.CompletedTask;
        }

        public Task<Album?> UpdateAlbum(int id, Album item)
        {
            var album = AllAlbums.FirstOrDefault(x => x.Id == id);
            if (album != null)
            {
                album.Title = item.Title;
                album.ReleaseYear = item.ReleaseYear;
                album.Image = item.Image;
            }

            return Task.FromResult(album);
        }

        public Task<Album?> GetAlbum(int id)
        {
            return Task.FromResult(AllAlbums.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Album>> GetAllAlbums()
        {
            return Task.FromResult(AllAlbums);
        }

        public Task DeleteAlbum(int id)
        {
            var album = AllAlbums.FirstOrDefault(x => x.Id == id);
            if (album != null)
            {
                AllAlbums.Remove(album);
            }

            return Task.CompletedTask;
        }
    }
}
