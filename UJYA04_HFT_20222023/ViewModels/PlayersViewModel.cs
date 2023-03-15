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
    public class PlayersViewModel : ObservableRecipient
    {
        public RestCollection<Players> Players { get; set; }

        private Players selectedPlayer;

        public Players SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    selectedPlayer = new Players()
                    {
                        PlayerName = value.PlayerName,
                        PlayerId = value.PlayerId,
                    };
                }
                OnPropertyChanged();
                (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }

        public ICommand CreatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PlayersViewModel()
        {
            if (!IsInDesignMode)
            {
                Players = new RestCollection<Players>("http://localhost:24518/", "Players");

                CreatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Add(new Players()
                    {
                        PlayerName = SelectedPlayer.PlayerName,
                        PlayerAge = SelectedPlayer.PlayerAge,
                        PlayerShirtNum = SelectedPlayer.PlayerShirtNum,
                        Rating = SelectedPlayer.Rating
                    });
                });

                DeletePlayerCommand = new RelayCommand(() =>
                {
                    Players.Delete(SelectedPlayer.PlayerId);
                },
                () =>
                {
                    return SelectedPlayer != null;
                }
                );
                UpdatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Update(SelectedPlayer);
                });

                SelectedPlayer = new Players();
            }
        }

    }
}

