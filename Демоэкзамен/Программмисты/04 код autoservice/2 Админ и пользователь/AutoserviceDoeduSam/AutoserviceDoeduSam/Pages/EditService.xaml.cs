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

namespace AutoserviceDoeduSam.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditService.xaml
    /// </summary>
    public partial class EditService : Page
    {
        public OpenFileDialog ofd = new OpenFileDialog();
        private Model.Service _currentService = new Model.Service();
        string path = "";
        private bool flag = false;
        private string _imgSource = string.Empty;

        public EditService(List<Model.Service> ListService = null)
        {
            InitializeComponent();
            if (ListService != null)
            {
                _currentService = ListService.First();
                DataContext = _currentService;
            }
            DataContext = _currentService;
            TypeAgentComboBox.ItemsSource = Model.autoserviceEntities.GetContext().Service.ToList();


        }

        private void SelectedPhoto_Click(object sender, RoutedEventArgs e)
        {
            string Source = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                flag = true;
                string ing = ofd.SafeFileName;
                _imgSource = Source.Replace("\\bin\\Debug", "\\Услуги автосервиса\\") + ing;
                PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                path = ofd.FileName;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                File.Copy(ofd.FileName, _imgSource, true);
                _currentService.MainImagePath = $"\\agents\\{ofd.SafeFileName}";
            }
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentService.Title))
                errors.AppendLine("Вы не указали наименование");

            if (TypeAgentComboBox.SelectedValue == null)
                errors.AppendLine("Вы не указали тип агента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentService.ID == 0)
            {
                Model.autoserviceEntities.GetContext().Service.Add(_currentService);
            }
            try
            {
                Model.autoserviceEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                Class.Manager.MainFrame.Navigate(new Admin());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
