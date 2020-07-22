using Generate_Logins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unique_Login
{
    public partial class Form1 : Form
    {
        Login login = new Login();
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            nbox_lengh_of_password.Value = 12;
        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = "This application is written by wajeht. \n";
                message += "\n https://www.github.com/wajeht";

            MessageBox.Show(message);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_copy_username_Click(object sender, EventArgs e)
        {

           if (string.IsNullOrEmpty(tbox_username.Text))
            {
                MessageBox.Show("Username is empty!");
            } else
            {
                System.Windows.Forms.Clipboard.SetText(tbox_username.Text);
            }

        }

        private void btn_copy_password_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(tbox_password.Text))
            {
                MessageBox.Show("Password is empty!");
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(tbox_password.Text);

            }

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            List<string> usernames = new List<string>();
            List<string> passwords = new List<string>();


            var generatedUsername = "";
            var generatedPassword = "";
            var lengthOfPassword = nbox_lengh_of_password.Value;
            var randomPassword = "";


            // usernames control flow below
            if (cbox_adjective.Checked)
            {
                usernames.Add(login.RandomAdjective());
            }

            if (cbox_animal.Checked)
            {
                usernames.Add(login.RandomAnimal());
            }

            if (cbox_noun.Checked)
            {
                usernames.Add(login.RandomNoun());
            }

            if (cbox_verb.Checked)
            {
                usernames.Add(login.RandomVerb());
            }

            foreach (string username in usernames)
            {
                generatedUsername += username;
            }


            // password contorl flow below
            if (cbox_uppercase.Checked)
            {
                passwords.Add(login.upercase);
            }

            if (cbox_lowercase.Checked)
            {
                passwords.Add(login.lowercase);
            }

            if (cbox_number.Checked)
            {
                passwords.Add(login.number);
            }

            if (cbox_special.Checked)
            {
                passwords.Add(login.special);
            }

            foreach (string password in passwords)
            {
                generatedPassword += password;
            }


            // error handling if user didn't select anyhing
            if (string.IsNullOrEmpty(generatedPassword) || string.IsNullOrEmpty(generatedUsername))
            {
                MessageBox.Show("Check at least one username and password type!");
            } else
            {
                for (var i = 0; i < lengthOfPassword; i++)
                {
                    randomPassword += generatedPassword[random.Next(generatedPassword.Length)];
                }

                tbox_password.Text = randomPassword.ToString();
                tbox_username.Text = generatedUsername.ToString();

                login.addToList(tbox_password.Text);
                login.addToList(tbox_username.Text);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbox_animal.Checked = false;
            cbox_adjective.Checked = false;
            cbox_verb.Checked = false;
            cbox_noun.Checked = false;

            cbox_uppercase.Checked = false;
            cbox_lowercase.Checked = false;
            cbox_number.Checked = false;
            cbox_special.Checked = false;

            tbox_password.Clear();
            tbox_username.Clear();

            login.Clear();
        }

        private void pbox_logo_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.github.com/wajeht");
            Process.Start(sInfo);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbox_username.Text == "" || tbox_password.Text == "")
            {
                MessageBox.Show("Your list is empty!");
            }
            else
            {

                MessageBox.Show("You list has been saved as unique_login.txt to your Desktop!");

                // this will store to user's desktop folder
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "unique_login.txt");
                login.WriteToFile(path);
                
            }
        }
    }
}
