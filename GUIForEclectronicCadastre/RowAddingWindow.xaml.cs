using System.Windows;

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
            if (InputTextBox.Text == "Input")
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
