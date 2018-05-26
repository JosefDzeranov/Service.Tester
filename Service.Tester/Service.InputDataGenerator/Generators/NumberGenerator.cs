using System;

namespace Service.InputDataGenerator.Generators
{
    public class NumberGenerator : IGenerator<int>
    {
        private int From { get; }
        private int To { get; }

        public NumberGenerator(int from, int to)
        {
            From = from;
            To = to;
        }

        public int Generate()
        {
            var random = new Random();
            return random.Next(From, To);
        }
    }
}