using System.Collections.Generic;

namespace Service.Common
{

    /// <summary>
    /// Класс для хранения статических данных.
    /// </summary>
    public sealed class DefaultValues
    {
        /// <summary>
        /// Путь расположения все откомпилированных файлов.
        /// </summary>
        public const string CompilePath = @"D:\\Compilers\\";

        /// <summary>
        /// Стандартные пространства имен необходимые для компиляции кода.
        /// </summary>
        public static readonly IEnumerable<string> SystemNamespaces =
            new[]
            {
                "System",
                "System.IO",
                "System.Net",
                "System.Linq",
                "System.Text",
                "System.Text.RegularExpressions",
                "System.Collections.Generic"
            };

        /// <summary>
        /// Стнадартные сборки необходимые для компиляции кода.
        /// </summary>
        public static readonly List<string> DefaultAssemblies = new List<string>
        {
            "mscorlib",
            "System",
            "System.Core"
        };

        /// <summary>
        /// Путь, где лежат стандартные сборки.
        /// </summary>
        public static readonly string RuntimePath =
            @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\{0}.dll";


        public static string sourceCode = @"
using System;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello world"");
        }
    }
}";
    }
}