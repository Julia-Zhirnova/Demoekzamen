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


namespace Uchet_Zayavok.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ispolnitel.xaml
    /// </summary>
    public partial class Ispolnitel : Page
    {
        public Ispolnitel()
        {
            InitializeComponent();
            DGZayavka.ItemsSource = Model.uchet_zayavokEntities.GetContext().Zayavka.ToList();
            Dannye.Visibility = Visibility.Hidden;
            Sortirovka.Visibility = Visibility.Hidden;
            if (Model.uchet_zayavokEntities.CurentUser.ID == 1)
            {
                Dannye.Visibility = Visibility.Visible;
                Sortirovka.Visibility = Visibility.Visible;
                var allStatus = Model.uchet_zayavokEntities.GetContext().Status.ToList();
                allStatus.Insert(0, new Model.Status { StatusZayavki = "Все статусы" });   
                var Filt = new List<string>() { "Все статусы" };
                Filt.AddRange(Model.uchet_zayavokEntities.GetContext().Status.Select(c => c.StatusZayavki).ToList());
                ComboType.ItemsSource = Filt;
                ComboType.SelectedIndex = 0;
            }
            
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData(ComboType.Text, SearchBox.Text);
        }
        private void RefreshData(string filt = "", string search = "")
        {
            
            var currentZayavka = Model.uchet_zayavokEntities.GetContext().Zayavka.ToList();
            List<Model.Zayavka> listZayavka = currentZayavka;
            CalculateSummaryData(listZayavka);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                currentZayavka = currentZayavka.Where(p => p.ReasonNeisp.ToLower().Contains(search.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filt) && !string.IsNullOrEmpty(filt))
            {
                if (filt != "Все статусы")
                {
                    currentZayavka = currentZayavka.Where(p => p.Status.StatusZayavki == filt).ToList();
                }
            }
            DGZayavka.ItemsSource = currentZayavka;

        }

        private void BtnEditAgent_Click(object sender, RoutedEventArgs e)
        {
            Classes.manager.MainFrame.Navigate(new EditZayavka((sender as Button).DataContext as Model.Zayavka));
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            var ZayavkaForRemoving = DGZayavka.SelectedItems.Cast<Model.Zayavka>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ZayavkaForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Model.uchet_zayavokEntities.GetContext().Zayavka.RemoveRange(ZayavkaForRemoving);
                    Model.uchet_zayavokEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void DGZayavka_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Model.uchet_zayavokEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGZayavka.ItemsSource = Model.uchet_zayavokEntities.GetContext().Zayavka.ToList();
            RefreshData(ComboType.Text, SearchBox.Text);
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            x.Text = "";
            RefreshData(ComboType.Text, SearchBox.Text);
            if (DGZayavka.Items.Count == 0)
            {
                x.Text = "По данному запросу ничего не найдено";
            }
        }
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                x.Text = "";
                RefreshData(ComboType.Text, SearchBox.Text);
                if (DGZayavka.Items.Count == 0)
                {
                    x.Text = "По данному запросу ничего не найдено";
                }
            }
        }
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            x.Text = "";
            RefreshData(ComboType.Text, SearchBox.Text);
        }
        private void CalculateSummaryData(List<Model.Zayavka> listZayavka)
        {
            LblTotalQuantity.Content = listZayavka.Count + " наименований";
// double sum = listZayavka.Average(x => x.DataEnd.GetValueOrDefault().Subtract(x.DataAdd.GetValueOrDefault()));
            LblTotalSum.Content = $"Среднее время выполнения заявки: {5:N2} дней.";
        }
    }
}
