namespace Sophonics.Abstraction;

public interface IPipelineExecutor
{
    public Task RunPipelineByName(string pipelineName);
}