using System;
using Service.Storage.ExtraModels;

namespace Service.Storage.Entities
{
    /// <summary>
    /// Решение задания
    /// </summary>
    public class Solution : EntityModel
    {
        public Problem Problem { get; set; }

        public Guid UserId { get; set; }

        public TestResults TestResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Input { get; set; }
    }
}