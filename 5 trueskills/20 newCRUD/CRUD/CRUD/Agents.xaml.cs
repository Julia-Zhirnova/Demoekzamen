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

namespace CRUD
{
    /// <summary>
    /// Логика взаимодействия для Agents.xaml
    /// </summary>
    public partial class Agents : Page
    {
       // CRUDEntities _context = new CRUDEntities();
        public Agents()
        {
            InitializeComponent();
            DGridCRUDagents.ItemsSource = CRUDEntities.GetContext().agents.ToList();
        }
        private void RefreshData()
        {
            DGridCRUDagents.ItemsSource = CRUDEntities.GetContext().agents.ToList();
            
        }
        private void BtnEditAgent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditAgentsPage((sender as Button).DataContext as agents));
        }

        private void BtnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditAgentsPage(null));
        }

        private void BtnDelAgent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
