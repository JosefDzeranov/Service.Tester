using Service.InputDataGenerator.Generators;

namespace Service.InputDataGenerator
{
    public class TwoObjectsOnLineCreator<T1, T2> : IDataCreator
    {
        private readonly IGenerator<T1> _firstObjectGenerator;
        private readonly IGenerator<T2> _secondObjectGenerator;

        public TwoObjectsOnLineCreator(IGenerator<T1> firstObjectGenerator, IGenerator<T2> secondObjectGenerator)
        {
            _firstObjectGenerator = firstObjectGenerator;
            _secondObjectGenerator = secondObjectGenerator;
        }

        public string CreateData()
        {
            return $"{_firstObjectGenerator} {_secondObjectGenerator}";
        }
    }
}