using Microsoft.EntityFrameworkCore;
using Sophonics.Storage.Entities;

namespace Sophonics.Storage;
public class SophonStore
{
    private readonly SophonDbContext sophonDbContext;
    public SophonStore()
    {
        sophonDbContext = new SophonDbContext();
    }

    #region Pipelines
    public async Task<List<DbPipeline>> GetAllPipelines()
    {
        return await sophonDbContext.DbPipelines.Include(x => x.PipelineJobs).ThenInclude(x => x.Dependencies).ToListAsync();
    }
    public async Task<DbPipeline> GetPipelineById(int id)
    {
        return await sophonDbContext.DbPipelines.Include(x => x.PipelineJobs).ThenInclude(x => x.Dependencies).FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task InsertPipeline(DbPipeline pipeline)
    {
        await sophonDbContext.DbPipelines.AddAsync(pipeline);
        await sophonDbContext.SaveChangesAsync();
    }

    #endregion
}