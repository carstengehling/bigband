using Conductor.Repositories.DTO;

namespace Conductor.Repositories
{
    public interface IArtistRepository
    {
        ArtistDTO GetArtist(string key);
        ArtistDTO CreateArtist(ArtistRegistrationDTO artistRegistration);
    }
}
