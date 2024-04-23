using System.Collections.Immutable;

namespace SampleGenerator;

internal sealed partial class IsEnumDefinedGenerator
{
  private readonly record struct IsEnumDefinedType(
        bool IsGlobalNamespace,
        string Namespace,
        string Name,
        ImmutableArray<IsEnumDefinedMethod> Methods)
    {
        public string GetFullName()
        {
            if (IsGlobalNamespace)
            {
                return Name;
            }
            else
            {
                return $"{Namespace}.{Name}";
            }
        }
    }
    
  private readonly record struct IsEnumDefinedMethod(
        string EnumName,
        ImmutableArray<string> EnumConstants);
}
