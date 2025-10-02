namespace Sophonics.Abstraction;

public interface IPipelineHost
{
    public Task RegisterPipeline<T>(T pipeline) where T : BasePipeline;
    
}