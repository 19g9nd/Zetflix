using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zeflix
{
    /// <summary>
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        public List<User> Users { get; set; } = new List<User>();
        public RegisterForm()
        {
            InitializeComponent();
        }
        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
        private void REG_Click(object sender, RoutedEventArgs e)
        {

            //===========================AGE CHECK===============================
            if (Convert.ToInt32(AgeBox.Text) < 18)
            {
                string url = "https://www.google.com/search?q=%D0%BC%D1%83%D0%BB%D1%8C%D1%82%D0%B8%D0%BA%D0%B8&rlz=1C1GCEA_enAZ906AZ906&oq=%D0%BC%D1%83%D0%BB%D1%8C%D1%82%D0%B8%D0%BA%D0%B8&aqs=chrome..69i57j0i131i433i512j46i512j0i131i433i512j0i512j46i512j0i512l4.2055j0j7&sourceid=chrome&ie=UTF-8";
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                ___Register_Button_.IsEnabled = false;
                return;
            }
            
            if (Convert.ToInt32(AgeBox.Text) > 100 ) {
                return;
            }

            //============================EMAIL CHECK===================================
           if (string.IsNullOrWhiteSpace(EmailBox.Text) & !IsValidEmail(EmailBox.Text))
            {
                Console.WriteLine("Email error");
                return;
              
            }
            //===========================================================================
            Users.Add(new User(NameBox.Text, EmailBox.Text, PassBox.Text));
            MainMovie mainMovie = new MainMovie();
            Hide();
            mainMovie.ShowDialog();
            Close();

        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                ___Register_Button_.IsEnabled = false;
            }
            else ___Register_Button_.IsEnabled = true;

       
        }

        private void PassBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PassBox.Text))
            {
                ___Register_Button_.IsEnabled = false;
            }
            else ___Register_Button_.IsEnabled = true;
        }

        private void AgeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
