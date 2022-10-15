using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UJYA04_HFT_20222023.Models
{
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int ManagerId { get; set; }
        [StringLength(240)]
        public string PlayerName { get; set; }
        [Range(1, 99)]
        public int PlayerShirtNum { get; set; }
        [Range(1, 99)]
        public int PlayerAge { get; set; }
        [Range(1,99)]
        public int Rating { get; set; }

        public Players()
        {

        }

        public Players(string line)
        {
            string[] split = line.Split('#');
            PlayerId = int.Parse(split[0]);
            TeamId = int.Parse(split[1]);
            ManagerId = int.Parse(split[2]);
            PlayerName = split[3];
            PlayerShirtNum = int.Parse(split[4]);
            PlayerAge = int.Parse(split[5]);
            Rating = int.Parse(split[6]);
        }
    }
}
