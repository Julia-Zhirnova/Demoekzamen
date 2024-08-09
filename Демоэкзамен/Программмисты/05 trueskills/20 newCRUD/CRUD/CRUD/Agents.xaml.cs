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
            var allTypes = CRUDEntities.GetContext().agents.ToList();
            allTypes.Insert(0, new agents { FirstName = "Все типы" });
            ComboBoxColumn.ItemsSource = allTypes;
          
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

        private void BtnSaveAgent_Click(object sender, RoutedEventArgs e)
        {
          //  CRUDEntities.GetContext().agents.Add(_currentagents);
        }

        private void AgentsDataGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Manager.MainFrame.Navigate(new EditAgentsPage(null));
            // CRUDEntities.GetContext().agents.Add((sender as Button).DataContext as agents); 
            try
            {
                CRUDEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void peopleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          /*  if (peopleComboBox.SelectedValue is { }) // если не равно null
            {
                selectedPerson.Text = peopleComboBox.SelectedValue.ToString();
            }*/
        }
    }
    public class Person
    {
        public string Name { get; set; } = "";
        public string Company { get; set; } = "";
        public override string ToString() => $"{Name} ({Company})";
    }
}
