using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.Net.Mail;
using System.IO;
using FypWeb.Class;

namespace FypWeb
{
    public partial class SignUp : System.Web.UI.Page
    {
        private static string conString = Utilities1.GetConnectionString();
        private static SqlConnection con = new SqlConnection(conString);
        private int enr;
        private string code;
        private static Random r = new Random();

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            if (ViewState["cell"] != null)
            {

                string value = ViewState["cell"].ToString();
                string[] rows, cell;
                rows = value.Split('\n');

                ViewState["id"] = rows.Length;
                for (int i = 1; i < rows.Length; i++)
                {
                    cell = rows[i].Split(',');
                    ImageButton imgbtn = new ImageButton();
                    imgbtn.ImageUrl = "images/cross.png";
                    imgbtn.Width = 20;
                    imgbtn.ID = i.ToString();

                    imgbtn.Click += new ImageClickEventHandler(imgbtn_click);

                    TableRow row = new TableRow();
                    for (int j = 0; j < cell.Length; j++)
                    {
                        TableCell c1 = new TableCell();
                        c1.Text = cell[j];
                        row.Cells.Add(c1);
                    }
                    TableCell c = new TableCell();
                    c.Controls.Add(imgbtn);
                    row.Cells.Add(c);
                    Table1.Rows.Add(row);

                }
              //  insName.Focus();
            }

            if (ViewState["expcell"] != null)
            {

                string expvalue = ViewState["expcell"].ToString();
                string[] exprows, expcell;
                exprows = expvalue.Split('\n');

                ViewState["idExp"] = exprows.Length;

                for (int i = 1; i < exprows.Length; i++)
                {
                    expcell = exprows[i].Split(',');
                    ImageButton imgbtn1 = new ImageButton();
                    imgbtn1.ImageUrl = "images/cross.png";
                    imgbtn1.Width = 20;
                    imgbtn1.ID = (i + 10).ToString();

                    imgbtn1.Click += new ImageClickEventHandler(expimgbtn_click);

                    TableRow row1 = new TableRow();
                    for (int j = 0; j < expcell.Length; j++)
                    {
                        TableCell c1 = new TableCell();
                        c1.Text = expcell[j];
                        row1.Cells.Add(c1);
                    }
                    TableCell c = new TableCell();
                    c.Controls.Add(imgbtn1);
                    row1.Cells.Add(c);
                    expTable.Rows.Add(row1);

                }
                workExp.Focus();
            }

            if (ViewState["cercell"] != null)
            {

                string cervalue = ViewState["cercell"].ToString();
                string[] cerrows, cercell;
                cerrows = cervalue.Split('\n');

                ViewState["idcer"] = cerrows.Length;

                for (int i = 1; i < cerrows.Length; i++)
                {
                    cercell = cerrows[i].Split(',');
                    ImageButton imgbtn1 = new ImageButton();
                    imgbtn1.ImageUrl = "images/cross.png";
                    imgbtn1.Width = 20;
                    imgbtn1.ID = (i + 20).ToString();

                    imgbtn1.Click += new ImageClickEventHandler(cerimgbtn_click);

                    TableRow row2 = new TableRow();
                    for (int j = 0; j < cercell.Length; j++)
                    {
                        TableCell c1 = new TableCell();
                        c1.Text = cercell[j];
                        row2.Cells.Add(c1);
                    }
                    TableCell c = new TableCell();
                    c.Controls.Add(imgbtn1);
                    row2.Cells.Add(c);
                    cerTable.Rows.Add(row2);

                }
                certification.Focus();
            }

            if (ViewState["skillcell"] != null)
            {

                string skillvalue = ViewState["skillcell"].ToString();
                string[] srows;
                srows = skillvalue.Split('\n');

                ViewState["idskill"] = srows.Length;

                for (int i = 1; i < srows.Length; i++)
                {
                    TableRow row3 = new TableRow();
                    ImageButton imgbtn1 = new ImageButton();
                    imgbtn1.ImageUrl = "images/cross.png";
                    imgbtn1.Width = 20;
                    imgbtn1.ID = (i + 30).ToString();

                    imgbtn1.Click += new ImageClickEventHandler(skillimgbtn_click);



                    TableCell c1 = new TableCell();
                    c1.Text = srows[i];
                    row3.Cells.Add(c1);




                    TableCell c = new TableCell();
                    c.Controls.Add(imgbtn1);
                    row3.Cells.Add(c);
                    skillTable.Rows.Add(row3);

                }
                profSkill.Focus();


            }

            if (ViewState["langcell"] != null)
            {

                string langvalue = ViewState["langcell"].ToString();
                string[] srows;
                srows = langvalue.Split('\n');

                ViewState["idlang"] = srows.Length;

                for (int i = 1; i < srows.Length; i++)
                {
                    TableRow row3 = new TableRow();
                    ImageButton imgbtn1 = new ImageButton();
                    imgbtn1.ImageUrl = "images/cross.png";
                    imgbtn1.Width = 20;
                    imgbtn1.ID = (i + 40).ToString();

                    imgbtn1.Click += new ImageClickEventHandler(langimgbtn_click);



                    TableCell c1 = new TableCell();
                    c1.Text = srows[i];
                    row3.Cells.Add(c1);




                    TableCell c = new TableCell();
                    c.Controls.Add(imgbtn1);
                    row3.Cells.Add(c);
                    langTable.Rows.Add(row3);

                }
                language.Focus();


            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            enrol.Focus();
            next1btn.Visible = false;

           
            if (IsPostBack)
            { }
            else
            {
                int year = Convert.ToInt32(DateTime.Now.Year.ToString());

                /*    for (int i = year; i > 1950; i--)
                    {
                        yearList1.Items.Remove(i.ToString());
                        yearList2.Items.Remove(i.ToString());

                        workYear1.Items.Remove(i.ToString());
                        workYear2.Items.Remove(i.ToString());

                        cerYear1.Items.Remove(i.ToString());
                        cerYear2.Items.Remove(i.ToString());
                    } */

                for (int i = year; i > 1950; i--)
                {
                    yearList1.Items.Add(i.ToString());
                    yearList2.Items.Add(i.ToString());

                    workYear1.Items.Add(i.ToString());
                    workYear2.Items.Add(i.ToString());

                    cerYear1.Items.Add(i.ToString());
                    cerYear2.Items.Add(i.ToString());


                }

            }

        }

        protected void list1Update(object sender, EventArgs e)
        {
            string[] uni = new string[] { "Software Engineering", "Computer Science", "Mathematics" };
            string[] uniDegree = new string[] { "Bachelors", "Masters", "PHD" };

            string[] sch = new string[] { "Computer Science", "Biological Science", "Humanities" };
            string[] schDegree = new string[] { "SSC", "O Level" };

            string[] clg = new string[] { "Pre-Engineering", "Pre-Medical", "Computer Science", "Humanities", "Home Economics", "Commerce" };
            string[] clgDegree = new string[] { "HSC", "A Level" };

            if (ins.SelectedItem.Value == "School")
            {
                major.DataSource = sch;
                major.DataBind();

                degree.DataSource = schDegree;
                degree.DataBind();
            }

            else if (ins.SelectedItem.Value == "High School")
            {
                major.DataSource = clg;
                major.DataBind();

                degree.DataSource = clgDegree;
                degree.DataBind();
            }
            else
            {
                major.DataSource = uni;
                major.DataBind();

                degree.DataSource = uniDegree;
                degree.DataBind();
            }
            insName.Focus();
        }
        protected void button1_click(object sender, EventArgs e){
            if (nic.Text.Contains('_'))
            {
                nic.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
            }
            else
            {
                   if (verify())
                   {
                enrol.ReadOnly = true;
                enrol.Enabled = false;
                nic.ReadOnly = true;
                nic.Enabled = false;
                enrol.Style["background-color"] = "#c8c8c8";
                nic.Style["background-color"] = "#c8c8c8";

                nameLabel.Visible = true;
                name.Visible = true;
                fnameLabel.Visible = true;
                fname.Visible = true;
                email.Focus();
                emailLabel.Visible = true;
                email.Visible = true;

                phoneLabel.Visible = true;
                phone.Visible = true;
                userNameLabel.Visible = true;
                userName.Visible = true;
                passLabel.Visible = true;
                pass.Visible = true;
                conLabel.Visible = true;
                confirm.Visible = true;
                next1btn.Visible = true;


                verifybutton.Disabled = true;
                verifybutton.Style["background-color"] = "#313131";
                verifybutton.Style["cursor"] = "default";


                // Button1.Visible = false;
                   }

                else
                {
                    enrol.Text = "";
                    nic.Text = "";
                }
            }
        }

        protected bool verify()
        {
            verifyerror.Visible = false;
            identicalerror.Visible = false;
            bool chk = true;
           // string query = "select * from studentRecord where enrolment='@enr' and cnic='@nic'";
            string query = "select * from studentRecord where enrolment='" + enrol.Text + "'" + " and cnic='" +nic.Text+"'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
          //  com.Parameters.AddWithValue("@enr", enrol.Text);
           // com.Parameters.AddWithValue("@nic", nic.Text);
            try
            {
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                if (dr["registered"].ToString() == "1")
                {
                    chk = false;
                    identicalerror.Visible = true;
                }
                else
                {
                    name.Text = dr.GetValue(2).ToString();
                    name.ReadOnly = true;
                    fname.Text = dr.GetValue(3).ToString();
                    fname.ReadOnly = true;
                    ViewState["EnrId"] = dr.GetValue(0).ToString();
                }
            }
            catch (Exception ex)
            {
                chk = false;
                verifyerror.Visible = true;
            }
            con.Close();

            return chk;
        }

        protected bool Step1_FieldValidation()
        {
            usernameerror.Visible = false;
            phoneerror.Visible = false;
            emailerror.Visible = false;

            bool check = true;

            try
            {
                MailAddress m = new MailAddress(email.Text);
                check = true;
                email.BackColor = System.Drawing.ColorTranslator.FromHtml("#e1e1e1");
            }
            catch (FormatException)
            {
                check = false;
                emailerror.Visible = true;
                email.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
            }

            if (!phone.Text.All(Char.IsDigit) || phone.Text.Length < 11)
            {
                //  phone.Text = "must enter the correct number";
                phoneerror.Visible = true;
                phone.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            else
                phone.BackColor = System.Drawing.ColorTranslator.FromHtml("#e1e1e1");
            if (!userName.Text.All(Char.IsLetterOrDigit))
            {
                //   userName.Text = "only letters or digits allowed";
                usernameerror.Visible = true;
                userName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            else
                userName.BackColor = System.Drawing.ColorTranslator.FromHtml("#e1e1e1");
            if (!pass.Text.All(Char.IsLetterOrDigit))
            {
                pass.Text = "only letters or digits allowed";
                pass.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4898e");
                check = false;
            }
            return check;
        }

        protected void next1_click(object sender, EventArgs e)
        {
            if (Step1_FieldValidation().Equals(false))
            {
                next1btn.Visible = true;
            }
            else
            {
                passwordmsg.Visible = false;
                emailregistered.Visible = false;
            string query = "select * from userReg1 where email='" + email.Text + "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                next1btn.Visible = true;
                emailregistered.Visible = true;

                con.Close();
            }
            else
            {
                con.Close();

                string p = pass.Text;
                if (p != confirm.Text)
                {
                    next1btn.Visible = true;
                    passwordmsg.Visible = true;
                    //confirm.Text = "not match";
                }
                else
                {
                    ViewState["password"] = pass.Text;
                    step1.Visible = false;
                    step2.Visible = true;
                    //    insName.Focus();

                }
            }
            }
        }
            // }

   

        protected void next2_click(object sender, EventArgs e)
        {
            educationerror.Visible = false;
            eduerror2.Visible = false;
            int uni = 0, sch = 0, clg = 0;
            for (int i = 1; i < Table1.Rows.Count; i++)
            {
                if (Table1.Rows[i].Cells[0].Text == "University")
                    uni++;
                else if (Table1.Rows[i].Cells[0].Text == "School")
                    sch++;
                else
                    clg++;

            }

            if (clg > 1 || sch > 1)
            {
                eduerror2.Visible = true;
            }

            else if (uni == 0 || clg != 1 || sch != 1)
            {
                educationerror.Visible = true;
            }
            else
            {
                step2.Visible = false;
                step3.Visible = true;
                workExp.Focus();
              
            }
        }

        private void imgbtn_click(object sender, EventArgs e)
        {

            string value;
            int ind = Convert.ToInt32(((ImageButton)sender).ID);
            TableRow row = Table1.Rows[ind];
            Table1.Rows.Remove(row);
            ViewState["id"] = Convert.ToInt32(ViewState["id"]) - 1;

            value = ViewState["cell"].ToString();
            string[] rows;
            rows = value.Split('\n');
            ViewState["cell"] = null;
            for (int i = 1; i < rows.Length; i++)
            {
                if (i != ind)
                    ViewState["cell"] += "\n" + rows[i];
            }

            insName.Focus();

            if (Table1.Rows.Count >= 6)
            {
                add.Visible = false;
                addButton1.Visible = false;
            }
            else
            {
                add.Visible = true;
                addButton1.Visible = true;
            }

            if (Table1.Rows.Count == 1)
                Table1.Visible = false;
            else
                Table1.Visible = true;

        }
        protected void add_click(object sender, EventArgs e)
        {


            ImageButton imgbtn = new ImageButton();
            if (ViewState["id"] == null)
            {
                imgbtn.ID = "1";
                ViewState["id"] = 1;

            }
            else
                imgbtn.ID = ViewState["id"].ToString();




            imgbtn.ImageUrl = "images/cross.png";
            imgbtn.Width = 20;
            imgbtn.Click += new ImageClickEventHandler(imgbtn_click);

            TableRow row = new TableRow();

            TableCell c1 = new TableCell();
            c1.Text = ins.SelectedValue;
            row.Cells.Add(c1);
            TableCell c2 = new TableCell();
            c2.Text = insName.Value;
            row.Cells.Add(c2);
            TableCell c3 = new TableCell();
            c3.Text = major.SelectedItem.Value;
            row.Cells.Add(c3);
            TableCell c4 = new TableCell();
            c4.Text = degree.SelectedItem.Value;
            row.Cells.Add(c4);
            TableCell c5 = new TableCell();
            c5.Text = yearList1.SelectedItem.Value;
            row.Cells.Add(c5);
            TableCell c6 = new TableCell();
            c6.Text = yearList2.SelectedItem.Value;
            row.Cells.Add(c6);


            string cell = ins.SelectedValue + "," + insName.Value + "," + major.SelectedItem.Value + "," + degree.SelectedItem.Value + "," + yearList1.SelectedItem.Value + "," + yearList2.SelectedItem.Value;
            ViewState["cell"] += "\n" + cell;

            imgbtn.Visible = true;
            TableCell c7 = new TableCell();
            c7.Controls.Add(imgbtn);
            row.Cells.Add(c7);


            Table1.Rows.Add(row);





            insName.Value = "";
            insName.Focus();

            Table1.Visible = true;

            if (Table1.Rows.Count >= 6)
            {
                add.Visible = false;
                addButton1.Visible = false;
            }
            else
            {
                add.Visible = true;
                addButton1.Visible = true;
            }

        }

        protected void listUpdate(object sender, EventArgs e)
        {
            string[] uni = new string[] { "Software Engineering", "Computer Science", "Mathematics" };
            string[] uniDegree = new string[] { "Bachelors", "Masters", "PHD" };

            string[] sch = new string[] { "Computer Science", "Biological Science", "Humanities" };
            string[] schDegree = new string[] { "SSC", "O Level" };

            string[] clg = new string[] { "Pre-Engineering", "Pre-Medical", "Computer Science", "Humanities", "Home Economics", "Commerce" };
            string[] clgDegree = new string[] { "HSC", "A Level" };

            if (ins.SelectedItem.Value == "School")
            {
                major.DataSource = sch;
                major.DataBind();

                degree.DataSource = schDegree;
                degree.DataBind();
            }

            else if (ins.SelectedItem.Value == "High School")
            {
                major.DataSource = clg;
                major.DataBind();

                degree.DataSource = clgDegree;
                degree.DataBind();
            }
            else
            {
                major.DataSource = uni;
                major.DataBind();

                degree.DataSource = uniDegree;
                degree.DataBind();
            }
            insName.Focus();
        }

        private void expimgbtn_click(object sender, EventArgs e)
        {
            string value;
            int ind = Convert.ToInt32(((ImageButton)sender).ID) - 10;
            TableRow row = expTable.Rows[ind];
            expTable.Rows.Remove(row);
            ViewState["idexp"] = Convert.ToInt32(ViewState["idexp"]) - 1;

            value = ViewState["expcell"].ToString();
            string[] rows;
            rows = value.Split('\n');
            ViewState["expcell"] = null;
            for (int i = 1; i < rows.Length; i++)
            {
                if (i != ind)
                    ViewState["expcell"] += "\n" + rows[i];
            }

            workExp.Focus();

            if (expTable.Rows.Count >= 5)
            {
                addExp.Visible = false;
                addButton2.Visible = false;
            }
            else
            {
                addExp.Visible = true;
                addButton2.Visible = true;
            }

            if (expTable.Rows.Count == 1)
                expTable.Visible = false;
            else
                expTable.Visible = true;

        }


        protected void addExp_click(object sender, EventArgs e)
        {
            
            ImageButton expimgbtn = new ImageButton();
            if (ViewState["idExp"] == null)
            {
                expimgbtn.ID = "11";
                ViewState["idExp"] = 11;

            }
            else
                expimgbtn.ID = ViewState["idExp"].ToString();

            expimgbtn.ImageUrl = "images/cross.png";
            expimgbtn.Width = 20;
            expimgbtn.Click += new ImageClickEventHandler(expimgbtn_click);


            TableRow row = new TableRow();

            TableCell c1 = new TableCell();
            c1.Text = workExp.Text;
            row.Cells.Add(c1);
     //       TableCell c2 = new TableCell();
       ///     c2.Text = workDesc.InnerText;
          //  row.Cells.Add(c2);
            TableCell c2 = new TableCell();
            c2.Text = workYear1.SelectedItem.Value;
            row.Cells.Add(c2);
            TableCell c3 = new TableCell();
            c3.Text = workYear2.SelectedItem.Value;
            row.Cells.Add(c3);

            string cell = workExp.Text + "," + workYear1.SelectedValue + "," + workYear2.SelectedValue + "";
            ViewState["expcell"] += "\n" + cell;

            TableCell c4 = new TableCell();
            c4.Controls.Add(expimgbtn);
            row.Cells.Add(c4);

            expTable.Rows.Add(row);
            workExp.Text = "";
            workExp.Focus();

            expTable.Visible = true;
            if (expTable.Rows.Count >= 5)
            {
                addExp.Visible = false;
                addButton2.Visible = false;
            }
            else
            {
                addExp.Visible = true;
                addButton2.Visible = true;
            }

        }

        private void cerimgbtn_click(object sender, EventArgs e)
        {
            string value;
            int ind = Convert.ToInt32(((ImageButton)sender).ID) - 20;
            TableRow row = cerTable.Rows[ind];
            cerTable.Rows.Remove(row);
            ViewState["idcer"] = Convert.ToInt32(ViewState["idcer"]) - 1;

            value = ViewState["cercell"].ToString();
            string[] rows;
            rows = value.Split('\n');
            ViewState["cercell"] = null;
            for (int i = 1; i < rows.Length; i++)
            {
                if (i != ind)
                    ViewState["cercell"] += "\n" + rows[i];
            }

            certification.Focus();
            if (cerTable.Rows.Count >= 5)
            {
                addCer.Visible = false;
                addButton5.Visible = false;
            }
            else
            {
                addCer.Visible = true;
                addButton5.Visible = true;
            }

            if (cerTable.Rows.Count == 1)
                cerTable.Visible = false;
            else
                cerTable.Visible = true;


        }


        protected void cerAdd_click(object sender, EventArgs e)
        {
            ImageButton cerimgbtn = new ImageButton();
            if (ViewState["idcer"] == null)
            {
                cerimgbtn.ID = "21";
                ViewState["idcer"] = 11;

            }
            else
                cerimgbtn.ID = ViewState["idcer"].ToString();

            cerimgbtn.ImageUrl = "images/cross.png";
            cerimgbtn.Width = 20;
            cerimgbtn.Click += new ImageClickEventHandler(cerimgbtn_click);


            TableRow row = new TableRow();

            TableCell c1 = new TableCell();
            c1.Text = certification.Text;
            row.Cells.Add(c1);
            TableCell c2 = new TableCell();
            c2.Text = cerYear1.SelectedValue;
            row.Cells.Add(c2);
            TableCell c3 = new TableCell();
            c3.Text = cerYear2.SelectedItem.Value;
            row.Cells.Add(c3);

            string cell = certification.Text + "," + cerYear1.SelectedValue + "," + cerYear2.SelectedValue + "";
            ViewState["cercell"] += "\n" + cell;

            TableCell c4 = new TableCell();
            c4.Controls.Add(cerimgbtn);
            row.Cells.Add(c4);

            cerTable.Rows.Add(row);
            certification.Text = "";
            certification.Focus();

            cerTable.Visible = true;

            if (cerTable.Rows.Count >= 5)
            {
                addCer.Visible = false;
                addButton5.Visible = false;
            }
            else
            {
                addCer.Visible = true;
                addButton5.Visible = true;
            }

        }

        private void skillimgbtn_click(object sender, EventArgs e)
        {
            string value;
            int ind = Convert.ToInt32(((ImageButton)sender).ID) - 30;
            TableRow row = skillTable.Rows[ind];
            skillTable.Rows.Remove(row);
            ViewState["idskill"] = Convert.ToInt32(ViewState["idskill"]) - 1;

            value = ViewState["skillcell"].ToString();
            string[] rows;
            rows = value.Split('\n');
            ViewState["skillcell"] = null;
            for (int i = 1; i < rows.Length; i++)
            {
                if (i != ind)
                    ViewState["skillcell"] += "\n" + rows[i];
            }

            profSkill.Focus();

            if (skillTable.Rows.Count >= 5)
            {
                addSkill.Visible = false;
                addButton3.Visible = false;
            }
            else
            {
                addSkill.Visible = true;
                addButton3.Visible = true;
            }

            if (skillTable.Rows.Count == 1)
                skillTable.Visible = false;
            else
                skillTable.Visible = true;

        }

        protected void addSkill_click(object sender, EventArgs e)
        {
            ImageButton simgbtn = new ImageButton();
            if (ViewState["idskill"] == null)
            {
                simgbtn.ID = "31";
                ViewState["idskill"] = 31;

            }
            else
                simgbtn.ID = ViewState["idskill"].ToString();

            simgbtn.ImageUrl = "images/cross.png";
            simgbtn.Width = 20;
            simgbtn.Click += new ImageClickEventHandler(skillimgbtn_click);


            TableRow row = new TableRow();

            TableCell c1 = new TableCell();
            c1.Text = profSkill.Text;
            row.Cells.Add(c1);

            string cell = profSkill.Text;
            ViewState["skillcell"] += "\n" + cell;

            TableCell c4 = new TableCell();
            c4.Controls.Add(simgbtn);
            row.Cells.Add(c4);

            skillTable.Rows.Add(row);
            profSkill.Text = "";
            profSkill.Focus();

            skillTable.Visible = true;
            if (skillTable.Rows.Count >= 5)
            {
                addSkill.Visible = false;
                addButton3.Visible = false;
            }
            else
            {
                addSkill.Visible = true;
                addButton3.Visible = true;
            }
        }



        private void langimgbtn_click(object sender, EventArgs e)
        {
            string value;
            int ind = Convert.ToInt32(((ImageButton)sender).ID) - 40;
            TableRow row = langTable.Rows[ind];
            langTable.Rows.Remove(row);
            ViewState["idlang"] = Convert.ToInt32(ViewState["idlang"]) - 1;

            value = ViewState["langcell"].ToString();
            string[] rows;
            rows = value.Split('\n');
            ViewState["langcell"] = null;
            for (int i = 1; i < rows.Length; i++)
            {
                if (i != ind)
                    ViewState["langcell"] += "\n" + rows[i];
            }

            language.Focus();
            if (langTable.Rows.Count >= 5)
            {
                addLang.Visible = false;
                addButton4.Visible = false;
            }
            else
            {
                addLang.Visible = true;
                addButton4.Visible = true;
            }

            if (langTable.Rows.Count == 1)
                langTable.Visible = false;
            else
                langTable.Visible = true;

        }

        protected void addLang_click(object sender, EventArgs e)
        {
            ImageButton imgbtn = new ImageButton();
            if (ViewState["idlang"] == null)
            {
                imgbtn.ID = "41";
                ViewState["idlang"] = 41;

            }
            else
                imgbtn.ID = ViewState["idlang"].ToString();

            imgbtn.ImageUrl = "images/cross.png";
            imgbtn.Width = 20;
            imgbtn.Click += new ImageClickEventHandler(langimgbtn_click);


            TableRow row = new TableRow();

            TableCell c1 = new TableCell();
            c1.Text = language.Text;
            row.Cells.Add(c1);

            string cell = language.Text;
            ViewState["langcell"] += "\n" + cell;

            TableCell c4 = new TableCell();
            c4.Controls.Add(imgbtn);
            row.Cells.Add(c4);

            langTable.Rows.Add(row);
            language.Text = "";
            language.Focus();

            langTable.Visible = true;
            if (langTable.Rows.Count >= 5)
            {
                addLang.Visible = false;
                addButton4.Visible = false;
            }
            else
            {
                addLang.Visible = true;
                addButton4.Visible = true;
            }
        }

        protected void next3_click(object sender, EventArgs e)
        {
            languageLabel.Visible = false;
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

            fileExtension = fileExtension.ToLower();
            if (FileUpload1.HasFile)
            {
                fileLabel.Visible = false;
                if (fileExtension != ".png" && fileExtension != ".jpg" && fileExtension != ".tiff")
                {
                   
                    fileLabel.Text = "Kindly select a png, jpg or tiff file";
                    fileLabel.Visible = true;
                }
                else
                {

                    if (langTable.Rows.Count == 1)
                    {
                        languageLabel.Visible = true;

                    }
                    else
                    {
                        languageLabel.Visible = false;
                        string path = "~/userImage/" + email.Text + "_" + FileUpload1.FileName;
                        FileUpload1.SaveAs(Server.MapPath(path));
                        ViewState["path"] = path;
                        step3.Visible = false;
                         emailVerification.Visible = true;
                     //   createAccount(sender, e);



                           sendEmail();


                    }
                }
            }

            else {
                fileLabel.Text = "Please select a file";
                fileLabel.Visible = true;
            }


           
           
    
        }

        private void sendEmail()
        {

            ViewState["code"] = (r.Next(1000, 9999).ToString("D4"));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("4bitdevelopers@gmail.com", "finalyearproject");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "UoK Alumni Web| Account Activation ";
            msg.Body = "Dear " + name.Text + ",\nThank you for creating an account!\n\nYour activation code has been generated.\nKindly copy the following code and paste it in the required field.\n\n\t\t\t\t" + ViewState["code"].ToString() + "\n\nIf you face any problems during account activation, kindly contact us:\n4bitdevelopers@gmail.com\n\nSincerely,\nAlumni Web Administrator Team,\nUniversity of Karachi";
            string to = email.Text;
            msg.To.Add(to);

            string from = " UoK Alumni <4bitdevelopers@gmail.com>";
            msg.From = new MailAddress(from);

            try
            {
                smtp.Send(msg);
                //  Label1.Text = "email has been sent";

            }
            catch (Exception exp)
            {

                Label1.Text = "Check your internet connection and try again";
            }
        }

        protected void createAccount(object sender, EventArgs e)
        {
            int userId;
            if (verificationCode.Text.Equals(ViewState["code"].ToString()))
            {


                Label1.Text = "Account created";
                string b64 = ViewState["path"].ToString();
                string query1 = "insert into userReg1(tblEnrId,enrolment,cnic,name,fatherName,email,cellPhone,username,password,picture,address,city,country)values(@enrId,@enr,@nic,@name,@fname,@email,@phone,@uname,@pass,@pic,'Not Available','Not Available','Not Available')";
                string q1 = "select * from userReg1 where enrolment='" + enrol.Text + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query1, con);
          
                com.Parameters.AddWithValue("@enrId", Convert.ToInt32(ViewState["EnrId"]));
                com.Parameters.AddWithValue("@enr", enrol.Text);
                com.Parameters.AddWithValue("@nic", nic.Text);
                com.Parameters.AddWithValue("@name",name.Text);
                com.Parameters.AddWithValue("@fname", fname.Text);
                com.Parameters.AddWithValue("@email", email.Text);
                com.Parameters.AddWithValue("@phone", phone.Text);
                com.Parameters.AddWithValue("@uname", userName.Text);
                com.Parameters.AddWithValue("@pass", ViewState["password"].ToString());
                com.Parameters.AddWithValue("@pic",b64);
                SqlDataReader dr = com.ExecuteReader();


                con.Close();

                con.Open();
                com = new SqlCommand(q1, con);
                dr = com.ExecuteReader();
                dr.Read();
                userId = Convert.ToInt32(dr.GetValue(0).ToString());
                con.Close();

                //   Label1.Text= userId.ToString();


                for (int i = 1; i < Table1.Rows.Count; i++)
                {
                    string query2 = "insert into userReg2(userId,educationalLevel,institute,major,degree,startYear,endYear)values(@userId,@level,@ins,@major,@deg,@syear,@eyear)";
                    con.Open();
                
                    com = new SqlCommand(query2, con);
                    com.Parameters.AddWithValue("@userId", userId);
                    com.Parameters.AddWithValue("@level", Table1.Rows[i].Cells[0].Text);
                    com.Parameters.AddWithValue("@ins", Table1.Rows[i].Cells[1].Text);
                    com.Parameters.AddWithValue("@major", Table1.Rows[i].Cells[2].Text);
                    com.Parameters.AddWithValue("@deg", Table1.Rows[i].Cells[3].Text);
                    com.Parameters.AddWithValue("@syear", Table1.Rows[i].Cells[4].Text);
                    com.Parameters.AddWithValue("@eyear", Table1.Rows[i].Cells[5].Text);
                    dr = com.ExecuteReader();
                    con.Close();
                }

                for (int i = 1; i < expTable.Rows.Count; i++)
                {
                    string query3 = "insert into WorkExperience(userId,experience,startYear,endYear)values(@id,@exp,@syear,@eyear)";
                    con.Open();
                
                    com = new SqlCommand(query3, con);
                    com.Parameters.AddWithValue("@id", userId);
                    com.Parameters.AddWithValue("@exp", expTable.Rows[i].Cells[0].Text);
                    com.Parameters.AddWithValue("@syear", expTable.Rows[i].Cells[1].Text);
                    com.Parameters.AddWithValue("@eyear", expTable.Rows[i].Cells[2].Text);
                    dr = com.ExecuteReader();
                    con.Close();
                }

                for (int i = 1; i < skillTable.Rows.Count; i++)
                {
                    string query4 = "insert into ProfessionalSkills(userId,skill)values(@uid,@skill)";
                    con.Open();
                    com = new SqlCommand(query4, con);
                    com.Parameters.AddWithValue("@uid",userId);
                    com.Parameters.AddWithValue("@skill", skillTable.Rows[i].Cells[0].Text);
                    dr = com.ExecuteReader();
                    con.Close();
                }

                for (int i = 1; i < langTable.Rows.Count; i++)
                {
                    string query5 = "insert into Lang(userId,language)values(@uid,@lang)";
                    con.Open();
                    com = new SqlCommand(query5, con);
                    com.Parameters.AddWithValue("@uid", userId);
                    com.Parameters.AddWithValue("@lang", langTable.Rows[i].Cells[0].Text);
                    dr = com.ExecuteReader();
                    con.Close();
                }

                for (int i = 1; i < cerTable.Rows.Count; i++)
                {
                    string query6 = "insert into Certification(userId,certificate,startYear,endYear)values(@uid,@cer,@syear,@eyear)";
                    con.Open();
                    com = new SqlCommand(query6, con);
                    com.Parameters.AddWithValue("@uid", userId);
                    com.Parameters.AddWithValue("@cer", cerTable.Rows[i].Cells[0].Text);
                    com.Parameters.AddWithValue("@syear", cerTable.Rows[i].Cells[1].Text);
                    com.Parameters.AddWithValue("@eyear", cerTable.Rows[i].Cells[2].Text);
                    dr = com.ExecuteReader();
                    con.Close();
                }

                string query7 = "Update studentRecord set registered='1' where enrolment=@enrol and cnic=@nic";
                con.Open();
                com = new SqlCommand(query7, con);
                com.Parameters.AddWithValue("@enrol", enrol.Text);
                com.Parameters.AddWithValue("@nic", nic.Text);
                dr = com.ExecuteReader();
                con.Close();


                emailVerification.Visible = false;
                SignUpCompleted.Visible = true;
                Response.AddHeader("REFRESH", "2;URL=Login.aspx");

            }
            else
            {
                Label1.Text = "Verification code is incorrect!";
            }
        }

        protected void Back_to_step1(object sender, EventArgs e)
        {
            step2.Visible = false;
            step1.Visible = true;
            next1btn.Visible = true;
        }

        protected void Back_to_step2(object sender, EventArgs e)
        {
            step3.Visible = false;
            step2.Visible = true;
            next1btn.Visible = true;
        }
    }
}