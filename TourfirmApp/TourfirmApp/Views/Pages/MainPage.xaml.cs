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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private static List<Orders> _order;
        Employees currentUser = new Employees();
        public MainPage(Employees _currentUser)
        {
            currentUser = _currentUser;
            InitializeComponent();
            dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.EmploeerID == currentUser.EmployeerID).ToList();
            cmbOrderStatus.SelectedIndex = 0;
            cmbOrderStatus.Text = "Все договора";
            cmbPaymentStatus.SelectedIndex = 0;
            cmbOrderStatus.Text = "Все договора";
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        private void cmbPaymentStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbPaymentStatus.SelectedIndex)
            {
                case 0:
                    cmbPaymentStatus.Text = "Все договора";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.EmploeerID == currentUser.EmployeerID).ToList();
                    break;
                case 1:
                    cmbPaymentStatus.Text = "Ожидается оплата";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.PaymentState == "Ожидается оплата" && x.EmploeerID == currentUser.EmployeerID).ToList();
                    break;
                case 2:
                    cmbPaymentStatus.Text = "Оплачено";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.PaymentState == "Оплачено" && x.EmploeerID == currentUser.EmployeerID).ToList();
                    break;
            }
        }

        private void cmbOrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbOrderStatus.SelectedIndex)
            {
                case 0:
                    cmbPaymentStatus.Text = "Все договора";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.EmploeerID == currentUser.EmployeerID).ToList();
                    break;
                case 1:
                    cmbPaymentStatus.Text = "Ещё не исполнен";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.OrderState == "Ещё не исполнен" && x.EmploeerID == currentUser.EmployeerID).ToList();
                    break;
                case 2:
                    cmbPaymentStatus.Text = "Исполнен";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.OrderState == "Исполнен" && x.EmploeerID == currentUser.EmployeerID).ToList();
                    break;
            }
        }
        public void UpLoad()
        {
            dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(p => p.EmploeerID == currentUser.EmployeerID).ToList();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem == null)
                MessageBox.Show("Выберите договор, щелкнув по нему правой кнопкой мыши");
            else
            {
                OrderEditWindow customerEdit = new OrderEditWindow((Orders)dgOrders.SelectedItem);
                customerEdit.ShowDialog();
                UpLoad();
            }
        }

        public void UpdateData(object sender, object e)
        {

            _order = TourfirmEntities.GetContext().Orders.Where(p => p.EmploeerID == currentUser.EmployeerID).ToList();
            if (!String.IsNullOrWhiteSpace(txtFind.Text))
            {
                String text = txtFind.Text.ToLower();
                _order = _order.Where(x => x.Customers.Lastname.ToLower().StartsWith(text) || x.DealAmount.ToString().StartsWith(text) && x.EmploeerID == currentUser.EmployeerID).ToList();
            }
            dgOrders.ItemsSource = _order;
        }
    }
}
