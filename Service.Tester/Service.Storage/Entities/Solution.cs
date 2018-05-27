using System;

namespace Service.Storage.Entities
{
    /// <summary>
    /// Решение задания
    /// </summary>
    internal class Solution : EntityModel
    {
        public Problem Problem { get; set; }

        /// <summary>
        /// Отправитель решения
        /// </summary>
        public  ApplicationUser User { get; set; }
        
        /// <summary>
        /// Вердикт тестирования
        /// </summary>
        public TestResult Status { get; set; }

        /// <summary>
        /// Дата отправления 
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public string Input { get; set; }
    }
}