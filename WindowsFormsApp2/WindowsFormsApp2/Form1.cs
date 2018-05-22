using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Users users;
        Passwordlist passwordlist;
        public Form1()
        {
            InitializeComponent();
            users = new Users();
            passwordlist = new Passwordlist();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        Passwords p = new Passwords();
            p.Password = textBoxPassword.Text;
            if (p.IsCorrect(p.Password) == false)
            {
                textBoxPassword.Text = " ";
                MessageBox.Show("Wrong format of password");
            }

            if (textBoxPassword.Text != " ")
            {
                int result = 0;

                if (users.Userlist.Count == 0)
                {
                    users.Add(new User(textBoxLogin.Text, textBoxPassword.Text, textBoxEmail.Text, textBoxPhone.Text, dateTimeExpiration.MaxDate));
                    listBoxUsers.Items.Add(((User)users.Userlist[users.Userlist.Count - 1]).ToString() + '\n');
                    passwordlist.Add(new Passwordlist(textBoxPassword.Text));
                    listBoxPassword.Items.Add(((Passwordlist)passwordlist.Passwordslist[passwordlist.Passwordslist.Count - 1]).ToString() + '\n');
                }
                else
                {
                    for (int i = 0; i < users.Userlist.Capacity; i++)
                    {
                        if (users.Userlist[i].ToString() != (textBoxPassword.Text))
                        {
                            users.Add(new User(textBoxLogin.Text, textBoxPassword.Text, textBoxEmail.Text, textBoxPhone.Text, dateTimeExpiration.MaxDate));
                            listBoxUsers.Items.Add(((User)users.Userlist[users.Userlist.Count - 1]).ToString() + '\n');
                            passwordlist.Add(new Passwordlist(textBoxPassword.Text));
                            listBoxPassword.Items.Add(((Passwordlist)passwordlist.Passwordslist[passwordlist.Passwordslist.Count - 1]).ToString() + '\n');
                            result = 1;
                            break;
                        }
                    }
                    if (result == 0)
                    {
                        textBoxPassword.Text = " ";
                        MessageBox.Show("Password has been already used");
                    }

                    result = 0;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Исправить поиск просроченных паролей +
            for (int i = 0; i < users.Userlist.Capacity; i++)
            {
                try
                {
                    if (((Passwords)((User)users.Userlist[i]).Passwords[((User)users.Userlist[i]).Passwords.Count - 1]).ExpirationDate < new DateTime().Date)
                    {
                        MessageBox.Show("Test");
                        break;
                    }
                }
                catch
                {
                    MessageBox.Show("Password is overdue");
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int j = 0;
            Passwords p = new Passwords();       
            p.Password = textBoxCurrentPassword.Text;
            
            if (p.IsCorrect(p.Password) == false)
            {
                textBoxCurrentPassword.Text = " ";
                MessageBox.Show("Wrong format of password");
            }

            if (textBoxCurrentPassword.Text != " ")
            {
                for(int i = 0; i < users.Userlist.Count; i++)
                {
                    if (users.Userlist[i].ToString() == textBoxCurrentPassword.Text)
                    {
                        j = i;
                        break;
                    }
                }

                if (j == 0)
                {
                    MessageBox.Show("Wrong password");
                }
                /*
                if (passwordlist.Contain(textBoxCurrentPassword.Text) == false)
                    MessageBox.Show("Wrong password");
                else
                {
                    j = users.BinarySearch(textBoxCurrentPassword.Text);
                }
                  */  
            }

            Passwords n = new Passwords();
            n.Password = textBoxNewPassword.Text;

            if (p.IsCorrect(n.Password) == false)
            {
                textBoxNewPassword.Text = " ";
                MessageBox.Show("Wrong format of password");
            }

            if (textBoxNewPassword.Text != " ")
            {
                users.RemoveAt(j);
                users.Insert(j, textBoxNewPassword.Text);
            }
        }
    }
}
