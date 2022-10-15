using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UJYA04_HFT_20222023.Models
{
    public class Teams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public int ManagerId { get; set; }
        public int PlayerId { get; set; }
        [StringLength(240)]
        public string TeamName { get; set; }
        [StringLength(240)]
        public string TeamOwner { get; set; }
        [Range(1000, 2000)]
        public int TeamFoundedYear { get; set; }
        [StringLength(240)]
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
