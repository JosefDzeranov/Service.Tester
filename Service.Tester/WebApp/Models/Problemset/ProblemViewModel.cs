using System;
using System.Collections.Generic;
using Service.Storage.Entities;

namespace WebApp.Models.Problemset
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
        /// Теги к задаче 
        /// </summary>
        public List<ProblemTag> Tags { get; set; }
    }
}