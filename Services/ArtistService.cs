using ProjectApi.models;

namespace ProjectApi.Services
{
    public class ArtistService : IArtistService
    {
        private static readonly List<Artist> AllArtists = new();
        private static int _lastUsedID = 0;

        public Task CreateArtist(Artist artist)
        {
            AllArtists.Add(artist);
            artist.Id = ++_lastUsedID;
            return Task.CompletedTask;
        }

        public Task<Artist?> UpdateArtist(int id, Artist item)
        {
            var artist = AllArtists.FirstOrDefault(x => x.Id == id);
            if (artist != null)
            {
                artist.Name = item.Name;
                artist.Genre = item.Genre;
                artist.Bio = item.Bio;
                artist.DebutYear = item.DebutYear;
                artist.Image = item.Image;
            }

            return Task.FromResult(artist);
        }

        public Task<Artist?> GetArtist(int id)
        {
            return Task.FromResult(AllArtists.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Artist>> GetAllArtists()
        {
            return Task.FromResult(AllArtists);
        }

        public Task DeleteArtist(int id)
        {
            var artist = AllArtists.FirstOrDefault(x => x.Id == id);
            if (artist != null)
            {
                AllArtists.Remove(artist);
            }

            return Task.CompletedTask;
        }
    }
}
