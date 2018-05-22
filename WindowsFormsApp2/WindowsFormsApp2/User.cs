using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class User
    {
        String login;
        ArrayList passwords; 
        String email;
        String phone;
        DateTime expiration;

        public User(string login, String password, string email, string phone, DateTime expiration)
        {
            passwords = new ArrayList();

            this.Login = login;
            if (password != " ")
                passwords.Add(new Passwords(password));
            this.Email = email;
            this.Phone = phone;
            this.expiration = expiration;            
        }

        public String ToString()
        {
            return this.login + "\t" + "\t" + ((Passwords)(this.passwords[this.passwords.Count-1])).Password + "\t" + this.email +"\t" + this.phone + "\t" + this.expiration;
        }

        public string Login { get => login; set => login = value; }
        public ArrayList Passwords { get => passwords; set => passwords = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime Expiration { get => expiration; set => expiration = value; }
    }
}
