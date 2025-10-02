using Sophonics.Models;

namespace Sophonics.Abstraction;

public abstract class BaseJob
{
    public Guid JobId { get; internal set; }
    public abstract Task<JobResult<BaseJob>> RunJobAsync(CancellationToken  cancellationToken);
}
public abstract class BaseJob<T> : BaseJob where T : class
{
    
}