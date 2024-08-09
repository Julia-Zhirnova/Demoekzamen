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
using WordApp.Models;
using Word = Microsoft.Office.Interop.Word;

namespace WordApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product product;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                product = new Product() { Id = 1, Name = "Huawei P50 Pro", Description = "Top" };
                product.Sales.Add(new Sale() { Id = 2, DateSale = DateTime.Now, Count = 1, Price = 100 });
                product.Sales.Add(new Sale() { Id = 3, DateSale = DateTime.Now.AddDays(-1), Count = 1, Price = 150 });
                product.Sales.Add(new Sale() { Id = 4, DateSale = DateTime.Now.AddDays(-2), Count = 1, Price = 170 });
                this.DataContext = product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Word._Application wApp = new Word.Application();
                Word._Document wDoc = wApp.Documents.Add();
                wApp.Visible = true;
                wDoc.Activate();
                var ProductParagraph = wDoc.Content.Paragraphs.Add();
                ProductParagraph.Range.Text = $"Код товара:\t{product.Id}\n" +
                    $"Наименование продукта:\t{product.Name}\n" +
                    $"Описание продукта:\t{product.Description}\n";
                Word.Table wTable = wDoc.Tables.Add((Microsoft.Office.Interop.Word.Range)ProductParagraph.Range,
                    product.Sales.Count + 1, 4, Word.WdDefaultTableBehavior.wdWord9TableBehavior);
                wTable.Cell(1, 1).Range.Text = "Дата продажи";
                wTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wTable.Cell(1, 2).Range.Text = "Количество товара";
                wTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wTable.Cell(1, 3).Range.Text = "Цена товара";
                wTable.Cell(1, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wTable.Cell(1, 4).Range.Text = "Стоимость";
                wTable.Cell(1, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int countRow = 2;
                foreach (var item in product.Sales)
                {
                    wTable.Cell(countRow, 1).Range.Text = item.DateSale.ToShortDateString();
                    wTable.Cell(countRow, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wTable.Cell(countRow, 2).Range.Text = item.Count.ToString();
                    wTable.Cell(countRow, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wTable.Cell(countRow, 3).Range.Text = item.Price.ToString();
                    wTable.Cell(countRow, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wTable.Cell(countRow,4).Range.Text = (item.Count*item.Price).ToString();
                    wTable.Cell(countRow, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    countRow++;
                }
                Word.Chart wChart;
                Word.InlineShape inlineShape;
                inlineShape = wDoc.InlineShapes.AddChart(Microsoft.Office.Core.XlChartType.xlColumnClustered, ProductParagraph.Range);
                wChart = inlineShape.Chart;
                dynamic chartWB = wChart.ChartData.Workbook;
                dynamic chartTable = chartWB.Sheets[1].ListObjects("Table1");
                chartTable.DataBodyRange.ClearContents();
                dynamic chartRange = chartTable.Range.Resize[2, product.Sales.Count + 1];
                chartTable.Resize(chartRange);
                int countCol = 2;
                foreach (var item in product.Sales)
                {
                    chartRange.Cells[1, countCol] = item.DateSale.ToShortDateString();
                    chartRange.Cells[2, countCol] = (item.Count * item.Price).ToString();
                    countCol++;
                }
                wDoc.SaveAs2($@"{Environment.CurrentDirectory}\1.docx");
                wDoc.SaveAs2($@"{Environment.CurrentDirectory}\1.pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);



            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ошибка");
            }
        }
    }
}
