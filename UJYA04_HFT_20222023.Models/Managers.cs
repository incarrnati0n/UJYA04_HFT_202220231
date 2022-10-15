using System;

namespace UJYA04_HFT_20222023.Models
{
    public class Managers
    {
        public int ManagerId { get; set; }
        public int TeamsId { get; set; }
        public int PlayerId { get; set; }
        public string ManagerName { get; set; }
        public int ManagerAge { get; set; }
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
