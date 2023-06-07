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
using TourfirmApp.Models;
using TourfirmApp.Views.Pages;

namespace TourfirmApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Employees _currentUser;
        private static Orders _orders;
        private TourfirmEntities db = new TourfirmEntities();
        
        public MainWindow(Employees currentUser)
        {
            
            _currentUser = currentUser;
            InitializeComponent();
            MainPage main = new MainPage(_currentUser);
            frame.Content = main;
            MainPage.Foreground = Brushes.Gray;
            FIO.Content = _currentUser.LastName + " " + _currentUser.FirstName;
            

        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Foreground = Brushes.Gray;
            ClientsPage.Foreground = Brushes.White;
            ToursPage.Foreground = Brushes.White;
            GroupPage.Foreground = Brushes.White;
            StatisticPage.Foreground = Brushes.White;
            ContractsPage.Foreground = Brushes.White;
            MainPage main = new MainPage(_currentUser);
            frame.Content = main;
        }

        private void ClientsPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Foreground = Brushes.White;
            ClientsPage.Foreground = Brushes.Gray;
            ToursPage.Foreground = Brushes.White;
            GroupPage.Foreground = Brushes.White;
            StatisticPage.Foreground = Brushes.White;
            ContractsPage.Foreground = Brushes.White;
            ClientsPage main1 = new ClientsPage();
            frame.Content = main1;
        }

        private void GroupPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Foreground = Brushes.White;
            ClientsPage.Foreground = Brushes.White;
            ToursPage.Foreground = Brushes.White;
            GroupPage.Foreground = Brushes.Gray;
            StatisticPage.Foreground = Brushes.White;
            ContractsPage.Foreground = Brushes.White;
            GroupPage main3 = new GroupPage();
            frame.Content = main3;
        }

        private void ToursPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Foreground = Brushes.White;
            ClientsPage.Foreground = Brushes.White;
            ToursPage.Foreground = Brushes.Gray;
            GroupPage.Foreground = Brushes.White;
            StatisticPage.Foreground = Brushes.White;
            ContractsPage.Foreground = Brushes.White;
            ToursPage main2 = new ToursPage(_currentUser);
            frame.Content = main2;
        }



        private void StatisticPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Foreground = Brushes.White;
            ClientsPage.Foreground = Brushes.White;
            ToursPage.Foreground = Brushes.White;
            GroupPage.Foreground = Brushes.White;
            StatisticPage.Foreground = Brushes.Gray;
            ContractsPage.Foreground = Brushes.White;
            StatisticPage main4 = new StatisticPage();
            frame.Content = main4;
        }

        private void ContractsPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Foreground = Brushes.White;
            ClientsPage.Foreground = Brushes.White;
            ToursPage.Foreground = Brushes.White;
            GroupPage.Foreground = Brushes.White;
            StatisticPage.Foreground = Brushes.White;
            ContractsPage.Foreground = Brushes.Gray;
            ContractsPage main5 = new ContractsPage();
            frame.Content = main5;
        }

        private void UserGuide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти из аккаунта?",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var AuthorizathionWindow = new AuthorizathionWindow();
                AuthorizathionWindow.Owner = this;
                AuthorizathionWindow.Show();
                Hide();
            }
            else
            {
                var AuthorizathionWindow = new AuthorizathionWindow();
                AuthorizathionWindow.Owner = this;
                AuthorizathionWindow.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите закрыть приложение?",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
