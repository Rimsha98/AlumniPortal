<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="FypWeb.SignUp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="jquery/jquery123.js"></script>
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <link id="Link1" rel="stylesheet" runat="server" media="screen" href="~/css/login-styles.css" />
    <link id="Link2" rel="stylesheet" runat="server" media="screen" href="~/css/register-Styles.css" />
    <title>UoK Alumni | Sign Up</title>
</head>

<body onload="javascript:document.getElementById('div1').scrollTop = document.getElementById('scroll').value;">
<div class="Screen">
    <div class="Left-Panel">
        <div class="overlay">
            <div class="Grid-Container">
                <div class="Logo">
                    <img src="images/KuLogoWhite.png" alt="UoK-Logo" style="width: 9vw;"/></div>
                <div class="Text-I">
                    <h1>UNIVERSITY OF</h1>
                    <h1>KARACHI</h1>
                    <div class="line"></div>
                    <h1 style="margin-top: 3%">ALUMNI WEB</h1></div>
                <div class="Text-II">
                    <p>Create your profile and connect with all Alumni of Karachi University.</p>
                    <p>Sign Up for free now!</p></div>
                <div class="Left-Buttons">
                    <button id="signupleft" runat="server" style="background-color: #64a462; color: #fcfcfc; cursor: default;">SIGN UP</button>
                    <button id="loginleft" runat="server" onclick="GoTo_Login()">LOGIN</button></div>
            </div>
        </div>
    </div>

    <div id="div1" class="Right-Panel" onscroll="javascript:document.getElementById('scroll').value = this.scrollTop">
            <form id="SignUp" runat="server" autocomplete="off">
                <input type="hidden" id="scroll" runat="server" />
                <div class="SignUp-Step1" runat="server" id="step1">
                    <div class="Heading-Main">
                        <h1>SIGN UP TO KU ALUMNI</h1></div>
                    <div class="Heading-Sub" >
                        <h1>Step 1: Basic Information</h1></div>
                    <div class="Step-Text">
                        <p>Kindly enter the following information to proceed.</p></div>


                    <div class="Form-Input1">
                        <label>University Enrollment Number: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox id="enrol" placeholder="enter your enrollment number" runat="server" onfocus="TBFocus(1)"></asp:TextBox></div>
                    <div class="Form-Input2" >
                        <label>CNIC Number: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox ID="nic" placeholder="enter your cnic number" runat="server" data-inputmask="'mask': '99999-9999999-9'" onfocus="TBFocus(2)"></asp:TextBox>
                        <!---   -->
                        <button id="verifybutton" class="Button1" type="button" onclick="Validate_Step0()" runat="server">VERIFY</button>
                        <div style="display: none;"><asp:Button ID="VerifyInDB" runat="server" OnClick="button1_click"/></div>
                        <p id="verifyerror" runat="server" visible=false style="color: Red;">Incorrect Enrollment or CNIC Number!</p>
                        <p id="identicalerror" runat=server visible=false style="color: #313131;">You are already registered.</p>
                        </div>


                    <div class="Form-Input3">
                        <label visible="false" id="nameLabel" runat="server">Full Name: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="name" placeholder="enter your full name" runat="server" onfocus="TBFocus(3)"></asp:TextBox></div>
                    <div class="Form-Input4"> 
                        <label visible="false" id="fnameLabel" runat="server">Father's Name: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="fname" placeholder="enter your father's name" runat="server" onfocus="TBFocus(4)"></asp:TextBox></div>
                    <div class="Form-Input5" >
                        <label visible="false" id="emailLabel" runat="server">Email ID: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="email" placeholder="enter your email id" runat="server" onfocus="TBFocus(5)"></asp:TextBox>
                        <p id="emailerror" visible=false runat=server style="margin: 0; padding: 0; font-size: 1vw;">Email not in correct format.</p>
                        <p id="emailregistered" visible=false runat=server style="margin: 0; padding: 0; font-size: 1vw;">This email is already registered.</p></div>
                    
                    <div class="Form-Input6" >
                        <label visible="false" id="phoneLabel" runat="server">Contact No: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="phone" MaxLength=12 placeholder="enter your mobile number" runat="server" onfocus="TBFocus(6)"></asp:TextBox>
                        <p id="phoneerror" style="margin: 0; padding: 0" runat="server" visible=false>Phone number not in correct format. </p></div>                       
                    <div class="Form-Input7">
                        <label visible="false" id="userNameLabel" runat="server">Username: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="userName" MaxLength=50 placeholder="enter a unique username" runat="server" onfocus="TBFocus(7)"></asp:TextBox>
                        <p id="usernameerror" style="margin: 0; padding: 0" runat="server" visible=false>username must only contain alphabets and numbers.</p></div>
                    <div class="Form-Input8" >
                        <label visible="false" id="passLabel" runat="server">Password: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="pass" MaxLength=50 placeholder="enter password" runat="server" TextMode=Password onfocus="TBFocus(8)"></asp:TextBox></div>
                    <div class="Form-Input9" >
                        <label visible="false" id="conLabel" runat="server" >Confirm Password: <span class="Mandatory" title="Mandatory field">*</span></label><br />
                        <asp:TextBox visible="false" ID="confirm" MaxLength=50 placeholder="re-enter your password" runat="server" TextMode=Password onfocus="TBFocus(9)"></asp:TextBox>          
                        <button id="next1btn" type="button" class="next1" runat="server" onclick="Validate_Step1()">NEXT</button>
                        <div style="display: none;"><asp:Button ID="NextStep1InDB" runat="server" OnClick="next1_click"/></div>
                        <p id="passwordmsg" visible=false runat=server style="margin: 0; padding: 0; font-size: 1vw;">Passwords <span style="color: Red">do not </span>match!</p></div>                        
                </div>

                <div class="SignUp-Step2"  runat="server" visible="false" id="step2">
                    <div class="Heading-Main">
                        <h1>SIGN UP TO KU ALUMNI</h1></div>
                    <div class="Heading-Sub">
                        <h1>Step 2: Educational Information</h1></div>
                    <div class="Step-Text">
                        <p>Kindly enter your educational information in the following fields.</p></div>
                    <div class="Form-Input1">
                        <label>Category: </label><br />
                        <asp:DropDownList ID="ins" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="list1Update">
                             <asp:ListItem>University</asp:ListItem>
                             <asp:ListItem>High School</asp:ListItem>
                             <asp:ListItem>School</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="Form-Input2">
                        <label>Institute Name: </label>
                        <input id="insName" maxlength="200" type="text" runat="server" placeholder="enter your institute name" onfocus="TBFocus(10)"/></div>
                    <div class="Form-Input3">
                        <label>Major: </label>
                        <asp:DropDownList ID="major" runat="server">
                            <asp:ListItem>Computer Science</asp:ListItem>
                            <asp:ListItem>Urdu</asp:ListItem>
                            <asp:ListItem>English</asp:ListItem>
                            <asp:ListItem>Mathematics</asp:ListItem>
                            <asp:ListItem>Economics</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="Form-Input4">
                        <label>Degree: </label>
                        <asp:DropDownList ID="degree" runat="server">
                            <asp:ListItem>Bachelors</asp:ListItem>
                            <asp:ListItem>Masters</asp:ListItem>
                            <asp:ListItem>PHD</asp:ListItem>
                            <asp:ListItem>Intermediate</asp:ListItem>
                            <asp:ListItem>Matriculation</asp:ListItem>
                            <asp:ListItem>O-Levels</asp:ListItem>
                            <asp:ListItem>A-Levels</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="Form-Input5">
                        <label>Time Period: </label>
                        <asp:DropDownList ID="yearList1" runat="server">
                        </asp:DropDownList>
                        <label> to </label>
                        <asp:DropDownList ID="yearList2" runat="server">
                        </asp:DropDownList>
                        
                        <button type="button" id="addButton1" runat="server" onclick="Validate_Step2()">+ ADD MORE</button>
                        <div style="display: none;"><asp:Button ID="add" runat="server" Text=" + ADD MORE" OnClick="add_click"/></div>
                        <br /><br />
                        <p id="educationerror" style="margin: 0; padding: 0; font-size: 1.2vw;" runat="server" visible=false><span style="color:red">Must</span> enter these three educational information: School, HighSchool, University.</p>
                        <p id="eduerror2" style="margin: 0; padding: 0; font-size: 1.2vw;" runat="server" visible=false><span style="color:red">Must</span> enter School and High School only once.</p>
                    </div>
                    <div class="Form-Input6" runat="server" id="TableDiv" >
                         <asp:Table ID="Table1" runat="server" Visible="false" GridLines="Both" class="Initial-Table">
                             <asp:TableRow ID="r1" runat="server">
                                 <asp:TableCell ID="TableCell1" runat="server"><b>Category</b></asp:TableCell>
                                 <asp:TableCell ID="TableCell2" runat="server"><b>Institute</b></asp:TableCell>
                                 <asp:TableCell ID="TableCell3" runat="server"><b>Major</b></asp:TableCell>
                                 <asp:TableCell ID="TableCell4" runat="server"><b>Degree</b></asp:TableCell>
                                 <asp:TableCell ID="TableCell5" runat="server"><b>From</b></asp:TableCell>
                                 <asp:TableCell ID="TableCell6" runat="server"><b>To</b></asp:TableCell>
                                 <asp:TableCell ID="TableCell7" runat="server"></asp:TableCell>
                             </asp:TableRow>
                         </asp:Table>
                    </div>
                    <div class="Form-Input7">
                        <asp:Button ID="back2" runat="server" Text="BACK" style="float:left;" OnClick="Back_to_step1"/>
                        <asp:Button ID="next2" runat="server" Text="NEXT STEP" OnClick="next2_click"/>
                        </div>

                </div>

                <div class="SignUp-Step3" runat="server" id="step3" Visible="false">
                    <div class="Heading-Main">
                        <h1>SIGN UP TO KU ALUMNI</h1></div>
                    <div class="Heading-Sub">
                        <h1>Step 3: Professional Information</h1></div>
                    <div class="Step-Text">
                        <p>Kindly enter your professional information in the following fields.</p></div>
                    
                    <div class="Form-Input1" style="width: 50vw;">
                        <div id="heads"><label style="color: #fcfcfc"><b>&nbsp;Work Experience</b></label><br /></div> 
                        <label>Experience Title: </label>
                        <asp:TextBox ID="workExp" runat="server" placeholder="enter your work experience" MaxLength="100" onfocus="TBFocus(11)"></asp:TextBox><br />
                      <!--  <label>Description: </label>-->
                       <!-- <textarea ID="workDesc" runat="server" MaxLength="200" placeholder="enter description here..."></textarea><br /> -->
                        <label>Time Period: </label>
                        <asp:DropDownList ID="workYear1" runat="server">      
                        </asp:DropDownList>
                        <label> to </label>
                        <asp:DropDownList ID="workYear2" runat="server">
                         
                        </asp:DropDownList>
                        <button type="button" id="addButton2" runat="server" onclick="Check_Exp()">+ ADD MORE</button>
                        <div style="display: none;"><asp:Button ID="addExp" runat="server" Text="+ADD MORE" OnClick="addExp_click"/></div>
                        
                        <asp:Table ID="expTable" runat="server" GridLines="both" class="Initial-Table" Visible="false">
                            <asp:TableRow ID="TableRow1" runat="server">
                               <asp:TableCell ID="TableCell20" runat="server"><b>Experience</b></asp:TableCell>
                               <asp:TableCell ID="TableCell9" runat="server"><b>From</b></asp:TableCell>
                               <asp:TableCell ID="TableCell10" runat="server"><b>To</b></asp:TableCell>
                               <asp:TableCell ID="TableCell11" runat="server"></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        </div>
                        
                       
                    <div class="Form-Input2" style="width: 50vw; margin-top: 8%;">
                        <div id="heads"><label style="color: #fcfcfc"><b>&nbsp;Professional Skills</b></label><br /></div>
                        <asp:TextBox ID="profSkill" runat="server" placeholder="enter your professional skill" MaxLength="150" onfocus="TBFocus(12)"></asp:TextBox><br />
                        <button type="button" id="addButton3" runat="server" onclick="Check_Skill()">+ ADD MORE</button>
                        <div style="display: none;"><asp:Button ID="addSkill" runat="server" Text=" +ADD MORE" OnClick="addSkill_click"/></div>
                        <br />
                        <asp:Table ID="skillTable" runat="server" GridLines="both" class="Initial-Table" Visible="false">
                           <asp:TableRow ID="TableRow2" runat="server">
                               <asp:TableCell ID="TableCell12" runat="server"><b>Skill(s)</b></asp:TableCell>
                               <asp:TableCell ID="TableCell13" runat="server"></asp:TableCell>
                           </asp:TableRow>
                        </asp:Table></div>
                    <div class="Form-Input3" style="width: 50vw; margin-top: 8%;">
                        <div id="heads"><label style="color: #fcfcfc"><b>&nbsp;Language(s) <span title="Must input atleast 1 language">*</span></b></label><br /></div>
                        <asp:TextBox ID="language" placeholder="enter the language you speak" MaxLength="30" runat="server" onfocus="TBFocus(13)"></asp:TextBox><br />
                        <button type="button" id="addButton4" runat="server" onclick="Check_Lang()">+ ADD MORE</button>
                        <div style="display: none;"><asp:Button ID="addLang" runat="server" Text=" +ADD MORE" OnClick="addLang_click"/></div>
                        <br />
                        <asp:Table ID="langTable" runat="server" GridLines="both" Visible="false" >
                           <asp:TableRow ID="TableRow3" runat="server" class="Initial-Table" >
                               <asp:TableCell ID="TableCell14" runat="server"><b>Language(s)</b></asp:TableCell>
                               <asp:TableCell ID="TableCell15" runat="server"></asp:TableCell>
                           </asp:TableRow>
                        </asp:Table></div>
                    <div class="Form-Input4" style="width: 50vw; padding: 0; margin-top: 8%;">
                        <div id="heads"><label style="color: #fcfcfc"><b>&nbsp;Certification</b></label><br /></div>
                        <asp:TextBox ID="certification" placeholder="enter the certification you achieved in your career" MaxLength="120" runat="server" onfocus="TBFocus(14)"></asp:TextBox><br />
                        <label style=" margin-left: 0;">Time Period: </label>
                        <asp:DropDownList ID="cerYear1" runat="server"></asp:DropDownList>
                        <label> to </label>
                        <asp:DropDownList ID="cerYear2" runat="server"></asp:DropDownList>
                        <button type="button" id="addButton5" runat="server" onclick="Check_Cert()">+ ADD MORE</button>
                        <div style="display: none;"><asp:Button ID="addCer" runat="server" Text=" +ADD MORE"  OnClick="cerAdd_click"/></div>
                        <br />
                        <asp:Table ID="cerTable" runat="server" GridLines="both" class="Initial-Table" Visible="false">
                            <asp:TableRow ID="TableRow4" runat="server">
                               <asp:TableCell ID="TableCell16" runat="server"><b>Certification</b></asp:TableCell>
                               <asp:TableCell ID="TableCell17" runat="server"><b>From</b></asp:TableCell>
                               <asp:TableCell ID="TableCell18" runat="server"><b>To</b></asp:TableCell>
                               <asp:TableCell ID="TableCell19" runat="server"></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table></div>
                    <div class="Form-Input5" style="width: 50vw; margin-top: 8%">
                     <div id="heads"><label style="color: #fcfcfc"><b>&nbsp;Picture <span title="Mandatory field">*</span></b></label><br /></div>
                        <label>Select a picture for your profile: </label>
                        <asp:FileUpload ID="FileUpload1" runat="server"/>
                        <asp:Label ID="fileLabel" runat="server" visible="false" Text="Label" style="color: Red; font-size: 1.2vw;" ></asp:Label>
                        <asp:Label ID="languageLabel" runat="server" visible="false" Text="Label" style="color: Red; font-size: 1.2vw;" >Must enter atleast one Language! </asp:Label>
                        
                        </div>
                    <div class="Form-Input6" style="width: 50vw; margin-top: 5%; padding: 0;">
                        <asp:Button ID="back3" runat="server" Text="BACK" style="float: left" onclick="Back_to_step2"/>
                        <asp:Button ID="next3" runat="server" Text="CREATE MY ACCOUNT" OnClick="next3_click"/></div>
                </div>

                <div id="emailVerification" runat="server"  Visible="false">
                  <p id="emailText">Kindly input the verification code that has been sent to your email ID:</p><br />
                   <asp:TextBox ID="verificationCode" runat="server"></asp:TextBox>
                   <asp:Label ID="Label1" runat="server"></asp:Label>
                   <br />
                   <asp:Button ID="create" runat="server" Text="Proceed"  OnClick="createAccount" />
               </div> 

               <div id="SignUpCompleted" runat="server" visible=false>
                 <p>Registration Successful!</p>                     
                        <p><span style="color: Red;">Re-directing</span> you now to Login page...</p>
                       
               </div>
            </form>
    </div>
</div>

<script src="jquery/jquery311.js"></script>
<script src="jquery/jqueryinputmask.js"></script>
<script>
    $("#nic").inputmask();

    function TBFocus(temp) {
        if (temp == 1) {
            document.forms["SignUp"]["enrol"].placeholder = "enter your enrollment";
            document.forms["SignUp"]["enrol"].style.backgroundColor = "#e1e1e1";
        }
        if (temp == 2) {
            document.forms["SignUp"]["nic"].placeholder = "enter your cnic number";
            document.forms["SignUp"]["nic"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 3) {
            document.forms["SignUp"]["name"].placeholder = "enter your full name";
            document.forms["SignUp"]["name"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 4) {
            document.forms["SignUp"]["fname"].placeholder = "enter your father's name";
            document.forms["SignUp"]["fname"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 5) {
            document.forms["SignUp"]["email"].placeholder = "enter your email ID";
            document.forms["SignUp"]["email"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 6) {
            document.forms["SignUp"]["phone"].placeholder = "enter your mobile number";
            document.forms["SignUp"]["phone"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 7) {
            document.forms["SignUp"]["userName"].placeholder = "enter a unique username";
            document.forms["SignUp"]["userName"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 8) {
            document.forms["SignUp"]["pass"].placeholder = "enter password";
            document.forms["SignUp"]["pass"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 9) {
            document.forms["SignUp"]["confirm"].placeholder = "re-enter your password";
            document.forms["SignUp"]["confirm"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 10) {
            document.forms["SignUp"]["insName"].placeholder = "enter your institute name";
            document.forms["SignUp"]["insName"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 11) {
            document.forms["SignUp"]["workExp"].placeholder = "enter your work experience";
            document.forms["SignUp"]["workExp"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 12) {
            document.forms["SignUp"]["profSkill"].placeholder = "enter your professional skill";
            document.forms["SignUp"]["profSkill"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 13) {
            document.forms["SignUp"]["language"].placeholder = "enter the language you speak";
            document.forms["SignUp"]["language"].style.backgroundColor = "#e1e1e1";
        }

        if (temp == 14) {
            document.forms["SignUp"]["certification"].placeholder = "enter the certification you achieved in your career";
            document.forms["SignUp"]["certification"].style.backgroundColor = "#e1e1e1";
        }

    }
    function GoTo_Login() {
        location.replace("Login.aspx");
    }

    function Validate_Step0() {
        var enroll = document.forms["SignUp"]["enrol"].value;
        var cnic = document.forms["SignUp"]["nic"].value;

        if (enroll == "") {
            document.getElementById("enrol").style.backgroundColor = "#f5898e";
            document.getElementById("enrol").placeholder = "must fillout this field";
        }
        if (cnic == "") {
            document.getElementById("nic").style.backgroundColor = "#f5898e";
            document.getElementById("nic").placeholder = "must fillout this field";
        }

        if (enroll != "" && cnic != "") {
            $('#VerifyInDB').trigger('click');
        }
    }

    function Validate_Step1() {
        var name = document.forms["SignUp"]["name"].value;
        var fname = document.forms["SignUp"]["fname"].value;
        var email = document.forms["SignUp"]["email"].value;
        var phone = document.forms["SignUp"]["phone"].value;
        var username = document.forms["SignUp"]["userName"].value;
        var password = document.forms["SignUp"]["pass"].value;
        var cpass = document.forms["SignUp"]["confirm"].value;

        if (name == "") {
            document.getElementById("name").style.backgroundColor = "#f4898e";
            document.getElementById("name").placeholder = "must fillout this field";
        }

        if (fname == "") {
            document.getElementById("fname").style.backgroundColor = "#f4898e";
            document.getElementById("fname").placeholder = "must fillout this field";
        }

        if (email == "") {
            document.getElementById("email").style.backgroundColor = "#f4898e";
            document.getElementById("email").placeholder = "must fillout this field";
        }

        if (phone == "") {
            document.getElementById("phone").style.backgroundColor = "#f4898e";
            document.getElementById("phone").placeholder = "must fillout this field";
        }

        if (username == "") {
            document.getElementById("userName").style.backgroundColor = "#f4898e";
            document.getElementById("userName").placeholder = "must fillout this field";
        }

        if (password == "") {
            document.getElementById("pass").style.backgroundColor = "#f4898e";
            document.getElementById("pass").placeholder = "must fillout this field";
        }

        if (cpass == "") {
            document.getElementById("confirm").style.backgroundColor = "#f4898e";
            document.getElementById("confirm").placeholder = "must fillout this field";
        }

        if (name != "" && fname != "" && email != "" && phone != "" && username != "" && password != "" && cpass != "") {
            $('#NextStep1InDB').trigger('click');
        }
    }

    function Validate_Step2() {
        var insName = document.forms["SignUp"]["insName"].value;

        if (insName == "") {
            document.getElementById("insName").style.backgroundColor = "#f4898e";
            document.getElementById("insName").placeholder = "must fillout this field";
        }

        if (insName != "") {
            $('#add').trigger('click');
        }
    }

    function Check_Exp() {
        var temp = document.forms["SignUp"]["workExp"].value;

        if (temp == "") {
            document.getElementById("workExp").style.backgroundColor = "#f4898e";
            document.getElementById("workExp").placeholder = "must fillout this field";
        }

        if (temp != "") {
            $('#addExp').trigger('click');
        }
    }

    function Check_Skill() {
        var temp = document.forms["SignUp"]["profSkill"].value;

        if (temp == "") {
            document.getElementById("profSkill").style.backgroundColor = "#f4898e";
            document.getElementById("profSkill").placeholder = "must fillout this field";
        }

        if (temp != "") {
            $('#addSkill').trigger('click');
        }
    }

    function Check_Lang() {
        var temp = document.forms["SignUp"]["language"].value;

        if (temp == "") {
            document.getElementById("language").style.backgroundColor = "#f4898e";
            document.getElementById("language").placeholder = "must fillout this field";
        }

        if (temp != "") {
            $('#addLang').trigger('click');
        }
    }

    function Check_Cert() {
        var temp = document.forms["SignUp"]["certification"].value;

        if (temp == "") {
            document.getElementById("certification").style.backgroundColor = "#f4898e";
            document.getElementById("certification").placeholder = "must fillout this field";
        }

        if (temp != "") {
            $('#addCer').trigger('click');
        }
    }

</script>
</body>
</html>
