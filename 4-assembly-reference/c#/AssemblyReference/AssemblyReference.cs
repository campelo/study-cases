using System.Reflection;

namespace AssemblyReference;

public static class AssemblyReference
{
  public static Assembly StaticReference => typeof(AssemblyReference).Assembly;
  public static readonly Assembly ReadOnlyReference = typeof(AssemblyReference).Assembly;
}
