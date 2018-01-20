using System;

namespace Conductor.Domain.Artists
{
    public enum PerformanceResult
    {
        Success,
        Failure
    }

    public class PerformCommand
    {
        public readonly string CompositionKey;
        public readonly PerformanceResult Result;
        public readonly string Output;

        public PerformCommand(string compositionKey, PerformanceResult result, string output)
        {
            CompositionKey = compositionKey ?? throw new ArgumentNullException(nameof(compositionKey));
            Result = result;
            Output = output ?? throw new ArgumentNullException(nameof(output));
        }
    }
}