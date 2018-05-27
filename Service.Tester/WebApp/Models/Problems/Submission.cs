using System;

namespace WebApp.Models.Problems
{
    public class Submission
    {
        public string Status { get; set; }
        public string Solution { get; set; }
        public DateTime SendTime { get; set; }
    }
}