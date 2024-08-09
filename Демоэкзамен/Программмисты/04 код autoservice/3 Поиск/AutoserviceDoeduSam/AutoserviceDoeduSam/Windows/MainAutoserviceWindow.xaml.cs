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
using System.Windows.Shapes;

namespace AutoserviceDoeduSam.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainAutoserviceWindow.xaml
    /// </summary>
    public partial class MainAutoserviceWindow : Window
    {
        public MainAutoserviceWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.ServicePage());
            Class.Manager.MainFrame = MainFrame;
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Class.Manager.MainFrame.CanGoBack) Back.Visibility = Visibility.Visible;
            else Back.Visibility = Visibility.Hidden;
            
            
            
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.Navigate(new Pages.Avtorisation());
        }

        private void Polzov_Click(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.Navigate(new Pages.ServicePage());
        }
    }
}
