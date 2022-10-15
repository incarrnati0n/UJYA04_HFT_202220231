using System;
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
        public int PlayerId { get; set; }
        [StringLength(240)]
        public string ManagerName { get; set; }
        [Range(1, 99)]
        public int ManagerAge { get; set; }
        [Range(1000000, 5000000)]
        public double ManagerSalary { get; set; }

        public Managers()
        {

        }

        public Managers(string line)
        {
            string[] split = line.Split('#');
            ManagerId = int.Parse(split[0]);
            TeamsId = int.Parse(split[1]);
            PlayerId = int.Parse(split[2]);
            ManagerName = split[3];
            ManagerAge = int.Parse(split[4]);
            ManagerSalary = double.Parse(split[5]);
        }


    }
}
