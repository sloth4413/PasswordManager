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
    public partial class NewEntry : Form
    {
        // Entry currently shown
        public Entry m_entry = new Entry();

        // Index to currently shown icon
        public int m_iconIndex = 0;

        public NewEntry()
        {
            InitializeComponent();
            button3.BackgroundImage = imageList1.Images[m_iconIndex];
            this.toolTip1.SetToolTip(this.button4, "Generate random password");
        }

        public void ShowEntry()
        {
            // Show entry on UI
            textBox1.Text = m_entry.siteName;
            textBox2.Text = m_entry.siteURL;
            textBox3.Text = m_entry.userName;
            textBox4.Text = m_entry.password;
            textBox5.Text = m_entry.comment;
            button3.BackgroundImage = imageList1.Images[m_iconIndex];
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            // Store entry data
            m_entry = new Entry();
            m_entry.siteName = textBox1.Text;
            m_entry.siteURL = textBox2.Text;
            m_entry.userName = textBox3.Text;
            m_entry.password = textBox4.Text;
            m_entry.comment = textBox5.Text;
            m_entry.iconIndex = m_iconIndex;

        }

        private void button3_Click(object sender, EventArgs e)
        {
              // Open form to choose icon
              ChooseIcon form2 = new ChooseIcon();
              // Pass forward ID of current icon
              form2.m_iconID = m_iconIndex;
              // Highlight that item
              form2.SelectItem();
              if (form2.ShowDialog() == DialogResult.OK)
              {
                  // Get ID of selected icon
                  m_iconIndex = form2.m_iconID;
                  // Set as background image
                  button3.BackgroundImage = imageList1.Images[m_iconIndex];
              }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewPassword np = new NewPassword();
            if (np.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = np.m_password;
            }
        }
    }
}
