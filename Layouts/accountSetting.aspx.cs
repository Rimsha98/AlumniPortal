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
    public partial class accountSetting : System.Web.UI.Page
    {
      //  private static string conString = "Data Source=.;Initial Catalog=UOK;Integrated Security=True";
        private static string conString = Utilities1.GetConnectionString();

        private static SqlConnection con = new SqlConnection(conString);
        string userId;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["userId"] == null)
                Response.Redirect("noSession.aspx");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPass.Visible = false;
            pwd.Focus();
            userId = Session["userId"].ToString();
            

        }

        protected void verifyPwd_Click(object sender, EventArgs e)
        {

            

            string query1 = "select * from userReg1 where userId='" + userId + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query1, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            if (IsPostBack)
            {
                if (dr["password"].ToString().Equals(pwd.Text))
                {
                    pwdDiv.Visible = false;
                    setting.Visible = true;
                    MainSection.Visible = true;
                    number.Text = dr["cellPhone"].ToString();
                    prof.Text = dr["profession"].ToString();
                    uname.Text = dr["username"].ToString();
                    city.Text = dr["city"].ToString();
                    country.Text = dr["country"].ToString();
                    //con.Close();
                }
                else
                {
                    if (setting.Visible == false)
                        VerifyPass.Visible = true;


                }


            }

            con.Close();
        }


        protected bool Step1_FieldValidation()
        {
            UsernameError.Visible = false;
            NumberError.Visible = false;
            CityError.Visible = false;
            CountryError.Visible = false;

            bool check = true;

            if (!number.Text.All(Char.IsDigit) || number.Text.Length < 11)
            {
                //  phone.Text = "must enter the correct number";
                NumberError.Visible = true;
                number.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            else
                number.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
            if (!uname.Text.All(Char.IsLetterOrDigit))
            {
                //   userName.Text = "only letters or digits allowed";
                UsernameError.Visible = true;
                uname.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            else
                uname.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");


            if (!city.Text.All(Char.IsLetter))
            {
                //   userName.Text = "only letters or digits allowed";
                CityError.Visible = true;
                city.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            else
                city.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");



            if (!country.Text.All(Char.IsLetter))
            {
                //   userName.Text = "only letters or digits allowed";
                CountryError.Visible = true;
                country.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            else
                country.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");


            return check;
        }

        protected void updatePersonalInfo_Click(object sender, EventArgs e)
        {
            PISaved.Visible = false;
            if (Step1_FieldValidation().Equals(true))
            {
                PISaved.Visible = true;
                userId = Session["userId"].ToString();
                if (uname.Text != "" && prof.Text != "" && number.Text != "")
                {
                    string query1 = "Update UserReg1 set username=@uname, profession=@prof, cellPhone=@num, city=@city, country=@country where userId='" + userId + "' ";
                    con.Open();
                    SqlCommand com = new SqlCommand(query1, con);
                    com.Parameters.AddWithValue("@uname", uname.Text);
                    com.Parameters.AddWithValue("@prof", prof.Text);
                    com.Parameters.AddWithValue("@num", number.Text);
                    com.Parameters.AddWithValue("@city", city.Text);
                    com.Parameters.AddWithValue("@country", country.Text);
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();
                    
                }
            }

        }

        protected void updatePwd_Click(object sender, EventArgs e)
        {
            CPError.Visible = false;
            CPSaved.Visible = false;
            userId = Session["userId"].ToString();
            if (newPwd.Text.Equals(newPwd1.Text))
            {
                string query1 = "UPDATE UserReg1 SET password=@pass WHERE userId='" + userId + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.AddWithValue("@pass", newPwd.Text);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                con.Close();
                CPSaved.Visible = true;
                
            }
            else
            {
                CPError.Visible = true;
            }
        }

        protected void updatePic_Click(object sender, EventArgs e)
        {
            picError.Visible = false;
            picTypeError.Visible = false;
            picSaved.Visible = false;
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

            fileExtension = fileExtension.ToLower();
            if (FileUpload1.HasFile)
            {

                if (fileExtension != ".png" && fileExtension != ".jpg" && fileExtension != ".tiff")
                {

                    picTypeError.Visible = true;

                }

                else
                {
                    userId = Session["userId"].ToString();
                    string query = "select picture,email from userReg1 where userId='" + userId + "'";
                    con.Open();
                    SqlCommand com = new SqlCommand(query, con);
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    string path = dr["picture"].ToString();
                    string email = dr["email"].ToString();
                    con.Close();
                   
                    path = "~/userImage/" + email + "_" + FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath(path));
                    string query1 = "Update UserReg1 set picture=@path where userId='" + userId + "' ";
                    con.Open();
                    com = new SqlCommand(query1, con);
                    com.Parameters.AddWithValue("@path", path);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();
                    picSaved.Visible = true;


                }
            }
            else
            {
                picError.Visible = true;
            }

        }
    }
}