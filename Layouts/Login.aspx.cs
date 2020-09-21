using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.Net.Mail;
using System.IO;
using FypWeb.Class;

namespace FypWeb
{
    public partial class Login : System.Web.UI.Page
    {

        private static string conString = Utilities1.GetConnectionString();
        private static SqlConnection con1 = new SqlConnection(conString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                Response.Redirect("UserProfile.aspx");
            }
            else
                uname.Focus();
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            con1.Close();
           
            string query = "select * from userReg1 where email='" + uname.Text + "' and password='" + pwd.Text + "'";
            con1.Open();
            SqlCommand com = new SqlCommand(query, con1);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["userId"] = dr["userId"].ToString();
                if (Convert.ToInt32(dr["userId"].ToString()) == 34)
                {
                    Session["userId"] = null;
                    Session["admin"] = "admin";
                    Response.Redirect("adminPortal.aspx");
                   
                }
                else
                    Response.Redirect("UserProfile.aspx");
                con1.Close();
            }
            else
            {
                ErrorMsg.Visible = true;
            }
            con1.Close();
        }


    }
}