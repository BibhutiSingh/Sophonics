namespace Sophonics.Storage.Entities;

public class DbPipeline : BaseAuditEnity
{
    public Guid PipelineId { get; set; }
    public string PipelineName { get; set; }
    public string PiplineAssemblyInfo { get; set; }

    public ICollection<PipelineJob> PipelineJobs { get; set; }= new HashSet<PipelineJob>();
}