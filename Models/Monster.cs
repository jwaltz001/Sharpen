using System;
namespace Sharpen.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
    }
}
