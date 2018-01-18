using Conductor.Repositories.DTO;
using System.Collections.Generic;

namespace Conductor.Repositories
{
    public interface ICompositionRepository
    {
        IEnumerable<CompositionDTO> GetUnplayedCompositions(string artistKey);
        void MarkAsPerformed(string artistKey, PerformanceDTO performance);
    }
}
