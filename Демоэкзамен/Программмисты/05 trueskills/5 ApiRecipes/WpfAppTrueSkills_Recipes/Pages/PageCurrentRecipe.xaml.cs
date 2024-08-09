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

namespace WpfAppTrueSkills_Recipes.Pages
{
    /// <summary>
    /// Interaction logic for PageCurrentRecipe.xaml
    /// </summary>
    public partial class PageCurrentRecipe : Page
    {
        private Models.Dish _selectedDish;
        private Models.MyRecipesEntities _context;

        public PageCurrentRecipe(Models.Dish selectedDish)
        {
            InitializeComponent();

            _context = new Models.MyRecipesEntities();
            _selectedDish = _context.Dishes.Find(selectedDish.Id);

            this.DataContext = _selectedDish;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файлы изображений (*.png;*.jpg)|*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                string fullPath = dialog.FileName;
                var bytes= System.IO.File.ReadAllBytes(fullPath);

                _selectedDish.Photo = bytes;

                this.DataContext = null;
                this.DataContext = _selectedDish;
            }
        }

        private void BtnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
