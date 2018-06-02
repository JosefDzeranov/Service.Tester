namespace Service.Runner.Interfaces
{
    public interface IRunner
    {
        string Run(string sourceCode, string input);

        string Run(string sourceCode);
    }
}