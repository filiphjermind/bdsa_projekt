using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SliceOfPie;
using System.IO;
using System.Text;

namespace WebUI
{
    public partial class WebUserInterface : System.Web.UI.Page
    {
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

        Engine engine = new Engine();
        User user;
        List<Document> docs;

        Document currentDoc;

        string selectedFile;

        public string test
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            user = engine.userhandler.GetUser("MrT", "1234");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            // Do some other processing...

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("window.open('SaveDocumentConfirmation.aspx', '', 'resizable=no, width=500px, height=300px');");
            sb.Append("</scri");
            sb.Append("pt>");

            Page.RegisterStartupScript("test", sb.ToString());
        }

        protected void Login(object sender, EventArgs e)
        {
            string username = userBox.Text;
            string password = passwordBox.Text;
        }

        /// <summary>
        /// Creates a new empty document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewDocument(object sender, EventArgs e)
        {
            newDocumentHidden.Value = "true";
            currentDoc = facade.NewDocument(user);
            fileNameBox.Text = "";
            textArea.Text = currentDoc.content;
        }

        /// <summary>
        /// Saves the currently opened document.
        /// Saves the file to the disc.
        /// Saves an entry in the database.
        /// If the file/path doesn't exist, create it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Save(object sender, EventArgs e)
        {
            if (!fileNameBox.Text.Equals(""))
            {
                currentDoc = new Document(user);
                currentDoc.content = textArea.Text;
                facade.SaveDocument(user, currentDoc, fileNameBox.Text);
            }
        }

        protected void DeleteDocument(object sender, EventArgs e)
        {
            currentDoc = new Document(user);
        }


        protected void OpenDocument(object sender, EventArgs e)
        {
            Document doc = facade.OpenDocument(16, user);
            currentDoc = doc;
            textArea.Text = currentDoc.content;
        }

        /// <summary>
        /// Reads the content of a file selected in the file tree and populates the text field with
        /// the file's content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OpenDocumentFromFileTree(object sender, EventArgs e)
        {
            newDocumentHidden.Value = "false";
            fileNameBox.Text = "";
            selectedFile = FileTree.SelectedNode.Value.ToString();
            string[] splitPath = selectedFile.Split('\\');

            for (int i = 5; i < splitPath.Length; i++)
            {
                fileNameBox.Text += "/" + splitPath[i];
            }
            
            // Display the content of the file in the textArea.
            textArea.Text = engine.userhandler.docHandler.ReadFile(FileTree.SelectedNode.Value.ToString());
        }

        /****************** ALL METHODS BELOW ARE USED TO POPULATE THE FILE TREE **********************/

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
            rootNode.SelectAction = TreeNodeSelectAction.Expand;
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
                    if (!s.Equals(""))
                    {
                        if (!Directory.Exists(s))
                        {
                            Directory.CreateDirectory(s);
                        }
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
                node.SelectAction = TreeNodeSelectAction.Expand;
                currentNode.ChildNodes.Add(node);
                //recursively call same method to go down the next level of the tree
                TraverseTree(dir, node);
            }
        }
    }
}