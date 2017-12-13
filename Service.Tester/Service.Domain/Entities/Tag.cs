﻿using System.Collections.Generic;

namespace Service.Domain.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Тэг задачи
    /// </summary>
    internal class Tag : EntityModel
    {
        /// <summary>
        /// Имя тэга
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Все задачи тэга
        /// </summary>
        public List<ProblemTag> Problems { get; set; }

        public Tag()
        {
            Problems = new List<ProblemTag>();
        }
    }
}