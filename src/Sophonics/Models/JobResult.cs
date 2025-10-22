using System;
using Sophonics.Abstraction;
using Sophonics.Enums;

namespace Sophonics.Models;
public class ExcecutionResult(JobResultType resultType, Exception ex)
{
    public JobResultType ExecutionResultType { get;} = resultType;
    public Exception Error { get; } = ex;

    public static ExcecutionResult Success() => new ExcecutionResult(JobResultType.Success, default);
    public static ExcecutionResult Failure(Exception ex) => new ExcecutionResult(JobResultType.Failed, ex);

}
public class JobResult<T>  where T : BaseJob
{
    public T Value { get; }
    public JobResultType JobResultType { get;}
    public Exception Error { get; }

    public JobResult(T value, JobResultType jobResult, Exception ex)
    {
        Value = value;
        JobResultType = jobResult;
        Error = ex;
    }

    public static JobResult<T> Success(T value) => new JobResult<T>(value, JobResultType.Success, default);
    public static JobResult<T> Failure(Exception ex) => new JobResult<T>(default, JobResultType.Failed, ex);

}