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
using Попрыженок.Entities;
using Попрыженок.Views;
using Попрыженок.Models;

namespace Попрыженок.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            AgentsDataGrid.ItemsSource = user1Entities.GetContext().Agent.ToList();
            SortComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.NavigationFrame.Navigate(new AddPage());
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var RemoveColums = AgentsDataGrid.SelectedItems.Cast<Agent>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {RemoveColums.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    user1Entities.GetContext().Agent.RemoveRange(RemoveColums);
                    user1Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    AgentsDataGrid.ItemsSource = user1Entities.GetContext().Agent.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AgentsDataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<Agent> EditColumn;
            EditColumn = AgentsDataGrid.SelectedItems.Cast<Agent>().ToList();
            AddPage EditPage = new AddPage(EditColumn);
            NavigationClass.NavigationFrame.Navigate(EditPage);
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(SearchTextBox.Text, (SortComboBox.SelectedItem as ComboBoxItem).Content.ToString(),AgentTypeComboBox.Text);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        int skip = 0;
        bool flag = true;
        private void Update(string searh="", string sort="", string filt = "")
        {            
            spPages.Children.Clear();
            var data = user1Entities.GetContext().Agent.ToList();
            if (!string.IsNullOrEmpty(searh) && !string.IsNullOrWhiteSpace(sort))
            {
                data = data.Where(p => p.Title.ToLower().Contains(searh.ToLower()) || p.Phone.ToLower().Contains(searh.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filt) && !string.IsNullOrEmpty(filt))
            {
                if (filt != "Все типы")
                {
                    data = data.Where(c => c.AgentType.Title == filt).ToList();
                }
            }
            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrWhiteSpace(sort))
            {
                if (sort == "Наименование (по возрастанию)")
                {
                    data = data.OrderBy(c => c.ID).ToList();
                }
                if (sort == "Наименование (по убыванию)")
                {
                    data = data.OrderByDescending(c => c.ID).ToList();
                }
                if (sort == "Приоритет (по возрастанию)")
                {
                    data = data.OrderBy(c => c.Priority).ToList();
                }
                if (sort == "Приоритет (по убыванию)")
                {
                    data = data.OrderByDescending(c => c.Priority).ToList();
                }
                if (sort == "Размер скидки (по возрастанию)")
                {                    
                    data = data.OrderBy(c => c.Discount).ToList();
                }
                if (sort == "Размер скидки (по убыванию)")
                {
                    data = data.OrderByDescending(c => c.Discount).ToList();
                }
            }
            var data2 = user1Entities.GetContext().Agent.ToList();
            AmountAgents.Text = data.Count.ToString() + " из " + data2.Count.ToString();
            for (int i = 0; i < data.Count / 10; i++)
            {
                TextBlock txt = new TextBlock()
                {
                    Margin = new Thickness(2, 0, 0, 2),
                    VerticalAlignment = VerticalAlignment.Center,
                    Text = (i + 1).ToString()
                };
                if (skip == 0)
                {
                    if (i == 0)
                        txt.TextDecorations = TextDecorations.Underline;
                }
                txt.MouseDown += (z, x) =>
                {                    
                    foreach (var item in spPages.Children)
                    {
                        (item as TextBlock).TextDecorations = null;
                    }
                    txt.TextDecorations = TextDecorations.Underline;
                    AgentsDataGrid.ItemsSource = data.Skip(i / 10).Take(10).ToList();
                    skip = (Convert.ToInt32(txt.Text) * 10) - 10;
                    Update(SearchTextBox.Text, SortComboBox.Text, AgentTypeComboBox.Text);
                };

                if (skip / 10 == i)
                {
                    txt.TextDecorations = TextDecorations.Underline;
                }
                spPages.Children.Add(txt);
            }
            data = data.Skip(skip).Take(10).ToList();
            if (data.Count == 0)
            {
                skip -= 10;
                flag = false;

            }
            AgentsDataGrid.ItemsSource = data;                                    
        }
        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (skip - 10 != -10)
            {
                skip -= 10;
                flag = true;
                Update(SearchTextBox.Text, SortComboBox.Text, AgentTypeComboBox.Text);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (flag)
            {
                skip += 10;
                Update(SearchTextBox.Text, SortComboBox.Text, AgentTypeComboBox.Text);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var AgentType = new List<string>() { "Все типы" };
            AgentType.AddRange(user1Entities.GetContext().AgentType.Select(c => c.Title).ToList());
            AgentTypeComboBox.ItemsSource = AgentType;
            AgentTypeComboBox.SelectedIndex = 0;
            Update(SearchTextBox.Text, SortComboBox.Text, AgentTypeComboBox.Text);
        }

        private void AgentTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(SearchTextBox.Text,SortComboBox.Text, ( AgentTypeComboBox.SelectedItem as string).ToString());
        }

        private void AgentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
