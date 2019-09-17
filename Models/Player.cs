using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public int CurrentHitPoints { get; set; }
        public int MaximumHitPoints { get; set; }
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        
        //public Weapon EquippedWeapon { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        //public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints)
        //{
        //    CurrentHitPoints = currentHitPoints;
        //    MaximumHitPoints = maximumHitPoints;
        //    Gold = gold;
        //    ExperiencePoints = experiencePoints;   
        //}

    }
}
