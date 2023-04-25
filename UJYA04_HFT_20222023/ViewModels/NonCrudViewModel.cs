using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.WpfClient
{
    public class NonCrudViewModel : ObservableRecipient
    {
        public static RestService rest;

        ObservableCollection<TeamInfo> AverageClubRating;

        ObservableCollection<string> Under25;

        public ICommand ListPlayerByShirtNumber { get; set; }
        public ICommand TeamsOfPlayersUnder25 { get; set; }
        public ICommand HighestRatingByTeamAndAge { get; set; }
        public ICommand ManagerName { get; set; }
        public ICommand AverageRatingInClub { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public NonCrudViewModel()
        {
            rest = new RestService("http://localhost:24518/", "stat");

            ListPlayerByShirtNumber = new RelayCommand(() =>
            {
                int shirtnumber = 29;
                var a = rest.Get<Managers>($"/stat/ListPlayerByShirtNumber/{shirtnumber}");
            });

            AverageRatingInClub = new RelayCommand(() =>
            {
                var a = rest.Get<TeamInfo>("/stat/AverageRatingInClub");
                AverageClubRating = new ObservableCollection<TeamInfo>(a);
            });

            TeamsOfPlayersUnder25 = new RelayCommand(() =>
            {
                var a = rest.Get<string>("/stat/TeamsOfPlayersUnder25");
                Under25 = new ObservableCollection<string>(a);
            });

            ManagerName = new RelayCommand(() =>
            {
                int managerid = 1;
                var a = rest.Get<string>($"/stat/ManagerName/{managerid}");
            });

            HighestRatingByTeamAndAge = new RelayCommand(() =>
            {
                string teamname = "Chelsea FC";
                int age = 23;
                var a = rest.Get<Players>($"/stat/HighestRatingByTeamAndAge/{age}, {teamname}");
            });

        }

    }
}
