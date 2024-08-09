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

namespace Train
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
                /*
        private static Entities Context;
        public static Entities GetContext()
        {
            if (Context == null)
            Context = new Entities();
            return Context;
        }        
             */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListGrid.ItemsSource = Entities.GetContext().View_alls().ToList();
        }
        private void Log(object sender, RoutedEventArgs e)
        {
            string login = Convert.ToString(Login.Text);
            string password = Convert.ToString(Password.Text);
            var logresult = Entities.GetContext().Users.Where(p => p.login == login && p.pass == password).ToList();
            if (logresult.Count > 0) MessageBox.Show("Вы авторизованы");
            else MessageBox.Show("Ошибка");
        }
    }
}
