using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;


namespace FypWeb
{
    public partial class NewsFeed : System.Web.UI.Page
    {
        private static string conString = "Data Source=.;Initial Catalog=UOK;Integrated Security=True";
        private static SqlConnection con = new SqlConnection(conString);
        string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["adminId"] = 34;
            if (Session["userId"] == null)
                Response.Redirect("noSession.aspx");
            else
            {
                if (IsPostBack)
                {
                }
                else

                    showNews();
            }
        }

        protected void showNews()
        {
            JobHead.Visible = true;


            string[,] jobs;
            int count;
            string query = "select count(*) from tbl_News ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0].ToString());
            con.Close();

            jobs = new string[count, 4];

            string query1 = "select * from tbl_News ";

            con.Open();
            com = new SqlCommand(query1, con);
            dr = com.ExecuteReader();
            int i = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    jobs[i, 0] = dr["newsDescription"].ToString();
                    jobs[i, 1] = dr["datee"].ToString();
                    jobs[i, 2] = dr["newsImage"].ToString();
                    i++;
                }
            }

            con.Close();
            i = 0;

            for (int j = count - 1; j >= 0; j--)
            {
                string query0 = "select * from userReg1 where userId='" + Session["adminId"].ToString() + "'";
                con.Open();
                com = new SqlCommand(query0, con);
                dr = com.ExecuteReader();
                dr.Read();

                Panel job = new Panel();
                job.ID = "" + i;
                job.Style["margin"] = "0 2vw 0 2vw";
                Table t = new Table();
                t.ID = "t" + i + "_" + i;
                TableRow row = new TableRow();
                Label date = new Label();
                date.Text = jobs[j, 1];
                date.ForeColor = System.Drawing.Color.LightGray;

                Label des = new Label();
                des.Text = jobs[j, 0];
                des.Style["display"] = "block";
                des.Style["width"] = "70vw";
                des.Style["margin-bottom"] = "1vw";

                Image img = new Image();
                img.Style["border-radius"] = "50%";
                img.ImageUrl = "~/images/adminProfilePic.png";
                img.Height = 30;
                img.Width = 30;

                Label name = new Label();
                name.Style.Add("color", "black");
                name.Text = dr["name"].ToString();
                name.Font.Bold = true;
                name.Font.Size = 14;
                name.Font.Underline = true;


                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);

                TableCell cell2 = new TableCell();
                cell2.Controls.Add(name);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                t.Rows.Add(row);

                job.Controls.Add(t);
                job.Controls.Add(date);

                job.Controls.Add(new LiteralControl("<br/>"));

                job.Controls.Add(des);
                //  job.Controls.Add(new LiteralControl("<br/>"));

                if (jobs[j, 2] != "")
                {


                    Image upload = new Image();
                    upload.ImageUrl = @"data:image/png;base64," + jobs[j, 2];
                    upload.Style["height"] = "75%";
                    upload.Style["width"] = "75%";

                    job.Controls.Add(upload);



                }


                newsPanel.Controls.Add(job);

                newsPanel.Controls.Add(new LiteralControl("<br/>"));
                con.Close();

            }
        }


        protected void searchNews_Click(object sender, EventArgs e)
        {
            // string query = "select * from userReg1 where name like '%" + SearchInput.Text + "%' and userId!='" + Session["adminId"].ToString() + "'";

            string[,] jobs;
            int count;
            string query = "select count(*) from tbl_News  where newsDescription like '%" + SearchBar.Text + "%' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0].ToString());
            con.Close();

            jobs = new string[count, 4];

            string query1 = "select * from tbl_News  where newsDescription like '%" + SearchBar.Text + "%'  ";

            con.Open();
            com = new SqlCommand(query1, con);
            dr = com.ExecuteReader();
            int i = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    jobs[i, 0] = dr["newsDescription"].ToString();
                    jobs[i, 1] = dr["datee"].ToString();
                    jobs[i, 2] = dr["newsImage"].ToString();
                    i++;
                }
            }

            con.Close();
            i = 0;

            for (int j = count - 1; j >= 0; j--)
            {
                string query0 = "select * from userReg1 where userId='" + Session["adminId"].ToString() + "'";
                con.Open();
                com = new SqlCommand(query0, con);
                dr = com.ExecuteReader();
                dr.Read();

                Panel job = new Panel();
                job.ID = "" + i;
                job.Style["margin"] = "0 2vw 0 2vw";
                Table t = new Table();
                t.ID = "t" + i + "_" + i;
                TableRow row = new TableRow();
                Label date = new Label();
                date.Text = jobs[j, 1];
                date.ForeColor = System.Drawing.Color.LightGray;

                Label des = new Label();
                des.Text = jobs[j, 0];
                des.Style["display"] = "block";
                des.Style["width"] = "70vw";
                des.Style["margin-bottom"] = "1vw";

                Image img = new Image();
                img.Style["border-radius"] = "50%";
                img.ImageUrl = "~/images/adminProfilePic.png";
                img.Height = 30;
                img.Width = 30;

                Label name = new Label();
                name.Style.Add("color", "black");
                name.Text = dr["name"].ToString();
                name.Font.Bold = true;
                name.Font.Size = 14;
                name.Font.Underline = true;


                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);

                TableCell cell2 = new TableCell();
                cell2.Controls.Add(name);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                t.Rows.Add(row);

                job.Controls.Add(t);
                job.Controls.Add(date);

                job.Controls.Add(new LiteralControl("<br/>"));

                job.Controls.Add(des);
                //  job.Controls.Add(new LiteralControl("<br/>"));

                if (jobs[j, 2] != "")
                {


                    Image upload = new Image();
                    upload.ImageUrl = @"data:image/png;base64," + jobs[j, 2];
                    upload.Style["height"] = "75%";
                    upload.Style["width"] = "75%";

                    job.Controls.Add(upload);



                }


                newsPanel.Controls.Add(job);

                newsPanel.Controls.Add(new LiteralControl("<br/>"));
                con.Close();

            }
        }
    }
    }