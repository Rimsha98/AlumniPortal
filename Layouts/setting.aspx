<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="FypWeb.setting" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/admin-portal-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <title>UoK Alumni | Admin Settings</title>
    <script src="jquery/jquery340.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    <div id="Navigation-Bar">
        <div id="adminNameBG"><label id="adminName" runat="server"></label></div>
        <asp:Button ID="newsPost" class="NavButtons" runat="server" Text="POST NEWS" OnClick="newsPost_Click" />
        <asp:Button ID="SearchUsers" class="NavButtons" runat="server" Text="SEARCH ALUMNI" OnClick="back1_Click"/>
        <asp:Button ID="accSetting" class="NavButtons" runat="server" Text="ACCOUNT SETTINGS" onclick="accSetting_Click"/>
        <asp:Button ID="adminLogout" class="NavButtons" runat="server" Text="LOGOUT" OnClick="adminLogout_Click" />
    </div>

    <div>
    <div id="pwdDiv" runat="server">
        <label>Kindly re-enter your password to change settings: </label><br />
        <asp:TextBox ID="pass" runat="server" TextMode="Password" placeholder="enter your password here" onfocus="TBFocus(1)"></asp:TextBox>
        <button type="button" id="VerifyPassBTN" runat="server" onclick="VerifyCheck()">VERIFY</button>
        <div style="display: none"><asp:Button ID="chk" runat="server" onclick="chk_Click" Text="Verify" /></div><br />
        <label id="passworderror" runat=server visible=false><span style="color:Red">Incorrect Password!</span> try entering it again.</label>
    </div>

    <div id="settingDiv" runat="server" visible="false">
        <table>
            <tr>    
            <td><label id="settingsHead"><font color="#154420"><b>Change Password </b></font></label><br /></td>
            <td></td>
            </tr>

            <tr>
            <td><label>Enter new password: </label></td>
            <td><asp:TextBox ID="newPwd" runat="server" TextMode="Password" onfocus="TBFocus(2)" placeholder="enter your password"></asp:TextBox><br /></td>
            </tr>

            <tr>
            <td><label>Re-enter password: </label></td>
            <td><asp:TextBox ID="newPwd1" runat="server" TextMode="Password" onfocus="TBFocus(3)" placeholder="re-enter your password"></asp:TextBox>
                
            </td>
            </tr>

            <tr>
            <td></td>
            <td>
            <label id="passchanged" runat=server visible=false style="color: Red; font-size: 1.1vw;">Password changed successfully.</label>
                <label id="passerror" runat=server visible=false style="color: Red; font-size: 1.1vw; "> Passwords do not match! </label>
            </td>
            </tr>

            <tr>
            <td></td>
            <td>
            <button type="button" id="updatePassBTN" runat="server" onclick="CheckPwd()">Update Password</button>
            <div style="display: none"><asp:Button ID="updatePwd" runat="server" onclick="updatePwd_Click" Text="Update Changes"/></div></td>
            </tr>

            <tr>
            <td><label id="settingsHead"><font color="#154420"><b>Change Picture</b></font></label><br /></td>
            <td></td>
            </tr>

            <tr>
            <td><br /><label>Select File: </label></td>
            <td><br /><asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 2vw; "/></td>
            </tr>

            <tr>
            <td></td>
            <td>
             <label id="fileempty" runat=server visible=false style="color: Red; font-size: 1.1vw; margin-left: 2vw;">Please Select a file!</label>
             <label id="filewrong" runat=server visible=false style="color: Red; font-size: 1.1vw; margin-left: 2vw; ">File must be JPG, PNG or TIFF format.</label>
             <label id="picsaved" runat=server visible=false style="color: Red; font-size: 1.1vw; margin-left: 2vw;">Profile Picture updated.</label>
            </td>
            </tr>

            <tr>
            <td></td>
            <td><asp:Button ID="updatePic" runat="server" Text="Update Picture" onclick="updatePic_Click" /></td>
            </tr>
        </table>
        </div>
    </div>
    </form>

    <script>
        function TBFocus(temp) {
            if (temp == 1) {
                document.forms["form1"]["pass"].placeholder = "enter your password here";
                document.forms["form1"]["pass"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 2) {
                document.forms["form1"]["newPwd"].placeholder = "enter your password";
                document.forms["form1"]["newPwd"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 3) {
                document.forms["form1"]["newPwd1"].placeholder = "re-enter your password";
                document.forms["form1"]["newPwd1"].style.backgroundColor = "#f0f0f0";
            }
        }

        function VerifyCheck() {
            var temp = document.forms["form1"]["pass"].value;

            if (temp == "") {
                document.getElementById("pass").style.backgroundColor = "#f5898e";
                document.getElementById("pass").placeholder = "must fillout this field";
            }
            else {
                $('#chk').trigger('click');
            }
        }

        function CheckPwd() {
            var pass1 = document.forms["form1"]["newPwd"].value;
            var pass2 = document.forms["form1"]["newPwd"].value;

            if (pass1 == "") {
                document.getElementById("newPwd").style.backgroundColor = "#f5898e";
                document.getElementById("newPwd").placeholder = "must fillout this field";
            }
            if (pass2 == "") {
                document.getElementById("newPwd1").style.backgroundColor = "#f5898e";
                document.getElementById("newPwd1").placeholder = "must fillout this field";
            }

            if (pass1 != "" && pass2 != "") {
                $('#updatePwd').trigger('click');
            }
        }
    </script>
</body>
</html>
