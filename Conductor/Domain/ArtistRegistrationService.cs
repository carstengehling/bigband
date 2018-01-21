using Conductor.Domain.Commands;
using Conductor.Repositories;
using Conductor.Repositories.DTO;
using System;

namespace Conductor.Domain
{
    public class ArtistRegistrationService : IArtistRegistrationService
    {
        private IArtistRepository _artists;
        private IEnsembleRepository _ensembles;

        public ArtistRegistrationService(IArtistRepository artists, IEnsembleRepository ensembles)
        {
            _artists = artists ?? throw new ArgumentNullException(nameof(artists));
            _ensembles = ensembles ?? throw new ArgumentNullException(nameof(ensembles));
        }

        public void RegisterArtist(RegisterArtistCommand command)
        {
            if (KeyAlreadyRegisteredOnDifferentMacAddress(command.Key, command.MacAddress))
                throw new Exception($"Key {command.Key} already used by different Artist");
                
            var ensemble = _ensembles.GetEnsemble(command.EnsembleKey);
            if (ensemble == null)
                throw new ArgumentException($"Ensemble not found: {command.EnsembleKey}");

            if (command.RegistrationKey != ensemble.RegistrationKey)
                throw new Exception($"Registration key does not match that of the Ensemble");

            var artist = new ArtistDTO
            {
                Key = command.Key,
                ComputerName = command.ComputerName,
                MacAddress = command.MacAddress
            };

            _artists.CreateArtist(artist);
            _artists.BindArtistToEnsemble(artist, ensemble);
        }

        private bool KeyAlreadyRegisteredOnDifferentMacAddress(string key, string macAddress)
        {
            var artist = _artists.GetArtist(key);
            if (artist == null)
                return false;

            return artist.MacAddress != macAddress;
        }
    }
}
