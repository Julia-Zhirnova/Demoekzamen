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

namespace CRUD.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();
            
            DGridCRUDagents.ItemsSource = Models.CRUDEntities.GetContext().agents.ToList();
        }

        private void BtnEditAgent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditAgentsPage((sender as Button).DataContext as Models.agents));
        }
        
        private void BtnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditAgentsPage(null));            
        }

        private void BtnDelAgent_Click(object sender, RoutedEventArgs e)
        {
            var agentsForRemoving = DGridCRUDagents.SelectedItems.Cast<Models.agents>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {agentsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Models.CRUDEntities.GetContext().agents.RemoveRange(agentsForRemoving);
                    Models.CRUDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridCRUDagents.ItemsSource = Models.CRUDEntities.GetContext().agents.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        
    }

}
