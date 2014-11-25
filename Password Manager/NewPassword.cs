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
    public partial class NewPassword : Form
    {
        public string m_password;
        public NewPassword()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_password = SecurityHelper.GeneratePassword((int)numericUpDown1.Value);
            textBox1.Text = m_password;
        }
    }
}
