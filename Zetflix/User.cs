using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Zeflix
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
     
        public User(string name, string email, string password)
        {
            Name = name;
            Password = password;
            Email = email;
          
        }

        public override string ToString() => $"{Name}: {Password} {Email}";
        public const string filePath = "userDtabase.json";
    }
    }
        
    
