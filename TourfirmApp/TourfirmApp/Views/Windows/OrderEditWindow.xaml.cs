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
    /// Логика взаимодействия для OrderEditWindow.xaml
    /// </summary>
    public partial class OrderEditWindow : Window
    {
        private TourfirmEntities db = new TourfirmEntities();
        private static Orders _currentOrder = new Orders();
        public OrderEditWindow(Orders currentOrder)
        {
            _currentOrder = currentOrder;
            InitializeComponent();
            txtPrePayment.Text = currentOrder.Prepayment.ToString();
            txtPaymentStatus.Text = currentOrder.PaymentState;
            txtOrderStatus.Text = currentOrder.OrderState;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            _currentOrder.Prepayment = Convert.ToDecimal(txtPrePayment.Text);
            _currentOrder.PaymentState = txtPaymentStatus.Text;
            _currentOrder.OrderState = txtOrderStatus.Text;

            TourfirmEntities.GetContext().SaveChanges();
            db.SaveChanges();
            MessageBox.Show("Заказчик успешно обновлен");
            Close();

        }
    }
}
