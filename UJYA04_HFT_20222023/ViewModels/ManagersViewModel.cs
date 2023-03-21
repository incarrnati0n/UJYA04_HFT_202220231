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
    public class ManagersViewModel : ObservableRecipient
    {
        public static Random r = new Random();
        public RestCollection<Managers> Managers { get; set; }

        private Managers selectedManager;

        public Managers SelectedManager
        {
            get { return selectedManager; }
            set
            {
                if (value != null)
                {
                    selectedManager = new Managers()
                    {
                        ManagerName = value.ManagerName,
                        ManagerId = value.ManagerId,
                        ManagerAge = value.ManagerAge,
                        ManagerSalary = value.ManagerSalary,
                        
                    };
                }
                OnPropertyChanged();
                (DeleteManagerCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }

        public ICommand CreateManagerCommand { get; set; }
        public ICommand DeleteManagerCommand { get; set; }
        public ICommand UpdateManagerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ManagersViewModel()
        {
            if (!IsInDesignMode)
            {
                Managers = new RestCollection<Managers>("http://localhost:24518/", "managers", "hub");

                CreateManagerCommand = new RelayCommand(() =>
                {
                    Managers.Add(new Managers()
                    {
                        ManagerName = SelectedManager.ManagerName,
                        ManagerAge = SelectedManager.ManagerAge,
                        ManagerSalary = SelectedManager.ManagerSalary,
                        /*Team = new Teams()
                        {
                            TeamFoundedYear = r.Next(1000, 2001) 
                        }*/
                    });
                });

                DeleteManagerCommand = new RelayCommand(() =>
                {
                    Managers.Delete(SelectedManager.ManagerId);
                },
                () =>
                {
                    return SelectedManager != null;
                }
                );
                UpdateManagerCommand = new RelayCommand(() =>
                {
                    Managers.Update(SelectedManager);
                });

                SelectedManager = new Managers();
            }
        }

    }
}

