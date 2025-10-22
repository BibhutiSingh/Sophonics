using Sophonics.Abstraction;

namespace Sophonics;

public class SophonPipelineHost: IPipelineHost
{
    private readonly Dictionary<Guid, BasePipeline> _pipelines = new Dictionary<Guid, BasePipeline>();
    public IServiceProvider ServiceProvider { get; }
    public IPipelineExecutor PipelineExecutor { get; }
    public Storage.SophonStore PipelineStore { get;}
    public SophonPipelineHost()
    {
        PipelineStore = new Storage.SophonStore();
    }

    public Task RegisterPipeline<T>(T pipeline) where T : BasePipeline
    {
       _pipelines.Add(pipeline.PipelineId, pipeline);
       return Task.CompletedTask;
    }
}