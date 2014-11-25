using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;  
using System.Runtime.Serialization;
using System.Windows;
using System.Web.Script.Serialization;

namespace Password_Manager
{
    public partial class Form1 : Form
    {
        // Array of our objects
        public List<Entry> m_entries = new List<Entry>();
       
        // If a new file is opened or one file is opened
        // at least once, this flag gets set to false.
        private bool noFileOpened = true;

        // Master password
        public string m_masterPwd = "";

        // Settings member variable
        public MySettings m_settings = new MySettings();

        // Flag to indicate first start of application
        public bool firstStart = true;

        public Form1()
        {
            InitializeComponent();

            // When program starts, no need to enable new entry and
            // save database menu items.
            newEntryToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;

            // Image lists
            listView1.SmallImageList = imageList1;
            listView1.LargeImageList = imageList2;

            toolStripButton1.Click += newToolStripMenuItem_Click;
            toolStripButton2.Click += openToolStripMenuItem_Click;
            toolStripButton3.Click += saveToolStripMenuItem_Click;
            toolStripButton5.Click += newEntryToolStripMenuItem_Click;

            toolStripButton3.Enabled = false;
            toolStripButton5.Enabled = false;

           

            try
            {
                // Load settings
                m_settings = MySettings.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Check list default style
            if (firstStart)
            {
                if (m_settings.viewMode == 0)
                {
                    listView1.View = View.LargeIcon;

                    // Uncheck details menu item
                    detailsToolStripMenuItem.Checked = false;

                    // Check large icons menu item
                    largeToolStripMenuItem.Checked = true;

                    firstStart = false;

                }
                else 
                {
                    listView1.View = View.Details;

                    // Uncheck details menu item
                    detailsToolStripMenuItem.Checked = true;

                    // Check large icons menu item
                    largeToolStripMenuItem.Checked = false;

                    firstStart = false;
                }
            }

                
             
        }

        /// <summary>
        /// Show entries from model object on the list view.
        /// </summary>
        public void ShowEntries()
        {
            // Clear items first
            listView1.Items.Clear();

            // Add model objects to list view.
            for (int i = 0; i < m_entries.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(m_entries[i].siteName);
                item1.SubItems.Add(m_entries[i].siteURL);
                item1.SubItems.Add(m_entries[i].userName);
                if (m_settings.showPass)
                    item1.SubItems.Add(m_entries[i].password);
                else
                    item1.SubItems.Add("*****");
                item1.SubItems.Add(m_entries[i].comment);
                item1.ImageIndex = m_entries[i].iconIndex;
                listView1.Items.Add(item1);
            }
        }

        /// <summary>
        /// User wants to create a new password entry.
        /// </summary>
        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new form where the user will enter
            // new password entry details, like username, etc.
            NewEntry form2 = new NewEntry();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // If user clicked OK on that dialog,
                // add the new entry which user typed to
                // our model objects array.
                m_entries.Add(form2.m_entry);

                // Show entries
                ShowEntries();
            }
        }

         
        /// <summary>
        /// User changed view to large icons.
        /// </summary>
        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;

            // Uncheck details menu item
            detailsToolStripMenuItem.Checked = false;

            // Check large icons menu item
            largeToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// User changed view to details.
        /// </summary>
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            // Check details menu item
            detailsToolStripMenuItem.Checked = true;

            // Uncheck large items menu item
            largeToolStripMenuItem.Checked = false;

        }


        private void listClick(object sender, EventArgs e)
        {
    
        }

        /// <summary>
        /// User clicked Save button on the menu. 
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If 'no file opened' check is true there is
            // no need to save anything, right?
            if (noFileOpened == true)
            {
                MessageBox.Show("It seems you didn't open any database");
                return;
            }

            try
            {
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    using (var fileStream = File.Open(saveFileDialog1.FileName, FileMode.Create)) 
                    using (var memoryStream = new MemoryStream())
                    {
                         // First, we serialize our objects to memory
                         // stream instead of file
                         var formatter = new BinaryFormatter();
                         formatter.Serialize(memoryStream, m_entries);
                       
                         // Now, we need to read the bytes from the memory stream
                         // Before, reading first, seek to the beginning, then do read.
                         memoryStream.Seek(0, SeekOrigin.Begin);
                         var bytes = new byte[memoryStream.Length];
                         memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                      
                        // Ok, we got the bytes, now let's encrypt them and
                        // write to file the encrypted bytes.
                        var encryptedBytes = SecurityHelper.Encrypt(bytes,m_masterPwd);
                        fileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                  }
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// User clicked the Open menu item.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)  
                {
                    // Enter master password
                    Master_password mp = new Master_password();
                    if (mp.ShowDialog() == DialogResult.OK)
                    {
                        m_masterPwd = mp.m_masterPassword;
                    }
                    else
                    {
                        return;
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        // Read all bytes from the file
                        byte [] fileBytes = File.ReadAllBytes(openFileDialog1.FileName);
                       
                        // Decrypt the bytes
                        byte [] decryptedBytes = SecurityHelper.Decrypt(fileBytes, m_masterPwd);

                        // Create memory stream out of decrypted bytes
                        var encStream = new MemoryStream(decryptedBytes);

                        // Now we must deserialize the memory stream
                        // and get list of our objects.
                        var formatter = new BinaryFormatter();
                        m_entries = (List<Entry>)formatter.Deserialize(encStream);

                        // Some flags.
                        listView1.Enabled = true;
                        noFileOpened = false;
                        saveToolStripMenuItem.Enabled = true;
                        toolStripButton3.Enabled = true;
                        toolStripButton5.Enabled = true;


                        // Show our objects.
                        ShowEntries();

                     }

                    // Enable menu item for adding new entry, since database was opened
                    newEntryToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "", ex.Message);
                MessageBox.Show(ex.Message);

            }
        }

        /// <summary>
        /// User clicked New in File menu. Enable adding new entry. 
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (noFileOpened == false)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to create new database?\nOld entries will be lost if they were not saved.", "Create new database", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
        
            }

            // Enter master password
            Master_password mp = new Master_password();
            if (mp.ShowDialog() == DialogResult.OK)
            {
                m_masterPwd = mp.m_masterPassword;
            }
            else
            {
                return;
            }
            

            // Enable adding new entry since user created new database of passwords
            newEntryToolStripMenuItem.Enabled = true;

            // We start with an empty array of entries since
            // user clicked New file. Old entries will be lost
            // if not saved.
            m_entries = new List<Entry>();

            listView1.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton5.Enabled = true;
            noFileOpened = false;

            ShowEntries();
            
        }

        /// <summary>
        /// Clicked application exit. 
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// List item double clicked. 
        /// </summary>
        private void doubleClick(object sender, EventArgs e)
        {
            // Get index of double clicked item.
            int i = listView1.SelectedItems[0].Index;

            NewEntry form2 = new NewEntry();
            form2.Text = "Edit entry";
            form2.m_iconIndex = m_entries[i].iconIndex;
            form2.m_entry = m_entries[i];

            // Pass selected entry forward to the form and show it.
            form2.ShowEntry();

            // User clicked OK.
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Retrieve data that user enetered.
                m_entries[i].siteName = form2.m_entry.siteName;
                m_entries[i].siteURL = form2.m_entry.siteURL;
                m_entries[i].userName = form2.m_entry.userName;
                m_entries[i].password = form2.m_entry.password;
                m_entries[i].comment = form2.m_entry.comment;
                m_entries[i].iconIndex = form2.m_iconIndex;
                
                // Show entries
                ShowEntries();
            }
        }

        private void listMouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    contextMenuStrip1.Show(listView, e.Location);
                }
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = listView1.SelectedItems[0].Index;
            m_entries.RemoveAt(i);
            ShowEntries();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AppSettings ap = new AppSettings();
            ap.m_showPass = m_settings.showPass;
            ap.m_viewMode = m_settings.viewMode;
            ap.ShowUI();
            if (ap.ShowDialog() == DialogResult.OK)
            {
                m_settings.viewMode = ap.m_viewMode;
                m_settings.showPass = ap.m_showPass;

                try
                {
                    m_settings.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ShowEntries();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Password manager. Version: 1.00\nCopyright \u00a9 Giorgi Moniava, 2014", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
    }

    // Class for managing application settings
    public class ApplicationSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.jsn";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    }

    public class MySettings:  ApplicationSettings<MySettings>
    {
        public int viewMode = 0;
        public bool showPass = false;
    }

    // Represents single entry.
    [Serializable]
    public class Entry
    {
        public string siteName;
        public string userName;
        public string password;
        public string siteURL;
        public string comment;
        public int iconIndex = 0;
    }
}
