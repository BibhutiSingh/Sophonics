using Microsoft.Extensions.Configuration;
using Sophonics.Abstraction;
using Sophonics.Enums;

namespace Sophonics;

public record SophonPipelineRunContext : IPipelineContext
{
    public Guid PipelineId { get; }
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }
    public PipelineRunOption PipelineRunOption { get; }
    public Dictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

    public SophonPipelineRunContext(Guid pipelineId, IServiceProvider serviceProvider,
        PipelineRunOption pipelineRunOption = PipelineRunOption.WaitAllModule,
        params Tuple<string, object>[] parameters)
    {
        PipelineId = pipelineId;
        ServiceProvider = serviceProvider;
        PipelineRunOption = pipelineRunOption;
        foreach (var parameter in parameters)
        {
            Parameters.Add(parameter.Item1,parameter.Item2);
        }
    }
    
}