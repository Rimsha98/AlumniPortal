using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FypWeb{
    public partial class NavBar : System.Web.UI.Page{

        protected void Page_Load(object sender, EventArgs e){

        }

        protected void Logout(object sender, EventArgs e){
            Session["userID"] = null;
            Session["otherUser"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Messages(object sender, EventArgs e){
            Response.Redirect("Messages.aspx");
        }

        protected void Settings(object sender, EventArgs e){
            Response.Redirect("accountSetting.aspx");
        }

        protected void ViewCV(object sender, EventArgs e){
            Response.Redirect("GenerateCV.aspx");
        }

        protected void ProfilePage(object sender, EventArgs e){
            Session["otherUser"] = Session["userId"].ToString();
            Response.Redirect("UserProfile.aspx");
        }

        protected void EditCV(object sender, EventArgs e){
            Response.Redirect("UpdateCV.aspx");
        }

        protected void Jobs(object sender, EventArgs e)
        {
            Response.Redirect("Jobs.aspx");
        }

        protected void Newsfeed(object sender, EventArgs e)
        {
            Response.Redirect("NewsFeed.aspx");
        }

        
    }
}