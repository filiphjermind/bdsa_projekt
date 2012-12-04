using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace SliceOfPie
{


    class DBConnector
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

            //InsertDocument("carlos", "Left there");
            //DeleteDocumentByUserName("carl");
            //DeleteDocumentByID(2);
            //UpdateDocumentByID(1,"carlos","right over there");
            //SelectDocumentsFromUser("carlos");
            //print(SelectDocumentsFromUser("carlos"));

            //InsertUser("God", "Almighty", "Blowback");
            //DeleteUserByUsername("K-Master");
            //UpdateUserByUsername("Karl", "Dante", "Henry", "password");
            //SelectUser("Henry", "password");
            SelectAllUsers();

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

        public void UpdateDocumentByID(int id, string newOwner, string newFile)
        {
            string query = "UPDATE document SET owner='"+newOwner+"', file='"+newFile+"' WHERE id="+id+"";
            ExecuteQuery(query);
        }

        public List<Document> SelectDocumentsFromUser(string username)
        { 
            List<Document> documentList = new List<Document>();
            List<int> idList = new List<int>();
            List<string> ownerList = new List<string>();
            List<string> titleList = new List<string>();
            List<string> fileList = new List<string>();

            string query = "SELECT * FROM document WHERE owner='"+username+"'";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                idList.Add((int)reader["id"]);
                ownerList.Add(reader["owner"] + "");
                fileList.Add(reader["file"] + "");
            }
            reader.Close();

            for (int i = 0; i < idList.Count; i++)
            {
                documentList.Add(OpenDocument(idList[i], ownerList[i], fileList[i]));
            }

                return documentList;
        }

        public Document OpenDocument(int id, string owner, string file)
        { 
            return new Document(owner, id, file);
            
        }

        public void print(List<Document> smukt)
        {
            foreach (Document d in smukt) Console.WriteLine(d.documentId);
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

        public string[] SelectUser(string usernameInput, string passwordInput)
        { 
            string[] userAssembly = new string[4];

            string query = "SELECT * FROM user WHERE username='"+usernameInput+"' and password='"+passwordInput+"'";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

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
            return userAssembly;
        }

        public List<string> SelectAllUsers()
        {
            List<string> userList = new List<string>();

            string query = "SELECT username FROM user";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                userList.Add(reader["username"] + "");
            }
            reader.Close();
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

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                path = reader["file"] + "";
            }
            reader.Close();
            return path;
        }

        public bool CheckPermission(User user, Document doc)
        {
            return false;
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

        private void ErrorMessage(string error)
        {
            Console.WriteLine("Error: " + error);
        }
    }
}
