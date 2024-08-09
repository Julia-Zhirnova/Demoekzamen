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
using DesktopSaleApp.Classes;
using DesktopSaleApp;
using System.Windows.Threading;
using DesktopSaleApp.Models;

namespace DesktopSaleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int attemps = 0;
        Random _random = new Random();
        private TextBlock myTextBlock;
        public MainWindow()
        {
            InitializeComponent();
            Classes.DbConnect.modeldb = new Models.Use_r4Entities1();
           
        }
        private void LogIN()
        {
            try
            {
                var userObj = Classes.DbConnect.modeldb.UsersTable.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == Password.Password);


                if (userObj != null)
                {
                    Models.Use_r4Entities1.currentuser = userObj;
                    MessageBox.Show("Здравствуйте " + userObj.Roles.RoleName + ", " + userObj.Login, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

                    switch (userObj.RoleID)
                    {
                        case 1:
                            var managerdata = Classes.DbConnect.modeldb.UsersTable.FirstOrDefault(c => c.UserID == userObj.UserID);
                            if (managerdata != null)
                            {

                                User user = new User
                                {
                                    FirstName = managerdata.FirstName,
                                    MiddleName = managerdata.MiddleName,
                                    LastName = managerdata.LastName,
                                    UniqueID = managerdata.UniqueID,
                                    Login = managerdata.Login,
                                    Password = managerdata.Password,
                                    RoleID = (int)managerdata.RoleID,
                                    PhotoPath = managerdata.ImagePath

                                };

                                var newWindow = new HelloWindow((user));
                                var newSalewindow = new Manager((user));
                                newWindow.Show();
                                newWindow.Closed += (s, args) => newSalewindow.Show();

                                this.Close();
                            }
                            break;
                        case 2:
                            var kladmandata = Classes.DbConnect.modeldb.UsersTable.FirstOrDefault(c => c.UserID == userObj.UserID);
                            if (kladmandata != null)
                            {

                                User user = new User
                                {
                                    FirstName = kladmandata.FirstName,
                                    MiddleName = kladmandata.MiddleName,
                                    LastName = kladmandata.LastName,
                                    UniqueID = kladmandata.UniqueID,
                                    Login = kladmandata.Login,
                                    Password = kladmandata.Password,
                                    RoleID = (int)kladmandata.RoleID,
                                    PhotoPath = kladmandata.ImagePath

                                };

                                var newWindow = new HelloWindow((user));
                                var newSalewindow = new StoreKeeper((user));
                                newWindow.Show();
                                newWindow.Closed += (s, args) => newSalewindow.Show();

                                this.Close();
                            }
                            break;
                        case 3:
                            var clientdata = Classes.DbConnect.modeldb.UsersTable.FirstOrDefault(c => c.UserID == userObj.UserID);
                            if (clientdata != null)
                            {

                                User user = new User
                                {
                                    FirstName = clientdata.FirstName,
                                    MiddleName = clientdata.MiddleName,
                                    LastName = clientdata.LastName,
                                    UniqueID = clientdata.UniqueID,
                                    Login = clientdata.Login,
                                    Password = clientdata.Password,
                                    RoleID = (int)clientdata.RoleID,
                                    PhotoPath = clientdata.ImagePath

                                };
                                
                                var newWindow = new HelloWindow((user));
                                var newSalewindow = new SaleWindow((user));
                                newWindow.Show();
                                newWindow.Closed+=(s,args)=> newSalewindow.Show();
                               
                                this.Close();
                            }
                            break;
                        case 4:
                            var pokupdata = Classes.DbConnect.modeldb.UsersTable.FirstOrDefault(c => c.UserID == userObj.UserID);
                            if (pokupdata != null)
                            {

                                User user = new User
                                {
                                    FirstName = pokupdata.FirstName,
                                    MiddleName = pokupdata.MiddleName,
                                    LastName = pokupdata.LastName,
                                    UniqueID = pokupdata.UniqueID,
                                    Login = pokupdata.Login,
                                    Password = pokupdata.Password,
                                    RoleID = (int)pokupdata.RoleID,
                                    PhotoPath = pokupdata.ImagePath

                                };

                                var newWindow = new HelloWindow((user));
                                var newSalewindow = new SaleWindow((user));
                                newWindow.Show();
                                newWindow.Closed += (s, args) => newSalewindow.Show();

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Данные клиента не найдены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }


                            break;

                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль", "Уведовление");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public string Symbols = "";

        /// <summary>
        /// отображение пароля при наведение на passwordbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBox_MouseEnter(object sender, MouseEventArgs e)
        {
            passwordTextBlock.Text = Password.Password;
            ShowPass.Visibility = Visibility.Visible;
            passwordTextBlock.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// возвращение маскировки, когда мыш уводится от passwordbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Password.Visibility = Visibility.Visible;
            passwordTextBlock.Visibility = Visibility.Collapsed;
            ShowPass.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var userObj = Classes.DbConnect.modeldb.UsersTable.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == Password.Password);

            if (userObj == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Password.Password = "";
                attemps++;
                CheckAttemps();
            }
            else
            {
                LogIN();
            }
        }
        /// <summary>
        /// Проверка попыток входа
        /// </summary>
        private void CheckAttemps()
        {

            if (attemps == 2)
            {

                MessageBox.Show("Слишком много неудачных попыток! Подтвердите, что вы человек", "Не удается войти!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Noises.Visibility = Visibility.Visible;
                SymbolsGen.Visibility = Visibility.Visible;
                GetCapcha.Visibility = Visibility.Visible;
                UpdateCapcha.Visibility = Visibility.Visible;
                ConfirmCapcha.Visibility = Visibility.Visible;
                LoginTB.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Collapsed;
                GenerateNoisesForCapcha(30);
                GenerateSymbols(6);
                if (GetCapcha.Text != Symbols)
                {
                }


            }
            else
            {
                if (attemps == 3)
                {
                    MessageBox.Show("Возможность входа заблокирована", "Слишком много неудачных попыток", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Blocked.Visibility = Visibility.Visible;

                    
                    foreach (UIElement element in UIInt.Children)
                    {
                        if (element is Control control && control.Name != "ExitButton" && control.Name != "SupportButton")
                        {
                            control.IsEnabled = false;
                        }
                    }

                    
                    double seconds = 10;
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (sender, args) =>
                    {
                        seconds--;
                        TimerTextBlock.Text = $"Попробуйте снова через {seconds} сек.";
                        if (seconds == 0)
                        {
                            timer.Stop();
                            Blocked.Visibility = Visibility.Collapsed;
                            TimerTextBlock.Visibility = Visibility.Collapsed;
                            
                            foreach (UIElement element in UIInt.Children)
                            {
                                if (element is Control control && control.Name != "ExitButton" && control.Name != "SupportButton")
                                {
                                    control.IsEnabled = true;
                                    attemps = 0;
                                }
                            }
                        }
                    };
                    timer.Start();
                    TimerTextBlock.Visibility = Visibility.Visible;








                }
            }
        }
        private void GenerateNoisesForCapcha(int volumeNoise)
        {
            Noises.Visibility = Visibility.Visible;
            for (int i = 0; i < volumeNoise; i++)
            {
                Ellipse ellipse = new Ellipse
                {
                    Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),

                     (byte)_random.Next(0, 256),
                     (byte)_random.Next(0, 256),
                     (byte)_random.Next(0, 256)))
                };

                ellipse.Height = ellipse.Width = _random.Next(20, 60);

                Canvas.SetLeft(ellipse, _random.Next(0, 290));
                Canvas.SetTop(ellipse, _random.Next(0, 100));

                Noises.Children.Add(ellipse);
            }
        }
        
        private void GenerateSymbols(int count)
        {
            string alphabet = "ABCDEFGHJKLMN123456789";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();



                lbl.Text = symbol;
                lbl.FontSize = _random.Next(10, 20);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(10, 10, 10, 10);





                Noises.Visibility = Visibility.Visible;
                SymbolsGen.Children.Add(lbl);
                Symbols = Symbols + symbol;
                myTextBlock = lbl;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Symbols = "";
            SymbolsGen.Children.Clear();
            Noises.Children.Clear();

            GenerateSymbols(6);
            GenerateNoisesForCapcha(25);

        }

        private void ConfirmCapcha_Click(object sender, RoutedEventArgs e)
        {
            if (GetCapcha.Text == Symbols)
                LoginTB.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
        }
    }
}
