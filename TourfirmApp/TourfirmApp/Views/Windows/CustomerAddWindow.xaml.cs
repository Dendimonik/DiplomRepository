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
using TourfirmApp.Models;

namespace TourfirmApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CustomerAddWindow.xaml
    /// </summary>
    public partial class CustomerAddWindow : Window
    {
        private static Customers _currentCustomer = new Customers();
        private TourfirmEntities db = new TourfirmEntities();
        public CustomerAddWindow(Customers currentCustomer)
        {
            InitializeComponent();
            DataContext = _currentCustomer;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customers customer = new Customers();

            customer.Firstname = txtFirstName.Text;
            customer.Lastname = txtLastName.Text;
            customer.Middlename = txtMiddleName.Text;
            customer.DocumentType = txtDocumentType.Text;
            customer.DocumentData = txtDocumentData.Text;
            customer.Phone = txtPhone.Text;
            customer.Bonus = 0;
            customer.BirthdayDate = (DateTime)dtBirthday.SelectedDate;


            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Заказчик успешно сохранен");
            Close();
        }
    }
}
