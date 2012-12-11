using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SliceOfPie;

namespace WebUI
{
    public partial class SaveDocumentConfirmation : System.Web.UI.Page
    {
        ClientSystemFacade facade = ClientSystemFacade.GetInstance();
        
        Engine engine = new Engine();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = engine.userhandler.GetUser("MrT", "1234");
        }

        protected void SaveNewDocument(object sender, EventArgs e)
        {
            //Document currentDoc = new Document(user);
            //currentDoc.content = 
            //facade.SaveDocument(user, currentDoc, sdfsdf);
        }
    }
}