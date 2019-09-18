using System;
namespace Sharpen.Models
{
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int clues_count { get; set; }
    }

    public class TriviaChallenge
    {
        public int id { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
        public int value { get; set; }
        public DateTime airdate { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int category_id { get; set; }
        public object game_id { get; set; }
        public object invalid_count { get; set; }
        public Category category { get; set; }
    }

    //public class TriviaChallenge
    //{
    //    public int Id { get; set; }
    //    public string Answer { get; set; }
    //    public string Question { get; set; }
    //    public int Value { get; set; }
    //    public int CategoryId { get; set; }
    //}
}
