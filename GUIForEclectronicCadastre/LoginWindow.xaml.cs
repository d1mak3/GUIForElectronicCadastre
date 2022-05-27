using System.Windows;
using System.Windows.Input;

namespace GUIForEclectronicCadastre
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DatabaseController databaseHandler;
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Clear();
            }            
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Visibility == Visibility.Visible)
            {
                PasswordTextBox.Visibility = Visibility.Hidden;
                UserPasswordBox.Visibility = Visibility.Visible;
                UserPasswordBox.Focus();
            }
        }

        private void DatabaseNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DatabaseNameTextBox.Text == "Database Name")
            {
                DatabaseNameTextBox.Clear();
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Если пользователь ничего не набрал, возвращаем надпись обратно в UsernameTextBox
            if (UsernameTextBox.Text.Length == 0)
            {
                UsernameTextBox.Text = "Username";
            }
        }

        private void UserPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Если пользователь ничего не набрал, возвращаем надпись обратно в PasswordTextBox
            if (UserPasswordBox.Password.Length == 0)
            {                
                PasswordTextBox.Visibility= Visibility.Visible;
                PasswordTextBox.Text = "Password";
                UserPasswordBox.Visibility = Visibility.Hidden;                
            }
        }

        private void DatabaseNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Если пользователь ничего не набрал, возвращаем надпись обратно в textbox
            if (DatabaseNameTextBox.Text.Length == 0)
            {
                DatabaseNameTextBox.Text = "Database Name";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            databaseHandler = new DatabaseController(UsernameTextBox.Text, UserPasswordBox.Password, DatabaseNameTextBox.Text);
            
            string resultOfConnection = databaseHandler.ConnectToDatabase();
            MessageBox.Show(resultOfConnection);

            if (resultOfConnection == "Successfuly connected!")
            {
                // Приведение текстбоксов в изначальное состояние
                UsernameTextBox.Focus();
                UsernameTextBox.Clear();
                UserPasswordBox.Focus();
                UserPasswordBox.Clear();
                DatabaseNameTextBox.Focus();
                DatabaseNameTextBox.Clear();
                LoginButton.Focus();

                DatabaseWindow databaseWindow = new DatabaseWindow(this);                
                databaseWindow.Show();
                this.Visibility = Visibility.Hidden;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginButton.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (databaseHandler is not null)
                databaseHandler.Disconnect();
        }
    }
}
