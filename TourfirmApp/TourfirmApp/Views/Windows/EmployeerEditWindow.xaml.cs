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
    /// Логика взаимодействия для EmployeerEditWindow.xaml
    /// </summary>
    public partial class EmployeerEditWindow : Window
    {
        private static Employees _currentEmployeer;
        private TourfirmEntities db = new TourfirmEntities();
        public EmployeerEditWindow(Employees curretEmployeer)
        {
            InitializeComponent();
            _currentEmployeer = curretEmployeer;
            txtFirstName.Text = _currentEmployeer.FirstName;
            txtLastName.Text = _currentEmployeer.LastName;
            txtMiddleName.Text = _currentEmployeer.MiddleName;
            txtPassword.Text = _currentEmployeer.Password;
            txtLogin.Text = _currentEmployeer.Login;
            txtPhone.Text = _currentEmployeer.Phone;
            txtEmail.Text = _currentEmployeer.Email;
            dtBirthday.SelectedDate = _currentEmployeer.BirthdayDate;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _currentEmployeer.FirstName = txtFirstName.Text;
            _currentEmployeer.LastName = txtLastName.Text;
            _currentEmployeer.MiddleName = txtMiddleName.Text;
            _currentEmployeer.Password = txtPassword.Text;
            _currentEmployeer.Login = txtLogin.Text;
            _currentEmployeer.Phone = txtPhone.Text;
            _currentEmployeer.Email = txtEmail.Text;
            _currentEmployeer.BirthdayDate = (DateTime)dtBirthday.SelectedDate;
            _currentEmployeer.Position = "Менеджер";


            TourfirmEntities.GetContext().SaveChanges();
            db.SaveChanges();
            MessageBox.Show("Сотрудник успешно обновлен");
            Close();
        }
    }
}
