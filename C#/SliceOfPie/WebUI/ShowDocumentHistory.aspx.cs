using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SliceOfPie;

namespace WebUI
{
    public partial class ShowDocumentHistory : System.Web.UI.Page
    {
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();

        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = facade.GetUser(Request.QueryString["username"].ToString());

            string FullFilePath = "root/" + user.username + "/" + Request.QueryString["filename"];

            List<string> docHistory = facade.GetDocumentHistory(user, FullFilePath);

            string[] history;

            foreach (string s in docHistory)
            {
                history = s.Split(',');
                historyRow.Text += "<tr> <td>" + history[0] + "</td><td>" + history[1] + "</td><td>" + history[2] + "</td><td>" + history[3] + "</td></tr>";
            }
        }
    }
}