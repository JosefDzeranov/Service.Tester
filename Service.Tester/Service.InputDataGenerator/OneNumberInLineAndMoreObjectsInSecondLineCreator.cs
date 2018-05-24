using System.Text;
using Service.InputDataGenerator.Generators;

namespace Service.InputDataGenerator
{
    public class OneNumberInLineAndMoreObjectsInSecondLineCreator<T> : IDataCreator
    {
        private readonly IGenerator<int> _numberGenerator;
        private readonly IGenerator<T> _secondLineObjectsGenerator;

        public OneNumberInLineAndMoreObjectsInSecondLineCreator(IGenerator<int> numberGenerator,
            IGenerator<T> secondLineObjectsGenerator)
        {
            _numberGenerator = numberGenerator;
            _secondLineObjectsGenerator = secondLineObjectsGenerator;
        }

        public string CreateData()
        {
            var number = _numberGenerator.Generate();
            var result = number.ToString();
            var temp = new StringBuilder();
            for (var i = 0; i < number; i++)
            {
                temp.Append(_secondLineObjectsGenerator.Generate());
                temp.Append(" ");
            }

            return result + "\n" + temp;
        }
    }
}