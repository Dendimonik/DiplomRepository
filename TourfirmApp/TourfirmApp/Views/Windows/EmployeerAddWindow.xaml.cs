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
    /// Логика взаимодействия для EmployeerAddWindow.xaml
    /// </summary>
    public partial class EmployeerAddWindow : Window
    {
        private static Employees _currentEmployeer = new Employees();
        private TourfirmEntities db = new TourfirmEntities();
        public EmployeerAddWindow(Employees curretEmployeer)
        {
            InitializeComponent();
            _currentEmployeer = curretEmployeer;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Employees employer = new Employees();

            employer.FirstName = txtFirstName.Text;
            employer.LastName = txtLastName.Text;
            employer.MiddleName = txtMiddleName.Text;
            employer.Password = txtPassword.Text;
            employer.Login = txtLogin.Text;
            employer.Phone = txtPhone.Text;
            employer.Email = txtEmail.Text;
            employer.BirthdayDate = (DateTime)dtBirthday.SelectedDate;
            employer.Position = "Менеджер";


            db.Employees.Add(employer);
            db.SaveChanges();
            MessageBox.Show("Сотрудник успешно сохранен");
            Close();
        }
    }
}
