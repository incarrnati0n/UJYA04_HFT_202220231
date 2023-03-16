using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UJYA04_HFT_20222023.Models;

namespace UJYA04_HFT_20222023.WpfClient
{
    public class TeamsViewModel : ObservableRecipient
    {
        public RestCollection<Teams> Teams { get; set; }

        private Teams selectedTeam;

        public Teams SelectedTeam
        {
            get { return selectedTeam; }
            set 
            {
                if (value != null)
                {
                    selectedTeam = new Teams()
                    {
                        TeamName = value.TeamName,
                        TeamId = value.TeamId,
                    };
                }
                OnPropertyChanged();
                (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
            }
            
        }

        public ICommand CreateTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public TeamsViewModel()
        {
            if (!IsInDesignMode)
            {
                Teams = new RestCollection<Teams>("http://localhost:24518/", "Teams", "hub");

                CreateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Add(new Teams()
                    {
                        TeamName = SelectedTeam.TeamName,
                        TeamOwner = SelectedTeam.TeamOwner,
                        TeamFoundedYear = SelectedTeam.TeamFoundedYear,
                        TeamStadiumName = SelectedTeam.TeamStadiumName
                    });
                });

                DeleteTeamCommand = new RelayCommand(() =>
                {
                    Teams.Delete(SelectedTeam.TeamId);
                },
                () =>
                {
                    return SelectedTeam != null;
                }
                );
                UpdateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Update(SelectedTeam);
                });

                SelectedTeam = new Teams();
            }
        }

    }
}
