using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using WeifenLuo.WinFormsUI.Docking;
using OpenMcdf;
using System.Collections.Generic;
using System.Linq;

namespace FTAMF
{
    public partial class MainForm : Form
    {
        private const int MAX_RECENT_FILES = 10;
        public MainForm()
        {
            InitializeComponent();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            Text = $"FTAMF v.{versionInfo.FileVersion}";
            VS2012BlueTheme theme = new VS2012BlueTheme();
            dockPanel1.Theme = theme;
            LoadRecentFiles();
        }

        #region Menu
        private void MnuOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open file",
                Filter = "APA file|*.apa|MER file|*.mer|All|*.*",
                FileName = "",
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)            {
                OpenFile(openFileDialog.FileName);
            }
        }

        private void MnuCloseFile_Click(object sender, EventArgs e)
        {

        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 dialog = new AboutBox1();
            dialog.ShowDialog();
        }

        #endregion


        #region Events

        private void RecentFile_Click(object sender, EventArgs e)
        {
            string path = ((ToolStripMenuItem)sender).Text;
            if (File.Exists(path))
            {
                OpenFile(path);
            }
            else
            {
                MessageBox.Show("File was moved or deleted. The path will be removed from Recent Files", "Atention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MnuRecentFiles.DropDownItems.Remove(FindRecentFile(path));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRecentFiles();
        }

        #endregion


        #region Recent Files

        /// <summary>
        /// Returns true if the file specified by the path is already open in the dockpanel.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool IsAlreadyOpen(string path)
        {
            foreach(DockContent item in dockPanel1.Contents)
            {
                if (((CFviewer)item).Tag.ToString() == path) return true;
            }
            return false;
        }

        /// <summary>
        /// Updates items in the Recent Files menu.
        /// </summary>
        /// <param name="path"></param>
        private void UpdateRecentFiles(string path)
        {
            ToolStripMenuItem item = FindRecentFile(path);

            if (item != null)
            {
                int x = MnuRecentFiles.DropDownItems.IndexOf(item);
                MnuRecentFiles.DropDownItems.RemoveAt(x);
                MnuRecentFiles.DropDownItems.Insert(0, item);
            }
            else 
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem(path);
                newItem.Click += new EventHandler(RecentFile_Click);
                MnuRecentFiles.DropDownItems.Insert(0, newItem);
                if (MnuRecentFiles.DropDownItems.Count > MAX_RECENT_FILES)
                {
                    MnuRecentFiles.DropDownItems.RemoveAt(MAX_RECENT_FILES);
                }
            }
        }

        /// <summary>
        /// Search for an item in the Recent Files menu.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ToolStripMenuItem FindRecentFile(string path)
        {
            foreach (ToolStripMenuItem item in MnuRecentFiles.DropDownItems)
            {
                if (item.Text == path) return item;
            }
            return null;
        }

        /// <summary>
        /// Verify if the path exists in the Recent File items. 
        /// </summary>
        /// <param name="path">True if the given path exists in the Recen Files items.</param>
        /// <returns></returns>
        private bool IsInRecentFiles(string path)
        {
            foreach (ToolStripMenuItem item in MnuRecentFiles.DropDownItems)
            {
                if (item.Text == path) return true;
            }
            return false;
        }

        /// <summary>
        /// Save recent files list to application settings.
        /// </summary>
        private void SaveRecentFiles()
        {
            if (MnuRecentFiles.DropDownItems.Count > 0)
            {
                List<string> list = new List<string>();
                foreach(ToolStripDropDownItem item in MnuRecentFiles.DropDownItems)
                {
                    list.Add(item.Text);
                }
                Properties.Settings.Default.RecentFiles = string.Join(";", list);
            }
            else
            {
                Properties.Settings.Default.RecentFiles = "";
            }
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Load recent files list from application settings.
        /// </summary>
        private void LoadRecentFiles()
        {
            MnuRecentFiles.DropDownItems.Clear();
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.RecentFiles))
            {
                list = Properties.Settings.Default.RecentFiles.Split(';').ToList<string>();
                foreach(string item in list)
                {
                    ToolStripMenuItem path = new ToolStripMenuItem(item);
                    path.Click += new EventHandler(RecentFile_Click);
                    MnuRecentFiles.DropDownItems.Add(path);
                }
            }
        }

        #endregion

        /// <summary>
        /// Open an APA or MER file. If it's already open, select the DockPanel tab.
        /// </summary>
        /// <param name="path"></param>
        private void OpenFile(string path)
        {
            if (IsAlreadyOpen(path))
            {
                SelectOpenDocumentTab(path);
            }
            else
            {
                new CFviewer(new CompoundFile(path))
                {
                    TabText = Path.GetFileName(path),
                    Tag = path
                }.Show(dockPanel1, DockState.Document);
            }
            UpdateRecentFiles(path);
        }

        /// <summary>
        /// Select the Dock Panel tab that corresponds to an open file.
        /// </summary>
        /// <param name="path"></param>
        private void SelectOpenDocumentTab(string path)
        {
            foreach (DockContent item in dockPanel1.Contents)
            {
                CFviewer cf = (CFviewer)item;
                if (cf.Tag.ToString() == path) cf.Select();
            }
        }


    }
}
