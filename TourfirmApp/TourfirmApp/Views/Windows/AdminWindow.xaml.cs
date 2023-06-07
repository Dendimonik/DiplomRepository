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
using TourfirmApp.Utils;
using TourfirmApp.Models;
using System.Windows.Threading;

namespace TourfirmApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private static List<Employees> _employ;
        private static Employees curretEmployeer;
        private TourfirmEntities db = new TourfirmEntities();
        public AdminWindow()
        {

            InitializeComponent();
            dgEmploeeys.ItemsSource = TourfirmEntities.GetContext().Employees.ToList();

        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
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
        public void UpLoad()
        {
            dgEmploeeys.ItemsSource = TourfirmEntities.GetContext().Employees.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeerAddWindow customerAdd = new EmployeerAddWindow(curretEmployeer);
            customerAdd.ShowDialog();
            UpLoad();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmploeeys.SelectedItem == null)
                MessageBox.Show("Выберите кабинет, щелкнув по нему правой кнопкой мыши");
            else
            {
                EmployeerEditWindow customerEdit = new EmployeerEditWindow((Employees)dgEmploeeys.SelectedItem);
                customerEdit.ShowDialog();
                UpLoad();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var customerForRemoving = dgEmploeeys.SelectedItems.Cast<Employees>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить работника?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourfirmEntities.GetContext().Employees.RemoveRange(customerForRemoving);
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

            _employ = TourfirmEntities.GetContext().Employees.ToList();
            if (!String.IsNullOrWhiteSpace(txtFind.Text))
            {
                String text = txtFind.Text.ToLower();
                _employ = _employ.Where(x => x.LastName.ToLower().StartsWith(text) || x.MiddleName.ToLower().StartsWith(text) || x.FirstName.ToLower().StartsWith(text) || x.Login.ToLower().StartsWith(text) || x.Password.ToLower().ToString().StartsWith(text)).ToList();
            }
            dgEmploeeys.ItemsSource = _employ;
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
