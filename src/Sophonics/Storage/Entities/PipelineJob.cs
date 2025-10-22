namespace Sophonics.Storage.Entities;

public class PipelineJob : BaseAuditEnity
{
    public int PipelineId { get; set; }
    public int JobId { get; set; }
    public ICollection<PipelineJobDependency> Dependencies { get; set; } = new HashSet<PipelineJobDependency>();

}

public class PipelineJobDependency : BaseAuditEnity
{
    public int PipelineJobId { get; set; }
    public int JobId { get; set; }
    public int DependencyType { get; set; }

}