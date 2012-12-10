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
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

        Engine engine = new Engine();
        User user;
        List<Document> docs;

        Document currentDoc;

        string userRoot;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.textArea.Text = Server.HtmlDecode(this.textArea.Text);
            user = engine.userhandler.GetUser("MrT", "1234");

            docs = engine.userhandler.docHandler.GetAllUsersDocuments(user);

            //userRoot = engine.rootDirectory;

            // Check if the document list is empty
            //if (docs != null) 
            //{
            //    foreach (Document d in docs)
            //    {
            //        // Check if the document is empty.
            //        if (d != null)
            //        {
            //            textArea.Text = d.content;
            //        }
            //    }
            //}

            //PopulateTree(user);

            //foreach (TreeNode n in FileTree.Nodes)
            //{
            //    n.SelectAction = TreeNodeSelectAction.SelectExpand;
            //}

            
            

        }

        protected void Populate(object sender, EventArgs e)
        {
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
            rootNode.SelectAction = TreeNodeSelectAction.SelectExpand;
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
                // Check if the document is empty.
                if (d != null)
                {
                    docFilePath.Add(d.path);
                }
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
            // Add all files to the fileTree
            foreach (FileInfo file in currentDir.GetFiles())
            {
                TreeNode node = new TreeNode(file.Name, file.FullName);
                node.SelectAction = TreeNodeSelectAction.Select;
                currentNode.ChildNodes.Add(node);
            }

            // add all directories / subdirectories to the fileTree
            foreach (DirectoryInfo dir in currentDir.GetDirectories())
            {
                //create node and add to the tree view
                TreeNode node = new TreeNode(dir.Name, dir.FullName);
                node.SelectAction = TreeNodeSelectAction.SelectExpand;
                currentNode.ChildNodes.Add(node);
                //recursively call same method to go down the next level of the tree
                TraverseTree(dir, node);
            }
        }

        protected void Click(object sender, EventArgs e)
        {
            textArea.Text = "Clicked: ";
        }

        private string SetCurrentRootDirectory(User user)
        {
            string userRoot = user.username;
            string rootDir = engine.rootDirectory + "/" + userRoot;

            return rootDir;
        }

        protected void NewDocument(object sender, EventArgs e)
        {
            currentDoc = facade.NewDocument(user);
            //currentDoc = doc;
            //textArea.Text = currentDoc.content;
        }

        protected void SaveDocument(object sender, EventArgs e)
        {
            //Document doc = new Document(user);
            currentDoc = new Document(user);
            currentDoc.content = textArea.Text;
            facade.SaveDocument(user, currentDoc, "hello.html");
        }

        protected void OpenDocument(object sender, EventArgs e)
        {
            Document doc = facade.OpenDocument(16, user);
            currentDoc = doc;
            textArea.Text = currentDoc.content;
        }
    }
}