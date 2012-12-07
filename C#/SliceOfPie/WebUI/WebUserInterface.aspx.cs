using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SliceOfPie;
using System.IO;

namespace WebUI
{
    public partial class WebUserInterface : System.Web.UI.Page
    {
        Engine engine = new Engine();

        User user; 
        protected void Page_Load(object sender, EventArgs e)
        {
            user = engine.userhandler.GetUser("jetli", "12345");

            List<Document> docs = engine.userhandler.docHandler.GetAllUsersDocuments(user);

            foreach (Document d in docs)
            {
                textArea.Text = d.content;
            }

            PopulateTree(user);

        }

        /// <summary>
        /// Fills the fileTree with all files / folders that
        /// belong to a user
        /// </summary>
        /// <param name="user">The owner of the files</param>
        private void PopulateTree(User user)
        { 
            // Get user root dir, create and add it to the tree.
            DirectoryInfo rootDir = new DirectoryInfo("root/" + user.username);
            TreeNode rootNode = new TreeNode(rootDir.Name, rootDir.FullName);
            FileTree.Nodes.Add(rootNode);

            // Get all users documents
            HandleDocPath(GetDocFilePath(user));

            // populate tree
            TraverseTree(rootDir, rootNode);
        }

        /// <summary>
        /// Retreives the document path to all the users documents
        /// from the database.
        /// </summary>
        /// <param name="user">The owner of the documents</param>
        /// <returns>A list of the path to all the users documents.</returns>
        private List<string> GetDocFilePath(User user)
        {
            List<Document> documents = engine.userhandler.docHandler.GetAllUsersDocuments(user);

            List<string> docFilePath = new List<string>();

            foreach (Document d in documents)
            {
                docFilePath.Add(d.path);
            }

            return docFilePath;
        }

        /// <summary>
        /// Splits the path by "/".
        /// If the directories don't exist, create them
        /// </summary>
        /// <param name="path">List of paths.</param>
        private void HandleDocPath(List<string> path)
        {
            string[] splitpath;

            // split all paths
            foreach (string p in path)
            {
                splitpath = p.Split('/');
                // Create directories if they do not exist
                foreach (string s in splitpath)
                {
                    if (!Directory.Exists(s))
                    {
                        Directory.CreateDirectory(s);
                    }
                }
            }
        }

        /// <summary>
        /// Recursively adds all folders and files to the fileTree.
        /// </summary>
        /// <param name="currentDir">Current directory</param>
        /// <param name="currentNode">Current node of the fileTree</param>
        private void TraverseTree(DirectoryInfo currentDir, TreeNode currentNode)
        {
            foreach (FileInfo file in currentDir.GetFiles())
            {
                TreeNode node = new TreeNode(file.Name, file.FullName);
                currentNode.ChildNodes.Add(node);
            }
            //loop through each sub-directory in the current one
            foreach (DirectoryInfo dir in currentDir.GetDirectories())
            {
                //create node and add to the tree view
                TreeNode node = new TreeNode(dir.Name, dir.FullName);
                currentNode.ChildNodes.Add(node);
                //recursively call same method to go down the next level of the tree
                TraverseTree(dir, node);
            }
        }

        protected void Click(object sender, EventArgs e)
        {
            textArea.Text = "Clicked: " + sender.ToString();
        }


    }
}