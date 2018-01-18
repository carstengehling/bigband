using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conductor.Entities
{
    public class Ensemble
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Key { get; set; }
        public string Name { get; set; }
        public string RegistrationKey { get; set; }

        public Collection<Artist> Artists { get; set; }
    }
}
