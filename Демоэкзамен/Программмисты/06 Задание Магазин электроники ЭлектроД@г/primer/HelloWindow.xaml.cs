using DesktopSaleApp.Classes;
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
using System.Windows.Threading;

namespace DesktopSaleApp
{
    /// <summary>
    /// Логика взаимодействия для HelloWindow.xaml
    /// </summary>
    public partial class HelloWindow : Window
    {
        private User user;

        private DispatcherTimer timer;

        private void Timer_Tick(object sender, EventArgs e)
        {
            // метод close, вызываемый для закрытия окна
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public HelloWindow(User user)
        {
            InitializeComponent();
            FirstNameBox.Text = user.FirstName;
            MiddleNameBox.Text = user.MiddleName;
            LastNameBox.Text = user.LastName;
            RoleIDBox.Text = user.RoleID.ToString();
            BitmapImage image = new BitmapImage(new Uri(user.PhotoPath, UriKind.RelativeOrAbsolute));
            PhotoUser.Source = image;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Итервал на переход в 5 секунд
            timer.Tick += Timer_Tick; // Обработчик события Tick
            timer.Start();

            if (user.RoleID == 1)
            {
                RoleIDBox.Text = "Администратор";
            }
            else if (user.RoleID == 2)
            {
                RoleIDBox.Text = "Менеджер";
            }
            else if (user.RoleID == 3)
            {
                RoleIDBox.Text = "Продавец";
            }
            else
            {
                RoleIDBox.Text = "Покупатель";
            }
        }        
       
    }
}
