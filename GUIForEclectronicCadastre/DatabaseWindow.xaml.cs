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

namespace GUIForEclectronicCadastre
{
    /// <summary>
    /// Логика взаимодействия для DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        // TODO: Test closing and reloging
        private readonly LoginWindow parent;

        public DatabaseWindow(LoginWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Close();
        }

        private void TablesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FunctionsMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
            parent.Close();
        }

        private void AddRowMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteRowMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RelogMenuItem_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            Close();            
        }
    }
}
