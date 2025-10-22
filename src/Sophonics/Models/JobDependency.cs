using Sophonics.Abstraction;
using Sophonics.Enums;

namespace Sophonics.Models;

public class JobDependency
{
    public BaseJob DependsOnJob { get; }
    public JobResultType DependsOnCondition { get; }

    public JobDependency(BaseJob dependsOnJob, JobResultType dependsOnCondition)
    {
        DependsOnJob = dependsOnJob;
        DependsOnCondition = dependsOnCondition;
    }
}