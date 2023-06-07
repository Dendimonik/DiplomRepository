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
    /// Логика взаимодействия для CustomerGroupEditWindow.xaml
    /// </summary>
    public partial class CustomerGroupEditWindow : Window
    {
        private static CustomerGroup _currentCustomerGroup;
        private TourfirmEntities db = new TourfirmEntities();
        public CustomerGroupEditWindow(CustomerGroup currentCustomerGroup)
        {
            InitializeComponent();
            _currentCustomerGroup = currentCustomerGroup;
            txtFirstName.Text = _currentCustomerGroup.Firstname;
            txtLastName.Text = _currentCustomerGroup.Lastname;
            txtMiddleName.Text = _currentCustomerGroup.Middlename;
            txtDocumentType.Text = _currentCustomerGroup.DocumentType;
            txtDocumentData.Text = _currentCustomerGroup.DocumentData;
            dtBirthday.SelectedDate = _currentCustomerGroup.BirthdayDate;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {



            _currentCustomerGroup.Firstname = txtFirstName.Text;
            _currentCustomerGroup.Lastname = txtLastName.Text;
            _currentCustomerGroup.Middlename = txtMiddleName.Text;
            _currentCustomerGroup.DocumentType = txtDocumentType.Text;
            _currentCustomerGroup.DocumentData = txtDocumentData.Text;
            _currentCustomerGroup.BirthdayDate = (DateTime)dtBirthday.SelectedDate;


            TourfirmEntities.GetContext().SaveChanges();
            db.SaveChanges();
            MessageBox.Show("Человек из группы заказчика успешно обновлен");
            Close();
        }

    }
}
