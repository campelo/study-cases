using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SampleGenerator;
[Generator(LanguageNames.CSharp)]
public class ClassNameGenerator : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValuesProvider<ClassDeclarationSyntax> provider = context
      .SyntaxProvider
      .CreateSyntaxProvider(
        predicate: (c, _) => c.IsKind(SyntaxKind.ClassDeclaration), // c is ClassDeclarationSyntax
        transform: (n, _) => (ClassDeclarationSyntax)n.Node)
      .Where(m => m is not null);

    var compilation = context
      .CompilationProvider
      .Combine(provider.Collect());

    context
      .RegisterSourceOutput(compilation,
        (spc, source) => Execute(spc, source.Left, source.Right));
  }

  private void Execute(SourceProductionContext context,
    Compilation compilation,
    ImmutableArray<ClassDeclarationSyntax> types)
  {
#if DEBUG
    if (!System.Diagnostics.Debugger.IsAttached)
      System.Diagnostics.Debugger.Break();
#endif
    if (types.Length == 0)
      context.ReportDiagnostic(Diagnostic.Create(
        new DiagnosticDescriptor(
          "SG0001",
          "No class found",
          "No class found in the project",
          "SampleSourceGenerator",
          DiagnosticSeverity.Warning,
          true),
        Location.None));

    var strBuilder = new StringBuilder();

    foreach (var type in types)
    {
      var symbol = compilation
        .GetSemanticModel(type.SyntaxTree)
        .GetDeclaredSymbol(type) as INamedTypeSymbol;

      if (symbol is null)
        continue;

      strBuilder.AppendLine();
      strBuilder.AppendLine($"\t\"{symbol.ToDisplayString()}\",");
    }

    if (strBuilder.Length > 0)
      strBuilder.Length--;

    var code = $$"""
        namespace SampleSourceGenerator;

        public static class ClassNames
        {
          public static List<string> Names = new List<string>()
          {
            {{strBuilder.ToString()}}
          };
        }
        """;

    context.AddSource("ClassNames.g.cs", code);
  }
}
