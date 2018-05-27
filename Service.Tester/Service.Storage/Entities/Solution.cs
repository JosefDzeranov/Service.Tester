using System;

namespace Service.Storage.Entities
{
    /// <summary>
    /// Решение задания
    /// </summary>
    internal class Solution : EntityModel
    {
        /// <summary>
        /// УИд задания, к которой относится решение 
        /// </summary>
        public Guid ProblemId { get; set; }
        public Problem Problem { get; set; }

        /// <summary>
        /// Отправитель решения
        /// </summary>
        public Guid UserId { get; set; }
        //public User User { get; set; }

        /// <summary>
        /// На каком языке программирования решение 
        /// </summary>
        public Guid ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        /// <summary>
        /// Вердикт тестирования
        /// </summary>
        public Guid TestResultId { get; set; }
        public TestResult TestResult { get; set; }

        /// <summary>
        /// Дата отправления 
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// Название файла с решением
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; }
    }
}