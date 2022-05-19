using System;
using System.Collections.Generic;
using System.Data;
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

namespace GUIForEclectronicCadastre
{
    /// <summary>
    /// Логика взаимодействия для RowAddingWindow.xaml
    /// </summary>
    public partial class RowAddingWindow : Window
    {
        private readonly DatabaseWindow parent;

        public RowAddingWindow(DatabaseWindow parent)
        {
            this.parent = parent;

            InitializeComponent();
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                InputTextBox.Text = "Input";
            }
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                MessageBox.Show("You should enter the data!");
                return;
            }

            try
            {                
                DatabaseController.ExecuteQuery("INSERT INTO " + parent.CurrentTableName + " VALUES (" + InputTextBox.Text + ");");
                parent.SetDataGrid(parent.CurrentTableName);
            }
            catch
            {
                MessageBox.Show("Wrong data!");
            }
        }
    }
}
