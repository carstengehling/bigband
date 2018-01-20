namespace Conductor.Domain.Artists
{
    public interface IArtistRegistrationService
    {
        void RegisterArtist(RegisterArtistCommand command);
    }
}