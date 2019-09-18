using System;
namespace Sharpen.Models
{
    public class TriviaChallenge
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public int Value { get; set; }
        public int CategoryId { get; set; }
    }
}
