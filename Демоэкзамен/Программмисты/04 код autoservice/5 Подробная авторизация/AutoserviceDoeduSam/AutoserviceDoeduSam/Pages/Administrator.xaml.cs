using AutoserviceDoeduSam.Class;
using AutoserviceDoeduSam.Models;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace AutoserviceDoeduSam.Pages
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date = new DateTime(0, 0);
        public Administrator()
        {
            InitializeComponent();
            string[] FIO = AvtorisationEntities.CurrentUser.Name.Split(new char[] { ' ' });
            string surname = FIO[0] + " " + FIO[1];
            UserTB.Text = surname;

            RoleTB.Text = AvtorisationEntities.CurrentUser.Role.Name;

            var fullFilePath = AvtorisationEntities.CurrentUser.PhotoPath;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Relative);
            bitmap.EndInit();
            UserPhoto.Source = bitmap;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            date = date.AddSeconds(1);
            TimeTB.Text = date.ToString("HH:mm:ss");

            if (TimeTB.Text == "00:00:10")
            {
                MessageBox.Show("Время сеанса подходит к концу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TimeTB.Text == "00:00:15")
            {
                timer.Stop();
                App.IsGone = true;
                Manager.MainFrame.Navigate(new Avtorisation());

            }
        }
    }
}
