using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace SliceOfPie
{
    public class DBConnector
    {
        private static DBConnector instance;
        private MySqlConnection connection;
        private string connectionString;

        public static DBConnector Instance
        {
            get
            {
                if (instance == null) instance = new DBConnector();
                return instance;
            }
        }
        
        private DBConnector()
        {
            Initialize();
            OpenConnection();

        }

        /// <summary>
        /// Instanciates a connection between program and server via a connectionstring
        /// </summary>
        private void Initialize()
        {
            connectionString = "SERVER=mysql.itu.dk;DATABASE=PieServer;UID=pieserver;PASSWORD=bdsapie;";
            connection = new MySqlConnection(connectionString);
            
        }

        /// <summary>
        /// Attempts to open the connection to our sever by using the already created connection 
        /// </summary>
        /// <returns>wether the connection was successfully opened or not.
        /// True = the connection was opened
        /// False the connection was not opened</returns>
        private bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:Console.WriteLine("Cannot connect to server.  Contact administrator");break;
                    case 1045:Console.WriteLine("Invalid username/password, please try again");break;
                }
                return false;
            }
        }

        /// <summary>
        /// Closes the connection
        /// </summary>
        /// <returns>wether the connection was closed or not.
        /// True = connection was closed
        /// False = connection was not closed</returns
        private bool CloseConnection()
        {
            try { connection.Close(); return true; }
            catch (MySqlException ex) { Console.WriteLine(ex.Message); return false; }
        }

        /// <summary>
        /// Inserts a document in the database.
        /// </summary>
        /// <param name="owner">User whom created the document</param>
        /// <param name="file">Location of document on the server</param>
        public void InsertDocument(string owner, string file)
        {
            string query = "INSERT INTO document (owner, file) VALUES('" + owner + "', '" + file + "')";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Deletes all of one users documents from database
        /// </summary>
        /// <param name="owner">user whoom owns the documents</param>
        public void DeleteDocumentByUserName(string owner)
        {
            string query = "DELETE FROM document WHERE owner='" + owner + "'";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Deletes a single document from the database
        /// </summary>
        /// <param name="id">ID of the document that need to be deleted</param>
        public void DeleteDocumentByID(int id)
        {
            string query = "DELETE FROM document WHERE id='" + id + "'";
            ExecuteQuery(query);
        }
        
        /// <summary>
        /// Deletes a document entry from the database
        /// </summary>
        /// <param name="path">"file" of document entry to be deleted</param>
        public void DeleteDocumentByPath(string path)
        {
            //string query = "DELETE FROM document WHERE owner ='" + user.username + "' AND WHERE file ='" + path + "'";
            string query = "DELETE FROM document WHERE file='" + path + "'";
            ExecuteQuery(query);
            Console.WriteLine("DBCON: " + path);
        }

        /// <summary>
        /// Updates a document entry in the database by looking up its "id" and replacing
        /// old values with input
        /// </summary>
        /// <param name="id">existing entry's id</param>
        /// <param name="newOwner">existing entry's new "owner"</param>
        /// <param name="newFile">Existing enry's new "file"</param>
        public void UpdateDocumentByID(int id, string newOwner, string newFile)
        {
            string query = "UPDATE document SET owner='"+newOwner+"', file='"+newFile+"' WHERE id="+id+"";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Selects all CREATED documents from 1 user
        /// </summary>
        /// <param name="user">target user</param>
        /// <returns>a list of all of target owner's created document's IDs</returns>
        public List<int> SelectDocumentsFromUser(User user)
        { 
            List<Document> documentList = new List<Document>();
            List<int> idList = new List<int>();

            string query = "SELECT id FROM document WHERE owner='"+user.username +"'";

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read()) idList.Add((int)reader["id"]);

            reader.Close();
            CloseConnection();

                return idList;
        }

        /// <summary>
        /// Inserts a user into the database
        /// </summary>
        /// <param name="name">user's name</param>
        /// <param name="username">user's username</param>
        /// <param name="password">user's password</param>
        public void InsertUser(string name, string username, string password)
        {
            string query = "INSERT INTO user (name, username, password) VALUES('" + name + "', '" + username + "', '" + password + "') ";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Deletes target user and all of his documents
        /// </summary>
        /// <param name="username">User's username</param>
        public void DeleteUserByUsername(string username)
        {
            DeleteDocumentByUserName(username);
            string query = "DELETE FROM user WHERE username='" + username + "'";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Updates a user entry in the database by looking up his username and replacing
        /// old values with input
        /// </summary>
        /// <param name="username">user entry in database</param>
        /// <param name="newName">Entry's new "name"</param>
        /// <param name="newUsername">Entry's new "username"</param>
        /// <param name="newPassword">Entry's new "password"</param>
        public void UpdateUserByUsername(string username, string newName, string newUsername, string newPassword)
        {
            string query = "UPDATE user SET username = '" + newUsername + "', name = '"+newName+"', password = '"+newPassword+"' WHERE username='" + username + "'"; 
            ExecuteQuery(query);
        }

        /// <summary>
        /// Retreives a user from the database.
        /// </summary>
        /// <param name="usernameInput">username of the user to retreive</param>
        /// <param name="passwordInput">users password</param>
        /// <returns>   Array with users information.
        ///             arr[0] = users id
        ///             arr[1] = users name
        ///             arr[2] = users username
        ///             arr[3] = users password
        /// </returns>
        public string[] SelectUser(string username)
        { 
            string[] userAssembly = new string[4];

            string query = "SELECT * FROM user WHERE username='" + username + "'";

            MySqlDataReader reader = ExecuteReader(query);

            try
            {
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    userAssembly[0] = id.ToString();
                    userAssembly[1] = reader["name"] + "";
                    userAssembly[2] = reader["username"] + "";
                    userAssembly[3] = reader["password"] + "";
                }
            }
            catch (NullReferenceException ex)
            {
                ErrorMessage("No user with both given username and password exists.");
            }
            reader.Close();
            CloseConnection();
            return userAssembly;
        }

        /// <summary>
        /// selects all users in the database
        /// </summary>
        /// <returns>a list of usernames from all users in the database</returns>
        public List<string> SelectAllUsers()
        {
            List<string> userList = new List<string>();

            string query = "SELECT username FROM user";

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                userList.Add(reader["username"] + "");
            }
            reader.Close();
            CloseConnection();
            return userList;
        }

        /// <summary>
        /// Checks the database for already existing document
        /// </summary>
        /// <param name="user">document's owner</param>
        /// <param name="doc">document instance</param>
        /// <returns>Wether the document exists or not.
        /// True = it exists
        /// False= it does not exist</returns>
        public bool CheckForDocument(User user, Document doc)
        {
            string query = "SELECT * FROM document WHERE owner='" + user.username + "' AND id='" + doc.documentId + "'";

            List<int> counterList = new List<int>();

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                counterList.Add((int)reader["id"]);
            }

            reader.Close();
            CloseConnection();

            if (counterList.Count > 0) return true;
            else return false;
        }

        /// <summary>
        /// Retreives a document from the database based on the document id.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        /// <returns>File path to the docuemnt</returns>
        public string GetDocument(int id, string user)
        {
            string query = "SELECT file FROM document WHERE id = '" + id + "' AND owner ='" + user + "'";

            string path = "";

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                path = (string) reader[0];
                //Console.WriteLine("Path: " + path);
            }
            reader.Close();
            CloseConnection();
            return path;
        }

        /// <summary>
        /// Finds a document in the database without need of an ID
        /// </summary>
        /// <param name="user">document's owner</param>
        /// <param name="filePath">document's filepath</param>
        /// <returns></returns>
        public string GetDocumentById(int id)
        {
            string query = "SELECT file FROM document WHERE id = '" + id + "'";

            string path = "";

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                path = (string) reader[0];
            }
            reader.Close();
            CloseConnection();
            return path;
        }
        public int GetDocument(string user, string filePath)
        {
            string query = "SELECT id FROM document WHERE file = '" + filePath + "' AND owner ='" + user + "'";

            int id = 0;

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                id = (int)reader["id"];
                //Console.WriteLine("Path: " + path);
            }
            reader.Close();
            CloseConnection();
            return id;
        }

        /// <summary>
        /// Inserts a userdocument in the database
        /// </summary>
        /// <param name="user">user "end" of userdocument relation</param>
        /// <param name="docID">document "end" of userdocument relation</param>
        /// <param name="permission">relation type, what level of authentication the user has to the specified document</param>
        public void InsertUserDocument(User user, int docID, Permission.Permissions permission)
        {
            string query = "INSERT INTO userdocument (userID, documentID, permission) VALUES('" + user.id + "', '" + docID + "', '" + permission.ToString() +"')";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Deletes a userdocument relation from the database
        /// </summary>
        /// <param name="user">userdocument relation's user</param>
        /// <param name="doc">userdocument relation's document</param>
        public void DeleteUserDocument(User user, Document doc)
        { 
            string query = "DELETE FROM userdocument WHERE userID='"+user.id+"' AND documentID='"+doc.documentId+"'";
            ExecuteQuery(query);
        }
        
        /// <summary>
        /// Updates a permission in an already existing userdocument relation
        /// </summary>
        
        /// <param name="newPerm">new permission to the userdocument relation</param>
        public void UpdatePermission(User user, Document doc, Permission.Permissions newPerm)
        {
            string query = "UPDATE userdocument SET permission='" + newPerm + "' WHERE userID='" + user.id + "' AND documentID='" + doc.documentId + "'";
            ExecuteQuery(query);
        }

        /// <summary>
        /// Selects all of the documents a user is able to see, that inclutes the
        /// documents he have created himself, and those that are shared with him
        /// </summary>
        /// <param name="user">userdocument relation's user</param>
        /// <returns>a List of all available documents' ids</returns>
        public List<int> GetUserdocumentsByUser(User user)
        {
            string query = "SELECT * FROM userdocument WHERE userID='"+user.id+"'";

            List<int> idList = new List<int>();

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                int id = (int)reader["documentID"];
                idList.Add(id);
            }

            reader.Close();
            CloseConnection();

            return idList;
        }

        /// <summary>
        /// Checks if a userdocument is already pressent in the database
        /// </summary>
        /// <param name="user">userdocument relation's user</param>
        /// <param name="doc">userdocument relation's document</param>
        /// <returns>a bool defing wether or not the userdocument already exists
        /// true = it does
        /// false = it does not</returns>
        public bool CheckForUserDocument(User user, Document doc)
        { 
            string query = "SELECT * FROM userdocument WHERE userID='"+user.id+"' AND documentID='"+doc.documentId+"'";

            List<int> counterList = new List<int>();

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                counterList.Add((int)reader["userID"]);
            }

            reader.Close();
            CloseConnection();

            if (counterList.Count > 0) return true;
            else return false;
        }
        
        /// <summary>
        /// Checks the permission of a userdocument relation between a given user and document
        /// </summary>
        /// <param name="user">userdocument relation's user</param>
        /// <param name="doc">userdocument relation's document</param>
        /// <returns>The permission of the userdocument relation</returns>
        public Permission.Permissions CheckPermission(User user, Document doc)
        {
            string query = "SELECT permission FROM userdocument WHERE userID='"+user.id+"' and documentID='"+doc.documentId+"'";

            string incPerm = "None";

            MySqlDataReader reader = ExecuteReader(query);            

            while (reader.Read())
            {
                incPerm = reader["permission"] + "";
            }

            reader.Close();
            CloseConnection();

            switch (incPerm)
            {
                case "None": return Permission.Permissions.None;
                case "View": return Permission.Permissions.View;
                case "Edit": return Permission.Permissions.Edit;
                case "Delete": return Permission.Permissions.Delete;
                default: return Permission.Permissions.None; Console.WriteLine("corrupt DB, check data"); break;
            }
        }

        /// <summary>
        /// Checks if there is an instance of a user in the database matching the input.
        /// </summary>
        /// <param name="username">users username</param>
        /// <param name="password">users password</param>
        /// <returns>a User instance, if null there is no user maching in the database, else returns the instance for confirmation</returns>
        public User AuthenticateUser(string username, string password)
        {
            User user = null;
            string query = "SELECT * FROM user WHERE username = '" + username + "' AND password = '" + password + "'";

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                int id = (int) reader[0];
                string name = (string) reader[1];
                string userName = (string) reader[2];
                string passWord = (string) reader[3];
                user = new User(id, name, userName, passWord);
            }

            //Console.WriteLine("READER " + reader[1] + " " + reader[2] + " " + reader[3]);
            reader.Close();
            CloseConnection();
            return user;
        }

        /// <summary>
        /// Executes an already existing query
        /// </summary>
        /// <param name="query">query to be executed</param>
        private void ExecuteQuery(string query)
        {
            if (connection.State != ConnectionState.Open) OpenConnection();
            if (connection.State != ConnectionState.Open) ErrorMessage("Cannot open connection to server");
            else
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        /// <summary>
        /// executes a reader and return it so a method can use it to read
        /// </summary>
        /// <param name="query">query to be executed</param>
        /// <returns>a MySqlDataReader instance</returns>
        private MySqlDataReader ExecuteReader(string query)
        {
            if (connection.State != ConnectionState.Open) OpenConnection();
            if (connection.State != ConnectionState.Open) ErrorMessage("Cannot open connection to server");
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //CloseConnection();
                    return reader;
                }
                catch (MySqlException e) { }
            }
            return null;
        }

        private void ErrorMessage(string error)
        {
            Console.WriteLine("Error: " + error);
        }
    }
}
