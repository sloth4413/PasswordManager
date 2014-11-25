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
    public partial class AppSettings : Form
    {
        public int m_viewMode;
        public bool m_showPass;

        public AppSettings()
        {
            InitializeComponent();
        }

        public void ShowUI()
        {
            if (m_viewMode == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            checkBox1.Checked = m_showPass;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                m_viewMode = 0;
            else
                m_viewMode = 1;

            m_showPass = checkBox1.Checked;
        }
    }
}
