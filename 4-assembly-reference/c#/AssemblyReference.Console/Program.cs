using AssemblyReference.Console;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<AssemblyLoad>();

// AssemblyLoad assemblyLoad = new();
// assemblyLoad.ByLoadFrom();
// assemblyLoad.ByStatic();
// assemblyLoad.ByReadOnly();
