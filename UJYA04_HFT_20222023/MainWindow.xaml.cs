using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UJYA04_HFT_20222023.WpfClient;

namespace UJYA04_HFT_20222023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Players(object sender, RoutedEventArgs e)
        {
            PlayersWindow playersWindow = new PlayersWindow();
            playersWindow.Show();
        }

        private void Button_Click_Managers(object sender, RoutedEventArgs e)
        {
            ManagersWindow managersWindow = new ManagersWindow();
            managersWindow.Show();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Teams(object sender, RoutedEventArgs e)
        {
            TeamsWindow teamsWindow = new TeamsWindow();
            teamsWindow.Show();
        }

        private void Button_Click_NC(object sender, RoutedEventArgs e)
        {
            NonCrudWindow nonCrudWindow = new NonCrudWindow();
            nonCrudWindow.Show();
        }
    }
}
