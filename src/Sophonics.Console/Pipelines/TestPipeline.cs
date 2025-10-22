
using Sophonics.Abstraction;
using Sophonics.Models;
using System;

namespace Sophonics.Console.Pipelines;

public class TestPipeline : SophonPipeline
{
    public override void SetupPipeline()
    {
        AppendJob(new GetData());
    }
}

public class GetData : SophonJob<string>
{
    public override async Task<JobResult<BaseJob>> RunJobAsync(IPipelineContext pipelineContext, CancellationToken cancellationToken)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            using Stream contentStream = await response.Content.ReadAsStreamAsync(); // Get content as stream
            using FileStream fileStream = new FileStream($"DataFile_{Guid.NewGuid()}.json", FileMode.Create, FileAccess.Write, FileShare.None);

            await contentStream.CopyToAsync(fileStream);

            return JobResult<BaseJob>.Success(this);
        }
        catch (Exception ex)
        {

            return JobResult<BaseJob>.Failure(ex);
        }
    }
}