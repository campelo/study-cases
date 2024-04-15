using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SampleGenerator;
[Generator]
public class ClassNameGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
      #if DEBUG
      if (!System.Diagnostics.Debugger.IsAttached)
        System.Diagnostics.Debugger.Launch();
      #endif
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
        var code = @"
        namespace SampleSourceGenerator;

        public static class ClassNames
        {
            public static string SayHello => ""Hello from my source generator!"";
        }
        ";

        context.AddSource("ClassNames.g.cs", code);
    }
}
