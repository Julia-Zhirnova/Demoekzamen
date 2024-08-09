using DesktopSaleApp.Classes;
using DesktopSaleApp.Models;
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

namespace DesktopSaleApp
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private List<PriceListTable> allItems;
        public Manager(User user)
        {
            InitializeComponent();
            allItems = Models.Use_r4Entities1.GetContext().PriceListTable.ToList();
            FIOBox.Text = user.MiddleName + user.FirstName + user.LastName;
            RoleBoxUser.Text = user.RoleID.ToString();
            if (RoleBoxUser.Text == "1")
            {
                RoleBoxUser.Text = "Менеджер";
            }
            else if (RoleBoxUser.Text == "2")
            {
                RoleBoxUser.Text = "Кладовщик";
            }
            else if (RoleBoxUser.Text == "3")
            {
                RoleBoxUser.Text = "Продавец";
            }
            else if (RoleBoxUser.Text == "4")
            {
                RoleBoxUser.Text = "Покупатель";
            }
            BitmapImage image = new BitmapImage(new Uri(user.PhotoPath, UriKind.RelativeOrAbsolute));
            UserPhoto.Source = image;
            var currentItems = allItems.ToList();
            var countitem = "0";
            var countitem1_3 = ("1", "2", "3");
            
            if (countitem == "0")
            {
                
            }
            else if (countitem1_3 == ("1", "2", "3"))
            {

            }
            
            ItemsView.ItemsSource = currentItems;
        }
        private void OnTextBlockLoaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null && textBlock.Text == "1")
            {
                textBlock.Text = "Ярославская область, город Люберцы, ул. Косиора, 29";
            }
            else if (textBlock != null && textBlock.Text == "2")
            {
                textBlock.Text = "Рязанская область, город Мытищи, пл. Будапештсткая, 69";

            }
            else if (textBlock != null && textBlock.Text == "3")
            {
                textBlock.Text = "Новосибирская область, город Можайск, спуск Космонавтов, 37";
            }
        }
        /// <summary>
        /// Метод замены ID на значения из таблицы Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_LoadedCategory(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null && textBlock.Text == "1")
            {
                textBlock.Text = "Микросхемы зарубежные 0…-9…";
            }
            else if (textBlock != null && textBlock.Text == "2")
            {
                textBlock.Text = "Микросхемы зарубежные C…-J…";
            }
            else if (textBlock != null && textBlock.Text == "3")
            {
                textBlock.Text = "Микросхемы зарубежные K…";
            }


        }
        /// <summary>
        /// Кнопка добавления в корзину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddToCart(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK");
        }
        private void ItemsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }
        /// <summary>
        /// Возвращение на mainwindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Descripton_Click(object sender, RoutedEventArgs e)
        {
            var loginpage = new MainWindow();
            loginpage.Show();
            this.Close();
        }
    }
}
