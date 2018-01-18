using System;

namespace Conductor.Repositories.DTO
{
    public class CompositionDTO
    {
        public string Key { get; set; }
        public string Script { get; set; }
        public DateTime CreatedAt { get; set; }

        public CompositionDTO(string key, string script, DateTime createdAt)
        {
            Key = key;
            Script = script;
            CreatedAt = createdAt;
        }
    }
}
