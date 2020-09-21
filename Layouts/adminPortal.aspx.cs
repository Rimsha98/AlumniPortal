using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using FypWeb.Class;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using Microsoft.Reporting.WebForms;

namespace FypWeb
{
    public partial class adminPortal : System.Web.UI.Page
    {
        private static string conString = Utilities1.GetConnectionString();
        private static SqlConnection con = new SqlConnection(conString);
        int temp = 34;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["admin"] == null)
                Response.Redirect("noSession.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["userId"] = "admin";
            string query1 = "select * from userReg1 where userId='" + temp + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query1, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows){
                adminName.InnerText = "Logged in as: " + dr["username"].ToString();
            }
            con.Close();

            #region Initial Binding
            DataTable dt = new DataTable();
            dt = GetDataForGridAndReport(nameTextbox.Text, departName.Text, emailTextbox.Text, major.Text, enrol.Text, cnic.Text, prof.Text, city.Text, country.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            #endregion

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            int index = GridView1.SelectedRow.RowIndex;
            string n = GridView1.SelectedRow.Cells[4].Text;
            name.Text = n;
            fname.Text = GridView1.SelectedRow.Cells[5].Text;
            nic.Text = GridView1.SelectedRow.Cells[3].Text;
            email.Text = GridView1.SelectedRow.Cells[6].Text;
            address.Text = GridView1.SelectedRow.Cells[10].Text;
          
            profession.Text = GridView1.SelectedRow.Cells[8].Text;
            if (profession.Text == "&nbsp;")
                profession.Text = "Not Available";
            cellphone.Text = GridView1.SelectedRow.Cells[7].Text;
           
            depart.Text = GridView1.SelectedRow.Cells[13].Text; ;
            maj.Text = GridView1.SelectedRow.Cells[14].Text; ;



            searchDiv.Visible = false;
            showEducation();
            showLang();
            showWork();
            showCertificate();
            showProfSkill();



            viewUserReport(sender, e);
           userview.Visible = true;
           search.Visible = false;
           reset.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "50px";
        }

        protected void showEducation()
        {
            string query, y1, y2, userId, exp = "";
            userId = GridView1.SelectedRow.Cells[1].Text;
            query = "select * from UserReg2 where userId='" + userId + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();


            int i = 0;

            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    i++;
                    y1 = dr["startyear"].ToString();
                    y2 = dr["endyear"].ToString();

                    exp = i + ". " + dr["degree"].ToString() + " in " + dr["major"].ToString() + " From " + dr["institute"].ToString() + "    (" + y1 + "-" + y2 + ")";
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = exp;

                    row.Cells.Add(cell);
                    eduTable.Rows.Add(row);

                }

            }
            else
            {
                eduTable.Visible = false;
                eduLabel.Visible = false;
            }

            con.Close();



        }

        protected void showProfSkill()
        {
            String l, exp = "";

            string userid = GridView1.SelectedRow.Cells[1].Text;
            string query = "select * from ProfessionalSkills where userId='" + userid + "' ";
            con.Open();
            int i = 0;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();



            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    i++;
                    l = dr["skill"].ToString();
                    exp = i + ". " + l;
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = exp;
                    row.Cells.Add(cell);
                    profTable.Rows.Add(row);

                }

            }
            else
            {
                exp = "No professional skills available.";
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = exp;
                row.Cells.Add(cell);
                profTable.Rows.Add(row);
               // profTable.Visible = false;
              //  profLabel.Visible = false;
            }

            con.Close();


        }


        protected void showLang()
        {
            String l, exp = "";

            string userid = GridView1.SelectedRow.Cells[1].Text;
            string query = "select * from Lang where userId='" + userid + "' ";
            con.Open();
            int i = 0;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();



            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    i++;
                    l = dr["language"].ToString();
                    exp = i + ". " + l;
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = exp;
                    row.Cells.Add(cell);
                    langTable.Rows.Add(row);

                }

            }
            else
            {
                langTable.Visible = false;
                langLabel.Visible = false;
            }

            con.Close();


        }
        protected void showWork()
        {

            String title, y1, y2, exp = "";

            string userid = GridView1.SelectedRow.Cells[1].Text;
            string query = "select * from WorkExperience where userId='" + userid + "' ";
            con.Open();
            int i = 0;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();


            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    i++;
                    y1 = dr["startyear"].ToString();
                    y2 = dr["endyear"].ToString();
                    title = dr["experience"].ToString();
                    exp = i + ". " + title + "   (" + y1 + "-" + y2 + ")";
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = exp;
                    row.Cells.Add(cell);
                    workTable.Rows.Add(row);

                }

            }
            else
            {
                exp = "No work experience achieved.";
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = exp;
                row.Cells.Add(cell);
                workTable.Rows.Add(row);
              //  workTable.Visible = false;
             //   we.Visible = false;

            }

            con.Close();



        }

        protected void showCertificate()
        {
            String title, y1, y2, exp = "";

            string userid = GridView1.SelectedRow.Cells[1].Text;
            string query = "select * from Certification where userId='" + userid + "' ";
            con.Open();
            int i = 0;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();

            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    i++;
                    y1 = dr["startyear"].ToString();
                    y2 = dr["endyear"].ToString();
                    title = dr["certificate"].ToString();
                    exp = i + ". " + title + "   (" + y1 + "-" + y2 + ")";
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = exp;
                    row.Cells.Add(cell);
                    cerTable.Rows.Add(row);

                }

            }
            else
            {
                exp = "No certification achieved.";
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = exp;
                row.Cells.Add(cell);
                cerTable.Rows.Add(row);
               // cerTable.Visible = false;
               // cerLabel.Visible = false;
            }

            con.Close();


        }


        protected void viewUserReport(object sender, EventArgs e)

        {
            userReport.Visible = true;

            StringWriter sw = new StringWriter();
            sw.Write("");
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            userReport.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());


            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            pdfDoc.SetPageSize(PageSize.A4.Rotate());
            PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~/PDFDoc/user.pdf"), FileMode.Create));



            pdfDoc.Open();
            htmlparser.Parse(sr);


            pdfDoc.Close();


        }



        public DataTable GetDataForGridAndReport(string Name, string Department, string Email, string major, string enrol, string cnic,
            string prof, string city, string country)
        {
            DataTable dt = new DataTable();
            string Query = "SELECT UserReg1.userId, UserReg1.enrolment,  UserReg1.cnic,  UserReg1.name,  UserReg1.fatherName,  UserReg1.email,  UserReg1.cellPhone,  UserReg1.profession,  UserReg1.username,  UserReg1.address, UserReg1.city,  UserReg1.country,studentRecord.department,studentRecord.class FROM UserReg1,studentRecord WHERE studentRecord.tblEnrId=UserReg1.tblEnrId and UserReg1.userId!='"+temp+"'";
            if (Name != "")
            {
                Query += " and UserReg1.name like '%" + Name + "%'";
            }
            if (Department != "")
            {
                Query += " and studentRecord.department like '%" + Department + "%'";
            }
            if (Email != "")
            {
                Query += " and UserReg1.email like '%" + Email + "%'";
            }
            if (major != "")
            {
                Query += " and studentRecord.class like '%" + major + "%'";
            }
            if (enrol != "")
            {
                Query += " and UserReg1.enrolment like '%" + enrol + "%'";
            }
            if (cnic != "")
            {
                Query += " and UserReg1.cnic like '%" + cnic + "%'";
            }
            if (prof != "")
            {
                Query += " and UserReg1.profession like '%" + prof + "%'";
            }
            if (city != "")
            {
                Query += " and UserReg1.city like '%" + city + "%'";
            }
            if (country != "")
            {
                Query += " and UserReg1.country like '%" + country + "%'";
            }
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            sda.Fill(dt);
            return dt;
        }
        protected void search_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = GetDataForGridAndReport(nameTextbox.Text, departName.Text, emailTextbox.Text, major.Text, enrol.Text, cnic.Text, prof.Text, city.Text, country.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPortal.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=user.pdf");
            Response.TransmitFile(Server.MapPath("~/PDFDoc/user.pdf"));
            Response.End();
        }

        protected void report_Click(object sender, EventArgs e)
        {

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
            DataTable dt = new DataTable();
            dt = GetDataForGridAndReport(nameTextbox.Text, departName.Text, emailTextbox.Text, major.Text, enrol.Text, cnic.Text, prof.Text, city.Text, country.Text);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "/Report1.rdlc";
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ReportViewer1.DataBind();

            Div1.Visible = true;
            searchDiv.Visible = false;
            search.Visible = false;
            reset.Visible = false;
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
            Session["admin"] =null;
            Response.Redirect("Login.aspx");
        }
    }
}