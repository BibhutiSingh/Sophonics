using Microsoft.Extensions.Configuration;
using Sophonics.Enums;

namespace Sophonics.Abstraction;

public interface IPipelineContext
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }
    public PipelineRunOption PipelineRunOption { get; }
    public Dictionary<string,object> Parameters { get;}

}