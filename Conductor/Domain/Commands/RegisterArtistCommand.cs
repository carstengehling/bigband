using System;

namespace Conductor.Domain.Commands
{
    public class RegisterArtistCommand
    {
        public readonly string Key;

        public readonly string ComputerName;
        public readonly string MacAddress;

        public readonly string EnsembleKey;
        public readonly string RegistrationKey;

        public RegisterArtistCommand(string key, string computerName, string macAddress, string ensembleKey, string registrationKey)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            ComputerName = computerName ?? throw new ArgumentNullException(nameof(computerName));
            MacAddress = macAddress ?? throw new ArgumentNullException(nameof(macAddress));
            EnsembleKey = ensembleKey ?? throw new ArgumentNullException(nameof(ensembleKey));
            RegistrationKey = registrationKey ?? throw new ArgumentNullException(nameof(registrationKey));
        }
    }
}
