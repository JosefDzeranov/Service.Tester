using System;
using System.Collections.Generic;

namespace Service.Domain.Entities
{
    /// <summary>
    /// Модель задания
    /// </summary>
    internal class Problem : EntityModel
    {
        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        public Guid? TypeId { get; set; }
        /// <summary>
        /// Тип задания
        /// </summary>
        public ProblemType Type { get; set; }

        /// <summary>
        /// Максимальное время, потраченное решением для данной задачи
        /// </summary>
        public double TimeLimit { get; set; }

        /// <summary>
        /// Максимум памяти, потраченное решением для данной задачи
        /// </summary>
        public int MemoryLimit { get; set; }

        /// <summary>
        /// Путь к файлам задачи 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Последняя дата изменения
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// Теги к задаче 
        /// </summary>
        public List<ProblemTag> Tags { get; set; }

        public Problem()
        {
            Tags = new List<ProblemTag>();
        }
    }
}