using Conductor.Domain.Commands;
using System;
using System.Collections.Generic;

namespace Conductor.Domain
{
    public class Artist
    {
        public readonly string Key;

        public readonly string ComputerName;
        public readonly string MacAddress;

        public IEnumerable<Composition> GetUnplayedCompositions()
        {
            throw new NotImplementedException();
        }

        public void PerformComposistion(PerformCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
