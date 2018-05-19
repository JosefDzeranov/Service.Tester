namespace Service.Runner.Interfaces
{
    public interface IRunner
    {
        string Run(IBuilderProcessor builderProcessor);

        /// <summary>
        /// Запускаем исходный код на входном параметре и получаем результат 
        /// </summary>
        string Run(IBuilderProcessor builderProcessor, string input);

        /// <summary>
        /// Запускаем исходный код на входном параметре и получаем результат 
        /// </summary>
        string Run(string sourceCode, string input);
    }
}