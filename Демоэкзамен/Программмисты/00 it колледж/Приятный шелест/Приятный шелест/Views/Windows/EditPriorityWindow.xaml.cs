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
using Приятный_шелест.Enitities;

namespace Приятный_шелест.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditPriorityWindow.xaml
    /// </summary>
    public partial class EditPriorityWindow : Window
    {
        public EditPriorityWindow(List<AGENT> agents)
        {
            InitializeComponent();
            lbMax.Content = agents.Max(c => c.PriorityCount).ToString();
            this.agents = agents;
        }
        List<AGENT> agents;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNewPriority.Text) && !string.IsNullOrWhiteSpace(txtNewPriority.Text))
                {
                    List<AGENTHISTORY> priorityAgentHistories = new List<AGENTHISTORY>();
                    for (int i = 0; i < agents.Count; i++)
                    {
                        priorityAgentHistories.Add(new AGENTHISTORY()
                        {
                            AGENT = agents[i],
                            PRIORITY = Convert.ToInt32(txtNewPriority.Text)
                        });
                    }
                    AppData.db.AGENTHISTORY.AddRange(priorityAgentHistories);
                    AppData.db.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Введите новое значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Значение олжно быть числом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
