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
using Попрыженок.Views;
using Попрыженок.Models;
using Попрыженок.Entities;
using Microsoft.Win32;
using System.IO;

namespace Попрыженок.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public OpenFileDialog ofd = new OpenFileDialog();
        private Agent _currentAgent = new Agent();
        string path = "";
        private bool flag = false;
        private string _imgSource = string.Empty;
        public AddPage(List<Agent> ListAgent = null)
        {
            InitializeComponent();
            if(ListAgent!= null)
            {
                _currentAgent = ListAgent.First();
                DataContext = _currentAgent;
            }
            DataContext = _currentAgent;
            TypeAgentComboBox.ItemsSource = user1Entities.GetContext().AgentType.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                File.Copy(ofd.FileName,_imgSource, true);
                _currentAgent.Logo = $"\\agents\\{ofd.SafeFileName}";
            }
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAgent.Title))
                errors.AppendLine("Вы не указали наименование");

            if (TypeAgentComboBox.SelectedValue == null)
                errors.AppendLine("Вы не указали тип агента");

            if (string.IsNullOrWhiteSpace(_currentAgent.Address))
                errors.AppendLine("Вы не указали адрес");

            if (string.IsNullOrWhiteSpace(_currentAgent.INN))
                errors.AppendLine("Вы не указали ИНН");

            if (string.IsNullOrWhiteSpace(_currentAgent.KPP))
                errors.AppendLine("Вы не указали КПП");

            if (string.IsNullOrWhiteSpace(_currentAgent.DirectorName))
                errors.AppendLine("Вы не указали ФИО директора");

            if (string.IsNullOrWhiteSpace(_currentAgent.Phone))
                errors.AppendLine("Вы не указали телефон");

            if (string.IsNullOrWhiteSpace(_currentAgent.Email))
                errors.AppendLine("Вы не указали почта");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentAgent.ID == 0)
            {
                user1Entities.GetContext().Agent.Add(_currentAgent);
            }
            try
            {
                user1Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                NavigationClass.NavigationFrame.Navigate(new MainPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SelectedPhoto_Click(object sender, RoutedEventArgs e)
        {            
            string Source = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                flag = true;
                string ing = ofd.SafeFileName;
                _imgSource = Source.Replace("\\bin\\Debug", "\\agents\\") + ing;
                PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                path = ofd.FileName;
            }
        }
    }
}
