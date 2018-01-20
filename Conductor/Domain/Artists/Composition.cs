using System;

namespace Conductor.Domain.Artists
{
    public class Composition
    {
        public readonly string Name;
        public readonly string Script;

        public Composition(string name, string script)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Script = script ?? throw new ArgumentNullException(nameof(script));
        }
    }
}
