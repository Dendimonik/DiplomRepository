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
using TourfirmApp.Utils;

namespace TourfirmApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizathionWindow.xaml
    /// </summary>
    public partial class AuthorizathionWindow : Window
    {

        public AuthorizathionWindow()
        {
            InitializeComponent();
            txtLogin.Focus();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtLogin.Text == "admin" && pswPass.Password == "root")
                {

                    var admWindow = new AdminWindow();
                    admWindow.Owner = this;
                    admWindow.Show();
                    Hide();


                }
                else
                {
                    var currentUser = AppData.DB.Employees.FirstOrDefault(c => c.Login == txtLogin.Text
                && c.Password == pswPass.Password);
                    if (currentUser != null)
                    {
                        var menedgWindow = new MainWindow(currentUser);
                        menedgWindow.Owner = this;
                        menedgWindow.Title = "Менеджер " + currentUser.FirstName + " " + currentUser.LastName;
                        menedgWindow.Show();
                        Hide();
                    }
                    else
                    {
                        throw new Exception("Пользователь не найден");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

      
    }
}
