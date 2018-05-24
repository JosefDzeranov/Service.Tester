namespace Service.InputDataGenerator.Generators
{
    public interface IGenerator<T>
    {
        T Generate();
    }
}