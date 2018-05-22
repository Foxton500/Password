using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Users
    {
        int index;
        String password;
        ArrayList userlist;

        public Users()
        {
            userlist = new ArrayList();
        }

        public ArrayList Userlist { get => userlist; }

        public void Add(User user)
        {
            userlist.Add(user);
        }

        public virtual int BinarySearch(String password) => userlist.BinarySearch(password);

        public virtual void RemoveAt(int index)
        {
            userlist.RemoveAt(index);
        }

        public virtual void Insert(int index, String password)
        {
            userlist.Insert(index, password);
        }



        // Добавить проверку при изменении пароля: был ли использован такой пароль
    }
}
