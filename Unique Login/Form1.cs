using Generate_Logins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unique_Login
{
    public partial class Form1 : Form
    {
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

        }

        private void btn_copy_password_Click(object sender, EventArgs e)
        {

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            List <string> username = new List<string>();

            var result = "";

            if (cbox_adjective.Checked)
            {
                username.Add(login.RandomAdjective());
            }

            if (cbox_animal.Checked)
            {
                username.Add(login.RandomAnimal());
            }

            if (cbox_noun.Checked)
            {
                username.Add(login.RandomNoun());
            }

            if (cbox_verb.Checked)
            {
                username.Add(login.RandomVerb());
            }




            foreach (string elements in username)
            {
                result += elements;
            }

            tbox_password.Text = result.ToString();

 

        }
    }
}
