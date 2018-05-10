using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCodeDom
{
    public class CodeDomExample
    {
        public static CodeCompileUnit BuildHelloWorldGraph()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace samples = new CodeNamespace("ChaoTestSamples");
            compileUnit.Namespaces.Add(samples);
            samples.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("HelloWorldClass");
            samples.Types.Add(class1);
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Hello World!"));
            start.Statements.Add(cs1);
            CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Press the Enter key to continue."));

            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2);

            // Build a call to System.Console.ReadLine.
            CodeMethodInvokeExpression csReadLine = new CodeMethodInvokeExpression(
                csSystemConsoleType, "ReadLine");

            // Add the ReadLine statement.
            start.Statements.Add(csReadLine);

            // Add the code entry point method to
            // the Members collection of the type.
            class1.Members.Add(start);
            return compileUnit;
        }

        public static void GenerateCode(CodeDomProvider provider,
            CodeCompileUnit compileunit)
        {
            // Build the source file name with the appropriate
            // language extension.
            String sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "TestGraph" + provider.FileExtension;
            }
            else
            {
                sourceFile = "TestGraph." + provider.FileExtension;
            }

            // Create an IndentedTextWriter, constructed with
            // a StreamWriter to the source file.
            IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(sourceFile, false), "    ");
            // Generate source code using the code generator.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions());
            // Close the output file.
            tw.Close();
        }

        public static CompilerResults CompileCode(CodeDomProvider provider,
                                                  String sourceFile,
                                                  String exeFile)
        {
            // Configure a CompilerParameters that links System.dll
            // and produces the specified executable file.
            String[] referenceAssemblies = { "System.dll" };
            CompilerParameters cp = new CompilerParameters(referenceAssemblies,
                                                           exeFile, false);
            // Generate an executable rather than a DLL file.
            cp.GenerateExecutable = true;

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);
            // Return the results of compilation.
            return cr;
        }
        public static void Main(string []args)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            GenerateCode(provider, BuildHelloWorldGraph());
            String sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "TestGraph" + provider.FileExtension;
            }
            else
            {
                sourceFile = "TestGraph." + provider.FileExtension;
            }

            // Compile the source file into an executable output file.
            CompilerResults cr = CodeDomExample.CompileCode(provider,
                                                            sourceFile,
                                                            "TestGraph.exe");
            Process.Start("TestGraph.exe");
            Console.Read();
        }
    }
}
