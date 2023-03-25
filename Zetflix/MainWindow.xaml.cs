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

namespace Zeflix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
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
                if (!string.IsNullOrWhiteSpace(_Password_Textbox_.Text)) // проверяем введён ли пароль         
                {

                    Console.WriteLine("OK");
                    MainMovie mainMovie = new MainMovie();
                    mainMovie.Show();


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
    }
}
