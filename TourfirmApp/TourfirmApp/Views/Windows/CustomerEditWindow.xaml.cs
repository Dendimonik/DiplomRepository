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
    /// Логика взаимодействия для CustomerEditWindow.xaml
    /// </summary>
    public partial class CustomerEditWindow : Window
    {
        private static Customers _currentCustomer;
        private TourfirmEntities db = new TourfirmEntities();
        public CustomerEditWindow(Customers currentCustomer)
        {
            InitializeComponent();
            _currentCustomer = currentCustomer;
            txtFirstName.Text = currentCustomer.Firstname;
            txtLastName.Text = currentCustomer.Lastname;
            txtMiddleName.Text = currentCustomer.Middlename;
            txtDocumentType.Text = currentCustomer.DocumentType;
            txtDocumentData.Text = currentCustomer.DocumentData;
            txtPhone.Text = currentCustomer.Phone;
            dtBirthday.SelectedDate = currentCustomer.BirthdayDate;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {



            _currentCustomer.Firstname = txtFirstName.Text;
            _currentCustomer.Lastname = txtLastName.Text;
            _currentCustomer.Middlename = txtMiddleName.Text;
            _currentCustomer.DocumentType = txtDocumentType.Text;
            _currentCustomer.DocumentData = txtDocumentData.Text;
            _currentCustomer.Phone = txtPhone.Text;
            _currentCustomer.Bonus = 0;
            _currentCustomer.BirthdayDate = (DateTime)dtBirthday.SelectedDate;


            TourfirmEntities.GetContext().SaveChanges();
            db.SaveChanges();
            MessageBox.Show("Заказчик успешно обновлен");
            Close();
        }
    }
}
