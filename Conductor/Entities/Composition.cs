using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conductor.Entities
{
    public class Composition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Key { get; set; }
        public string Script { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public bool Success { get; set; }
        public string Output { get; set; }

        public Artist Artist { get; set; }
    }
}
