using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.WpfClient.ViewModels
{
    public class TeamsViewModel : ObservableRecipient
    {
        public RestCollection<Teams> Teams { get; set; }

        private Teams selectedTeam;

        public Teams MyProperty
        {
            get { return selectedTeam; }
            set 
            {
                selectedTeam = new Teams()
                {
                    TeamName = value.TeamName,
                    TeamId = value.TeamId,
                    TeamFoundedYear = value.TeamFoundedYear,
                    TeamOwner = value.TeamOwner,
                    TeamStadiumName = value.TeamStadiumName,
                };
            }
        }

    }
}
