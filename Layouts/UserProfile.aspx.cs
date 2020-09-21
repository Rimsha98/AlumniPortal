using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Drawing;
using FypWeb.Class;

namespace FypWeb{
    public partial class UserProfile : System.Web.UI.Page{
        private static string conString = Utilities1.GetConnectionString();
        private static SqlConnection con = new SqlConnection(conString);
        string userId;

        protected override void OnInit(EventArgs e){
            base.OnInit(e);
            if (Session["userId"] == null)
                Response.Redirect("noSession.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["otherUser"] == null)
                userId = Session["userId"].ToString();
            else
                userId = Session["otherUser"].ToString();

            string enr = "";
            string query1 = "select * from userReg1 where userId='" + userId + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query1, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                fullname.InnerText = "@" + dr["username"].ToString();
                if (dr["profession"].ToString() == "" || dr["profession"].ToString() == null)
                {
                    prof.Visible = false;
                }
                else
                {
                    prof.Visible = true;
                    prof.InnerText = dr["profession"].ToString(); //get profession from db and send here.
                }
                string path = dr["picture"].ToString();

                ProfilePic.ImageUrl = path;
                name.InnerText = dr["name"].ToString();
                fname.InnerText = dr["fatherName"].ToString();
                if (dr["city"].ToString() != null || dr["city"].ToString() != "")
                    city.InnerText = dr["city"].ToString();

                if (dr["country"].ToString() != null || dr["country"].ToString() != "")
                    country.InnerText = dr["country"].ToString();
                enr = dr["tblEnrId"].ToString();

            }
            con.Close();

            query1 = "select * from studentRecord where tblEnrId='" + enr + "' ";
            con.Open();
            com = new SqlCommand(query1, con);
            dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                depart.InnerText = dr["department"].ToString();
                deg.InnerText = dr["class"].ToString();
            }
            con.Close();
        }
    }
}