using System;

namespace ProblemProcessor
{
    public class ProblemType
    {
        public Guid Id { get; set; }
        
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