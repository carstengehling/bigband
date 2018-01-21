using Conductor.Repositories.DTO;

namespace Conductor.Repositories
{
    public interface IArtistRepository
    {
        ArtistDTO GetArtist(string key);
        ArtistDTO GetArtistByMacAddress(string macAddress);

        void CreateArtist(ArtistDTO artist);

        void BindArtistToEnsemble(ArtistDTO artist, EnsembleDTO ensemble);
    }
}
