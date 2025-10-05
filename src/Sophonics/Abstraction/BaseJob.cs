using Sophonics.Models;

namespace Sophonics.Abstraction;

public abstract class BaseJob
{
    public Guid JobId { get; internal set; }
    public abstract Task<JobResult<BaseJob>> RunJobAsync(IPipelineContext pipelineContext, CancellationToken  cancellationToken);
}