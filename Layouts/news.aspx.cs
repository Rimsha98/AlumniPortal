using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FypWeb.Class;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace FypWeb
{
    public partial class news : System.Web.UI.Page
    {
        private static string conString = Utilities1.GetConnectionString();

        private static SqlConnection con = new SqlConnection(conString);
        string userId;
        int temp = 34;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["adminId"] = 34;

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


            if (Session["adminId"] == null)
                Response.Redirect("noSession.aspx");
            else
            {
                if (IsPostBack)
                {
                }
                else
                {
                    showJobs();

                }
            }
        }

        protected void showJobs()
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
                if (dr["picture"].ToString() == "")
                    img.ImageUrl = "~/images/adminProfilePic.png";
                else
                    img.ImageUrl = dr["picture"].ToString();
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
        protected void postNews_Click(object sender, EventArgs e)
        {
            jobimagerror.Visible = false;
            if (newsDes.InnerText != "")
            {
                string b64 = "";
                string query = "select * from userReg1 where userID='" + Session["adminId"].ToString() + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();

                Panel job = new Panel();
                job.Style["border"] = "1px solid red";
                job.Style["margin"] = "0 2vw 0 2vw";
                Image img = new Image();
                img.Style["border-radius"] = "50%";
                if (dr["picture"].ToString() == "")
                    img.ImageUrl = "~/images/UserIcoGreen.png";
                else
                    img.ImageUrl = dr["picture"].ToString();
                img.Height = 30;
                img.Width = 30;


                Label name = new Label();
                // name.Click += new EventHandler(nameClick);
                // name.ID = "n" + i + "_" + i;
                name.Style.Add("color", "black");
                name.Text = dr["name"].ToString();
                name.Font.Bold = true;
                name.Font.Size = 14;
                name.Font.Underline = true;

                Label id = new Label();
                id.Visible = false;
                id.Text = dr["userId"].ToString();




                Table t = new Table();
                //   t.ID = "t" + i + "_" + i;
                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);

                TableCell cell2 = new TableCell();
                cell2.Controls.Add(name);
                cell2.Controls.Add(id);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                t.Rows.Add(row);

                job.Controls.Add(t);

                Label date = new Label();
                string d = DateTime.Now.ToString();
                date.Text = d;
                date.ForeColor = System.Drawing.Color.LightGray;
                job.Controls.Add(date);

                job.Controls.Add(new LiteralControl("<br/>"));
                job.Controls.Add(new LiteralControl("<br/>"));

                Label des = new Label();
                des.Text = newsDes.InnerText;
                des.Style["display"] = "block";
                des.Style["width"] = "70vw";
                des.Style["margin-bottom"] = "1vw";

                job.Controls.Add(des);
                //  job.Controls.Add(new LiteralControl("<br/>"));



                if (FileUpload1.HasFile)
                {

                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    fileExtension = fileExtension.ToLower();

                    if (fileExtension != ".png" && fileExtension != ".jpg" && fileExtension != ".tiff")
                        jobimagerror.Visible = true;


                    else
                    {

                        jobimagerror.Visible = false;
                        HttpPostedFile postedfile = FileUpload1.PostedFile;
                        string fileName = Path.GetFileName(postedfile.FileName);
                        Stream stream = postedfile.InputStream;
                        BinaryReader br = new BinaryReader(stream);
                        byte[] image = br.ReadBytes((int)stream.Length);

                        b64 = Convert.ToBase64String(image);
                        Image upload = new Image();
                        upload.ImageUrl = @"data:image/png;base64," + b64;
                        upload.Style["height"] = "75%";
                        upload.Style["width"] = "75%";
                        upload.Style["margin-left"] = "auto";
                        upload.Style["margin-right"] = "auto";

                        job.Controls.Add(upload);

                        //    jobPanel.Controls.Add(job);


                    }
                }


                con.Close();

                string query2 = "insert into tbl_News (newsImage,newsDescription,datee) values ('" + b64 + "', @des,'" + d + "') ";

                con.Open();
                com = new SqlCommand(query2, con);
                com.Parameters.AddWithValue("@des" ,newsDes.InnerText.ToString());
                dr = com.ExecuteReader();
                dr.Read();
                con.Close();


            }
            else
            {
                Response.Write("<script>alert('Please fill out * fields')</script");

            }
            showJobs();
            newsDes.InnerText = "";
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