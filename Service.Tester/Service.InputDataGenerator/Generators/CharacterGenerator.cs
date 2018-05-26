using System;

namespace Service.InputDataGenerator.Generators
{
    public class CharacterGenerator : IGenerator<char>
    {
        private int From { get; }
        private int To { get; }

        public CharacterGenerator(int from, int to)
        {
            From = from;
            To = to;
        }

        public char Generate()
        {
            var random = new Random();
            return Convert.ToChar(random.Next(From, To));
        }
    }
}