using System;

namespace Service.Problems.Restore.Models
{
    public class RestoreData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string SourceCode { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}