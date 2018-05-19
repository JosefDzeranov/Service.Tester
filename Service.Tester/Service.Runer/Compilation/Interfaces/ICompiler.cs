using System.Collections.Generic;

namespace Service.Runner.Compilation.Interfaces
{
    /// <summary>
    /// Интерфейс для компиляции.
    /// </summary>
    public interface ICompiler
    {
        /// <summary>
        /// Метод для компиляции исходного кода.
        /// </summary>
        /// <param name="source">Исходный код</param>
        /// <param name="exeName">Имя полученного исполняемого файла</param>
        /// <param name="assemblyLocations">Расположение сборок, которые нужны при компиляции исходного кода</param>
        /// <returns>Результат компиляции</returns>
        CompileResult Compile(string source, string exeName, List<string> assemblyLocations = null);
    }
}