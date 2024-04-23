using Microsoft.CodeAnalysis;

namespace SampleGenerator;

internal sealed partial class IsEnumDefinedGenerator
{
  private static readonly SymbolDisplayFormat _format = SymbolDisplayFormat.FullyQualifiedFormat
    .WithMemberOptions(SymbolDisplayMemberOptions.IncludeContainingType);
}
