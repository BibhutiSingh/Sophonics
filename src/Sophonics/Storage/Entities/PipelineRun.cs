namespace Sophonics.Storage.Entities;

public class PipelineRun : BaseAuditEnity
{
    public int PipelineId { get; set; }
    public RunStatus Status { get; set; }
    public string Remarks { get; set; }
    public ICollection<PipelineJobRun> JobRuns { get; set; } = new HashSet<PipelineJobRun>();

}
public class PipelineJobRun : BaseAuditEnity
{
    public int PipelineRunId { get; set; }
    public int JobId { get; set; }
    public RunStatus Status { get; set; }
    public string Remarks { get; set; }

}
public enum RunStatus
{
    Pending = 0,
    InProgress = 1,
    Completed = 2,
    Failed = 3,
    Canceled = 4,
    Skipped = 5,
    PartialSuccess = 6 //Only be used for Pipeline
}