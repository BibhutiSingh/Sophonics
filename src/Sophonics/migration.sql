CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "DbJobs" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_DbJobs" PRIMARY KEY AUTOINCREMENT,
    "JobId" TEXT NOT NULL,
    "JobName" TEXT NOT NULL,
    "JobAssemblyInfo" TEXT NOT NULL,
    "CreatedAt" TEXT NULL,
    "UpdatedAt" TEXT NULL
);

CREATE TABLE "DbPipelines" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_DbPipelines" PRIMARY KEY AUTOINCREMENT,
    "PipelineId" TEXT NOT NULL,
    "PipelineName" TEXT NOT NULL,
    "PiplineAssemblyInfo" TEXT NOT NULL,
    "CreatedAt" TEXT NULL,
    "UpdatedAt" TEXT NULL
);

CREATE TABLE "PipelineRuns" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PipelineRuns" PRIMARY KEY AUTOINCREMENT,
    "PipelineId" INTEGER NOT NULL,
    "Status" INTEGER NOT NULL,
    "Remarks" TEXT NOT NULL,
    "CreatedAt" TEXT NULL,
    "UpdatedAt" TEXT NULL
);

CREATE TABLE "PipelineJobs" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PipelineJobs" PRIMARY KEY AUTOINCREMENT,
    "PipelineId" INTEGER NOT NULL,
    "JobId" INTEGER NOT NULL,
    "CreatedAt" TEXT NULL,
    "UpdatedAt" TEXT NULL,
    CONSTRAINT "FK_PipelineJobs_DbPipelines_PipelineId" FOREIGN KEY ("PipelineId") REFERENCES "DbPipelines" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PipelineJobRuns" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PipelineJobRuns" PRIMARY KEY AUTOINCREMENT,
    "PipelineRunId" INTEGER NOT NULL,
    "JobId" INTEGER NOT NULL,
    "Status" INTEGER NOT NULL,
    "Remarks" TEXT NOT NULL,
    "CreatedAt" TEXT NULL,
    "UpdatedAt" TEXT NULL,
    CONSTRAINT "FK_PipelineJobRuns_PipelineRuns_PipelineRunId" FOREIGN KEY ("PipelineRunId") REFERENCES "PipelineRuns" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PipelineJobDependencies" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PipelineJobDependencies" PRIMARY KEY AUTOINCREMENT,
    "PipelineJobId" INTEGER NOT NULL,
    "JobId" INTEGER NOT NULL,
    "DependencyType" INTEGER NOT NULL,
    "CreatedAt" TEXT NULL,
    "UpdatedAt" TEXT NULL,
    CONSTRAINT "FK_PipelineJobDependencies_PipelineJobs_PipelineJobId" FOREIGN KEY ("PipelineJobId") REFERENCES "PipelineJobs" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_DbJobs_JobId" ON "DbJobs" ("JobId");

CREATE UNIQUE INDEX "IX_DbPipelines_PipelineId" ON "DbPipelines" ("PipelineId");

CREATE INDEX "IX_PipelineJobDependencies_PipelineJobId" ON "PipelineJobDependencies" ("PipelineJobId");

CREATE INDEX "IX_PipelineJobRuns_PipelineRunId" ON "PipelineJobRuns" ("PipelineRunId");

CREATE INDEX "IX_PipelineJobs_PipelineId" ON "PipelineJobs" ("PipelineId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20251010062720_InitialCreate', '9.0.9');

COMMIT;

