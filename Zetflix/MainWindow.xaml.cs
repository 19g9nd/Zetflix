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
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Zeflix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public List<User> Users { get; set; } = new List<User>();
        public MainWindow()
        {

            InitializeComponent();
            User u1 = new User("Lotte", "guzmanbentley@ginkle.com","&L87j5");//хотела сделать через десериализацию json, но не смогла
            Users.Add(u1);
        }

        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if(_Email_Textbox_.Text == "Username@gmail.com" || _Password_Textbox_.Text == "Password")
            {
                Console.WriteLine("Error");
                return;
            }
            
            if (!string.IsNullOrWhiteSpace(_Email_Textbox_.Text) & IsValidEmail(_Email_Textbox_.Text)) //проверяем email
            {
                if ( (!string.IsNullOrWhiteSpace(_Password_Textbox_.Text))
                    & Users.Any(u => String.Equals(u.Email, _Email_Textbox_.Text))
                    & Users.Any(u => String.Equals(u.Password, _Password_Textbox_.Text))
                    )// проверяем введён ли пароль         
                {

                    Console.WriteLine("OK");
                    MainMovie mainMovie = new MainMovie();
                    Hide();
                    mainMovie.ShowDialog();
                    Close();

                }
            }
            else //если метод вернул false ||  длина < 0
            {
                Console.WriteLine("Email error");
            }
        }

        private void _Email_Textbox__TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            Hide();
            registerForm.ShowDialog();
            Close();
        }
    }
}
