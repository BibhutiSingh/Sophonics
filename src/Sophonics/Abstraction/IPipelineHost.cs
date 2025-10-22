namespace Sophonics.Abstraction;

public interface IPipelineHost
{
    public IServiceProvider ServiceProvider { get;  }
    public Task RegisterPipeline<T>(T pipeline) where T : BasePipeline;
    
}