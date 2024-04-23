﻿using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Globalization;
using System.CodeDom.Compiler;

namespace SampleGenerator;

[Generator(LanguageNames.CSharp)]
internal sealed partial class IsEnumDefinedGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static void (IncrementalGeneratorPostInitializationContext context) =>{
          context.AddSource("Gen.Sample.IsEnumDefinedAttribute.g.cs", SourceText.From(_isEnumDefinedAttributeSource, Encoding.UTF8));
        });

        var source = context.SyntaxProvider
          .ForAttributeWithMetadataName("Gen.Sample.IsEnumDefinedAttribute`1",
            static bool (SyntaxNode node, CancellationToken cancellationToken) => {
              return node is ClassDeclarationSyntax classDeclarationSyntax 
                && classDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword);
            },
            static IsEnumDefinedSource (GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken) =>{
              Debug.Assert(context.TargetNode is ClassDeclarationSyntax);
              Debug.Assert(context.TargetSymbol is INamedTypeSymbol);
              Debug.Assert(!context.Attributes.IsEmpty);

              var node = (ClassDeclarationSyntax)context.TargetNode;
              var symbol = (INamedTypeSymbol)context.TargetSymbol;
              return new IsEnumDefinedSource(node, symbol, context.Attributes);
            })
          .Collect()
          .SelectMany(static ImmutableArray<IGrouping<ISymbol?, IsEnumDefinedSource>> (ImmutableArray<IsEnumDefinedSource> sources, CancellationToken cancellationToken) => {
            return sources
              .GroupBy(s => s.Symbol, SymbolEqualityComparer.Default)
              .ToImmutableArray();
          })
          .Select(static IsEnumDefinedType (IGrouping<ISymbol?, IsEnumDefinedSource> sources, CancellationToken cancellationToken) => {
            var source = sources.First();
            var methods = ImmutableArray.CreateBuilder<IsEnumDefinedMethod>(source.Attributes.Length);

            foreach (AttributeData attribute in source.Attributes)
            {
              Debug.Assert(attribute.AttributeClass is not null);
              Debug.Assert(attribute.AttributeClass.TypeArguments.Length == 1);

              ITypeSymbol enumeration = attribute.AttributeClass.TypeArguments[0];
              Debug.Assert(enumeration is INamedTypeSymbol { EnumUnderlyingType: not null });

              IsEnumDefinedMethod method = new(enumeration.ToDisplayString(_format),
                enumeration.GetMembers()
                  .Where(static bool (ISymbol member) => member.Kind == SymbolKind.Field)
                  .Select(static string (ISymbol field) => field.ToDisplayString(_format))
                  .ToImmutableArray());
              methods.Add(method);
            }

            Debug.Assert(methods.Capacity == source.Attributes.Length);
            Debug.Assert(methods.Count == source.Attributes.Length);

            return new IsEnumDefinedType(source.Symbol.ContainingNamespace.IsGlobalNamespace,
              source.Symbol.ContainingNamespace.ToDisplayString(),
              source.Symbol.Name,
              methods.MoveToImmutable());
          })
          .WithComparer(_comparer);

          context.RegisterSourceOutput(source, static void (SourceProductionContext context, IsEnumDefinedType source) => {
            Debug.Assert(!source.Methods.IsEmpty);

            StringBuilder strBuilder = new();
            using StringWriter strWriter = new(strBuilder, CultureInfo.InvariantCulture);
            using IndentedTextWriter document = new(strWriter, "  ");

            document.WriteLine("// <auto-generated/>");
            document.WriteLine("#nullable enable");
            document.WriteLineNoTabs(null!);

            if (!source.IsGlobalNamespace)
            {
              document.WriteLine($"namespace {source.Namespace};");
              document.WriteLineNoTabs(null!);
            }

            document.WriteLine($"partial class {source.Name}");
            document.WriteLine('{');
            document.Indent++;

            for (int i = 0; i < source.Methods.Length; i++)
            {
                IsEnumDefinedMethod method = source.Methods[i];

                document.WriteLine($"[{_generatedCodeAttribute}]");
                document.WriteLine($"public static bool IsDefined({method.EnumName} value)");
                document.WriteLine('{');
                document.Indent++;

                if (method.EnumConstants.IsEmpty)
                    document.WriteLine("return false;");
                else
                {
                    document.WriteLine("return value is");
                    document.Indent++;
                    for (int j = 0; j < method.EnumConstants.Length; j++)
                    {
                        string constant = method.EnumConstants[j];
                        document.Write(constant);
                        if (j + 1 < method.EnumConstants.Length)
                            document.WriteLine(" or");
                        else
                            document.WriteLine(';');
                    }
                    document.Indent--;
                }

                document.Indent--;
                document.WriteLine('}');

                if (i + 1 < source.Methods.Length)
                    document.WriteLineNoTabs(null!);
            }
            
            document.Indent--;
            document.WriteLine('}');

            Debug.Assert(document.Indent == 0);

            context.AddSource($"{source.GetFullName()}.IsDefined.g.cs", strWriter.ToString());
          });
    }
}
