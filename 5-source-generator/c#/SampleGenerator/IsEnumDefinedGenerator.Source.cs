using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SampleGenerator;

internal sealed partial class IsEnumDefinedGenerator
{
  private readonly record struct IsEnumDefinedSource(
    ClassDeclarationSyntax Node, 
    INamedTypeSymbol Symbol, 
    ImmutableArray<AttributeData> Attributes)
    {
    }
}
