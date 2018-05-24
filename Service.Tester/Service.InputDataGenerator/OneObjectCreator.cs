using Service.InputDataGenerator.Generators;

namespace Service.InputDataGenerator
{
    public class OneObjectCreator<T> : IDataCreator
    {
        private readonly IGenerator<T> _generator;

        public OneObjectCreator(IGenerator<T> generator)
        {
            _generator = generator;
        }

        public string CreateData()
        {
            return _generator.Generate().ToString();
        }
    }
}