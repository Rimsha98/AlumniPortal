using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using FypWeb.Class;

namespace FypWeb
{
    public partial class setting : System.Web.UI.Page
    {
        private static string conString = Utilities1.GetConnectionString();

        private static SqlConnection con = new SqlConnection(conString);
        int temp = 34;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["adminId"] = 34;
            pass.Focus();

            string query1 = "select * from userReg1 where userId='" + temp + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query1, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                adminName.InnerText = "Logged in as: " + dr["username"].ToString();
            }
            con.Close();

        }

        protected void chk_Click(object sender, EventArgs e)
        {
            passworderror.Visible = false;
            string query1 = "select * from userReg1 where userId='" + Session["adminId"].ToString() + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query1, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
             if (dr["password"].ToString().Equals(pass.Text))
                {
                    pwdDiv.Visible = false;
                    settingDiv.Visible = true;
                }
                else
                {
                    if (settingDiv.Visible == false)
                        passworderror.Visible = true;

                }


          

            con.Close();
        }

        protected void updatePwd_Click(object sender, EventArgs e)
        {
            passerror.Visible = false;
            passchanged.Visible = false;
            if (newPwd.Text.Equals(newPwd1.Text))
            {
                string query1 = "UPDATE UserReg1 SET password='" + newPwd.Text + "' WHERE userId='" + Session["adminId"].ToString() + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                con.Close();
                passchanged.Visible = true;
            }
            else
            {
                passerror.Visible = true;
            }
        }

        protected void updatePic_Click(object sender, EventArgs e)
        {
            picsaved.Visible = false;
            fileempty.Visible = false;
            filewrong.Visible = false;
             string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

            fileExtension = fileExtension.ToLower();
            if (FileUpload1.HasFile)
            {

                if (fileExtension != ".png" && fileExtension != ".jpg" && fileExtension != ".tiff")
                {

                    filewrong.Visible = true;

                }

                else
                {

                    string query = "select picture,email from userReg1 where userId='" + Session["adminId"].ToString() + "'";
                    con.Open();
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    string path = dr["picture"].ToString();
                    string email = dr["email"].ToString();
                    con.Close();

                    path = "~/userImage/" + email + "_" + FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath(path));
                    string query1 = "Update UserReg1 set picture='" + path + "' where userId='" + Session["adminId"].ToString() + "' ";
                    con.Open();
                    com = new SqlCommand(query1, con);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();
                    picsaved.Visible = true;


                }
            }
            else {
                fileempty.Visible = true;
            }
        }

        protected void newsPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("news.aspx");
        }

        protected void accSetting_Click(object sender, EventArgs e)
        {
            Response.Redirect("setting.aspx");
        }

        protected void back1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPortal.aspx");
        }

        protected void adminLogout_Click(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["admin"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}