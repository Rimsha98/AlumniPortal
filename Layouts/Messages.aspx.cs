using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using FypWeb.Class;

namespace FypWeb
{
    public partial class Messages : System.Web.UI.Page
    {
         private static string conString = Utilities1.GetConnectionString();

        private static SqlConnection con = new SqlConnection(conString);
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["adminId"] = 34;
            if (Session["userId"] == null)
                Response.Redirect("noSession.aspx");
            else
            {
                userId = Session["userId"].ToString();
              //  Response.AppendHeader("Refresh", "60");
                msg.Focus();



                if (SearchInput.Text == "")
                {
                    if (SearchInput.Text == "")
                    {
                        int i = 0;

                        string query = "select * from userReg1 where userId!='" + Session["adminId"].ToString() + "' and userId!='"+userId+"' ";
                        con.Open();
                        SqlCommand com = new SqlCommand(query, con);
                        SqlDataReader dr = com.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (IsPostBack)
                                { }
                                else
                                {
                                    if (i == 0)
                                        Session["otherUser"] = dr["userId"].ToString();
                                }

                                ImageButton img = new ImageButton();
                                img.ID = "img" + i + "_" + i;
                                img.Style["border-radius"] = "50%";
                                img.Click += new ImageClickEventHandler(imgClick);
                                string base64 = dr["picture"].ToString();
                                if (base64 == null)
                                    img.ImageUrl = "~/images/UserIcoGreen.png";
                                else
                                    img.ImageUrl = base64;
                                img.Attributes.Add("class", "UserListImage");

                                LinkButton name = new LinkButton();
                                name.Click += new EventHandler(nameClick);
                                name.ID = "n" + i + "_" + i;
                                name.Text = dr["name"].ToString();
                                name.Attributes.Add("class", "UserListLinks");

                                Label id = new Label();
                                id.Visible = false;
                                id.Text = dr["userId"].ToString();
                                id.ID = "id" + i + "_" + i;


                                Table t = new Table();
                                t.ID = "t" + i + "_" + i;
                                TableRow row = new TableRow();

                                TableCell cell1 = new TableCell();
                                cell1.Controls.Add(img);

                                TableCell cell2 = new TableCell();
                                cell2.Controls.Add(name);
                                cell2.Controls.Add(id);
                                row.Cells.Add(cell1);
                                row.Cells.Add(cell2);
                                t.Rows.Add(row);

                                Panel main = new Panel();
                                main.Controls.Add(t);

                                main.ID = "p" + i + "_" + i;

                                users.Controls.Add(main);



                                if (dr["userId"].ToString()==Session["otherUser"].ToString())
                                {
                                    recImage.Attributes.Add("class", "UserListImage");
                                    recImage.ImageUrl = img.ImageUrl;
                                    recImage.Style["border-radius"] = "50%";
                                    recName.Attributes.Add("class", "UserListLinks");
                                    recName.Text = name.Text; ;
                                    recId.Text = id.Text;


                                }
                                i++;
                            }

                            con.Close();
                        }
                        else
                        {

                            Label l = new Label();
                            l.Text = "no users yet";
                            users.Controls.Add(l);
                        }
                        con.Close();


                        showMessage(userId, recId.Text);
                    }
                }
                else { 
                search_click(sender,e);
                }
            }
        }

        protected void showMessage(string userId, string recId)
        {

            msgPanel.Controls.Clear();
            con.Close();
            string query2 = "select * from tbl_MSG where userID='" + userId + "' and recID='" + recId + "' or userID='" + recId + "' and recID='" + userId + " '";
            con.Open();
            SqlCommand com = new SqlCommand(query2, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label msg1 = new Label();
                    
                    msg1.Text = "<b>" + dr["message"].ToString() + "</b>" + "<br/>" + dr["datee"].ToString();
                    msg1.Style["display"] = "block";
                    msg1.Style["width"] = "98%";
                    msg1.Style["font-family"] = "Lucida Sans Unicode";
                    msg1.Style["font-size"] = "1vw";
                    msg1.Style["margin"] = "0.5vw";
                    msg1.Style["margin-bottom"] = "1vw";
                    msg1.Style["overflow-x"] = "none";
                    if (dr["recID"].ToString().Equals(userId))
                    {

                        msg1.Style["color"] = "#313131";
                        msg1.Style["text-align"] = "left";

                    }
                    else
                    {
                        msg1.Style["color"] = "#313131";
                        msg1.Style["text-align"] = "right";
                    }

                    msgPanel.Controls.Add(msg1);
                }
            }



            else
            {
                Label none = new Label();
                none.Style["margin-left"] = "0.5vw";
                none.Text = "no conversation yet";
                msgPanel.Controls.Add(none);

            }
            con.Close();
        }


        protected void nameClick(object sender, EventArgs e)
        {
            userId = Session["userId"].ToString();
            string value = ((LinkButton)sender).ID;
            string[] ids = value.Split('_');
            int id = Convert.ToInt32(ids[1]);

            Panel p = (Panel)users.FindControl("p" + id + "_" + id);

            Table t = (Table)p.FindControl("t" + id + "_" + id);
            Label l = (Label)t.Rows[0].Cells[1].FindControl("id" + id + "_" + id);

            string query = "select * from userReg1 where userId='" + Convert.ToInt32(l.Text) + "' and userId !='" + Session["adminId"].ToString() + "' and userId!='" + userId + "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            recName.Text = dr["name"].ToString();
            string base64 = dr["picture"].ToString();
            if (base64 == null)
                recImage.ImageUrl = "~/images/UserIcoGreen.png";
            else
                recImage.ImageUrl = base64;
            recId.Text = (l.Text);
            Session["otherUser"] = l.Text;


            con.Close();
          
            showMessage(userId, l.Text);


        }



        protected void imgClick(object sender, EventArgs e)
        {
            userId = Session["userId"].ToString();
            string value = ((ImageButton)sender).ID;
            string[] ids = value.Split('_');
            int id = Convert.ToInt32(ids[1]);

            Panel p = (Panel)users.FindControl("p" + id + "_" + id);
            Table t = (Table)p.FindControl("t" + id + "_" + id);
            Label l = (Label)t.Rows[0].Cells[1].FindControl("id" + id + "_" + id);

            string query = "select * from userReg1 where userId='" + Convert.ToInt32(l.Text) + "' and userId!='" + Session["adminId"].ToString() + "' and userId!='" + userId + "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            recName.Text = dr["name"].ToString();
            string base64 = dr["picture"].ToString();
            if (base64 == null)
                recImage.ImageUrl = "~/images/UserIcoGreen.png";
            else
                recImage.ImageUrl =base64;
            recId.Text = l.Text;
            Session["otherUser"] = l.Text;


            con.Close();
           
            showMessage(userId, l.Text);
        }

        protected void send_Click(object sender, EventArgs e)
        {
            userId = Session["userId"].ToString();
            string date = DateTime.Now.ToString();
            string query2 = "insert into tbl_MSG (userID,recID,message,datee) values (@uid,@rid,@msg,@date) ";
            con.Open();
            SqlCommand com = new SqlCommand(query2, con);
            com.Parameters.AddWithValue("@uid", userId);
            com.Parameters.AddWithValue("@rid", Session["otherUser"].ToString());
            com.Parameters.AddWithValue("@msg", msg.InnerText);
            com.Parameters.AddWithValue("@date", date);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            con.Close();
            showMessage(userId, Session["otherUser"].ToString());
            msg.InnerText = "";

        }

        protected void search_click(object sender, EventArgs e)
        {
            users.Controls.Clear();
            userId = Session["userId"].ToString();
            int i=0;
            string query = "select * from userReg1 where name like '%" + SearchInput.Text + "%' and userId!='" + Session["adminId"].ToString() + "' and userId!='" + userId + "'";
               con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if( i==0)
                            Session["otherUser"] = dr["userId"].ToString();
                        ImageButton img = new ImageButton();
                        img.ID = "img" + i + "_" + i;
                        img.Click += new ImageClickEventHandler(imgClick);
                        string base64 = dr["picture"].ToString();
                        if (base64 == null)
                            img.ImageUrl = "~/images/UserIcoGreen.png";
                        else
                            img.ImageUrl = base64;
                        img.Attributes.Add("class", "UserListImage");

                        LinkButton name = new LinkButton();
                        name.Click += new EventHandler(nameClick);
                        name.ID = "n" + i + "_" + i;
                        name.Text = dr["name"].ToString();
                        name.Attributes.Add("class", "UserListLinks");

                        Label id = new Label();
                        id.Visible = false;
                        id.Text = dr["userId"].ToString();
                        id.ID = "id" + i + "_" + i;


                        Table t = new Table();
                        t.ID = "t" + i + "_" + i;
                        TableRow row = new TableRow();

                        TableCell cell1 = new TableCell();
                        cell1.Controls.Add(img);

                        TableCell cell2 = new TableCell();
                        cell2.Controls.Add(name);
                        cell2.Controls.Add(id);
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        t.Rows.Add(row);

                        Panel main = new Panel();
                        main.Controls.Add(t);

                        main.ID = "p" + i + "_" + i;

                        users.Controls.Add(main);

                        if (i == 0)
                        {
                              recImage.Attributes.Add("class", "UserListImage");
                                recImage.ImageUrl = img.ImageUrl;
                                recName.Attributes.Add("class", "UserListLinks");
                                recName.Text = name.Text; ;
                                recId.Text = id.Text;


                          
                        }
                        i++;
                    }
                    
                    }
                else
                {

                    Label l = new Label();
                    l.Text = "no users yet";
          
                    users.Controls.Add(l);

                }
                showMessage(userId, recId.Text);
                    con.Close();
        }


        protected void viewProf_Click(object sender, EventArgs e)
        {
           // Session["otherUser"] = recId.Text;
            Response.Redirect("UserProfile.aspx");

        }
    }
}