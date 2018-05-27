using System;

namespace ProblemProcessor.Solutions
{
    public class Solution
    {
        public Guid ProblemId { get; set; }
        public Guid UserId { get; set; }
        public string Input { get; set; }
        public TestResults Result { get; set; }
        public DateTime SendTime { get; set; }
    }
}