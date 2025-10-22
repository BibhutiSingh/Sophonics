namespace Sophonics.Storage.Entities;

public abstract class BaseEnity
{
    public int Id { get; set; }
}
public abstract class BaseAuditEnity : BaseEnity
{
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
}
