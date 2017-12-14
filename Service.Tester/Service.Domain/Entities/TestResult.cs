using Service.Domain.ExtraModels;

namespace Service.Domain.Entities
{
    /// <summary>
    /// Варианты результатов тестирования решения
    /// </summary>
    internal class TestResult : EntityModel
    {
        /// <summary>
        /// Какой ответ от сервера
        /// </summary>
        public TestResults Result { get; set; }

        /// <summary>
        /// Полное название на русском
        /// </summary>
        public string Description { get; set; }
    }
}