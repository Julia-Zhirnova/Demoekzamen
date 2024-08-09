using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Приятный_шелест.Enitities;

namespace Приятный_шелест.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditAgentWindow.xaml
    /// </summary>
    public partial class EditAgentWindow : Window
    {
        public EditAgentWindow()
        {
            InitializeComponent();
            TypeAgentComboBox.ItemsSource = AppData.db.AGENTTYPE.ToList();
            cmbProduct.ItemsSource = AppData.db.GOOD.ToList();
            DataContext = new AGENT();
        }
        public EditAgentWindow(AGENT agent)
        {
            InitializeComponent();
            edit = true;
            DataContext = agent;
            TypeAgentComboBox.ItemsSource = AppData.db.AGENTTYPE.ToList();
            TypeAgentComboBox.Text = agent.AGENTTYPE.NAME;
            cmbProduct.ItemsSource = AppData.db.GOOD.ToList();
            btnDelete.Visibility = Visibility.Visible;
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                path = ofd.FileName;
            }
        }
        string path = "";
        bool edit = false;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit == true)
                {
                    if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                    {
                        File.Copy(path, Environment.CurrentDirectory + (DataContext as AGENT).PHOTOPATH, true);
                    }
                    if (!string.IsNullOrWhiteSpace(txtPriority.Text) && !string.IsNullOrEmpty(txtPriority.Text))
                    {
                        if (txtPriority.Text.All(c => char.IsDigit(c)))
                        {
                            if (txtPriority.Text != (DataContext as AGENT).PriorityCount.ToString())
                            {
                                AGENTHISTORY history = new AGENTHISTORY();
                                history.PRIORITY = Convert.ToInt32(txtPriority.Text);
                                history.AGENT = (DataContext as AGENT);
                                AppData.db.AGENTHISTORY.Add(history);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(DirectorNameInput.Text) && !string.IsNullOrWhiteSpace(DirectorNameInput.Text))
                    {
                        if (DirectorNameInput.Text != (DataContext as AGENT).DirectorFullName)
                        {
                            string[] array = DirectorNameInput.Text.Split(' ');
                            if (array.Length == 3)
                            {
                                (DataContext as AGENT).DIRECTORLASTNAME = array[0];
                                (DataContext as AGENT).DIRECTORFIRSTNAME = array[1];
                                (DataContext as AGENT).DIRECTORMIDDLENAME = array[2];
                            }
                        }
                    }
                    AppData.db.SaveChanges();
                    this.Close();
                }
                else
                {
                    if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                    {
                        File.Copy(path, Environment.CurrentDirectory + @"\agents" + System.IO.Path.GetFileName(path), true);
                        (DataContext as AGENT).PHOTOPATH = @"\agents" + System.IO.Path.GetFileName(path);
                    }
                    if (!string.IsNullOrWhiteSpace(txtPriority.Text) && !string.IsNullOrEmpty(txtPriority.Text))
                    {
                        if (txtPriority.Text.All(c => char.IsDigit(c)))
                        {

                            AGENTHISTORY history = new AGENTHISTORY();
                            history.PRIORITY = Convert.ToInt32(txtPriority.Text);
                            history.AGENT = (DataContext as AGENT);
                            AppData.db.AGENTHISTORY.Add(history);

                        }
                    }
                    if (!string.IsNullOrEmpty(DirectorNameInput.Text) && !string.IsNullOrWhiteSpace(DirectorNameInput.Text))
                    {
                        if (DirectorNameInput.Text != (DataContext as AGENT).DirectorFullName)
                        {
                            string[] array = DirectorNameInput.Text.Split(' ');
                            if (array.Length == 3)
                            {
                                (DataContext as AGENT).DIRECTORLASTNAME = array[0];
                                (DataContext as AGENT).DIRECTORFIRSTNAME = array[1];
                                (DataContext as AGENT).DIRECTORMIDDLENAME = array[2];
                            }
                        }
                    }

                    AppData.db.AGENT.Add(DataContext as AGENT);
                    AppData.db.SaveChanges();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Прозошла ошибка, попробуйте позже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AGENT).SALECONTRACT.Remove((sender as Button).DataContext as SALECONTRACT);
            SaleProductDataGrid.ItemsSource = null;
            SaleProductDataGrid.ItemsSource = (DataContext as AGENT).SALECONTRACT;

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if(cmbProduct.SelectedIndex != -1)
            {
                if(!string.IsNullOrEmpty(txtCount.Text) && !string.IsNullOrWhiteSpace(txtCount.Text))
                {
                    if (txtCount.Text.All(c => char.IsDigit(c)))
                    {
                        int count = Convert.ToInt32(txtCount.Text);
                        if(count > 0)
                        {
                            (DataContext as AGENT).SALECONTRACT.Add(new SALECONTRACT()
                            {
                                AGENT = (DataContext as AGENT),
                                COUNT = count,
                                GOOD = (cmbProduct.SelectedItem as GOOD),
                                DATE = DateTime.Now
                            });
                            SaleProductDataGrid.ItemsSource = null;
                            SaleProductDataGrid.ItemsSource = (DataContext as AGENT).SALECONTRACT;
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if((DataContext as AGENT).SALECONTRACT.Count != 0)
                {
                    MessageBox.Show("Удаление не возможно", "Ошикба", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AppData.db.AGENTHISTORY.RemoveRange((DataContext as AGENT).AGENTHISTORY);
                    AppData.db.AGENT.Remove(DataContext as AGENT);
                    AppData.db.SaveChanges();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Прозошла ошибка, попробуйте позже", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
