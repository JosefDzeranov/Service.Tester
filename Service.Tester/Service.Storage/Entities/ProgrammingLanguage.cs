﻿using System.Collections.Generic;
using Service.Storage.ExtraModels;

namespace Service.Storage.Entities
{
    internal class ProgrammingLanguage : EntityModel
    {
        /// <summary>
        /// Название языка программирования
        /// </summary>
        public ProgrammingLanguageName Name { get; set; }

        /// <summary>
        /// Доступен ли данный язык программирования
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Все решения на данном языке программирования
        /// </summary>
        public List<Solution> Solutions { get; set; }
    }
}