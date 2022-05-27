using System;
using System.Data;
using System.Windows;

namespace GUIForEclectronicCadastre
{
    /// <summary>
    /// Логика взаимодействия для TablesSelectionWindow.xaml
    /// </summary>
    public partial class TableSelectionWindow : Window
    {
        private readonly DatabaseWindow parent;

        public TableSelectionWindow(DatabaseWindow parent)
        {
            this.parent = parent;
            this.parent.IsEnabled = false;            

            InitializeComponent();
            FillList();
        }

        /// <summary>
        /// Заполнение списка доступными таблицами
        /// </summary>
        private void FillList()
        {
            DatabaseController databaseController = new DatabaseController();

            try
            {
                DataTable dataFromSQL = DatabaseController.ExecuteQuery("SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';");
                foreach (DataRow row in dataFromSQL.Rows)
                {                    
                    for (int i = 0; i < dataFromSQL.Columns.Count; i++)
                    {
                        TablesListBox.Items.Add(row[i].ToString());
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Sql Error");
            }
        }

        private void SelectTableButton_Click(object sender, RoutedEventArgs e)
        {
            if (TablesListBox.SelectedItem == null)
            {
                MessageBox.Show("You should pick a table!");
                return;
            }

            bool result = parent.SetDataGrid(TablesListBox.SelectedItem.ToString());

            if (result)
            {
                parent.IsEnabled = true;
                Close();
            }
            else
            {
                MessageBox.Show("Couldn't display the table! Please, try again.");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.IsEnabled = true;
        }
    }
}
