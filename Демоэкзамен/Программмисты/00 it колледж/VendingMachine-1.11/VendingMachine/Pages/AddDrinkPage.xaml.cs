using Microsoft.Win32;
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
using VendingMachine.Classes;

namespace VendingMachine.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDrinkPage.xaml
    /// </summary>
    public partial class AddDrinkPage : Page
    {
        public OpenFileDialog ofd = new OpenFileDialog();
        string path = "";
        private bool flag = false;
        private string _imgSource = string.Empty;
        public AddDrinkPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DrinksPage());
        }

        private void BtnAddImg_Click(object sender, RoutedEventArgs e)
        {
            string Source = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                flag = true;
                string ing = ofd.SafeFileName;
                _imgSource = Source.Replace("\\bin\\Debug", "\\Resources\\Drinks\\") + ing;
                PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                path = ofd.FileName;
            }
        }
    }
}
