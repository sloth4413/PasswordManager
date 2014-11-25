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
    public partial class ChooseIcon : Form
    {
        // Index to selected icon.
        public int m_iconID = 0;
        
        public ChooseIcon()
        {
            InitializeComponent();

            // Set image list.
            listView1.LargeImageList = imageList1;

            // Add items to the list for each image.
            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);
            }

        }

        public void SelectItem()
        {
            // Highlight selected item.
            listView1.Items[m_iconID].Selected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // When user clicked OK retrieve ID of selected icon.
            m_iconID = listView1.SelectedItems[0].Index;
        }
    }
}
