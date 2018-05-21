namespace Service.Runner.Interfaces
{
    public interface IRunner
    {
        /// <summary>
        /// Запускаем исходный код на входном параметре и получаем результат 
        /// </summary>
        string Run(string sourceCode, string input);
    }
}