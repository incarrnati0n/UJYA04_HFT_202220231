﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UJYA04_HFT_20222023.Models
{
    public class Managers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerId { get; set; }
        public int TeamsId { get; set; }
        [StringLength(240)]
        public string ManagerName { get; set; }
        [Range(1, 99)]
        public int ManagerAge { get; set; }
        [Range(1000000, 5000000)]
        public double ManagerSalary { get; set; }
        [NotMapped]
        public virtual Teams Team { get; set; }


        public Managers()
        {

        }

        public Managers(string line)
        {
            string[] split = line.Split('#');
            ManagerId = int.Parse(split[0]);
            TeamsId = int.Parse(split[1]);
            ManagerName = split[2];
            ManagerAge = int.Parse(split[3]);
            ManagerSalary = double.Parse(split[4]);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Managers)
            {
                return false;
            }
            else
            {
                return (ManagerName == (obj as Managers).ManagerName);
            }
        }
    }
}
