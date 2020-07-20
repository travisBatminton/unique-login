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
    }
}
