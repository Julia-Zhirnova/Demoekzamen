using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfAppTrueSkills_Recipes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new Pages.PageListDishes());


            TestAPI();

            //Models.MyRecipesEntities context = new Models.MyRecipesEntities();
            //foreach (var dish in context.Dishes)
            //{
            //    System.IO.File.WriteAllBytes(dish.PhotoPath,dish.Photo);
            //}
        }

        private static void TestAPI()
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            var ingredientsJson = webClient.DownloadString("http://localhost:4548/api/Ingredients");

            var objects=JsonConvert.DeserializeObject<List<Models.IngredientResponse>>(ingredientsJson);
        }

        private void BtnDishes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageListDishes());
        }

        private void BtnIngredients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageListIngredients());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCaptcha_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageCaptcha());
        }
    }
}
