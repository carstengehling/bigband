using Conductor.Entities;
using Conductor.Repositories.DTO;
using System;

namespace Conductor.Repositories.Adapters
{
    public class DbArtistRepository : IArtistRepository
    {
        private ApplicationContext _context;

        public DbArtistRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArtistDTO GetArtist(string key)
        {
            throw new System.NotImplementedException();
        }

        public ArtistDTO GetArtistByMacAddress(string macAddress)
        {
            throw new NotImplementedException();
        }

        /*
        public ArtistDTO CreateArtist(ArtistRegistrationDTO registration)
        {
            var ensemble = _context.Ensembles.FirstOrDefault(e => e.Key == registration.EnsembleKey);
            if (ensemble == null)
                throw new ArgumentException($"Ensemble not found: {registration.EnsembleKey}");

            var artist = new Artist
            {
                Key = registration.Key,
                ComputerName = registration.ComputerName,
                MacAddress = registration.MacAddress,
                Ensemble = ensemble
            };

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return new ArtistDTO
            {
                Key = artist.Key,
                ComputerName = artist.ComputerName,
                MacAddress = artist.MacAddress
            };
        }
        */

        public void CreateArtist(ArtistDTO artist)
        {
            throw new NotImplementedException();
        }

        public void BindArtistToEnsemble(ArtistDTO artist, EnsembleDTO ensemble)
        {
            throw new NotImplementedException();
        }
    }
}
