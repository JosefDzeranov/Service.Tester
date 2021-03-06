﻿using Service.Storage.ExtraModels;

namespace Service.Storage.Entities
{
    /// <summary>
    /// Тип задания
    /// </summary>
    public class ProblemType : EntityModel
    {
        /// <summary>
        /// Имя типа задания
        /// </summary>
        public ProblemTypes Type { get; set; }

        /// <summary>
        /// Полное название типа задания
        /// </summary>
        public string Name { get; set; }
    }
}