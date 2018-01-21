using Conductor.Domain.Commands;

namespace Conductor.Domain
{
    public interface IArtistRegistrationService
    {
        void RegisterArtist(RegisterArtistCommand command);
    }
}