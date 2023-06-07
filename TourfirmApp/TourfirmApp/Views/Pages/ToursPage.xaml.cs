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
using System.Windows.Threading;
using TourfirmApp.Models;
using TourfirmApp.Views.Windows;

namespace TourfirmApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        private static List<Tours> _tour;
        private static Tours currenTour;
        private static Employees currentEmpl;
        public ToursPage(Employees _currentUser)
        {
            InitializeComponent();
            cmbHotel.IsEnabled = false;
            currentEmpl = _currentUser;
            //var fullEntries = TourfirmEntities.GetContext().Tours
            //.Join(
            //TourfirmEntities.GetContext().Hotels,
            // entryPoint => entryPoint.HotelID,
            // entry => entry.HotelID,
            // (entryPoint, entry) => new { entryPoint, entry }
            //      );
            //dgTours.ItemsSource = fullEntries;
            dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
            cmbRegion.SelectedIndex = 0;
            cmbRegion.Text = "Все регионы";


        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            currenTour = dgTours.SelectedItem as Tours;
            var tourFind = new TourFindWindow(currenTour, currentEmpl);
            tourFind.Title = "Подбор тура";
            tourFind.ShowDialog();

        }
        public void UpLoad()
        {
            dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
        }

        private void cmbHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var fullEntries = TourfirmEntities.GetContext().Tours
            //.Join(
            //TourfirmEntities.GetContext().Hotels,
            // entryPoint => entryPoint.HotelID,
            // entry => entry.HotelID,
            // (entryPoint, entry) => new { entryPoint, entry }
            //      );
            //dgTours.ItemsSource = fullEntries;

            //dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.HotelName.Equals(cmbHotel.SelectedItem)).ToList();

            switch (cmbHotel.SelectedIndex)
            {
                case 0:
                    cmbRegion.Text = "Все регионы";
                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
                    cmbHotel.Text = "Все отели";
                    cmbHotel.SelectedIndex = 0;
                    break;
                case 1:
                    cmbRegion.Text = "Краснодарский край";
                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.HotelName == "Селена").ToList();
                    cmbHotel.Text = "Селена";
                    cmbHotel.SelectedIndex = 1;
                    break;
                case 2:
                    cmbRegion.Text = "Крым";
                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.HotelName == "МРИЯ РЕЗОРТ энд СПА").ToList();
                    cmbHotel.Text = "МРИЯ РЕЗОРТ энд СПА";
                    cmbHotel.SelectedIndex = 2;
                    break;
                case 3:
                    cmbRegion.Text = "Краснодарский край";
                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.HotelName == "Красная Талка").ToList();
                    cmbHotel.Text = "Красная Талка";
                    cmbHotel.SelectedIndex = 3;
                    break;
                case 4:
                    cmbRegion.Text = "Крым";
                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.HotelName == "Вилла Елена").ToList();
                    cmbHotel.Text = "Вилла Елена";
                    cmbHotel.SelectedIndex = 4;
                    break;
            }
        }

        private void cmbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (cmbRegion.SelectedIndex)
            {
                case 0:

                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.ToList();
                    cmbRegion.SelectedIndex = 0;
                    cmbHotel.SelectedIndex = 0;
                    cmbHotel.Text = "Все отели";
                    break;
                case 1:

                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.Region == "Крым").ToList();
                    cmbHotel.Text = "Все отели";
                    cmbHotel.SelectedIndex = 0;
                    cmbRegion.SelectedIndex = 1;
                    break;
                case 2:
                    dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.Hotels.Region == "Краснодарский край").ToList();
                    cmbHotel.Text = "Все отели";
                    cmbHotel.SelectedIndex = 0;
                    cmbRegion.SelectedIndex = 2;
                    break;
            }
            cmbHotel.IsEnabled = true;
        }

        public void UpdateData(object sender, object e)
        {
        }

        private void btnDataFind_Click(object sender, RoutedEventArgs e)
        {
            var start = dtStart.SelectedDate;
            var end = dtEnd.SelectedDate;
            dgTours.ItemsSource = TourfirmEntities.GetContext().Tours.Where(p => p.StartDate >= start && p.EndDate <= end).ToList();
        }
    }
}

