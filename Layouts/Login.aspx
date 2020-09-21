<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FypWeb.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/login-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <script src="jquery/jquery340.js"></script>
    <title>UoK Alumni | User Login</title>
</head>

<body>
    <div class="Screen">
        <div class="Left-Panel">
            <div class="overlay">
                <div class="Grid-Container">
                    <div class="Logo">
                        <img src="images/KuLogoWhite.png" alt="KU Logo" style="width: 9vw;"/></div>
                    <div class="Text-I">
                        <h1>UNIVERSITY OF </h1>
                        <h1>KARACHI</h1>
                        <div class="line"></div>
                        <h1 style="margin-top: 3%">ALUMNI WEB</h1></div>
                    <div class="Text-II">
                        <p>Create your profile and connect with all Alumni of Karachi University.</p>
                        <p>Sign Up for free now!</p></div>
                    <div class="Left-Buttons">
                        <button onclick="GoTo_SignUp()">SIGN UP</button>
                        <button style="background-color: #64a462; color: #fcfcfc; cursor: default">LOGIN</button></div>
                </div>
            </div>
        </div>

        <div class="Right-Panel">
            <div class="Outer-Container">
                <form id="form2" runat="server" autocomplete="off" >
                    <div class="Login-Container">
                        <div class="LM-Heading">
                            <h1>USER LOGIN</h1></div>
                        <div class="LM-Label1">
                            <label>email: </label><br />
                            <div class="Custom-TextBox">
                                <div class="col1"><img src="images/user_ico.png"/></div>
                                <div class="col2"><asp:TextBox ID="uname" runat="server" onfocus="EmailOnFocus(this)" placeholder="enter your email id" type="Text" ></asp:TextBox></div>
                            </div></div>
                        <div class="LM-Label2">
                            <label>password: </label><br />
                            <div class="Custom-TextBox">
                                <div class="col1"><img src="images/password_ico.png" /></div>
                                <div class="col2"><asp:TextBox ID="pwd" runat="server" onfocus="PwdOnFocus(this)" placeholder="enter your password" type="password"></asp:TextBox></div>
                                <div class="col3" id="Pass-Eye">
                                <img id="toggle" src="images/eye_ico.png" onclick="Toggle_Password()"/>
                                </div>
                             </div></div>
                        <div class="LM-Label3">
                            <p id="ErrorMsg" visible=false style="font-size: 1.3vw; margin: 0.5vw 0 0.5vw 0;" runat="server"><span style="color: Red">Incorrect</span> Email or Password.</p>
                            <a href="ForgotPassword.aspx" style="outline-color:  #64a462;">forgot your password?</a>
                        </div>
                        <div class="LM-Button">
                            <button class="loginButton" type="button" runat="server" onclick="ValidateFields()">LOGIN</button>
                            <div style= "display:none;"><asp:Button ID="LoginCheckBtn" onclick="loginButton_Click" runat="server"/></div>
                        </div>
                        <div class="LM-Label4">
                            <p>Don't have an account?&nbsp;&nbsp;</p>
                            <a href="SignUp.aspx" style="outline-color:  #64a462;">Create one now!</a></div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script>
        function EmailOnFocus(temp) {
            temp.style.backgroundColor = "#e1e1e1";
            temp.placeholder = "enter your email id";
        }

        function PwdOnFocus(temp) {
            temp.style.backgroundColor = "#e1e1e1";
            temp.placeholder = "enter your password";
        }

        function Toggle_Password() {
            var temp = document.getElementById("pwd");
            if (temp.type === "password") {
                temp.type = "text";
                document.getElementById("toggle").src = "images/eyeshut_ico.png";
            } else {
                temp.type = "password";
                document.getElementById("toggle").src = "images/eye_ico.png";
            }
        }

        function GoTo_SignUp() {
            location.replace("SignUp.aspx");
        }

        function ValidateFields() {
            var email = document.forms["form2"]["uname"].value;
            var pwd = document.forms["form2"]["pwd"].value;

            if (email == "") {
                document.getElementById("uname").style.backgroundColor = "#f5898e";
                document.getElementById("uname").placeholder = "must fillout this field";
            }
            if (pwd == "") {
                document.getElementById("pwd").style.backgroundColor = "#f5898e";
                document.getElementById("pwd").placeholder = "must fillout this field";
            }

            if (email != "" && pwd != "") {
                $('#LoginCheckBtn').trigger('click');
            }
        }

        function FPBox() {
            FPForm.style.display = "block";
            document.getElementById("email").focus();
        }

        function CloseForm() {
            FPForm.style.display = "none";
        }

    </script>
</body>
</html>