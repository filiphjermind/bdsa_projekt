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
    public partial class ShowDocument : System.Web.UI.Page
    {
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = facade.GetUser(Request.QueryString["username"].ToString());

            string FullFilePath = "root/" + user.username + "/" + Request.QueryString["filename"];

            //Response.Write("USER: " + user.username + " FILENAME: " + Request.QueryString["filename"]);

            //Request.QueryString["param1"].ToString();
            //string FullFilePath = facade.GetDocumentByPath(user, Request.QueryString["filename"]).path;

            FileInfo file = new FileInfo(FullFilePath);
            if (file.Exists)
            {
                Response.ContentType = "text/html"; //"application/vnd.ms-word";
                Response.AddHeader("Content-Disposition", "inline; filename=\"" + file.Name + "\"");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.TransmitFile(file.FullName);
            }
        }
    }
}