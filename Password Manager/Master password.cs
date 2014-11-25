using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class Master_password : Form
    {
        public string m_masterPassword;

        public Master_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Passwords can't be empty");
                return;
            }

            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Passwords don't match");
                return;
            }

            if (textBox1.Text.Length < 5)
            {
                MessageBox.Show("Password length should not be less than 5 characters.");
                return;
            }

            m_masterPassword = textBox1.Text;
            this.DialogResult = DialogResult.OK;

        }
    }
}
