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
using System.Windows.Shapes;
using System.Windows.Threading;
using TourfirmApp.Models;

namespace TourfirmApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для TourFindWindow.xaml
    /// </summary>
    public partial class TourFindWindow : Window
    {
        private TourfirmEntities db = new TourfirmEntities();
        private static List<Customers> _customer;
        private static Tours _currentTour;
        private static Employees _employees;
        private static Customers custom;
        public TourFindWindow(Tours currenTour, Employees currentEmpl)
        {
            _employees = currentEmpl;
            _currentTour = currenTour;
            InitializeComponent();
            txtHotelName.Text = $"{_currentTour.Hotels.HotelName}";
            txtNutri.Text = $"{_currentTour.Nutrition}";
            txtDescription.Text = $"{_currentTour.Description}";
            txtCost.Text = $"Цена за одного:\t{_currentTour.CostForOne}\n Цена за двоих:\t{_currentTour.CostForTwo}\nДоп. место:\t{_currentTour.ExtraBed}";
            txtRoomCategory.Text = $"{_currentTour.RoomCategory}";
            txtDate.Text = $"C {_currentTour.StartDate} по {_currentTour.EndDate}";
            txtCos.Text = $"{_currentTour.CostForOne}";
            dgCustomers.ItemsSource = TourfirmEntities.GetContext().Customers.ToList();



        }
        private void rdOne_Checked(object sender, RoutedEventArgs e)
        {   
            txtCos.Text = $"{_currentTour.CostForOne}";
        }

        private void rdTwo_Checked(object sender, RoutedEventArgs e)
        {
            txtCos.Text = $"{_currentTour.CostForTwo}";
        }

        private void rdThree_Checked(object sender, RoutedEventArgs e)
        {
            var b = _currentTour.CostForTwo + _currentTour.ExtraBed;
            txtCos.Text = $"{b}";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem == null)
                MessageBox.Show("Выберите заказчика договора, щелкнув по нему правой кнопкой мыши");
            else
            {
                custom = dgCustomers.SelectedItem as Customers;
                Orders order = new Orders();
                var b = Convert.ToDecimal(txtCos.Text);
                order.EmploeerID = _employees.EmployeerID;
                order.TourID = _currentTour.TourID;
                order.CustomerID = custom.Customer_ID;
                order.DealAmount = b;
                order.Prepayment = 0;
                order.PaymentState = "Ожидается оплата";
                order.OrderState = "Ещё не исполнен";
                order.ConclusionDate = DateTime.Now;

                db.Orders.Add(order);
                db.SaveChanges();
                MessageBox.Show("Договор успешно сохранен");
                Close();
            }
        }


        public void UpdateData(object sender, object e)
        {
            _customer = TourfirmEntities.GetContext().Customers.ToList();
            if (!String.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                String text = txtCustomer.Text.ToLower();
                _customer = _customer.Where(x => x.DocumentData.ToString().StartsWith(text) || x.Lastname.ToLower().StartsWith(text)).ToList();
            }
            dgCustomers.ItemsSource = _customer;
        }
        private void txtCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }
    }
}
