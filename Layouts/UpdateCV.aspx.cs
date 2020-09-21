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
    public partial class cv : System.Web.UI.Page
    {
        //private static string conString = "Data Source=.;Initial Catalog=UOK;Integrated Security=True";
        private static string conString = Utilities1.GetConnectionString();

        private static SqlConnection con = new SqlConnection(conString);
       string userId;
       protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);

           
            //skill table
            if (ViewState["skills"] != null)
            {
                string skillsString = ViewState["skills"].ToString();
                string[] skills = skillsString.Split('$');
                for (int i = 1; i < skills.Length; i++)
                {
                    TextBox tb = new TextBox();
                    
                    tb.Text = skills[i];
                    tb.ID = "tb" + i;
                    tb.CssClass = "SkillsTextBox";
                    TableRow row = new TableRow();
                    TableCell c = new TableCell();
                    // c.Text = dr.GetValue(0).ToString();
                    c.Controls.Add(tb);
                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "s_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(del_Click);
                    TableCell c1 = new TableCell();
                    c1.Controls.Add(del);

                    row.Cells.Add(c);
                    row.Cells.Add(c1);
                    skillCvTable.Rows.Add(row);
                    
                }

            }
                 //Language table

            if (ViewState["lang"] != null)
            {
                string langString = ViewState["lang"].ToString();
                string[] lang = langString.Split('$');
                for (int i = 1; i < lang.Length; i++)
                {
                    TextBox tb = new TextBox();
                    tb.Text = lang[i];
                    tb.ID = "lang" + i;
                    tb.CssClass = "SkillsTextBox";
                    TableRow row = new TableRow();
                    TableCell c = new TableCell();
                    // c.Text = dr.GetValue(0).ToString();
                    c.Controls.Add(tb);

                   
                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "l_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(langDel_Click);
                    if (i == 1)
                        del.Visible = false;

                    TableCell c1 = new TableCell();
                    c1.Controls.Add(del);

                    row.Cells.Add(c);
                    row.Cells.Add(c1);
                    langCvTable.Rows.Add(row);

                }

             

           
            }

           //experience table

            if (ViewState["exp"] != null)
            {
                string expdata = ViewState["exp"].ToString();
                string[] rows = expdata.Split(new String[] {"\n*\n"}, StringSplitOptions.None);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] cells = rows[i].Split('$');

                    TextBox tb1 = new TextBox();
                    tb1.Text = cells[0];
                    tb1.ID = "t" +i;
                    tb1.CssClass = "Title";

                    TextBox tb2 = new TextBox();
                    tb2.Text = cells[1];
                    tb2.ID = "d" +i;
                    tb2.CssClass = "Description";
       
                    TextBox tb3 = new TextBox();
                    tb3.Text = cells[2];
                    tb3.ID = "y1" +i;
                    tb3.CssClass = "StartYear";
      
                    TextBox tb4 = new TextBox();
                    tb4.Text = cells[3];
                    tb4.ID = "y2" +i;
                    tb4.CssClass = "EndYear";
      

                    TableRow row = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Controls.Add(tb1);
                    row.Cells.Add(c1);
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(tb2);
                    row.Cells.Add(c2);
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(tb3);
                    row.Cells.Add(c3);
                    TableCell c4 = new TableCell();
                    c4.Controls.Add(tb4);
                    row.Cells.Add(c4);

                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "e_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(expDel_Click);
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(del);
                    row.Cells.Add(c5);

                    expCvTable.Rows.Add(row);

                }

            }
                 //University table

            if (ViewState["uni"] != null)
            {
                string unidata = ViewState["uni"].ToString();
                string[] unirows = unidata.Split('\n');

                for (int i = 1; i < unirows.Length; i++)
                {
                    string[] cells = unirows[i].Split('$');

                    TextBox tb1 = new TextBox();
                    tb1.Text = cells[0];
                    tb1.ID = "u" + i;
                    tb1.CssClass = "UniTitle";
                  //  tb1.Width = 170;
                    TextBox tb2 = new TextBox();
                    tb2.Text = cells[1];
                    tb2.ID = "m" + i;
                    tb2.CssClass = "UniTB";
                  //  tb2.Width = 170;
                    TextBox tb3 = new TextBox();
                    tb3.Text = cells[2];
                    tb3.ID = "deg" +i;
                    tb3.CssClass = "UniTB";
                  //  tb3.Width = 100;
                    TextBox tb4 = new TextBox();
                    tb4.Text = cells[3];
                    tb4.ID = "uy1" +i;
                    tb4.CssClass = "StartYear";
                  ///  tb4.Width = 80;
                    TextBox tb5 = new TextBox();
                    tb5.Text = cells[3];
                    tb5.ID = "uy2" +i;
                    tb5.CssClass = "EndYear";
                  //  tb5.Width = 80;

                    TableRow row = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Controls.Add(tb1);
                    row.Cells.Add(c1);
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(tb2);
                    row.Cells.Add(c2);
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(tb3);
                    row.Cells.Add(c3);
                    TableCell c4 = new TableCell();
                    c4.Controls.Add(tb4);
                    row.Cells.Add(c4);
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(tb5);
                    row.Cells.Add(c5);

                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "u_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(uniDel_Click);
                    if (i == 1)
                        del.Visible = false;

                    TableCell c6 = new TableCell();
                    c5.Controls.Add(del);
                    row.Cells.Add(c6);

                    uniCvTable.Rows.Add(row);
                   

                }

            }
                 //Certification table

            if (ViewState["cer"] != null)
            {
                string cerdata = ViewState["cer"].ToString();
                string[] cerrows = cerdata.Split('\n');

                for (int i = 1; i < cerrows.Length; i++)
                {
                    string[] cells = cerrows[i].Split('$');

                    TextBox tb1 = new TextBox();
                    tb1.Text = cells[0];
                    tb1.ID = "c" +i;
                    tb1.CssClass = "CerTitle";
                  //  tb1.Width = 170;
                    TextBox tb2 = new TextBox();
                    tb2.Text = cells[1];
                    tb2.ID = "cy1" +i;
                    tb2.CssClass = "StartYear";
                 //   tb2.Width = 80;
                    TextBox tb3 = new TextBox();
                    tb3.Text = cells[2];
                    tb3.ID = "cy2" +i;
                    tb3.CssClass = "EndYear";
                   // tb3.Width = 80;


                    TableRow row = new TableRow();

                    TableCell c1 = new TableCell();
                    c1.Controls.Add(tb1);
                    row.Cells.Add(c1);
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(tb2);
                    row.Cells.Add(c2);
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(tb3);
                    row.Cells.Add(c3);

                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "c_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(cerDel_Click);
                    TableCell c4 = new TableCell();
                    c4.Controls.Add(del);
                    row.Cells.Add(c4);

                    certificationCvTable.Rows.Add(row);

                }
            }


             }

         

      
       
        protected void Page_Load(object sender, EventArgs e)
         {

             if (Session["userId"] != null)
             {
                 if (IsPostBack)
                 {

                 }
                 else
                 {

                     showData(sender, e);

                 }
             }
             else
                 Response.Redirect("noSession.aspx");
        }
     
        private void showData(object sender, EventArgs e)
        {
            userId = Session["userId"].ToString();
                string query1 = "select * from userReg1 where userId='" + userId + "' ";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                cellPhone.Text = dr["cellPhone"].ToString();
                address.Text = dr["address"].ToString();
                profession.Text = dr["profession"].ToString();
                email.Text = dr["email"].ToString();
                about.Text = dr["initialpara"].ToString();

                con.Close();
                showProfSkill();
                showLang();
                showWorkExp();
                showEducation();
                showCertification();
               


         


  }
        private void showProfSkill()

        {

            userId = Session["userId"].ToString();
            string query = "select skill from ProfessionalSkills where userId='" + userId + "' ";
            con.Open();
           SqlCommand com = new SqlCommand(query, con);
           SqlDataReader dr = com.ExecuteReader();
            int i = 1;
            string data="";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TextBox tb = new TextBox();
                    tb.Text = dr.GetValue(0).ToString();
                   data+="$"+tb.Text;
                    tb.ID = "tb" + i;
                    tb.CssClass = "SkillsTextBox";
                   // tb.ReadOnly = true;
                    TableRow row = new TableRow();

                    TableCell c = new TableCell();
                    // c.Text = dr.GetValue(0).ToString();
                    c.Controls.Add(tb);

                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "s_"+i;
                    del.CssClass = "DeleteButton";
                    del.Click+= new EventHandler(del_Click);
                    TableCell c1 = new TableCell();
                    c1.Controls.Add(del);
                 
                    row.Cells.Add(c);
                    row.Cells.Add(c1);
                  

                    skillCvTable.Rows.Add(row);
                    i++;
                }
                ViewState["skillId"] = i;
                ViewState["skills"] = data;
                //   TextBox t = (TextBox)skillCvTable.Rows[0].Cells[0].FindControl("tb1");
                //  profSkill.Text = t.Text;
               
            }
            else
            {
                skillCvTable.Visible = false;
             
            }

            con.Close();
        }


        private void showLang()
        {
            //languages
            userId = Session["userId"].ToString();
            string query = "select language from Lang where userId='" + userId + "' ";
            con.Open();
           SqlCommand com = new SqlCommand(query, con);
           SqlDataReader dr = com.ExecuteReader();
           string data = "";
          
            int i = 1;
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    TextBox tb = new TextBox();
                    tb.Text = dr.GetValue(0).ToString();
                    tb.ID = "lang" + i;
                    tb.CssClass = "SkillsTextBox";
                    TableRow row = new TableRow();
                    data += "$" + tb.Text;
                    TableCell c = new TableCell();
                    // c.Text = dr.GetValue(0).ToString();
                    c.Controls.Add(tb);

                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "l_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(langDel_Click);
                    if (i == 1)
                        del.Visible = false;

                    TableCell c1 = new TableCell();
                    c1.Controls.Add(del);

                    row.Cells.Add(c);
                    row.Cells.Add(c1);
                    langCvTable.Rows.Add(row);
                    i++;
                }

                ViewState["lang"] = data;
                ViewState["langId"] = i;
                //TextBox t = (TextBox)langCvTable.Rows[0].Cells[0].FindControl("tb0");
                //lang.Text = t.Text;

                if (langCvTable.Rows.Count == 2)
                    langCvTable.Rows[1].Cells[1].FindControl("l_1").Visible = false;

            }
            else
            {
                langCvTable.Visible = false;
             
            }

            con.Close();
        }

        private void showWorkExp()
        {
            userId = Session["userId"].ToString();
            string query = "select * from WorkExperience where userId='" + userId + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            string data = "";


            int i = 1;

            if (dr.HasRows)
            {
                

                while (dr.Read())
                {
                    TextBox tb1 = new TextBox();
                    tb1.Text = dr["experience"].ToString();
                    tb1.ID = "t" + i;
                    tb1.CssClass = "Title";
                 
                    TextBox tb2 = new TextBox();
                    tb2.Text = dr["description"].ToString();
                    tb2.ID = "d" + i;
                    tb2.CssClass = "Description";
             
                    TextBox tb3 = new TextBox();
                    tb3.Text = dr["startyear"].ToString();
                    tb3.ID = "y1" + i;
                    tb3.CssClass = "StartYear";
                
                    TextBox tb4 = new TextBox();
                    tb4.Text = dr["endyear"].ToString();
                    tb4.ID = "y2" + i;
                    tb4.CssClass = "EndYear";
                  

                    TableRow row = new TableRow();
                    data +="\n*\n" + tb1.Text + "$" + tb2.Text + "$" + tb3.Text + "$" + tb4.Text;
                    TableCell c1 = new TableCell();
                    c1.Controls.Add(tb1);
                    row.Cells.Add(c1);
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(tb2);
                    row.Cells.Add(c2);
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(tb3);
                    row.Cells.Add(c3);
                    TableCell c4= new TableCell();
                    c4.Controls.Add(tb4);
                    row.Cells.Add(c4);

                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "e_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(expDel_Click);
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(del);
                    row.Cells.Add(c5);

                    expCvTable.Rows.Add(row);
                    i++;
                  
                }

                ViewState["expId"] = i;
                ViewState["exp"] = data;
            }
            else
            {
                expCvTable.Visible = false;

            }

            con.Close();
        }

        private void showCertification()
        {
            userId = Session["userId"].ToString();
            string query = "select * from Certification where userId='" + userId + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            int i = 1;
            string data = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TextBox tb1= new TextBox();
                    tb1.Text = dr["certificate"].ToString();
                    tb1.ID = "c" + i;
                    tb1.CssClass = "CerTitle";
                   // tb1.Width = 172;

                    TextBox tb2 = new TextBox();
                    tb2.Text = dr["startyear"].ToString();
                    tb2.ID = "cy1" + i;
                    tb2.CssClass = "StartYear";
                 //   tb2.Width = 80;

                    TextBox tb3 = new TextBox();
                    tb3.Text = dr["endyear"].ToString();
                    tb3.ID = "cy2" + i;
                    tb3.CssClass = "EndYear";
                 //   tb3.Width = 80;

                    data += "\n" + tb1.Text+"$"+tb2.Text+"$"+tb3.Text;
                    TableRow row = new TableRow();

                    TableCell c1 = new TableCell();
                     c1.Controls.Add(tb1);
                    row.Cells.Add(c1);
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(tb2);
                    row.Cells.Add(c2);
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(tb3);
                    row.Cells.Add(c3);


                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "c_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(cerDel_Click);
                    TableCell c4 = new TableCell();
                    c4.Controls.Add(del);
                    row.Cells.Add(c4);

                    certificationCvTable.Rows.Add(row);
                    i++;
                }
                ViewState["cerId"] = i;
                ViewState["cer"] = data;
              
            }
            else
            {
                certificationCvTable.Visible = false;

            }

            con.Close();
        }
        private void showEducation()
        {
            //school info
            userId = Session["userId"].ToString();
            string query = "select * from UserReg2 where userId='" + userId + "' and educationalLevel='School' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                schName.Value = dr["institute"].ToString();
                schYear1.Text = dr["startYear"].ToString();
                schYear2.Text = dr["endYear"].ToString();
                schDegree.Text = dr["degree"].ToString();
                schMajor.Value = dr["major"].ToString();

            }
            con.Close();

            // High school info
            query = "select * from UserReg2 where userId='" + userId + "' and educationalLevel='High School' ";
            con.Open();
           com = new SqlCommand(query, con);
          dr = com.ExecuteReader();

          if (dr.HasRows)
          {
              dr.Read();

              clgName.Value = dr["institute"].ToString();
              clgYear1.Text = dr["startYear"].ToString();
              clgYear2.Text = dr["endYear"].ToString();
              clgDegree.Text = dr["degree"].ToString();
              clgMajor.Value = dr["major"].ToString();

          }
            con.Close();

            query = "select * from UserReg2 where userId='" + userId + "' and educationalLevel='University' ";
            con.Open();
            com = new SqlCommand(query, con);
            dr = com.ExecuteReader();
            int i = 1;
            string data = "";
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    TextBox tb1 = new TextBox();
                    tb1.Text = dr["institute"].ToString();
                    tb1.ID = "u" + i;
                    tb1.CssClass = "UniTitle";
                    //   tb1.Width = 170;
                    TextBox tb2 = new TextBox();
                    tb2.Text = dr["major"].ToString();
                    tb2.ID = "m" + i;
                    tb2.CssClass = "UniTB";
                    //     tb2.Width = 170;
                    TextBox tb3 = new TextBox();
                    tb3.Text = dr["degree"].ToString();
                    tb3.ID = "deg" + i;
                    tb3.CssClass = "UniTB";
                    //  tb3.Width = 100;
                    TextBox tb4 = new TextBox();
                    tb4.Text = dr["startYear"].ToString();
                    tb4.ID = "uy1" + i;
                    tb4.CssClass = "StartYear";
                    //   tb4.Width = 80;
                    TextBox tb5 = new TextBox();
                    tb5.Text = dr["endYear"].ToString();
                    tb5.ID = "uy2" + i;
                    tb5.CssClass = "EndYear";
                    //    tb5.Width = 80;

                    TableRow row = new TableRow();
                    data += "\n" + tb1.Text + "$" + tb2.Text + "$" + tb3.Text + "$" + tb4.Text + "$" + tb5.Text;
                    TableCell c1 = new TableCell();
                    c1.Controls.Add(tb1);
                    row.Cells.Add(c1);
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(tb2);
                    row.Cells.Add(c2);
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(tb3);
                    row.Cells.Add(c3);
                    TableCell c4 = new TableCell();
                    c4.Controls.Add(tb4);
                    row.Cells.Add(c4);
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(tb5);
                    row.Cells.Add(c5);
                    Button del = new Button();
                    del.Text = "x";
                    del.ID = "u_" + i;
                    del.CssClass = "DeleteButton";
                    del.Click += new EventHandler(uniDel_Click);
                    if (i == 1)
                        del.Visible = false;
                    TableCell c6 = new TableCell();
                    c5.Controls.Add(del);
                    row.Cells.Add(c6);

                    uniCvTable.Rows.Add(row);
                    i++;
                }
            }
            con.Close();

            ViewState["uni"] = data;
            ViewState["uniId"] = i;
        
        }


        protected void addSkill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(profSkill.Text))
            {
                profSkill.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
            }
            else
            {

                profSkill.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                TextBox tb = new TextBox();
                tb.Text = profSkill.Text;

                if (ViewState["skillId"] == null)
                    ViewState["skillId"] = 1;

                tb.ID = "tb" + skillCvTable.Rows.Count;
                tb.CssClass = "SkillsTextBox";
                TableRow row = new TableRow();

                TableCell c = new TableCell();
                c.Controls.Add(tb);

                Button del = new Button();
                del.Text = "x";
                del.ID = "s_" + skillCvTable.Rows.Count;
                del.CssClass = "DeleteButton";
                del.Click += new EventHandler(del_Click);

                ViewState["skillId"] = Convert.ToInt32(ViewState["skillId"]) + 1;
                TableCell c1 = new TableCell();
                c1.Controls.Add(del);

                row.Cells.Add(c);
                row.Cells.Add(c1);

                skillCvTable.Rows.Add(row);
                ViewState["skills"] += "$" + profSkill.Text;
                profSkill.Text = "";
                skillCvTable.Visible = true;

                if (skillCvTable.Rows.Count >= 5)
                    addSkill.Visible = false;
                else
                {
                    addSkill.Visible = true;
                    profSkill.Focus();
                }
            }
        }

        protected void addLang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lang.Text))
            {
                lang.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
            }
            else
            {

                lang.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                TextBox tb = new TextBox();
                tb.Text = lang.Text;

                if (ViewState["langId"] == null)
                    ViewState["langId"] = 1;

                tb.ID = "lang" + langCvTable.Rows.Count;
                tb.CssClass = "SkillsTextBox";

                TableRow row = new TableRow();

                TableCell c = new TableCell();
                c.Controls.Add(tb);
                Button del = new Button();
                del.Text = "x";
                del.ID = "l_" + langCvTable.Rows.Count;
                del.CssClass = "DeleteButton";
                del.Click += new EventHandler(langDel_Click);



                ViewState["langId"] = Convert.ToInt32(ViewState["langId"]) + 1;

                TableCell c1 = new TableCell();
                c1.Controls.Add(del);

                row.Cells.Add(c);
                row.Cells.Add(c1);

                langCvTable.Rows.Add(row);
                ViewState["lang"] += "$" + lang.Text;
                lang.Text = "";

                langCvTable.Visible = true;

                if (langCvTable.Rows.Count >= 5)
                    addLang.Visible = false;
                else
                {
                    addLang.Visible = true;
                    lang.Focus();
                }
            }
        }

        protected bool ValidateExp()
        {
            bool check = true;
            int count = 0;

            if (string.IsNullOrEmpty(workExp.Text))
            {
                workExp.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                workExp.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
               
            }

            if (string.IsNullOrEmpty(workDes.Text))
            {
                workDes.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                workDes.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                
            }

            if (string.IsNullOrEmpty(workYear1.Text) || workYear1.Text.Contains('_'))
            {
                workYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                workYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                check = true;
            }

            if (string.IsNullOrEmpty(workYear2.Text) || workYear2.Text.Contains('_'))
            {
                workYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                workYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                
            }

            if (count > 0)
                check = false;
            else
                check = true;

            return check;
        }

        protected void addExp_Click(object sender, EventArgs e)
        {

            if (ValidateExp().Equals(true))
            {
                if (ViewState["expId"] == null)
                    ViewState["expId"] = 1;
                string i = expCvTable.Rows.Count.ToString();
                ViewState["expId"] = Convert.ToInt32(ViewState["expId"]) + 1;

                TextBox tb1 = new TextBox();
                tb1.Text = workExp.Text;
                tb1.ID = "t" + i;
                tb1.CssClass = "Title";

                TextBox tb2 = new TextBox();
                tb2.Text = workDes.Text;
                tb2.ID = "d" + i;
                tb2.CssClass = "Description";

                TextBox tb3 = new TextBox();
                tb3.Text = workYear1.Text;
                tb3.ID = "y1" + i;
                tb3.CssClass = "StartYear";

                TextBox tb4 = new TextBox();
                tb4.Text = workYear2.Text;
                tb4.ID = "y2" + i;
                tb4.CssClass = "EndYear";




                TableRow row = new TableRow();
                TableCell c1 = new TableCell();
                c1.Controls.Add(tb1);
                row.Cells.Add(c1);
                TableCell c2 = new TableCell();
                c2.Controls.Add(tb2);
                row.Cells.Add(c2);
                TableCell c3 = new TableCell();
                c3.Controls.Add(tb3);
                row.Cells.Add(c3);
                TableCell c4 = new TableCell();
                c4.Controls.Add(tb4);
                row.Cells.Add(c4);

                Button del = new Button();
                del.Text = "x";
                del.ID = "e_" + i;
                del.CssClass = "DeleteButton";
                del.Click += new EventHandler(expDel_Click);
                TableCell c5 = new TableCell();
                c5.Controls.Add(del);
                row.Cells.Add(c5);

                expCvTable.Rows.Add(row);
                ViewState["exp"] += "\n*\n" + tb1.Text + "$" + tb2.Text + "$" + tb3.Text + "$" + tb4.Text;
                workExp.Text = "";
                workDes.Text = "";
                workYear1.Text = "";
                workYear2.Text = "";

                expCvTable.Visible = true;

                if (expCvTable.Rows.Count >= 5)
                    addExp.Visible = false;
                else
                    addExp.Visible = true;
            }
        }



        protected bool ValidateUni()
        {
            bool check = true;
            int count = 0;

            if (string.IsNullOrEmpty(uniName.Value))
            {
                uniName.Style["background-color"] = "#f4898e";
                count++;
            }
            else
            {
                uniName.Style["background-color"] = "#f0f0f0";

            }

            if (string.IsNullOrEmpty(uniDegree.Text))
            {
                uniDegree.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                uniDegree.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

            }

            if (string.IsNullOrEmpty(uniMajor.Value))
            {
                uniMajor.Style["background-color"] = "#f4898e";
                count++;
            }
            else
            {
                uniMajor.Style["background-color"] = "#f0f0f0";

            }

            if (string.IsNullOrEmpty(uniYear1.Text) || uniYear1.Text.Contains('_'))
            {
                uniYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                uniYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                check = true;
            }

            if (string.IsNullOrEmpty(uniYear2.Text) || uniYear2.Text.Contains('_'))
            {
                uniYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                uniYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

            }

            if (count > 0)
                check = false;
            else
                check = true;

            return check;
        }





        protected void addUni_Click(object sender, EventArgs e)
        {

            if (ValidateUni().Equals(true))
            {
                if (ViewState["uniId"] == null)
                    ViewState["uniId"] = 1;
                string i =uniCvTable.Rows.Count.ToString();
                ViewState["uniId"] = Convert.ToInt32(ViewState["uniId"]) + 1;

                TextBox tb1 = new TextBox();
                tb1.Text = uniName.Value;
                tb1.ID = "u" + i;
                tb1.CssClass = "UniTitle";

               // tb1.Width = 170;
                TextBox tb2 = new TextBox();
                tb2.Text = uniMajor.Value;
                tb2.ID = "m" + i;
                tb2.CssClass = "UniTB";

             //   tb2.Width = 170;
                TextBox tb3 = new TextBox();
                tb3.Text = uniDegree.Text;
                tb3.ID = "deg" + i;
                tb3.CssClass = "UniTB";
              //  tb3.Width = 100;
                TextBox tb4 = new TextBox();
                tb4.Text = uniYear1.Text;
                tb4.ID = "uy1" + i;
                tb4.CssClass = "StartYear";
              //  tb4.Width = 80;
                TextBox tb5 = new TextBox();
                tb5.Text = uniYear2.Text;
                tb5.ID = "uy2" + i;
                tb5.CssClass = "EndYear";
              //  tb5.Width = 80;


                TableRow row = new TableRow();
                TableCell c1 = new TableCell();
                c1.Controls.Add(tb1);
                row.Cells.Add(c1);
                TableCell c2 = new TableCell();
                c2.Controls.Add(tb2);
                row.Cells.Add(c2);
                TableCell c3 = new TableCell();
                c3.Controls.Add(tb3);
                row.Cells.Add(c3);
                TableCell c4 = new TableCell();
                c4.Controls.Add(tb4);
                row.Cells.Add(c4);
                TableCell c5= new TableCell();
                c5.Controls.Add(tb5);
                row.Cells.Add(c5);
                Button del = new Button();
                del.Text = "x";
                del.ID = "u_" + i;
                del.CssClass = "DeleteButton";
                del.Click += new EventHandler(uniDel_Click);
                TableCell c6 = new TableCell();
                c6.Controls.Add(del);
                row.Cells.Add(c6);

                uniCvTable.Rows.Add(row);
                ViewState["uni"] += "\n" + tb1.Text + "$" + tb2.Text + "$" + tb3.Text + "$" + tb4.Text + "$" + tb5.Text;

                uniName.Value = "";
                uniMajor.Value = "";
                uniDegree.Text = "";
                uniYear1.Text = "";
                uniYear2.Text = "";

                uniCvTable.Visible = true;

                if (uniCvTable.Rows.Count >= 4)
                    addUni.Visible = false;
                else
                    addUni.Visible = true;

            }
        }

        protected bool ValidateCer()
        {
            bool check = true;
            int count = 0;

            if (string.IsNullOrEmpty(cerTitle.Value))
            {
                cerTitle.Style["background-color"] = "#f4898e";
                count++;
            }
            else
            {
                cerTitle.Style["background-color"] = "#f0f0f0";

            }

            if (string.IsNullOrEmpty(cerYear1.Text) || cerYear1.Text.Contains('_'))
            {
                cerYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                cerYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                check = true;
            }

            if (string.IsNullOrEmpty(cerYear2.Text) || cerYear2.Text.Contains('_'))
            {
                cerYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                count++;
            }
            else
            {
                cerYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

            }

            if (count > 0)
                check = false;
            else
                check = true;

            return check;
        }

        protected void addCertification_Click(object sender, EventArgs e)
        {

            if (ValidateCer().Equals(true))
            {
                if (ViewState["cerId"] == null)
                    ViewState["cerId"] = 1;
                string i = ViewState["cerId"].ToString();
                ViewState["cerId"] = Convert.ToInt32(ViewState["cerId"]) + 1;

                TextBox tb1 = new TextBox();
                tb1.Text = cerTitle.Value;
                tb1.ID = "c" + i;
                tb1.CssClass = "CerTitle";
            //    tb1.Width = 170;
                TextBox tb2 = new TextBox();
                tb2.Text = cerYear1.Text;
                tb2.ID = "cy1" + i;
                tb2.CssClass = "StartYear";
             //   tb2.Width = 80;
                TextBox tb3 = new TextBox();
                tb3.Text =cerYear2.Text;
                tb3.ID = "cy2" + i;
                tb3.CssClass = "EndYear";
              //  tb3.Width = 80;
               



                TableRow row = new TableRow();
                TableCell c1 = new TableCell();
                c1.Controls.Add(tb1);
                row.Cells.Add(c1);
                TableCell c2 = new TableCell();
                c2.Controls.Add(tb2);
                row.Cells.Add(c2);
                TableCell c3 = new TableCell();
                c3.Controls.Add(tb3);
                row.Cells.Add(c3);

                Button del = new Button();
                del.Text = "x";
                del.ID = "c_" + i;
                del.CssClass = "DeleteButton";
                del.Click += new EventHandler(cerDel_Click);
                TableCell c4 = new TableCell();
                c4.Controls.Add(del);
                row.Cells.Add(c4);
               
                certificationCvTable.Rows.Add(row);
                ViewState["cer"] += "\n" + tb1.Text + "$" + tb2.Text + "$" + tb3.Text ;
                cerTitle.Value = "";
                cerYear1.Text = "";
                cerYear2.Text = "";

                certificationCvTable.Visible = true;

                if (certificationCvTable.Rows.Count >= 5)
                    addCertification.Visible = false;
                else
                    addCertification.Visible = true;
            }
        }

       protected void  del_Click(object sender, EventArgs e)
       {
           string value;
           string[] ind =(((Button)sender).ID).Split('_');
           int id = Convert.ToInt32(ind[1]);
           TableRow row = skillCvTable.Rows[id];
           skillCvTable.Rows.Remove(row);
      
          
           value = ViewState["skills"].ToString();
           string[] rows;
           rows = value.Split('$');
           ViewState["skills"] = null;
           for (int i = 1; i < rows.Length; i++)
           {
               if (i != id)
               {
                
               
                   ViewState["skills"] += "$" + rows[i];
               }
           }

           if (skillCvTable.Rows.Count == 1)
               skillCvTable.Visible = false;
           else
               skillCvTable.Visible = true;

          if (skillCvTable.Rows.Count <= 5)
               addSkill.Visible = true;
         
          

          profSkill.Focus();

       }

       protected void langDel_Click(object sender, EventArgs e)
       {
           string value;
           string[] ind = (((Button)sender).ID).Split('_');
           int id = Convert.ToInt32(ind[1]);
           TableRow row = langCvTable.Rows[id];
           langCvTable.Rows.Remove(row);

           value = ViewState["lang"].ToString();
           string[] rows;
           rows = value.Split('$');
           ViewState["lang"] = null;
           for (int i = 1; i < rows.Length; i++)
           {
               if (i != id)
               {
                   ViewState["lang"] += "$" + rows[i];

               }
           }


           if (langCvTable.Rows.Count == 1)
               langCvTable.Visible = false;
           else
               langCvTable.Visible = true;

          if (langCvTable.Rows.Count <= 5)
           {
               addLang.Visible = true;

              
            
               }


         

           lang.Focus();

       }

       protected void uniDel_Click(object sender, EventArgs e)
       {
           string value;
           string[] ind = (((Button)sender).ID).Split('_');
           int id = Convert.ToInt32(ind[1]);
           TableRow row = uniCvTable.Rows[id];
           uniCvTable.Rows.Remove(row);

           value = ViewState["uni"].ToString();
           string[] rows;
           rows = value.Split('\n');
           ViewState["uni"] = null;
           for (int i = 1; i < rows.Length; i++)
           {
               if (i != id)
               {
                   ViewState["uni"] += "\n" + rows[i];

               }
           }


           if (uniCvTable.Rows.Count == 1)
               uniCvTable.Visible = false;
           else
               uniCvTable.Visible = true;

           if (uniCvTable.Rows.Count <= 5)
           {
               addUni.Visible = true;

           }





          uniName.Focus();

       }


       protected void cerDel_Click(object sender, EventArgs e)
       {
           string value;
           string[] ind = (((Button)sender).ID).Split('_');
           int id = Convert.ToInt32(ind[1]);
           TableRow row = certificationCvTable.Rows[id];
           certificationCvTable.Rows.Remove(row);

           value = ViewState["cer"].ToString();
           string[] rows;
           rows = value.Split('\n');
           ViewState["cer"] = null;
           for (int i = 1; i < rows.Length; i++)
           {
               if (i != id)
               {
                   ViewState["cer"] += "\n" + rows[i];

               }
           }


           if (certificationCvTable.Rows.Count == 1)
               certificationCvTable.Visible = false;
           else
               certificationCvTable.Visible = true;

           if (certificationCvTable.Rows.Count <= 5)
           {
               addCertification.Visible = true;

           }





         cerTitle.Focus();

       }


       protected void expDel_Click(object sender, EventArgs e)
       {
           string value;
           string[] ind = (((Button)sender).ID).Split('_');
           int id = Convert.ToInt32(ind[1]);
           TableRow row = expCvTable.Rows[id];
           expCvTable.Rows.Remove(row);

           value = ViewState["exp"].ToString();
           string[] rows;
           rows = value.Split(new String[] { "\n*\n" }, StringSplitOptions.None);
           ViewState["exp"] = null;
           for (int i = 1; i < rows.Length; i++)
           {
               if (i != id)
               {
                   ViewState["exp"] += "\n*\n" + rows[i];

               }
           }


           if (expCvTable.Rows.Count == 1)
               expCvTable.Visible = false;
           else
               expCvTable.Visible = true;

           if (expCvTable.Rows.Count <= 5)
           {
               addExp.Visible = true;

           }





           workExp.Focus();

       }


       protected bool Validate_Fields()
       {
           WrongNumber.Visible = false;
           bool check = true;
           int count = 0;

           // Cellphone check
           if (cellPhone.Text == " " || cellPhone.Text == null)
           {
               WrongNumber.Visible = true;
               cellPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
               cellPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
           if (!cellPhone.Text.All(Char.IsDigit) || cellPhone.Text.Length < 11)
           {
               WrongNumber.Visible = true;
               cellPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
               cellPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

           //HS Check

           if (string.IsNullOrEmpty(clgName.Value))
           {
               clgName.Style["background-color"] = "#f4898e";
               count++;
           }
           else
           {
               clgName.Style["background-color"] = "#f0f0f0";

           }

           if (string.IsNullOrEmpty(clgDegree.Text))
           {
               clgDegree.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
           {
               clgDegree.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

           }

           if (string.IsNullOrEmpty(clgMajor.Value))
           {
               clgMajor.Style["background-color"] = "#f4898e";
               count++;
           }
           else
           {
               clgMajor.Style["background-color"] = "#f0f0f0";

           }

           if (string.IsNullOrEmpty(clgYear1.Text) || clgYear1.Text.Contains('_'))
           {
               clgYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
           {
               clgYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
               check = true;
           }

           if (string.IsNullOrEmpty(clgYear2.Text) || clgYear2.Text.Contains('_'))
           {
               clgYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
           {
               clgYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

           }

           // School Check

           if (string.IsNullOrEmpty(schName.Value))
           {
               schName.Style["background-color"] = "#f4898e";
               count++;
           }
           else
           {
               schName.Style["background-color"] = "#f0f0f0";

           }

           if (string.IsNullOrEmpty(schDegree.Text))
           {
               schDegree.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
           {
               schDegree.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

           }

           if (string.IsNullOrEmpty(schMajor.Value))
           {
               schMajor.Style["background-color"] = "#f4898e";
               count++;
           }
           else
           {
               schMajor.Style["background-color"] = "#f0f0f0";

           }

           if (string.IsNullOrEmpty(schYear1.Text) || schYear1.Text.Contains('_'))
           {
               schYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
           {
               schYear1.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
               check = true;
           }

           if (string.IsNullOrEmpty(schYear2.Text) || schYear2.Text.Contains('_'))
           {
               schYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
               count++;
           }
           else
           {
               schYear2.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

           }

           if (count > 0)
               check = false;
           else
               check = true;
           return check;
       }

        protected void saveChanges_Click(object sender, EventArgs e)
        {
            if (Validate_Fields())
            {

                userId = Session["userId"].ToString();
                //updating basic info
                string query1 = "UPDATE UserReg1 SET initialpara=@about, profession=@prof , cellPhone=@phone, address=@add WHERE userId='" + userId + "' ";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.AddWithValue("@about", about.Text);
                com.Parameters.AddWithValue("@prof", profession.Text);
                com.Parameters.AddWithValue("@phone", cellPhone.Text);
                com.Parameters.AddWithValue("@add", address.Text);
                com.CommandTimeout = 0;
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                con.Close();

                //update professional skills

                if (!(skillCvTable.Rows.Count <= 1))
                {

                    string query2 = "Delete from ProfessionalSkills where userId='" + userId + "' ";
                    con.Open();
                    com = new SqlCommand(query2, con);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();


                    for (int i = 1; i < skillCvTable.Rows.Count; i++)
                    {
                        TextBox t = (TextBox)skillCvTable.Rows[i].Cells[0].FindControl("tb" + i);
                        con.Open();
                        string query3 = "insert into ProfessionalSkills (userId,skill) values (@id,@skill) ";
                        com = new SqlCommand(query3, con);
                        com.Parameters.AddWithValue("@id", userId);
                        com.Parameters.AddWithValue("@skill", t.Text);
                        dr = com.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }


                }

                //update languages

                if (!(langCvTable.Rows.Count <= 1))
                {

                    string query4 = "Delete from Lang where userId='" + userId + "' ";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();


                    for (int i = 1; i < langCvTable.Rows.Count; i++)
                    {

                        TextBox temp = (TextBox)langCvTable.Rows[i].Cells[0].FindControl("lang" + i);
                        con.Open();
                        string query3 = "insert into Lang (userId,language) values (@id,@lang) ";
                        com = new SqlCommand(query3, con);
                        com.Parameters.AddWithValue("@id", userId);
                        com.Parameters.AddWithValue("@lang", temp.Text);
                        dr = com.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }



                }

                //update experience

                if (!(expCvTable.Rows.Count <= 1))
                {

                    string query4 = "Delete from WorkExperience where userId='" + userId + "' ";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();


                    for (int i = 1; i < expCvTable.Rows.Count; i++)
                    {

                        TextBox temp1 = (TextBox)expCvTable.Rows[i].Cells[0].FindControl("t" + i);
                        TextBox temp2 = (TextBox)expCvTable.Rows[i].Cells[0].FindControl("d" + i);
                        TextBox temp3 = (TextBox)expCvTable.Rows[i].Cells[0].FindControl("y1" + i);
                        TextBox temp4 = (TextBox)expCvTable.Rows[i].Cells[0].FindControl("y2" + i);
                        con.Open();
                        string query3 = "insert into WorkExperience (userId,experience,description,startyear,endyear) values (@id,@exp,@des,@syear,@eyear) ";
                        com = new SqlCommand(query3, con);
                        com.Parameters.AddWithValue("@id", userId);
                        com.Parameters.AddWithValue("@exp", temp1.Text);
                        com.Parameters.AddWithValue("@des", temp2.Text);
                        com.Parameters.AddWithValue("@syear", temp3.Text);
                        com.Parameters.AddWithValue("@eyear", temp4.Text);
                        dr = com.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }
                }


                //update unii

                if (!(uniCvTable.Rows.Count <= 1))
                {

                    string query4 = "Delete from UserReg2 where userId='" + userId + "' and educationalLevel='University' ";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();


                    for (int i = 1; i < uniCvTable.Rows.Count; i++)
                    {

                        TextBox temp1 = (TextBox)uniCvTable.Rows[i].Cells[0].FindControl("u" + i);
                        TextBox temp2 = (TextBox)uniCvTable.Rows[i].Cells[0].FindControl("m" + i);
                        TextBox temp3 = (TextBox)uniCvTable.Rows[i].Cells[0].FindControl("deg" + i);
                        TextBox temp4 = (TextBox)uniCvTable.Rows[i].Cells[0].FindControl("uy1" + i);
                        TextBox temp5 = (TextBox)uniCvTable.Rows[i].Cells[0].FindControl("uy2" + i);
                        con.Open();
                        string query3 = "insert into UserReg2 (userId,educationalLevel,institute,major,degree,startYear,endYear) values (@id,'University',@ins,@major,@deg,@syear,@eyear) ";
                        com = new SqlCommand(query3, con);
                        com.Parameters.AddWithValue("@id", userId);
                        com.Parameters.AddWithValue("@ins", temp1.Text);
                        com.Parameters.AddWithValue("@major", temp2.Text);
                        com.Parameters.AddWithValue("@deg", temp3.Text);
                        com.Parameters.AddWithValue("@syear", temp4.Text);
                        com.Parameters.AddWithValue("@eyear", temp5.Text);
                        dr = com.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }
                }

                //update school

                if (schName.Value != "" && schMajor.Value != "" && schDegree.Text != "" && schYear1.Text != "" && schYear2.Text != "")
                {

                    string query4 = "Update UserReg2 set institute=@ins, major=@major , degree=@deg, startYear=@syear, endYear=@eyear where userId='" + userId + "' and educationalLevel='School' ";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    com.Parameters.AddWithValue("@ins", schName.Value);
                    com.Parameters.AddWithValue("@major", schMajor.Value);
                    com.Parameters.AddWithValue("@deg", schDegree.Text);
                    com.Parameters.AddWithValue("@syear", schYear1.Text);
                    com.Parameters.AddWithValue("@eyear", schYear2.Text);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();
                }

                //update HighSchool

                if (clgName.Value != "" && clgMajor.Value != "" && clgDegree.Text != "" && clgYear1.Text != "" && clgYear2.Text != "")
                {

                    string query4 = "Update UserReg2 set institute=@ins, major=@major , degree=@deg, startYear=@syear, endYear=@eyear where userId='" + userId + "' and educationalLevel='High School' ";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    com.Parameters.AddWithValue("@ins", clgName.Value);
                    com.Parameters.AddWithValue("@major", clgMajor.Value);
                    com.Parameters.AddWithValue("@deg", clgDegree.Text);
                    com.Parameters.AddWithValue("@syear", clgYear1.Text);
                    com.Parameters.AddWithValue("@eyear", clgYear2.Text);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();
                }

                //update certification

                if (!(certificationCvTable.Rows.Count <= 1))
                {

                    string query4 = "Delete from Certification where userId='" + userId + "' ";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    dr = com.ExecuteReader();
                    dr.Read();
                    con.Close();


                    for (int i = 1; i < certificationCvTable.Rows.Count; i++)
                    {

                        TextBox temp1 = (TextBox)certificationCvTable.Rows[i].Cells[0].FindControl("c" + i);
                        TextBox temp2 = (TextBox)certificationCvTable.Rows[i].Cells[0].FindControl("cy1" + i);
                        TextBox temp3 = (TextBox)certificationCvTable.Rows[i].Cells[0].FindControl("cy2" + i);

                        con.Open();
                        string query3 = "insert into Certification (userId,certificate,startyear,endyear) values (@id,@cer,@syear,@eyear) ";
                        com = new SqlCommand(query3, con);
                        com.Parameters.AddWithValue("@id", userId);
                        com.Parameters.AddWithValue("@cer", temp1.Text);
                        com.Parameters.AddWithValue("@syear", temp2.Text);
                        com.Parameters.AddWithValue("@eyear", temp3.Text);
                        dr = com.ExecuteReader();
                        dr.Read();
                        con.Close();
                    }
                }

                
                saved.Visible = true;
                cvDiv.Visible = false;
                Response.AddHeader("REFRESH", "2;URL=GenerateCV.aspx");
            }
        }

        protected void Cancel_Changes(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}