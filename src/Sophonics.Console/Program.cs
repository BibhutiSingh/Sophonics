// See https://aka.ms/new-console-template for more information

using Sophonics;
using Sophonics.Console.Pipelines;

Console.WriteLine("Setting up pipeline");
SophonPipelineHost sophonPipelineHost = new SophonPipelineHost();
await sophonPipelineHost.RegisterPipeline<TestPipeline>(new TestPipeline());
