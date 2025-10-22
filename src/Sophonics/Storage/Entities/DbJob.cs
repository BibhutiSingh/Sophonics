namespace Sophonics.Storage.Entities;

public class DbJob : BaseAuditEnity
{
    public Guid JobId { get; set; }
    public string JobName { get; set; }
    public string JobAssemblyInfo { get; set; }
}