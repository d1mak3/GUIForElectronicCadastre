using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace GUIForEclectronicCadastre
{
    /// <summary>
    /// Логика взаимодействия для DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {       
        private readonly LoginWindow parent;
        public string CurrentTableName { get; private set; }

        public DatabaseWindow(LoginWindow parent)
        {
            this.parent = parent;
            CurrentTableName = "";
            InitializeComponent();
        }       

        public bool SetDataGrid(string tableName)
        {
            try
            {
                DatabaseController databaseController = new DatabaseController();
                DataTable dataFromTable = DatabaseController.ExecuteQuery("SELECT * FROM " + tableName);
                DatabaseGrid.ItemsSource = dataFromTable.DefaultView;
                CurrentTableName = tableName;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateStringToIdentifyTheRow(DataRowView dataRowView, string columnToExcludeName)
        {
            string stringToIdentifyTheRow = "";

            for (int i = 0; i < DatabaseGrid.Columns.Count; i++)
            {
                string dataToIdentifyTheRow = dataRowView[i].ToString();

                if (columnToExcludeName != null && columnToExcludeName == DatabaseGrid.Columns[i].Header)
                {
                    continue;
                }

                // На последней итерации не добавляем " AND"
                if (i == 0)
                {
                    stringToIdentifyTheRow += " " + DatabaseGrid.Columns[i].Header + " = " + "\'" + dataToIdentifyTheRow + "\'";
                    continue;
                }

                stringToIdentifyTheRow += " AND " + DatabaseGrid.Columns[i].Header + " = " + "\'" + dataToIdentifyTheRow + "\'";
            }

            return stringToIdentifyTheRow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
        }

        private void OpenTableMenuItem_Click(object sender, RoutedEventArgs e)
        {
            TableSelectionWindow tableSelectionWindow = new TableSelectionWindow(this);
            tableSelectionWindow.Show();
        }             

        private void AddRowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTableName == "")
            {
                MessageBox.Show("You should select a table!");
                return;
            }

            RowAddingWindow rowAddingWindow = new RowAddingWindow(this);
            rowAddingWindow.Show();
        }

        private void DeleteRowMenuItem_Click(object sender, RoutedEventArgs e)
        {          
            if (DatabaseGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("You should select a row!");
                return;
            }

            string rowToDeleteString = GenerateStringToIdentifyTheRow((DataRowView)DatabaseGrid.SelectedItem, "");

            try
            {                
                DatabaseController.ExecuteQuery("DELETE FROM " + CurrentTableName + " WHERE" + rowToDeleteString + ";");
                SetDataGrid(CurrentTableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
            parent.Close();
        }

        private void RelogMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();                     
        }

        private void CloseTableMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DatabaseGrid.ItemsSource = null;
        }        

        private void DatabaseGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string columnHeader = e.Column.Header.ToString();
            string rowToUpdateString = GenerateStringToIdentifyTheRow((DataRowView)DatabaseGrid.SelectedItem, columnHeader);
            string newData = (e.EditingElement as TextBox).Text.ToString();  
           
            try
            {                
                DatabaseController.ExecuteQuery("UPDATE " + CurrentTableName + " SET " + columnHeader + " = " + "\'" + newData + "\'" + " WHERE" + rowToUpdateString + ";");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
