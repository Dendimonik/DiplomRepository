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
    /// Логика взаимодействия для CustomerGroupAddWindow.xaml
    /// </summary>
    public partial class CustomerGroupAddWindow : Window
    {
        private static Customers custom;
        private TourfirmEntities db = new TourfirmEntities();
        public CustomerGroupAddWindow()
        {
            InitializeComponent();
            dgCustomers.ItemsSource = TourfirmEntities.GetContext().Customers.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem == null)
                MessageBox.Show("Выберите заказчика, щелкнув по нему правой кнопкой мыши");
            else
            {
                custom = dgCustomers.SelectedItem as Customers;
                CustomerGroup customGroup = new CustomerGroup();

                customGroup.Customer_ID = custom.Customer_ID;
                customGroup.Firstname = txtFirstName.Text;
                customGroup.Middlename = txtMiddleName.Text;
                customGroup.Lastname = txtLastName.Text;
                customGroup.BirthdayDate = (DateTime)dtBirthday.SelectedDate;
                customGroup.DocumentType = txtDocumentType.Text;
                customGroup.DocumentData = txtDocumentData.Text;

                db.CustomerGroup.Add(customGroup);
                db.SaveChanges();
                MessageBox.Show("Человек из группы заказчика успешно сохранен");
                Close();

            }
        }
        public void UpLoad()
        {
            dgCustomers.ItemsSource = TourfirmEntities.GetContext().Customers.ToList();
        }
    }
}
