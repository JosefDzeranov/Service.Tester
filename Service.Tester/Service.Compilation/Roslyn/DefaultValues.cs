using System.Collections.Generic;

namespace Service.Compilation.Roslyn
{

    /// <summary>
    /// Класс для хранения статических данных.
    /// </summary>
    internal sealed class DefaultValues
    {
        /// <summary>
        /// Путь расположения все откомпилированных файлов.
        /// </summary>
        internal const string CompilePath = @"D:\\Compilers\\";

        /// <summary>
        /// Стандартные пространства имен необходимые для компиляции кода.
        /// </summary>
        internal static readonly IEnumerable<string> SystemNamespaces =
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
        internal static readonly List<string> DefaultAssemblies = new List<string>
        {
            "mscorlib",
            "System",
            "System.Core"
        };

        /// <summary>
        /// Путь, где лежат стандартные сборки.
        /// </summary>
        internal static readonly string RuntimePath =
            @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\{0}.dll";
    }
}