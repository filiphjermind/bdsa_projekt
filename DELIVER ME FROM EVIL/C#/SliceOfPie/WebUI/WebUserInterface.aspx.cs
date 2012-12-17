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

        User user;

        // Currently opened document.
        Document currentDoc;

        // The currently selected file (in the file tree).
        string selectedFile;

        TreeNode node;
        TreeNode rootNode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (hiddenUsername.Value == "") { } else
            user = facade.GetUser(hiddenUsername.Value, hiddenPassword.Value);
        }

        // Used for testing!
        //protected void Button1_Click(object sender, EventArgs e)
        //{            
        //    // Do some other processing...
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<script>");
        //    sb.Append("window.open('SaveDocumentConfirmation.aspx', '', 'resizable=no, width=500px, height=300px');");
        //    sb.Append("</scri");
        //    sb.Append("pt>");

        //    Page.RegisterStartupScript("test", sb.ToString());
        //}

        /// <summary>
        /// Opens up a new window that allows a user to sign up for the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SignUp(object sender, EventArgs e)
        {
            // Do some other processing...
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("window.open('Signup.aspx', '', 'resizable=no, width=500px, height=300px');");
            sb.Append("</scri");
            sb.Append("pt>");

            Page.RegisterStartupScript("test", sb.ToString());
        }

        /// <summary>
        /// Logs the user into the system by checking his credentials
        /// against those stored in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Login(object sender, EventArgs e)
        {
            string username = userBox.Text;
            string password = passwordBox.Text;
            if (username != "" && password != "")
            {
                User user = facade.Authenticate(username, password);
                if (user.username != null && user.password != null)
                {
                    hiddenID.Value = user.id.ToString();
                    hiddenUsername.Value = user.username;
                    hiddenPassword.Value = user.password;
                    MessageLabel("Signed in as: " + hiddenUsername.Value);
                }
                else MessageLabel("Wrong username or password");
            }
            else MessageLabel("Please fill out username and password!");
        }

        /// <summary>
        /// Logs a user out of the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Logout(object sender, EventArgs e)
        {
            // Clear all text boxes.
            hiddenPassword.Value = "";
            hiddenUsername.Value = "";
            userBox.Text = "";
            fileNameBox.Text = "";
            // Clear user
            user = null;
            // Reload the page
            Response.Redirect(Request.RawUrl);
            MessageLabel("Logged out");
        }

        protected void GetDocumentHistory(object sender, EventArgs e)
        {
            //if (!fileNameBox.Text.Equals("") && !fileNameBox.Text.Equals(" "))
            //{
            //    if (user != null)
            //    {
            //        currentDoc = facade.GetDocumentByPath(user, "root/" + user.username + "/" + fileNameBox.Text.ToString());
            //        Response.Write("SDFSDFSD" + currentDoc.path);
            //    }
            //}
            string queryString = "http://localhost:63518/ShowDocumentHistory.aspx?filename=" + fileNameBox.Text.Trim() + "&username=" + user.username;
            string newWin = "window.open('" + queryString + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "pop", newWin, true);
        }

        /// <summary>
        /// Shares the current document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ShareDocument(object sender, EventArgs e)
        {
            if (!fileNameBox.Text.Equals(""))
            {
                Response.Write("FILENAME " + fileNameBox.Text);
                User toUser = facade.GetUser(ShareBox.Text);
                if (toUser != null)
                {
                    currentDoc = new Document(user);
                    currentDoc.content = textArea.Text;
                    //facade.SaveDocument(user, currentDoc, fileNameBox.Text);
                    facade.ShareDocument(user, currentDoc, Permission.Permissions.Edit, fileNameBox.Text, toUser);
                    MessageLabel("Document shared!");
                }
                
            }
            //else MessageLabel("No document selected!");
            //if (!fileNameBox.Text.Equals(""))
            //{
            //    User toUser = facade.GetUser(ShareBox.Text);
            //    if (toUser != null)
            //    {
            //        currentDoc = facade.GetDocumentByPath(user, hiddenPath.Value);
            //        currentDoc.content = textArea.Text;
            //        facade.ShareDocument(user, currentDoc, Permission.Permissions.Edit, toUser);
            //    }
            //}
            
        }

        protected void ShowDocument(object sender, EventArgs e)
        {
            string url = FileTree.SelectedNode.Value.ToString();
            ////string url = hiddenPath.Value;
            //Response.Write("SHOW: " + url);

            //// Do some other processing...
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script>");
            //sb.Append("window.open('" + url + "', '', 'resizable=no, width=500px, height=300px');");
            //sb.Append("</scri");
            //sb.Append("pt>");

            //Page.RegisterStartupScript("test", sb.ToString());


        //    string FullFilePath = url;//path of file //"D:\\ASP\\ASP.doc";
        //FileInfo file = new FileInfo(FullFilePath);
        //if (file.Exists)
        //{
        //    Response.ContentType = "text/html"; //"application/vnd.ms-word";
        //    Response.AddHeader("Content-Disposition", "inline; filename=\"" + file.Name + "\"");
        //    Response.AddHeader("Content-Length", file.Length.ToString());
        //    Response.TransmitFile(file.FullName);
        //}

            string queryString = "http://localhost:63518/ShowDocument.aspx?filename=" + fileNameBox.Text.Trim() + "&username=" + user.username;
            string newWin = "window.open('" + queryString + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "pop", newWin, true);

        }

        /// <summary>
        /// Creates a new empty document without saving it.
        /// Clears all test boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewDocument(object sender, EventArgs e)
        {
            currentDoc = facade.NewDocument(user, "", "", Permission.Permissions.Edit);
            fileNameBox.Text = "";
            textArea.Text = currentDoc.content;
            MessageLabel("New document created!");
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
                MessageLabel("Document saved!");
            } 
            else MessageLabel("No document selected!");
        }

        /// <summary>
        /// Deletes the currently opened document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteDocument(object sender, EventArgs e)
        {
            string path = "root/" + user.username + "/" + fileNameBox.Text;

            // Delete the document if any document is opened.
            if (fileNameBox.Text != "" && fileNameBox != null && path != "")
            {
                textArea.Text = "";
                fileNameBox.Text = "";
                facade.DeleteDocument(user, path);
                MessageLabel("Document deleted!");
            }
            else MessageLabel("No document selected!");
        }

        /// <summary>
        /// Reads the content of a file selected in the file tree and populates the text field with
        /// the file's content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OpenDocumentFromFileTree(object sender, EventArgs e)
        {
            fileNameBox.Text = "";
            selectedFile = FileTree.SelectedNode.Value.ToString();
            string[] splitPath = selectedFile.Split('\\');

            // Display the file (and it's path) in the filebox.
            for (int i = 5; i < splitPath.Length; i++)
            {
                if (i == splitPath.Length - 1)
                {
                    fileNameBox.Text += splitPath[i];
                }
                else
                {
                    fileNameBox.Text += splitPath[i] + "/";
                }
            }

            for (int i = 3; i < splitPath.Length; i++)
            {
                if (i == splitPath.Length - 1)
                {
                    hiddenPath.Value += splitPath[i];
                }
                else
                {
                    hiddenPath.Value += splitPath[i] + "/";
                }
            }

            //Response.Write(hiddenPath.Value);
            
            // Display the content of the file in the textArea.
            textArea.Text = facade.ReadFile(FileTree.SelectedNode.Value.ToString());
        }

        /************************************* PRIVATE HELPER METHODS ***************************************************/

        private void MessageLabel(string message)
        {
            msgLabel.Text = message;
        }

        /****************** ALL METHODS BELOW ARE USED TO POPULATE THE FILE TREE **********************/

        protected void Populate(object sender, EventArgs e)
        {
            //rootNode = null;
            //node = null;
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
            /*TreeNode*/ rootNode = new TreeNode(rootDir.Name, rootDir.FullName);
            rootNode.SelectAction = TreeNodeSelectAction.Expand;
            FileTree.Nodes.Add(rootNode);

            // Get all users documents
            HandleDocPath(GetDocFilePath(user));

            // populate tree
            TraverseTree(rootDir, rootNode);

            GetSharedDocuments(GetDocFilePath(user));

            //AddSharedDocument("hvass/Testing Purpose.html", rootNode);
        }

        private void GetSharedDocuments(List<string> path)
        {
            string[] splitSharedPath;
            string pathToDoc = "";
            foreach (string p in path)
            {
                splitSharedPath = p.Split('/');
                if (!splitSharedPath[1].Equals(user.username))
                {
                    AddSharedDocument(p, rootNode);
                }
            }
        }

        /// <summary>
        /// Retreives the document path to all the users documents
        /// from the database.
        /// </summary>
        /// <param name="user">The owner of the documents</param>
        /// <returns>A list of the path to all the users documents.</returns>
        private List<string> GetDocFilePath(User user)
        {
            List<Document> documents = facade.GetAllUsersDocuments(user);

            List<string> docFilePath = new List<string>();

            foreach (Document d in documents)
            {
                // Check if the document is empty.
                if (d != null)
                {
                    //Response.Write(documents.Count + " " +  d.path);
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

        private void AddSharedDocument(string fileName, TreeNode currentNode)
        {
            FileInfo file = new FileInfo(fileName);
            node = new TreeNode(file.Name, file.FullName);
            node.SelectAction = TreeNodeSelectAction.Select;
            currentNode.ChildNodes.Add(node);
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
                /*TreeNode*/ node = new TreeNode(file.Name, file.FullName);
                node.SelectAction = TreeNodeSelectAction.Select;
                currentNode.ChildNodes.Add(node);
            }

            // add all directories / subdirectories to the fileTree
            foreach (DirectoryInfo dir in currentDir.GetDirectories())
            {
                //create node and add to the tree view
                /*TreeNode*/ node = new TreeNode(dir.Name, dir.FullName);
                node.SelectAction = TreeNodeSelectAction.Expand;
                currentNode.ChildNodes.Add(node);
                //recursively call same method to go down the next level of the tree
                TraverseTree(dir, node);
            }
        }
    }
}