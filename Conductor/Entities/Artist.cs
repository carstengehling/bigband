using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conductor.Entities
{
    public class Artist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Key { get; set; }
        public string ComputerName { get; set; }
        public string MacAddress { get; set; }

        public Ensemble Ensemble { get; set; }

        public Collection<Composition> Compositions { get; set; }
    }
}
