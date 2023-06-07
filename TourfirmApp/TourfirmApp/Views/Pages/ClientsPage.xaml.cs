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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private static List<Customers> _custom;
        private static Customers curretCustomer;

        public ClientsPage()
        {
            InitializeComponent();
            dgCustomers.ItemsSource = TourfirmEntities.GetContext().Customers.ToList();
        }
        public void UpLoad()
        {
            dgCustomers.ItemsSource = TourfirmEntities.GetContext().Customers.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomerAddWindow customerAdd = new CustomerAddWindow(curretCustomer);
            customerAdd.ShowDialog();
            UpLoad();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem == null)
                MessageBox.Show("Выберите кабинет, щелкнув по нему правой кнопкой мыши");
            else
            {
                CustomerEditWindow customerEdit = new CustomerEditWindow((Customers)dgCustomers.SelectedItem);
                customerEdit.ShowDialog();
                UpLoad();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var customerForRemoving = dgCustomers.SelectedItems.Cast<Customers>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {customerForRemoving.Count()} заказчиков?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourfirmEntities.GetContext().Customers.RemoveRange(customerForRemoving);
                    TourfirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    UpLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void UpdateData(object sender, object e)
        {

            _custom = TourfirmEntities.GetContext().Customers.ToList();
            if (!String.IsNullOrWhiteSpace(txtFind.Text))
            {
                String text = txtFind.Text.ToLower();
                _custom = _custom.Where(x => x.Lastname.ToLower().StartsWith(text) || x.Middlename.ToLower().StartsWith(text) || x.Firstname.ToLower().StartsWith(text) || x.DocumentData.ToString().StartsWith(text)).ToList();
            }
            dgCustomers.ItemsSource = _custom;
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }
    }
}
