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


namespace AutoserviceDoeduSam.Pages
{
    /// <summary>
    /// Логика взаимодействия для Avtorisation.xaml
    /// </summary>
    public partial class Avtorisation : Page
    {
        public bool DialogResult;
        public Avtorisation()
        {
            InitializeComponent();
        }

        private void Btn_Ok(object sender, RoutedEventArgs e)
        {
            if (TBox_Code.Text == String.Empty)//Проверка на пустоту текстбокса
                MessageBox.Show("Введите код");
            if (TBox_Code.Text == "0000")
                Class.Manager.MainFrame.Navigate(new Pages.Admin());
            else Class.Manager.MainFrame.Navigate(new Pages.ServicePage());
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.Navigate(new Pages.ServicePage());
        }
    }
}
