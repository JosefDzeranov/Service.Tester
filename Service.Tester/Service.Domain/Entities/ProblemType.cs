using System;
using Service.Domain.ExtraModels;

namespace Service.Domain.Entities
{
    /// <summary>
    /// Тип задания
    /// </summary>
    public class ProblemType
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Имя типа задания
        /// </summary>
        public ProblemTypes Name { get; set; }

        /// <summary>
        /// Полное название типа задания
        /// </summary>
        public string FullName { get; set; }
    }
}