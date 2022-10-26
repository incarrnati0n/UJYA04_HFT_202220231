using Newtonsoft.Json;
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
        [StringLength(240)]
        public string TeamName { get; set; }
        [StringLength(240)]
        public string TeamOwner { get; set; }
        [Range(1000, 2000)]
        public int TeamFoundedYear { get; set; }
        [StringLength(240)]
        public string TeamStadiumName { get; set; }
        [JsonIgnore]
        public virtual Managers Manager { get; set; }
        [JsonIgnore]
        public virtual ICollection<Players> Player { get; set; }

        public Teams()
        {
            Player = new HashSet<Players>();
        }

        public Teams(string line)
        {
            string[] split = line.Split('#');
            TeamId = int.Parse(split[0]);
            ManagerId = int.Parse(split[1]);
            TeamName = split[2];
            TeamOwner = split[3];
            TeamFoundedYear = int.Parse(split[4]);
            TeamStadiumName = split[5];
            Player = new HashSet<Players>();
        }

    }
}
