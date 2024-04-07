using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace AssemblyReference.Console;

public class AssemblyLoad
{
  [Benchmark]
  public void ByLoadFrom()
  {
    string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    string assemblyPath = Path.Combine(currentFolder, "AssemblyReference.dll");
    Assembly assembly = Assembly.LoadFrom(assemblyPath);
    WriteAssemblyInformation(assembly);
  }

  private static void WriteAssemblyInformation(Assembly assembly)
  {
    Type[] types1 = assembly.GetTypes();
    foreach (Type type in types1)
    {
      System.Console.WriteLine(type.FullName);
      MethodInfo[] methods = type.GetMethods();
      foreach (MethodInfo method in methods)
      {
        System.Console.WriteLine(method.Name);
        ParameterInfo[] parameters = method.GetParameters();
        foreach (ParameterInfo parameter in parameters)
        {
          System.Console.WriteLine(parameter.Name);
        }
      }
    }
  }

  [Benchmark]
  public void ByStatic()
  {
    Assembly assembly = AssemblyReference.StaticReference;
    WriteAssemblyInformation(assembly);
  }

  [Benchmark]
  public void ByReadOnly()
  {
    Assembly assembly = AssemblyReference.ReadOnlyReference;
    WriteAssemblyInformation(assembly);
  }
}
