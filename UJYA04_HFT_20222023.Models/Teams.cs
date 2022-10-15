using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UJYA04_HFT_20222023.Models
{
    public class Teams
    {
        public int TeamId { get; set; }
        public int ManagerId { get; set; }
        public int PlayerId { get; set; }
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public int TeamFoundedYear { get; set; }
        public string TeamStadiumName { get; set; }


        public Teams()
        {

        }

        public Teams(string line)
        {
            string[] split = line.Split('#');
            TeamId = int.Parse(split[0]);
            ManagerId = int.Parse(split[1]);
            PlayerId = int.Parse(split[2]);
            TeamName = split[3];
            TeamOwner = split[4];
            TeamFoundedYear = int.Parse(split[5]);
            TeamStadiumName = split[6];
        }

    }
}
