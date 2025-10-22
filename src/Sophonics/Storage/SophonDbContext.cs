using Microsoft.EntityFrameworkCore;
using Sophonics.Storage.Entities;

namespace Sophonics.Storage;

public class SophonDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=sophon.db");
    }
    public DbSet<DbJob> DbJobs { get; set; }
    public DbSet<DbPipeline> DbPipelines { get; set; }
    public DbSet<PipelineJob> PipelineJobs { get; set; }
    public DbSet<PipelineJobDependency> PipelineJobDependencies { get; set; }
    public DbSet<PipelineRun> PipelineRuns { get; set; }
    public DbSet<PipelineJobRun> PipelineJobRuns { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DbJob>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.JobId).IsUnique();
            entity.Property(e => e.JobName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.JobAssemblyInfo).IsRequired();
        });
        modelBuilder.Entity<DbPipeline>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.PipelineId).IsUnique();
            entity.Property(e => e.PipelineName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.PiplineAssemblyInfo).IsRequired();
            entity.HasMany(e => e.PipelineJobs)
                  .WithOne()
                  .HasForeignKey(pj => pj.PipelineId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<PipelineJob>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PipelineId).IsRequired();
            entity.Property(e => e.JobId).IsRequired();
            entity.HasMany(e => e.Dependencies)
                  .WithOne()
                  .HasForeignKey(d => d.PipelineJobId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<PipelineJobDependency>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PipelineJobId).IsRequired();
            entity.Property(e => e.JobId).IsRequired();
            entity.Property(e => e.DependencyType).IsRequired();
        });
        modelBuilder.Entity<PipelineRun>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PipelineId).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.Remarks).HasMaxLength(1000);
            entity.HasMany(e => e.JobRuns)
                  .WithOne()
                  .HasForeignKey(jr => jr.PipelineRunId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<PipelineJobRun>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PipelineRunId).IsRequired();
            entity.Property(e => e.JobId).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.Remarks).HasMaxLength(1000);
        });

    }
}
