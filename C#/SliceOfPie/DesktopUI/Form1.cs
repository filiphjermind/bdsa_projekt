using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DesktopUI
{
    public partial class Form1 : Form
    {
        private DirectoryInfo CurrentDirectoryInfo;
        private string currentPath;
        public Form1()
        {
            
            InitializeComponent();
            rootDirectory.Text = @"C:\Users\" + Environment.UserName + @"\Documents\SliceOfPie";
            PopulateTreeView();
        }
        /// <summary>
        /// This method populates the tree based on which root directory the user
        /// have chosen.
        /// 
        /// This method is inspired by the msdn walkthrough from the following link: 
        /// http://msdn.microsoft.com/en-us/library/ms171645.aspx
        /// 
        /// </summary>
        private void PopulateTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(rootDirectory.Text);
            if (!info.Exists)
            {
                info.Create();
            }

            rootNode = new TreeNode(info.Name);
            rootNode.Tag = info;
            GetDirectories(info.GetDirectories(), rootNode);
            treeView1.Nodes.Add(rootNode);
            
            
        }
        /// <summary>
        /// This method adds a given directory to given TreeNode
        /// 
        /// This method is inspired by the msdn walkthrough from the following link: 
        /// http://msdn.microsoft.com/en-us/library/ms171645.aspx
        /// 
        /// </summary>
        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        void treeView1_NodeMouseClick(object sender,
            TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            CurrentDirectoryInfo = nodeDirInfo;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// This method should be called when the user have updatted the settings, such
        /// as username and password and rootdirectory. The method then updates the
        /// explorer view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickUpdateSettings(object sender, EventArgs e)
        {
            PopulateTreeView();
        }


        /// <summary>
        /// This method creates a new document based on the name the user types and
        /// the directory the user is located in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickCreateDocument(object sender, EventArgs e)
        {
            string text = "";
            System.IO.File.WriteAllText(CurrentDirectoryInfo.FullName + @"\" + CreateDocumentText.Text, text);
            CreateDocumentText.Text = "";

        }
        /// <summary>
        /// This method creates a new folder based on the name the user types and
        /// the directory the user is located in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickCreateFolder(object sender, EventArgs e)
        {
            //Creates the folder
            System.IO.Directory.CreateDirectory(CurrentDirectoryInfo.FullName + @"\" + CreateFolderText.Text);
            //Clear the foldername textfield
            CreateFolderText.Text = "";
            PopulateTreeView();
        }

        private void onClickShareDocumentButton(object sender, EventArgs e)
        {

        }

        private void OnClickShareFolderButton(object sender, EventArgs e)
        {

        }

        private void OnClickSynchronize(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method opens a document when the user click on the name 
        /// in the listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemActivated(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem lvi = (ListViewItem)lv.SelectedItems[0];
            DirectoryInfo di = (DirectoryInfo)treeView1.SelectedNode.Tag;
            currentPath = di.FullName + @"\" + lvi.Text;
            StreamReader streamReader = new StreamReader(currentPath);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            DocumentContent.Text = text;
            DocumentNameLabel.Text = "Document name: " +lvi.Text;
            
        }
        /// <summary>
        /// This method saves the document that is open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickSave(object sender, EventArgs e)
        {
            //deletes all existing text and writes the new text
            File.WriteAllText(currentPath, DocumentContent.Text);
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {   
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    DocumentContent.Text = "" + currentPath;
                   File.Delete(CurrentDirectoryInfo.FullName + @"\" + listView1.SelectedItems[i].Text);
                }
            }
            DocumentNameLabel.Text = "Document name: ";
        }

    }
}
