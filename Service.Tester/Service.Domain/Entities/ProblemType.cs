using System;
using Service.Domain.ExtraModels;

namespace Service.Domain.Entities
{
    /// <summary>
    /// Тип задания
    /// </summary>
    internal class ProblemType : EntityModel
    {
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