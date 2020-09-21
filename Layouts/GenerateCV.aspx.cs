using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;
using FypWeb.Class;

namespace FypWeb
{
    public partial class GenerateCV : System.Web.UI.Page
    {

       // private static string conString = "Data Source=.;Initial Catalog=UOK;Integrated Security=True";
        private static string conString = Utilities1.GetConnectionString();

        private static SqlConnection con = new SqlConnection(conString);
      string userId ;

        

        // ye count variables mene abhi initialize karay huay hain but ye count db se ayega, agar user ne 4 skill dali to skill = 4 etc

        string Year1, Year2, MyString, MyTitle, Dash = "&#8210;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                userId = Session["userId"].ToString();
                string query1 = "select * from userReg1 where userId='" + userId + "' ";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                /* cellPhone.Text = dr["cellPhone"].ToString();
                 address.Text = dr["address"].ToString();
                 profession.Text = dr["profession"].ToString();
                 email.Text = dr["email"].ToString();
                 about.Text = dr["initialpara"].ToString();*/



                CV_Name.InnerText = dr["name"].ToString();

                if (dr["profession"].ToString() == "" || dr["profession"].ToString() == null)
                {
                    CV_Profession.Visible = false;
                }
                else
                {
                    CV_Profession.Visible = true;
                    CV_Profession.InnerText = dr["profession"].ToString(); //get profession from db and send here.
                }


                CV_Phone.InnerText = dr["cellPhone"].ToString(); //get phone from db and send here.
                CV_Email.InnerText = dr["email"].ToString(); //get email from db and send here.

                if (dr["address"].ToString() == "" || dr["address"].ToString() == null)
                {
                    CV_Address.Visible = false;
                    address_label.Visible = false;
                }
                else
                {
                    address_label.Visible = true;
                    CV_Address.Visible = true;
                    CV_Address.InnerText = dr["address"].ToString(); //put Address from db in here.


                }


                if (dr["initialpara"].ToString() == "" || dr["initialpara"].ToString() == null)
                {
                    CV_InitParahgraph.Visible = false;
                }
                else
                {
                    CV_InitParahgraph.Visible = true;
                    CV_InitParahgraph.InnerText = dr["initialpara"].ToString();
                }


                con.Close();

                //Professional Skills
                string query = "select skill from ProfessionalSkills where userId='" + userId + "' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        HtmlGenericControl parah = new HtmlGenericControl("p");
                        parah.InnerText = dr.GetValue(0).ToString();
                        Skills_Div.Controls.Add(parah);

                    }
                }
                else
                    CV_Skill.InnerText = "No Professional Skills";

                con.Close();


                //Languages

                query = "select language from Lang where userId='" + userId + "' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {

                        HtmlGenericControl parah = new HtmlGenericControl("p");
                        parah.InnerText = dr.GetValue(0).ToString();
                        Lang_Div.Controls.Add(parah);

                    }
                }


                con.Close();

                //Experience

                query = "select * from WorkExperience where userId='" + userId + "' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();

                if (dr.HasRows)
                {


                    while (dr.Read())
                    {

                        Year1 = dr["startyear"].ToString();
                        Year2 = dr["endyear"].ToString();
                        MyString = dr["description"].ToString();
                        MyTitle = dr["experience"].ToString();
                        HtmlTableRow row = new HtmlTableRow();
                        row.Attributes["class"] = "WorkTitles";
                        Experience_Table(Year1, Year2, Dash, MyTitle, row);
                        CV_ExpTable.Rows.Add(row);

                        HtmlTableRow row2 = new HtmlTableRow();
                        Experience_Table("", "", "", MyString, row2);
                        CV_ExpTable.Rows.Add(row2);



                    }

                }
                else
                {
                    CV_Exp.InnerText = "No Experience yet.";
                }

                con.Close();


                //Education
                //school info
                query = "select * from UserReg2 where userId='" + userId + "' and educationalLevel='School' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();

                HtmlTableRow row3 = new HtmlTableRow();
                    dr.Read();

                    
                    Year1 = dr["startYear"].ToString();
                    Year2 = dr["endYear"].ToString();
                    MyString = dr["degree"].ToString() + " in " + dr["major"].ToString() + " From " + dr["institute"].ToString();
                    
                    row3.Attributes["class"] = "WorkTitles";
                    for (int j = 0; j < 4; j++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        cell.Attributes["class"] = "EducYears";
                        if (j.Equals(0))
                            cell.Controls.Add(new LiteralControl(Year1));
                        if (j.Equals(1))
                            cell.Controls.Add(new LiteralControl(Dash));
                        if (j.Equals(2))
                            cell.Controls.Add(new LiteralControl(Year2));
                        if (j.Equals(3))
                        {
                            cell.Attributes["class"] = "Educ_Title";
                            cell.Controls.Add(new LiteralControl(MyString));
                        }
                        row3.Cells.Add(cell);
                   
                }
                CV_EducationTable.Rows.Add(row3);


                con.Close();


                // High school info
                query = "select * from UserReg2 where userId='" + userId + "' and educationalLevel='High School' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();


                    Year1 = dr["startYear"].ToString();
                    Year2 = dr["endYear"].ToString();
                    MyString = dr["degree"].ToString() + " in " + dr["major"].ToString() + " From " + dr["institute"].ToString();
                    row3 = new HtmlTableRow();
                    row3.Attributes["class"] = "WorkTitles";
                    for (int j = 0; j < 4; j++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        cell.Attributes["class"] = "EducYears";
                        if (j.Equals(0))
                            cell.Controls.Add(new LiteralControl(Year1));
                        if (j.Equals(1))
                            cell.Controls.Add(new LiteralControl(Dash));
                        if (j.Equals(2))
                            cell.Controls.Add(new LiteralControl(Year2));
                        if (j.Equals(3))
                        {
                            cell.Attributes["class"] = "Educ_Title";
                            cell.Controls.Add(new LiteralControl(MyString));
                        }
                        row3.Cells.Add(cell);
                    }
                }
                CV_EducationTable.Rows.Add(row3);


                con.Close();


                //uniInfo
                query = "select * from UserReg2 where userId='" + userId + "' and educationalLevel='University' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
               
                    while (dr.Read())
                    {

                        Year1 = dr["startYear"].ToString();
                        Year2 = dr["endYear"].ToString();
                        MyString = dr["degree"].ToString() + " in " + dr["major"].ToString() + " From " + dr["institute"].ToString();
                        row3 = new HtmlTableRow();
                        row3.Attributes["class"] = "WorkTitles";
                        for (int j = 0; j < 4; j++)
                        {
                            HtmlTableCell cell = new HtmlTableCell();
                            cell.Attributes["class"] = "EducYears";
                            if (j.Equals(0))
                                cell.Controls.Add(new LiteralControl(Year1));
                            if (j.Equals(1))
                                cell.Controls.Add(new LiteralControl(Dash));
                            if (j.Equals(2))
                                cell.Controls.Add(new LiteralControl(Year2));
                            if (j.Equals(3))
                            {
                                cell.Attributes["class"] = "Educ_Title";
                                cell.Controls.Add(new LiteralControl(MyString));
                            }
                            row3.Cells.Add(cell);
                        
                    }
                    CV_EducationTable.Rows.Add(row3);

                }
                con.Close();

                query = "select * from Certification where userId='" + userId + "' ";
                con.Open();
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Year1 = dr["startyear"].ToString();
                        Year2 = dr["endyear"].ToString();
                        MyString = dr["certificate"].ToString();
                        HtmlTableRow row = new HtmlTableRow();
                        row.Attributes["class"] = "WorkTitles";
                        for (int j = 0; j < 4; j++)
                        {
                            HtmlTableCell cell = new HtmlTableCell();
                            cell.Attributes["class"] = "CellYears";
                            if (j.Equals(0))
                                cell.Controls.Add(new LiteralControl(Year1));
                            if (j.Equals(1))
                                cell.Controls.Add(new LiteralControl(Dash));
                            if (j.Equals(2))
                                cell.Controls.Add(new LiteralControl(Year2));
                            if (j.Equals(3))
                            {
                                cell.Attributes["class"] = "CellParah";
                                cell.Controls.Add(new LiteralControl(MyString));
                            }
                            row.Cells.Add(cell);
                        }
                        CV_CertTable.Rows.Add(row);

                    }
                }

                else
                {
                    CV_Certi.InnerText = "No Certificates achieved yet.";
                }

                con.Close();

            }
            else
                Response.Redirect("noSession.aspx");

        }

        protected void Experience_Table(string Year1, string Year2, string Dash, string temp, HtmlTableRow row)
        {
            for (int j = 0; j < 4; j++)
            {
                HtmlTableCell cell = new HtmlTableCell();
                cell.Attributes["class"] = "CellYears";
                if (j.Equals(0))
                    cell.Controls.Add(new LiteralControl(Year1));
                if (j.Equals(1))
                    cell.Controls.Add(new LiteralControl(Dash));
                if (j.Equals(2))
                    cell.Controls.Add(new LiteralControl(Year2));
                if (j.Equals(3))
                {
                    if (Dash.Equals(""))
                        cell.Attributes["class"] = "ExpParah";
                    else
                        cell.Attributes["class"] = "Main_Titles";
                    cell.Controls.Add(new LiteralControl(temp));
                }
                row.Cells.Add(cell);
            }
        }
    }
}