using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Draw;
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.IO.Image;
using iText.Layout.Element;
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
using TourfirmApp.Models;
using Microsoft.Win32;
using TourfirmApp.Views.Windows;
using System.Windows.Threading;

namespace TourfirmApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractsPage.xaml
    /// </summary>
    public partial class ContractsPage : Page
    {
        private static List<Orders> _order;
        private static Orders currentOrder;
        public ContractsPage()
        {
            InitializeComponent();
            dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.ToList();
        }
       
        private void btnContractCreate_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem == null)
                MessageBox.Show("Выберите договор, щелкнув по нему правой кнопкой мыши");
            else
            {
                var b = dgOrders.SelectedItem as Orders;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files | *.pdf";

                if (sfd.ShowDialog() == false) return;

                PdfWriter writer = new PdfWriter(sfd.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                pdf.SetDefaultPageSize(PageSize.A5);

                PdfFont font = PdfFontFactory.CreateFont("C:\\Windows\\Fonts\\Arial.ttf");


                Paragraph header = new Paragraph($"Договор оказания туристических услуг № {b.OrderID} ")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(14)
                   .SetFont(font);
                document.Add(header);

                Paragraph prob = new Paragraph()
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(14)
                    .SetFont(font);
                document.Add(prob);

                Paragraph header1 = new Paragraph($"«{DateTime.Now.Day}» июня\t2023 г.\t\t\t\t\t\t\t г.Коломна")
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                  .SetFontSize(12)
                  .SetFont(font);
                document.Add(header1);

                Paragraph prob1 = new Paragraph()
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                  .SetFontSize(14)
                  .SetFont(font);
                document.Add(prob1);

                Paragraph a1 = new Paragraph($"\t\tИндивидуальный предприниматель Соломатин Дмитрий Алексеевич, действующий на основании Свидетельства о государственной регистрации физического лица в качестве индивидуального предпринимателя, выданного Инспекцией Федеральной налоговой службы по г.Москва, " +
                    $"серия 36 №003865724 и являющийся объектом налогообложения по УСН, именуемый в дальнейшем ИСПОЛНИТЕЛЬ с одной стороны, и {b.Customers.Lastname}\t{b.Customers.Firstname}\t{b.Customers.Middlename}\tименуемый в дальнейшем ЗАКАЗЧИК, с другой стороны, заключили настоящий ДОГОВОР о следующем: ")
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL)
                  .SetFontSize(12)
                  .SetFont(font);
                document.Add(a1);

                Paragraph prob3 = new Paragraph()
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(14)
                .SetFont(font);
                document.Add(prob3);

                Paragraph head11 = new Paragraph("1. Предмет договора. ")
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                  .SetFontSize(14)
                  .SetFont(font);
                document.Add(head11);

                Paragraph prob4 = new Paragraph()
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(14)
                    .SetFont(font);
                document.Add(prob4);

                Paragraph a2 = new Paragraph("\t\t1.1. ИСПОЛНИТЕЛЬ, действующий по поручению, от имени, за счет и в интересах ЗАКАЗЧИКА " +
                    "(туриста(-ов) ЗАКАЗЧИКА), обязуется осуществить комплекс работ по бронированию туристических услуг" +
                    "(подбор номера, бронирование, оплата и др.) на ФИО туриста(-ов) ЗАКАЗЧИКА на месте")
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL)
                  .SetFontSize(12)
                  .SetFont(font);
                document.Add(a2);

                Paragraph prob5 = new Paragraph()
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(14)
                .SetFont(font);
                document.Add(prob5);

                Paragraph head2 = new Paragraph("2. Общая стоимость договора и порядок расчетов. ")
               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
               .SetFontSize(14)
               .SetFont(font);
                document.Add(head2);

                Paragraph prob6 = new Paragraph()
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(14)
                .SetFont(font);
                document.Add(prob6);

                Paragraph a3 = new Paragraph($"\t\t2.1. Общая стоимость оплаты за туруслуги составляет: {b.DealAmount}" +
                    $"\n2.2.Оплата производится ЗАКАЗЧИКОМ(туристом(-ами) ЗАКАЗЧИКА) ИСПОЛНИТЕЛЮ согласно СЧЕТУ.Оплата производится в течении 3 дней с момента выставления СЧЕТА." +
                    $"\n2.3.Денежные средства, полученные ИСПОЛНИТЕЛЕМ на исполнение предмета ДОГОВОРА не являются собственностью ИСПОЛНИТЕЛЯ, за исключением агентского вознаграждения заложенного в цене " +
                    $"ДОГОВОРА, и предоставлены ИСПОЛНИТЕЛЮ ЗАКАЗЧИКОМ(туристом(-ами) ЗАКАЗЧИКА) наременное хранение для осуществления дальнейшей оплаты на объект." +
                    $"Вознаграждение ИСПОЛНИТЕЛЯ удерживается из суммы платежа.")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL)
                .SetFontSize(12)
                .SetFont(font);
                document.Add(a3);

                Paragraph prob7 = new Paragraph()
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(14)
                .SetFont(font);
                document.Add(prob7);

                Paragraph head3 = new Paragraph("3. Права и обязанности сторон: ")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(14)
                .SetFont(font);
                document.Add(head3);

                Paragraph prob8 = new Paragraph()
          .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
          .SetFontSize(14)
          .SetFont(font);
                document.Add(prob8);

                Paragraph a4 = new Paragraph("\n3.1. ЗАКАЗЧИК (турист (-ы) ЗАКАЗЧИКА) имеет право:" +
                    "\n- требовать от ИСПОЛНИТЕЛЯ выполнения полного комплекса работ по бронированию туруслуг согласно п.1.1 данного ДОГОВОРА." +
                    "\n- требовать от объекта размещения предоставления ЗАКАЗЧИКУ(туристу(-ам) ЗАКАЗЧИКА) полного комплекса туристических услуг согласно п.1.1 данного ДОГОВОРА." +
                    "\n3.2.ЗАКАЗЧИК(турист(-ы) ЗАКАЗЧИКА) обязаны:" +
                    "\n-получить консультацию в медицинском учреждении по месту жительства о противопоказаниях к санаторно - курортному лечению." +
                    "\n- заранее подготовить все необходимые для поселения документы, а именно:" +
                    "\n1.для взрослого — паспорт, санаторно - курортная карта." +
                    "\n2.для детей – свидетельство о рождении, справка об эпидокружении и прививках." +
                    "\n- соблюдать графики, сроки и порядок заезда и выезда." +
                    "\n- соблюдать требования Законодательства РФ, правила поведения в местах пребывания; не нарушать общественный порядок; соблюдать требования по сбережению объектов истории и культуры, природы; " +
                    "соблюдать все правила техники безопасности, в том числе – противопожарной, общеобязатель   ные требования и правила внутреннего распорядка в местах размещения и пребывания.предохранительные и предупредительные меры по обеспечению личной безопасности и безопасности окружающих лиц;" +
                    "\n-в случае причинения материального ущерба, ИСПОЛНИТЕЛЮ либо Принимающей стороне компенсировать убытки в полном объеме." +
                    "\n3.3.ИСПОЛНИТЕЛЬ имеет право:" +
                    "\n-обеспечивать прием на обслуживание только лиц, указанных в ПОДТВЕРЖДЕНИИ БРОНИРОВАНИЯ." +
                    "\n-ИСПОЛНИТЕЛЬ является представителем ЗАКАЗЧИКА(туриста(-ов) ЗАКАЗЧИКА) и ему" +
                    "предоставлено право в рамках настоящего ДОГОВОРА действовать от имени и в интересах ЗАКАЗЧИКА(туриста(-ов) ЗАКАЗЧИКА) с целью бронирования туристических услуг согласно п.1 данного ДОГОВОРА. " +
                    "\n3.4.ИСПОЛНИТЕЛЬ обязан:" +
                    "\n-соблюдать все условия данного ДОГОВОРА." +
                    "\n-требовать от объекта размещения предоставления ЗАКАЗЧИКУ(туристу(-ам) ЗАКАЗЧИКА) полного комплекса туристических услуг согласно п.1.1 данного ДОГОВОРА." +
                    "\n-соблюдать графики, сроки и порядок заезда и выезда ЗАКАЗЧИКА(туриста(-ов) ЗАКАЗЧИКА). " +
                    "\n-редоставить ЗАКАЗЧИКУ(туристу (-ам) ЗАКАЗЧИКА) необходимые для поселения на объект размещения(ДОГОВОР, ПОДТВЕРЖДЕНИЕ БРОНИРОВАНИЯ или путевка)." +
                    "\n-информировать ЗАКАЗЧИКА(туриста (-ов) ЗАКАЗЧИКА) об обязательном(медицинском и от несчастного случая) страховании.")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.JUSTIFIED_ALL)
                .SetFontSize(12)
                .SetFont(font);
                document.Add(a4);


                //Services[] services = db.EntryServicesRefs.Where(r => r.Id_entry == entries.Id).Select(s => s.Services).ToArray();
                //Orders[] orders = db.Orders.Where(p => p.Tours.StartDate >= dtStart.SelectedDate && p.Tours.EndDate <= dtEnd.SelectedDate).ToArray();

                document.Close();

                MessageBox.Show("Договор успешно сохранен", "Информация о договоре", MessageBoxButton.OK);
            }
            
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            currentOrder = dgOrders.SelectedItem as Orders;
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        private void cmbPaymentStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbPaymentStatus.SelectedIndex)
            {
                case 0:
                    cmbPaymentStatus.Text = "Все договора";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.ToList();
                    break;
                case 1:
                    cmbPaymentStatus.Text = "Ожидается оплата";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.PaymentState == "Ожидается оплата").ToList();
                    break;
                case 2:
                    cmbPaymentStatus.Text = "Оплачено";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.PaymentState == "Оплачено").ToList();
                    break;
            }
        }

        private void cmbOrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbOrderStatus.SelectedIndex)
            {
                case 0:
                    cmbPaymentStatus.Text = "Все договора";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.ToList();
                    break;
                case 1:
                    cmbPaymentStatus.Text = "Ещё не исполнен";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.OrderState == "Ещё не исполнен").ToList();
                    break;
                case 2:
                    cmbPaymentStatus.Text = "Исполнен";
                    dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.Where(x => x.OrderState == "Исполнен").ToList();
                    break;
            }
        }
        public void UpLoad()
        {
            dgOrders.ItemsSource = TourfirmEntities.GetContext().Orders.ToList();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem == null)
                MessageBox.Show("Выберите договор, щелкнув по нему правой кнопкой мыши");
            else
            {
                OrderEditWindow customerEdit = new OrderEditWindow((Orders)dgOrders.SelectedItem);
                customerEdit.ShowDialog();
                UpLoad();
            }
        }

        public void UpdateData(object sender, object e)
        {

            _order = TourfirmEntities.GetContext().Orders.ToList();
            if (!String.IsNullOrWhiteSpace(txtFind.Text))
            {
                String text = txtFind.Text.ToLower();
                _order = _order.Where(x => x.Customers.Lastname.ToLower().StartsWith(text) || x.DealAmount.ToString().StartsWith(text)).ToList();
            }
            dgOrders.ItemsSource = _order;
        }
    }
}
