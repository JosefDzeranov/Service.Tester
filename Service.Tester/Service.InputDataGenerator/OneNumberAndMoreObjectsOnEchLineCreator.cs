using System.Text;
using Service.InputDataGenerator.Generators;

namespace Service.InputDataGenerator
{
    public class OneNumberAndMoreObjectsOnEchLineCreator<T> : IDataCreator
    {
        private readonly IGenerator<int> _numberGenerator;
        private readonly IGenerator<T> _objectsOnLinesGenerator;

        public OneNumberAndMoreObjectsOnEchLineCreator(IGenerator<int> numberGenerator,
            IGenerator<T> objectsOnLinesGenerator)
        {
            _numberGenerator = numberGenerator;
            _objectsOnLinesGenerator = objectsOnLinesGenerator;
        }

        public string CreateData()
        {
            var number = _numberGenerator.Generate();
            var result = number.ToString();
            var temp = new StringBuilder(2 * number);
            for (var i = 0; i < number; i++)
            {
                temp.Append(_objectsOnLinesGenerator.Generate());
                temp.Append(" ");
            }

            return result + "\n" + temp;
        }
    }
}