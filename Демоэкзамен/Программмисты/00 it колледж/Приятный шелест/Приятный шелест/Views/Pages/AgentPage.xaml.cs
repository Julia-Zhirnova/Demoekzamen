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
using Приятный_шелест.Enitities;
using Приятный_шелест.Views.Windows;

namespace Приятный_шелест.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(txtSearch.Text, cmbFilter.Text,(cmbSort.SelectedItem as ComboBoxItem).Content.ToString());
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(txtSearch.Text, (cmbFilter.SelectedItem as string).ToString(), cmbSort.Text);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update(txtSearch.Text, cmbFilter.Text, cmbSort.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var AgentType = new List<string>() { "Все типы" };
            AgentType.AddRange(AppData.db.AGENTTYPE.Select(c => c.NAME).ToList());
            cmbFilter.ItemsSource = AgentType;
            cmbFilter.SelectedIndex = 0;
            Update(txtSearch.Text, cmbFilter.Text, cmbSort.Text);
        }
        void Update(string search = "" , string type = "", string sort = "")
        {
            spPages.Children.Clear();
            var Data = AppData.db.AGENT.ToList();
            if(!string.IsNullOrWhiteSpace(search) && !string.IsNullOrEmpty(search))
            {
                Data = Data.Where(c => c.EMAIL.ToLower().Contains(search.ToLower()) || c.PHONE.ToLower().Contains(search.ToLower())).ToList();
            }
            if(!string.IsNullOrWhiteSpace(type) && !string.IsNullOrEmpty(type))
            {
                if(type != "Все типы")
                {
                    Data = Data.Where(c => c.AGENTTYPE.NAME == type).ToList();
                }
            }
            if(!string.IsNullOrEmpty(sort) && !string.IsNullOrWhiteSpace(sort))
            {
                if(sort == "Наименование (по возрастанию)")
                {
                    Data = Data.OrderBy(c => c.NAME).ToList();
                }
                if (sort == "Наименование (по убыванию)")
                {
                    Data = Data.OrderByDescending(c => c.NAME).ToList();
                }
                if (sort == "Размер скидки (по возрастанию)")
                {
                    Data = Data.OrderBy(c => c.Discount).ToList();
                }
                if (sort == "Размер скидки (по убыванию)")
                {
                    Data = Data.OrderByDescending(c => c.Discount).ToList();
                }
                if (sort == "Приоритет (по убыванию)")
                {
                    Data = Data.OrderBy(c => c.AGENTHISTORY.LastOrDefault().PRIORITY).ToList();
                }
                if (sort == "Приоритет (по убыванию)")
                {
                    Data = Data.OrderByDescending(c => c.AGENTHISTORY.LastOrDefault().PRIORITY).ToList();
                }
            }
            for (int i = 0; i < Data.Count/10; i++)
            {
                TextBlock txt = new TextBlock()
                {
                    Margin = new Thickness(2, 0, 0, 2),
                    VerticalAlignment = VerticalAlignment.Center,
                    Text = (i + 1).ToString()
                };
                if ( skip == 0)
                {
                    if(i == 0)
                    txt.TextDecorations = TextDecorations.Underline;
                }
                txt.MouseDown += (z, x) =>
                {
                    foreach (var item in spPages.Children)
                    {
                        (item as TextBlock).TextDecorations = null;
                    }
                    txt.TextDecorations = TextDecorations.Underline;
                    dgAgents.ItemsSource = Data.Skip(i / 10).Take(10).ToList();
                    skip = (Convert.ToInt32(txt.Text) * 10)-10;
                };

                if(skip/10 == i)
                {
                    txt.TextDecorations = TextDecorations.Underline;
                }
                spPages.Children.Add(txt);
            }
            Data = Data.Skip(skip).Take(10).ToList();
            if (Data.Count == 0 )
            {
                skip -= 10;
                flag = false;
               
            }
            else
            {
                dgAgents.ItemsSource = Data;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(skip - 10 != -10)
            {
                skip -= 10;
                flag = true;
                Update(txtSearch.Text, cmbFilter.Text, cmbSort.Text);
            }
            
        }
        int skip = 0;
        bool flag = true;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                skip += 10;
                Update(txtSearch.Text, cmbFilter.Text, cmbSort.Text);
            }
        }

        private void dgAgents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (dgAgents.SelectedItems.Count != 0)
            {
                btnEditPriority.Visibility = Visibility.Visible;
            }
            else
            {
                btnEditPriority.Visibility = Visibility.Collapsed;
            }
        }

        private void btnEditPriority_Click(object sender, RoutedEventArgs e)
        {
            List<AGENT> agentList = new List<AGENT>();
            foreach (var item in dgAgents.SelectedItems)
            {
                agentList.Add(item as AGENT);
            }
            EditPriorityWindow window = new EditPriorityWindow(agentList);
            window.ShowDialog();
            Update(txtSearch.Text, cmbFilter.Text, cmbSort.Text);
        }

        private void btnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            EditAgentWindow editAgentWindow = new EditAgentWindow();
            editAgentWindow.ShowDialog();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EditAgentWindow editAgentWindow = new EditAgentWindow((sender as StackPanel).DataContext as AGENT);
            editAgentWindow.Show();
            Update(txtSearch.Text, cmbFilter.Text, cmbSort.Text);
        }
    }
}
