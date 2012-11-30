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

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"), 
                     new ListViewItem.ListViewSubItem(item, 
						dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
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

        private void onClickUpdateSettings(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void OnClickCreateDocument(object sender, EventArgs e)
        {
            string text = "";
            System.IO.File.WriteAllText(CurrentDirectoryInfo.FullName + @"\" + CreateDocumentText.Text, text);
            CreateDocumentText.Text = "";

        }

        private void OnClickCreateFolder(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(CurrentDirectoryInfo.FullName + @"\" + CreateFolderText.Text);
            CreateFolderText.Text = "";
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

        private void OnDoubleClickFileOrFolder(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            ListView.CheckedListViewItemCollection checkedItems = listView.CheckedItems;
            DocumentContent.Text = DocumentContent.Text + listView1;
        }

        private void temp(object sender, ItemCheckedEventArgs e)
        {
            DocumentContent.Text = DocumentContent.Text + e.Item.ToString();
        }

    }
}
