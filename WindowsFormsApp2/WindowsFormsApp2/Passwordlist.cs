using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Passwordlist
    {
        String password;
        ArrayList passwordslist;

        public Passwordlist()
        {
            passwordslist = new ArrayList();
        }

        public ArrayList Passwordslist { get => passwordslist; }

        public Passwordlist(string password)
        {
            this.Password = password;
        }

        public string Password { get => password; set => password = value; }

        public void Add(Passwordlist passwordlist)
        {
            passwordslist.Add(passwordlist);
        }  
        
        public bool Contain(String password)
        {
            bool result = false;
            if (passwordslist.Contains(password))
                result = true;
            return result;
        }

        public String ToString()
        {
            return this.password;
        }
    }
}
