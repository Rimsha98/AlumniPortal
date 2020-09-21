<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="FypWeb.ForgotPassword" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link2" rel="stylesheet" runat="server" media="screen" href="~/css/forgotpass-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <script src="jquery/jquery340.js"></script>
    <title>UoK Alumni | Forgot Password</title>
</head>
<body>
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
                    <button id="signupleft" runat="server" onclick="GoTo_SignUp()">SIGN UP</button>
                    <button id="loginleft" runat="server" onclick="GoTo_Login()">LOGIN</button></div>
            </div>
        </div>
    </div>

    <div class="Right-Panel">
            <form id="form1" runat="server">
    <div id="FPForm">
            <div id="div1" runat="server">
                <h1>FORGOT PASSWORD</h1>
                <p>Forgot your password? You can retrieve it in just a few simple steps.</p>
                <p>Kindly enter your <span style="color: Red;">email ID </span>below: </p>
                <asp:TextBox ID="email" runat="server" placeholder="enter your email ID" onfocus="EmailOnFocus(this)"></asp:TextBox><br />
                <p id="invalidemail" runat="server" style="margin-top: 0.5vw; text-align: left; margin-left: 10vw;" visible=false><span style="color: Red">Invalid Email!</span> Try again.</p>
                <p id="notconnected" runat="server" style="margin-top: 0.5vw; text-align: left; margin-left: 10vw;" visible=false>You are not connected to the internet.</p>
                <button id="fpNext1" type="button" onclick="CheckEmail()">NEXT</button>
                <div style= "display:none;"><asp:Button ID="Next1" runat="server" Text="NEXT" onclick="fpNext1_Click" /></div> 
            </div>
            <div id="div2" runat="server" visible=false  >
                <h1>CODE VERIFICATION</h1>
                <p>A verification code was sent to the email that you entered.</p>
                <p>Kindly enter that <span style="color: Red;">4-digit code </span>below: </p>
                <asp:TextBox ID="code" runat="server" onfocus="CodeOnFocus(this)" placeholder="enter 4-digit code here"></asp:TextBox>
                
                <p id="displaymsg" visible="false" runat="server" style="text-align: left; margin: 0 0 0 10vw;">
                <span style="color: Red;">Invalid Input! </span>Try again.</p>

                <p id="P2" visible="false" style=" text-align: left; margin: 0 0 0 10vw;" runat="server">
                <span style="color: Red;">Code Resent!</span> Try entering the new code.</p>


                <br />
                        <button id="fpNext2" type="button" onclick="CheckCode()">NEXT</button>
                        <div style= "display:none;"><asp:Button ID="Next2" runat="server" Text="NEXT" onclick="fpNext2_Click"/></div>
                        <asp:Button ID="resend" runat="server" onclick="Resend_Email" Text="RE-SEND CODE"/>
                        </div>
                <div id="div3" runat="server" visible="false">
                <h1>UPDATE PASSWORD</h1>
                <p>Kindly fillout the following fields.</p>
                <br /><label>Enter New Password:</label>&nbsp;&nbsp;
                <asp:TextBox ID="pass1" onfocus="PasswordOnFocus(this)"  placeholder="enter password"  type="password" runat="server"></asp:TextBox>
                    <br />
                    <label style="margin-left: 0.75vw;">Re-Enter Password:</label>&nbsp;&nbsp;
                <asp:TextBox ID="pass2" onfocus="PasswordOnFocus(this)" placeholder="enter password" type="password" runat="server"></asp:TextBox>
                <br />

                <p id="P3" visible="false" style=" text-align: left; color: red; margin: -1vw 0 1vw 18.8vw;" runat="server">Passwords do not match!</p>
                <button id="confirm" type="button" onclick="CheckPasswords()">NEXT</button>
                        <div style= "display:none;"><asp:Button ID="confirmpass" runat="server" Text="CONFIRM" onclick="confirm_Click" /></div>
                        
                
            </div>
                <br />

                <div id="div4" runat="server" visible=false>
                        <p>Your password has been changed successfully.</p>                     
                        <p><span style="color: Red;">Re-directing</span> you now to Login page...</p>
                        </div>
            </div>
    
    </form>
    </div>
</div>

<script>
    function EmailOnFocus(temp) {
        temp.style.backgroundColor = "#e1e1e1";
        temp.placeholder = "enter your email id";
    }

    function CodeOnFocus(temp) {
        temp.style.backgroundColor = "#e1e1e1";
        temp.placeholder = "enter 4-digit code here";
    }

    function PasswordOnFocus(temp) {
        temp.style.backgroundColor = "#e1e1e1";
        temp.placeholder = "enter password";
    }

    function CheckEmail() {
        var email = document.forms["form1"]["email"].value;

        if (email == "") {
            document.getElementById("email").style.backgroundColor = "#f5898e";
            document.getElementById("email").placeholder = "must fillout this field";
        }

        if (email != "") {
            $('#Next1').trigger('click');
        }
    }

    function CheckCode() {
        var code = document.forms["form1"]["code"].value;

        if (code == "") {
            document.getElementById("code").style.backgroundColor = "#f5898e";
            document.getElementById("code").placeholder = "must fillout this field";
        }

        if (code != "") {
            $('#Next2').trigger('click');
        }
    }

    function CheckPasswords() {
        var pass1 = document.forms["form1"]["pass1"].value;
        var pass2 = document.forms["form1"]["pass2"].value;

        if (pass1 == "") {
            document.getElementById("pass1").style.backgroundColor = "#f5898e";
            document.getElementById("pass1").placeholder = "must fillout this field";
        }
        if (pass2 == "") {
            document.getElementById("pass2").style.backgroundColor = "#f5898e";
            document.getElementById("pass2").placeholder = "must fillout this field";
        }

        if (pass1 != "" && pass2 != "") {
            $('#confirmpass').trigger('click');
        }
    }


    function GoTo_Login() {
        location.replace("Login.aspx");
    }

    function GoTo_SignUp() {
        location.replace("SignUp.aspx");
    }



</script>



    
</body>
</html>
