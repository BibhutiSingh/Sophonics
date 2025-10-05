using Sophonics.Abstraction;

namespace Sophonics;

public class SophonPipelineHost: IPipelineHost
{
    private readonly Dictionary<Guid, BasePipeline> _pipelines = new Dictionary<Guid, BasePipeline>();
    public IServiceProvider ServiceProvider { get; }

    public Task RegisterPipeline<T>(T pipeline) where T : BasePipeline
    {
       _pipelines.Add(pipeline.PipelineId, pipeline);
       return Task.CompletedTask;
    }
}