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

namespace FypWeb{
    public partial class ForgotPassword : System.Web.UI.Page{
        private static string conString = Utilities1.GetConnectionString();
        private static SqlConnection con = new SqlConnection(conString);
        private static Random r = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fpNext1_Click(object sender, EventArgs e)
        {
            notconnected.Visible = false;
            P2.Visible = false;
            string query = "select * from UserReg1 where email='" + email.Text + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    div1.Visible = false;
                    div2.Visible = true;
                    sendEmail(dr["name"].ToString());
                    ViewState["fpid"] = dr["userId"].ToString();
                    P2.Visible = false;
                    con.Close();

                }
                else
                {
                    invalidemail.Visible = true;
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                displaymsg.Visible = true;
                con.Close();
            }
        }

        protected void Resend_Email(object sender, EventArgs e)
        {
            displaymsg.Visible = false;
            string query = "select * from UserReg1 where email='" + email.Text + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                sendEmail(dr["name"].ToString());
                ViewState["fpid"] = dr["userId"].ToString();
                P2.Visible = true;
                con.Close();
            }
            catch (Exception ex)
            {
                displaymsg.Visible = true;
                con.Close();
            }
        }

        private void sendEmail(string name)
        {
            ViewState["fpcode"] = (r.Next(1000, 9999).ToString("D4"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("4bitdevelopers@gmail.com", "finalyearproject");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "UoK Alumni Web| Account Activation ";
            msg.Body = "Dear " + name + ",\nThank you for joining us!\n\nYour activation code has been generated.\nKindly copy the following code and paste it in the required field.\n\n\t\t\t\t" + ViewState["fpcode"].ToString() + "\n\nIf you face any problems during account activation, kindly contact us:\n4bitdevelopers@gmail.com\n\nSincerely,\nAlumni Web Administrator Team,\nUniversity of Karachi";
            string to = email.Text;
            msg.To.Add(to);

            string from = " UoK Alumni <4bitdevelopers@gmail.com>";
            msg.From = new MailAddress(from);

            try
            {
                smtp.Send(msg);
            }
            catch (Exception exp)
            {
               // Response.Write("<script>alert('You are not connected to Internet')</script>");
                div2.Visible = false;
                div1.Visible = true;
                notconnected.Visible = true;
               // Response.AddHeader("REFRESH", "2;URL=ForgotPassword.aspx");
            }
        }

        protected void fpNext2_Click(object sender, EventArgs e)
        {
            if (code.Text.All(char.IsDigit))
            {
                if (code.Text == ViewState["fpcode"].ToString())
                {
                    div2.Visible = false;
                    div3.Visible = true;

                    pass1.Focus();
                }
                else
                {
                    displaymsg.Visible = true;
                }
            }
            else
            {
                displaymsg.Visible = true;
            }
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            if (pass1.Text != "" && pass2.Text != "")
            {
                if (pass1.Text == pass2.Text)
                {
                    con.Open();
                    string q1 = "UPDATE UserReg1 SET password='" + pass1.Text + "' WHERE email='" + email.Text + "'";
                    SqlCommand com1 = new SqlCommand(q1, con);
                    SqlDataReader dr = com1.ExecuteReader();
                    dr.Read();
                    con.Close();
                    div3.Visible = false;
                    div4.Visible = true;
                    Response.AddHeader("REFRESH", "2;URL=Login.aspx");

                }
                else
                {
                    P3.Visible = true;
                }
            }
        }
    }
}