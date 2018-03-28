using System;
using System.Collections.Generic;
using Service.Domain.Entities;

namespace WebApp.Models.Problems
{
    public class ProblemViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Тип задания
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Последняя дата изменения
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// Теги к задаче 
        /// </summary>
        public List<ProblemTag> Tags { get; set; }
    }
}