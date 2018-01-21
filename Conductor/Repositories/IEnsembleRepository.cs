using Conductor.Repositories.DTO;

namespace Conductor.Repositories
{
    public interface IEnsembleRepository
    {
        EnsembleDTO GetEnsemble(string key);
    }
}
