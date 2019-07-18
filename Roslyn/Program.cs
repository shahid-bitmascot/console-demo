using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Roslyn
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = @"
                    using System;

                    class Test
                        {
                            public void Print()
                            {
                                Console.WriteLine(DateTime.Now);
                            }
                        }
                    ";

            //var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);
            //var sourceCode = SourceText.From(code);
            //var syntaxTree = SyntaxFactory.ParseSyntaxTree(sourceCode, options);

            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            var references = new MetadataReference[]
             {
                MetadataReference.CreateFromFile("C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\2.1.11\\System.Runtime.dll"),
                MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).GetTypeInfo().Assembly.Location)
             };

            var compilation = CSharpCompilation.Create("a")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(references)
                .AddSyntaxTrees(new[] { syntaxTree });

            var assemblyName = "a.dll";
            var result = compilation.Emit(assemblyName);

            if (result.Success)
            {
                var a = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.GetFullPath(assemblyName));
                var type = a.GetType("Test");
                var instance = Activator.CreateInstance(type);
                type.GetMethod("Print").Invoke(instance, null);
            }

            Console.WriteLine("Hello World!");
        }
    }

    class Test
    {
        public void Print()
        {
            Console.WriteLine("Hello World");
        }
    }
}
