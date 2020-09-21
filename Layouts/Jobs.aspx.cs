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
    public partial class Jobs : System.Web.UI.Page
    {
        private static string conString = "Data Source=.;Initial Catalog=UOK;Integrated Security=True";
        private static SqlConnection con = new SqlConnection(conString);
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
                Response.Redirect("noSession.aspx");
            else
            {
                if (IsPostBack)
                {
                }
                else
                {
                    showJobs(0);
                 //   newsFeed.BackColor = System.Drawing.Color.Black;
                    newsFeed.Enabled = false;

                }
            }
        }

        protected void showJobs(int chk)
        {
            JobHead.Visible = true;
            string[,] jobs;
            int count;
            userId = Session["userId"].ToString();
            string query = "select count(*) from tbl_job";
            if(chk==1)
                query = "select count(*) from tbl_job where jobDescription like '%" + SearchBar.Text + "%' or jobTitle  like '%" + SearchBar.Text + "%' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0].ToString());
            con.Close();

            jobs = new string[count, 5];

            string query1 = "select *from tbl_job ";
            if (chk == 1)
                query1 = "select *from tbl_job where jobDescription like '%" + SearchBar.Text + "%' or jobTitle  like '%" + SearchBar.Text + "%'";

            con.Open();
            com = new SqlCommand(query1, con);
            dr = com.ExecuteReader();
            int i = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    jobs[i, 0] = dr["userID"].ToString();
                    jobs[i, 1] = dr["jobTitle"].ToString();
                    jobs[i, 2] = dr["jobDescription"].ToString();
                    jobs[i, 3] = dr["datee"].ToString();
                    jobs[i, 4] = dr["jobImage"].ToString();
                    i++;
                }
            }

            con.Close();
            i = 0;
            for (int j = count - 1; j >= 0; j--)
            {
                string query0 = "select * from userReg1 where userId='" + jobs[j, 0] + "'";
                con.Open();
                com = new SqlCommand(query0, con);
                dr = com.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    jobPanel.Controls.Add(new LiteralControl("<br/>"));
                    
                    Panel job = new Panel();
                    job.ID = "" + i;
                   // job.Style["border"] = "1px solid red";
                    job.Style["margin"] = "0 2vw 0 2vw";
                    Label id = new Label();
                    id.Visible = false;
                    id.Text = jobs[j, 0];
                    Table t = new Table();
                    t.ID = "t" + i + "_" + i;
                    TableRow row = new TableRow();
                    Label date = new Label();
                    date.Text = jobs[j, 3];
                    date.ForeColor = System.Drawing.Color.LightGray;
                    Label title = new Label();
                    title.Text = "<b>Job Title:</b>" + " " + jobs[j, 1];
                    title.Style["display"] = "block";
                    title.Style["width"] = "70vw";
                    title.ID = "title" + i + "_" + i;

                    Label des = new Label();
                    des.Text = "<b>Description:</b>" + " " + jobs[j, 2];
                    des.Style["display"] = "block";
                    des.Style["width"] = "70vw";
                    des.Style["margin-bottom"] = "1vw";
                    Image img = new Image();

                    img.ImageUrl = dr["picture"].ToString();
                    img.Style["border-radius"] = "50%";
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


                    TableCell cell1 = new TableCell();
                    cell1.Controls.Add(img);

                    TableCell cell2 = new TableCell();
                    cell2.Controls.Add(name);
                    cell2.Controls.Add(id);
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    t.Rows.Add(row);

                    job.Controls.Add(t);
                    job.Controls.Add(date);
                    job.Controls.Add(new LiteralControl("<br/>"));
                    job.Controls.Add(title);

                    job.Controls.Add(des);
                    //  job.Controls.Add(new LiteralControl("<br/>"));

                    if (jobs[j, 4] != "")
                    {


                        Image upload = new Image();
                        upload.ImageUrl = @"data:image/png;base64," + jobs[j, 4];
                        upload.Style["height"] = "75%";
                        upload.Style["width"] = "75%";
                        job.Controls.Add(upload);


                    }


                    jobPanel.Controls.Add(job);
                    jobPanel.Controls.Add(new LiteralControl("<br/>"));

                }
                    con.Close();

                }
            
        }
        protected void post_Click(object sender, EventArgs e)
        {
            jobimagerror.Visible = false;
            if (jobTitle.Text != "" && jobDes.InnerText != "")
            {
                userId = Session["userId"].ToString();
                string b64 = "";
                string query = "select * from userReg1 where userID='" + userId + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();

                Panel job = new Panel();
                job.Style["border"] = "1px solid red";
                job.Style["margin"] = "0 2vw 0 2vw";
                Image img = new Image();
                string base64 = dr["picture"].ToString();
                img.ImageUrl = base64;
                img.Style["border-radius"] = "50%";
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

                
                Label title = new Label();
                title.Text = "<b>Job Title:</b>" + " " + jobTitle.Text;
                title.Style["display"] = "block";
                title.Style["width"] = "70vw";

                job.Controls.Add(title);

                Label des = new Label();
                des.Text = "<b>Description:</b>" + " " + jobDes.InnerText;
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

                string query2 = "insert into tbl_Job (userID,jobTitle,jobImage,jobDescription,datee) values (@uid,@title,@pic,@des,@date) ";

                con.Open();
                com = new SqlCommand(query2, con);
                com.Parameters.AddWithValue("@uid", userId);
                com.Parameters.AddWithValue("@title", jobTitle.Text);
                com.Parameters.AddWithValue("@pic", b64);
                com.Parameters.AddWithValue("@des", jobDes.InnerText);
                com.Parameters.AddWithValue("@date", d);
                dr = com.ExecuteReader();
                dr.Read();
                con.Close();

                jobTitle.Text = "";
                jobDes.InnerText = "";

            }
            else
            {
                Response.Write("<script>alert('Please fill out all fields')</script");

            }
            showJobs(0);
            
        }

        protected void newsFeed_Click(object sender, EventArgs e)
        {
            showJobs(0);
            newsFeed.Enabled = false;


            jobPostDiv.Visible = true;


        }

        protected void myPost_Click(object sender, EventArgs e)
        {

            JobHead.Visible = false;
            jobPostDiv.Visible = false;
        //    newsFeed.BackColor = System.Drawing.Color.LightGray;
            newsFeed.Enabled = true;
            string[,] jobs;
            int count;
            userId = Session["userId"].ToString();
            string query = "select count(*) from tbl_job where userID='" + userId + "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            count = Convert.ToInt32(dr[0].ToString());
            con.Close();

            jobs = new string[count, 6];

            string query1 = "select * from tbl_job where userID='" + userId + "'";
            con.Open();
            com = new SqlCommand(query1, con);
            dr = com.ExecuteReader();
            int i = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    jobs[i, 0] = dr["userID"].ToString();
                    jobs[i, 1] = dr["jobTitle"].ToString();
                    jobs[i, 2] = dr["jobDescription"].ToString();
                    jobs[i, 3] = dr["datee"].ToString();
                    jobs[i, 4] = dr["jobImage"].ToString();
                    jobs[i, 5] = dr["jobID"].ToString();
                    i++;
                }
            }

            i = 0;
            con.Close();
            for (int j = count - 1; j >= 0; j--)
            {
                string query0 = "select * from userReg1 where userId='" + jobs[j, 0] + "'";
                con.Open();
                com = new SqlCommand(query0, con);
                dr = com.ExecuteReader();
                dr.Read();

                Panel job = new Panel();
                job.ID = i.ToString();
                job.Style["margin"] = "0 2vw 0 2vw";
                Label id = new Label();
                id.ID = "id" + i;
                id.Visible = false;
                id.Text = jobs[j, 5];
                Table t = new Table();
                t.ID = "t" + i;
                TableRow row = new TableRow();
                Label date = new Label();
                date.Text = jobs[j, 3];
                date.ForeColor = System.Drawing.Color.LightGray;
                Label title = new Label();
                title.Text = "<b>Job Title:</b>" + " " + jobs[j, 1];
                title.Style["display"] = "block";
                title.Style["width"] = "70vw";

                Label des = new Label();
                des.Text = "<b>Description:</b>" + " " + jobs[j, 2];
                des.Style["display"] = "block";
                des.Style["width"] = "70vw";
                des.Style["margin-bottom"] = "1vw";
                Image img = new Image();

                img.ImageUrl = dr["picture"].ToString();
                img.Style["border-radius"] = "50%";
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


                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);

                TableCell cell2 = new TableCell();
                cell2.Width = 250;
                cell2.Controls.Add(name);
                cell2.Controls.Add(id);

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                t.Rows.Add(row);

                job.Controls.Add(t);
                job.Controls.Add(date);
                job.Controls.Add(title);

                job.Controls.Add(des);
                //  job.Controls.Add(new LiteralControl("<br/>"));

                if (jobs[j, 4] != "")
                {


                    Image upload = new Image();
                    upload.ImageUrl = @"data:image/png;base64," + jobs[j, 4];
                    upload.Style["height"] = "75%";
                    upload.Style["width"] = "75%";

                    job.Controls.Add(upload);



                }


                jobPanel.Controls.Add(job);

                jobPanel.Controls.Add(new LiteralControl("<br/>"));

                con.Close();

            }




        }

        protected void searchJob_Click(object sender, EventArgs e)
        {
            if (jobPostDiv.Visible == false)
            {

                string[,] jobs;
                int count;
                userId = Session["userId"].ToString();

                string query = "select count(*) from tbl_job where userID='" + userId + "' and jobDescription like '%" + SearchBar.Text + "%' or jobTitle  like '%" + SearchBar.Text + "%'  ";
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                count = Convert.ToInt32(dr[0].ToString());
                con.Close();

                jobs = new string[count, 6];

                string query1 = "select * from tbl_job where userID='" + userId + "' and jobDescription like '%" + SearchBar.Text + "%' or jobTitle  like '%" + SearchBar.Text + "%' ";
                con.Open();
                com = new SqlCommand(query1, con);
                dr = com.ExecuteReader();
                int i = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        jobs[i, 1] = dr["jobTitle"].ToString();
                        jobs[i, 2] = dr["jobDescription"].ToString();
                        jobs[i, 3] = dr["datee"].ToString();
                        jobs[i, 4] = dr["jobImage"].ToString();
                        jobs[i, 5] = dr["jobID"].ToString();
                        i++;
                    }
                }

                i = 0;
                con.Close();
                for (int j = count - 1; j >= 0; j--)
                {
                    string query0 = "select * from userReg1 where userId='" + userId + "'";
                    con.Open();
                    com = new SqlCommand(query0, con);
                    dr = com.ExecuteReader();
                    dr.Read();

                    Panel job = new Panel();
                    job.ID = i.ToString();
                    job.Style["margin"] = "0 2vw 0 2vw";
                    Label id = new Label();
                    id.ID = "id" + i;
                    id.Visible = false;
                    id.Text = jobs[j, 5];
                    Table t = new Table();
                    t.ID = "t" + i;
                    TableRow row = new TableRow();
                    Label date = new Label();
                    date.Text = jobs[j, 3];
                    date.ForeColor = System.Drawing.Color.LightGray;
                    Label title = new Label();
                    title.Text = "<b>Job Title:</b>" + " " + jobs[j, 1];
                    title.Style["display"] = "block";
                    title.Style["width"] = "70vw";

                    Label des = new Label();
                    des.Text = "<b>Description:</b>" + " " + jobs[j, 2];
                    des.Style["display"] = "block";
                    des.Style["width"] = "70vw";
                    des.Style["margin-bottom"] = "1vw";
                    Image img = new Image();

                    img.ImageUrl = dr["picture"].ToString();
                    img.Style["border-radius"] = "50%";
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


                    TableCell cell1 = new TableCell();
                    cell1.Controls.Add(img);

                    TableCell cell2 = new TableCell();
                    cell2.Width = 250;
                    cell2.Controls.Add(name);
                    cell2.Controls.Add(id);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);

                    t.Rows.Add(row);

                    job.Controls.Add(t);
                    job.Controls.Add(date);
                    job.Controls.Add(title);

                    job.Controls.Add(des);
                    //  job.Controls.Add(new LiteralControl("<br/>"));

                    if (jobs[j, 4] != "")
                    {


                        Image upload = new Image();
                        upload.ImageUrl = @"data:image/png;base64," + jobs[j, 4];
                        upload.Style["height"] = "75%";
                        upload.Style["width"] = "75%";

                        job.Controls.Add(upload);



                    }


                    jobPanel.Controls.Add(job);

                    jobPanel.Controls.Add(new LiteralControl("<br/>"));

                    con.Close();

                }

            }
            else {

                showJobs(1);
            }
        }


        protected void del_Click(object sender, EventArgs e)
        {
            string value = ((Button)sender).ID;
            string[] id;
            id = value.Split('_');

            Panel t = (Panel)jobPanel.FindControl(id[1]);
            Table table = (Table)t.FindControl("t" + id[1]);
            Label l = (Label)table.Rows[0].Cells[1].FindControl("id" + id[1]);

            string query = "delete * from tbl_Job where jobID='" + l.Text + "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            con.Close();

            showJobs(0);

        }
    }
}