using Sophonics.Enums;
using Sophonics.Models;

namespace Sophonics.Abstraction;

public abstract class BasePipeline
{
    public Guid PipelineId { get; set; }
    public IPipelineContext PipelineContext { get; }
    private List<Tuple<BaseJob, JobDependency>> _jobCollection = new List<Tuple<BaseJob, JobDependency>>();

    public virtual void AppendJob(BaseJob job, JobDependency dependency = default)
    {
        job.JobId = Guid.NewGuid();
        _jobCollection.Add(new Tuple<BaseJob, JobDependency>(job, dependency));
    }
    public abstract void SetupPipeline();

    public virtual async Task<ExcecutionResult> RunPipelineAsync(CancellationToken token)
    {
        //Simple Job runs
        var jobResults = _jobCollection.Select(async job =>
        {
            try
            {
                var result = await job.Item1.RunJobAsync(PipelineContext, token);
                return result;
            }
            catch (Exception ex)
            {
                return JobResult<BaseJob>.Failure(ex);
            }
        });
        var results = await Task.WhenAll(jobResults);
        return results.All(r => r.JobResultType == JobResultType.Success)
            ? ExcecutionResult.Success()
            : ExcecutionResult.Failure(new Exception("One or more jobs failed."));
    }
}