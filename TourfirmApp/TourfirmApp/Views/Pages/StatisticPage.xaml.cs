using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TourfirmApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        private TourfirmEntities db = new TourfirmEntities();
        public StatisticPage()
        {
            InitializeComponent();
        }

        private void btnTourReport_Click(object sender, RoutedEventArgs e)
        {
            if (dtEnd.SelectedDate == null || dtStart.SelectedDate == null || dtStart.SelectedDate > dtEnd.SelectedDate)
            {
                MessageBox.Show("Неправильная дата", "Информация об оборудовании", MessageBoxButton.OK);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files | *.pdf";

                if (sfd.ShowDialog() == false) return;

                PdfWriter writer = new PdfWriter(sfd.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                pdf.SetDefaultPageSize(PageSize.A5);

                PdfFont font = PdfFontFactory.CreateFont("C:\\Windows\\Fonts\\Arial.ttf");


                Paragraph header = new Paragraph("Отчёт по проданным турам")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(20)
                   .SetFont(font);
                Paragraph dateReport = new Paragraph($"за {dtStart.Text} по {dtEnd.Text} ")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(16)
                   .SetFont(font);

                document.Add(header);
                document.Add(dateReport);

                LineSeparator ls = new LineSeparator(new SolidLine());

                document.Add(ls);

                Table table = new Table(2, false);
                table.SetMarginTop(10);
                table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                Cell header1 = new Cell(1, 1)
                 .SetBackgroundColor(ColorConstants.GRAY)
                 .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(font)
                 .Add(new Paragraph("Тур"));
                table.AddCell(header1);

                Cell header2 = new Cell(1, 2)
                 .SetBackgroundColor(ColorConstants.GRAY)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .Add(new Paragraph("Цена"))
                 .SetFont(font);
                table.AddCell(header2);


                //Services[] services = db.EntryServicesRefs.Where(r => r.Id_entry == entries.Id).Select(s => s.Services).ToArray();
                Orders[] orders = db.Orders.Where(p => p.Tours.StartDate >= dtStart.SelectedDate && p.Tours.EndDate <= dtEnd.SelectedDate).ToArray();
                decimal sum = 0;
                
                for (int i = 0; i < orders.Length; i++)
                {
                    Orders service = orders[i];

                    Cell cell1 = new Cell(i + 1, 1)
                     .SetTextAlignment(TextAlignment.CENTER)
                     .Add(new Paragraph($"{service.Tours.Description}"))
                     .SetFont(font);
                    table.AddCell(cell1);

                    Cell cell2 = new Cell(i + 1, 2)
                     .SetTextAlignment(TextAlignment.CENTER)
                     .Add(new Paragraph($"{service.DealAmount} руб."))
                     .SetFont(font);
                    table.AddCell(cell2);

                    sum += service.DealAmount;
                }

                document.Add(table);

                Paragraph total = new Paragraph($"Итоговая сумма: {sum} руб.")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(16)
                   .SetFont(font);
                document.Add(total);

                document.Close();

                MessageBox.Show("Отчёт успешно сохранен", "Информация об отчёте", MessageBoxButton.OK);
            } 
        }

        private void btnCustomerReport_Click(object sender, RoutedEventArgs e)
        {
            if (dtEnd.SelectedDate == null || dtStart.SelectedDate == null || dtStart.SelectedDate > dtEnd.SelectedDate)
            {
                MessageBox.Show("Неправильная дата", "Информация об оборудовании", MessageBoxButton.OK);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files | *.pdf";

                if (sfd.ShowDialog() == false) return;

                PdfWriter writer = new PdfWriter(sfd.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                pdf.SetDefaultPageSize(PageSize.A5);

                PdfFont font = PdfFontFactory.CreateFont("C:\\Windows\\Fonts\\Arial.ttf");


                Paragraph header = new Paragraph("Отчёт по работе с клиентами")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(20)
                   .SetFont(font);
                Paragraph dateReport = new Paragraph($"за {dtStart.Text} по {dtEnd.Text} ")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(16)
                   .SetFont(font);

                document.Add(header);
                document.Add(dateReport);

                LineSeparator ls = new LineSeparator(new SolidLine());

                document.Add(ls);

                Table table = new Table(2, false);
                table.SetMarginTop(10);
                table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                Cell header1 = new Cell(1, 1)
                 .SetBackgroundColor(ColorConstants.GRAY)
                 .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(font)
                 .Add(new Paragraph("Клиент"));
                table.AddCell(header1);

                Cell header2 = new Cell(1, 2)
                 .SetBackgroundColor(ColorConstants.GRAY)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .Add(new Paragraph("Цена"))
                 .SetFont(font);
                table.AddCell(header2);


                //Services[] services = db.EntryServicesRefs.Where(r => r.Id_entry == entries.Id).Select(s => s.Services).ToArray();
                Orders[] orders = db.Orders.Where(p => p.Tours.StartDate >= dtStart.SelectedDate && p.Tours.EndDate <= dtEnd.SelectedDate).ToArray();
                decimal sum = 0;

                for (int i = 0; i < orders.Length; i++)
                {
                    Orders service = orders[i];

                    Cell cell1 = new Cell(i + 1, 1)
                     .SetTextAlignment(TextAlignment.CENTER)
                     .Add(new Paragraph($"{service.Customers.Lastname}\t{service.Customers.Firstname}"))
                     .SetFont(font);
                    table.AddCell(cell1);

                    Cell cell2 = new Cell(i + 1, 2)
                     .SetTextAlignment(TextAlignment.CENTER)
                     .Add(new Paragraph($"{service.DealAmount} руб."))
                     .SetFont(font);
                    table.AddCell(cell2);

                    sum += service.DealAmount;
                }

                document.Add(table);

                Paragraph total = new Paragraph($"Итоговая сумма: {sum} руб.")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(16)
                   .SetFont(font);
                document.Add(total);

                document.Close();

                MessageBox.Show("Отчёт успешно сохранен", "Информация об отчёте", MessageBoxButton.OK);
            }
        }
    }
}
