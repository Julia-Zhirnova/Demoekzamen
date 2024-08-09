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

namespace ServiceApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();

            DGrid.ItemsSource = Entities.GetContext().Service.ToList();

        }

        private void Update(string sort = "", string search = "")
        {
            var data = Entities.GetContext().Service.ToList();

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                data = data.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            

            DGrid.ItemsSource = data;
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NothingFoundTB.Text = "";
                Update(SortComboBox.Text, SearchBox.Text);
                if (DGrid.Items.Count == 0)
                {
                    NothingFoundTB.Text = "По данному запросу ничего не найдено";
                }
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            NothingFoundTB.Text = "";
            Update(SortComboBox.Text, SearchBox.Text);
            if (DGrid.Items.Count == 0)
            {
                NothingFoundTB.Text = "По данному запросу ничего не найдено";
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            NothingFoundTB.Text = "";
            Update(SortComboBox.Text, SearchBox.Text);
        }

        private void DGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGrid.ItemsSource = Entities.GetContext().Service.ToList();
            Update(SortComboBox.Text, SearchBox.Text);
        }
    }
}
