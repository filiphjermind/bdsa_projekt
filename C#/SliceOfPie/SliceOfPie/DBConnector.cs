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

        private void Initialize()
        {
            connectionString = "SERVER=mysql.itu.dk;DATABASE=PieServer;UID=pieserver;PASSWORD=bdsapie;";
            connection = new MySqlConnection(connectionString);
            
        }

        //opens connection to the database
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

        //Close connection
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

        public void DeleteDocumentByPath(User user, string path)
        {
            string query = "DELETE * FROM document WHERE owner = '"+user.username+"' AND file = '"+path+"'";
            ExecuteQuery(query);

        }

        public void UpdateDocumentByID(int id, string newOwner, string newFile)
        {
            string query = "UPDATE document SET owner='"+newOwner+"', file='"+newFile+"' WHERE id="+id+"";
            ExecuteQuery(query);
        }

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

        public void InsertUserDocument(User user, Document doc, Permission.Permissions permission)
        {
            string query = "INSERT INTO userdocument (userID, documentID, permission) VALUES('" + user.id + "', '" + doc.documentId + "', '" + permission.ToString() +"')";
            ExecuteQuery(query);
        }


        public Permission.Permissions CheckPermission(User user, Document doc)
        {
            string query = "SELECT permission FROM userdocument WHERE userID='"+user.id+"' and documentID='"+doc.documentId+"'";

            string incPerm = "None";

            MySqlDataReader reader = ExecuteReader(query);            

            while (reader.Read())
            {
                incPerm = reader["permission"] + "";
            }

            switch (incPerm)
            {
                case "None": return Permission.Permissions.None;
                case "View": return Permission.Permissions.View;
                case "Edit": return Permission.Permissions.Edit;
                case "Delete": return Permission.Permissions.Delete;
                default: return Permission.Permissions.None; Console.WriteLine("corrupt DB, check data"); break;
            }
            CloseConnection();
        }

        public User AuthenticateUser(string username, string password)
        {
            User user = null;
            string query = "SELECT * FROM user WHERE username = '" + username + "' AND password = '" + password + "'";

            MySqlDataReader reader = ExecuteReader(query);

            while (reader.Read())
            {
                //int id = (int) reader[1];
                string name = (string) reader[1];
                string userName = (string) reader[2];
                string passWord = (string) reader[3];
                user = new User(name, userName, passWord);
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
