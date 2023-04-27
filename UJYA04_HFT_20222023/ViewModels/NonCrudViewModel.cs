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
using System.Windows.Media;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.WpfClient
{
    public class NonCrudViewModel : ObservableRecipient
    {

        //TODo property for modifiable param
        //Grid-->Stackpanel
        public static RestService rest;


        //Collections for the RelayCommands
        private ObservableCollection<TeamInfo> averageClubRating;

        public ObservableCollection<TeamInfo> AverageClubRating 
        {   get 
            { 
                return averageClubRating; 
            }
            set
            {
                averageClubRating = value;
                OnPropertyChanged();
            } 
        }

        private string under25;

        public string Under25 
        {
            get 
            {
                return under25;
            }
            set 
            {
                under25 = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Managers> getTeamFromShirtnumber;

        public ObservableCollection<Managers> GetTeamFromShirtnumber
        {
            get { return getTeamFromShirtnumber; }
            set 
            { 
                getTeamFromShirtnumber = value;
                OnPropertyChanged();
            }
        }

        private string getManager;

        public string GetManager
        {
            get { return getManager; }
            set 
            {
                getManager = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Players> getRating;

        public ObservableCollection<Players> GetRating
        {
            get { return getRating; }
            set 
            { 
                getRating = value;
                OnPropertyChanged();
            }
        }


        //Fields for parameters

        public int shirtnumber { get; set; }

        public int managerid { get; set; }

        public int age { get; set; }
        public string teamname { get; set; }

        public ICommand ListPlayerByShirtNumber { get; set; }
        public ICommand TeamsOfPlayersUnder25 { get; set; }
        public ICommand HighestRatingByTeamAndAge { get; set; }
        public ICommand GetManagerName { get; set; }
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
            rest = new RestService("http://localhost:24518/", "players");

            ListPlayerByShirtNumber = new RelayCommand(() =>
            {
                
                var a = rest.Get<Managers>($"http://localhost:24518/stat/ListPlayerByShirtNumber/{shirtnumber}");
                GetTeamFromShirtnumber = new ObservableCollection<Managers>(a);
            });

            AverageRatingInClub = new RelayCommand(() =>
            {
                var a = rest.Get<TeamInfo>("http://localhost:24518/stat/AverageRatingInClub");
                AverageClubRating = new ObservableCollection<TeamInfo>(a);
            });

            TeamsOfPlayersUnder25 = new RelayCommand(() =>
            {
                var a = rest.Get<string>("http://localhost:24518/stat/TeamsOfPlayersUnder25");
                Under25 = a.First();
            });

            GetManagerName = new RelayCommand(() =>
            {
                
                var a = rest.Get<string>($"http://localhost:24518/stat/ManagerName/{managerid}");
                GetManager = a.First();               
            });

            HighestRatingByTeamAndAge = new RelayCommand(() =>
            {
                var a = rest.Get<Players>($"http://localhost:24518/stat/HighestRatingByTeamAndAge/{age},{teamname}");
                GetRating = new ObservableCollection<Players>(a);
            });

        }

    }
}
