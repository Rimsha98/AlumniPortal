<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountSetting.aspx.cs" Inherits="FypWeb.accountSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="Link1" rel="stylesheet" runat="server" media="screen" href="~/css/accountSettings.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <title>UoK Alumni | Account Settings</title>
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>
</head>

<body>
    <div id="Nav-Settings"></div>
    
    <form id="form1" runat="server">
    <div id="pwdDiv" runat="server">
        <p>To change your account settings, kindly enter your password: </p>
        <asp:TextBox ID="pwd" TextMode="Password" runat="server" placeholder="enter your password here" onfocus="TBFocus(1)"></asp:TextBox>&nbsp;
           <button type="button" id="VerifyBTN" runat="server" onclick="CheckEmpty()">VERIFY</button>
           <div style="display:none"><asp:Button ID="verifyPwd" runat="server" Text="VERIFY" onclick="verifyPwd_Click" /></div>
            <br />
            <label id="VerifyPass" runat="server" visible="false" style="font-size: 1.3vw; margin-right: 13.5vw;"><span style="color: Red">Wrong Password! </span>Try entering it again.</label>
    </div>
    <div id="MainSection" runat="server" visible="false">
    <div id="setting" visible="false" runat="server">
        <h1 id="ASh1">ACCOUNT SETTINGS</h1>
        <div class="PInfo">Personal Information</div>
           <table id="PITable">
           <tr>
           <td style="width: 16vw;"><label>Username: </label></td>
           <td><asp:TextBox ID="uname" runat="server" placeholder="enter your username" onfocus="TBFocus(2)" MaxLength="50"></asp:TextBox>
                <br />
                <label id="UsernameError" class="errors" runat="server" visible="false">username must be alphanumeric.</label>
           </td>
           </tr>

           <tr>
           <td><label>Profession: </label></td>
           <td><asp:TextBox ID="prof" runat="server" placeholder="enter profession" onfocus="TBFocus(3)" MaxLength="45"></asp:TextBox>
           </td>
           </tr>

           <tr>
           <td><label>Contact Number: </label></td>
           <td><asp:TextBox ID="number" runat="server" placeholder="enter your mobile number" onfocus="TBFocus(4)" MaxLength="12"></asp:TextBox>
                <br />
                <label id="NumberError" class="errors" runat="server" visible="false">number not in correct format.</label>
           </td>
           </tr>

           <tr>
           <td><label>City: </label></td>
           <td><asp:TextBox ID="city" runat="server" placeholder="enter your city" onfocus="TBFocus(5)" MaxLength=50></asp:TextBox>
                <br />
                <label id="CityError" class="errors" runat="server" visible="false">city name must be alphabets only.</label>
           </td>
           </tr>

           <tr>
           <td><label>Country: </label></td>
           <td><asp:TextBox ID="country" runat="server" placeholder="enter your country" onfocus="TBFocus(6)" MaxLength=50></asp:TextBox>
           <br />
                <label id="CountryError" class="errors" runat="server" visible="false">country name must be alphabets only.</label>
           </td>
           </tr>

           <tr>
           <td></td>
           <td>
                <label id="PISaved" class="errors" runat="server" visible="false">All changes saved successfully.</label>
           <br />
           <button type="button" id="UpdatePIButton" runat="server" onclick="Validate_Sec1()">UPDATE CHANGES</button>
           <div style="display: none"><asp:Button ID="updatePersonalInfo" runat="server" onclick="updatePersonalInfo_Click" /></div>
           </td>
           </tr>

</table>
        <div class="PInfo">Change Password</div>
        <table id="CPTable">
        <tr>
        <td style="width: 16vw;"><label>Enter New Password: </label></td>
        <td><asp:TextBox ID="newPwd" TextMode="Password" runat="server" placeholder="enter your password" onfocus="TBFocus(7)" MaxLength="100"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>Re-Enter New Password: </label></td>
        <td><asp:TextBox ID="newPwd1" TextMode="Password"  runat="server" placeholder="re-enter your password" onfocus="TBFocus(8)" MaxLength="100"></asp:TextBox></td>
        </tr>
      <tr>
        <td></td>
        <td>
        <label id="CPError" class="errors" runat="server" visible="false">Passwords do not match!</label>
        <label id="CPSaved" class="errors" runat="server" visible="false">All changes saved successfully.</label>
        <br />
        <button type="button" id="UpdatePassBTN" runat="server" onclick="Validate_Sec2()">UPDATE CHANGES</button>
        <div style="display: none"><asp:Button ID="updatePwd" runat="server" Text="UPDATE CHANGES" onclick="updatePwd_Click" /></div></td>
        </tr>

        </table>

        <div class="PInfo">Change Profile Picture</div>
        <table id="PPTable">
        <tr>
        <td style="width: 16vw; "><label>Select Picture: </label></td>
        <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
        </tr>

        <tr>
        <td></td>
        <td>
        <label id="picError" class="errors" runat="server" visible="false">Please select a file!</label>
        <label id="picTypeError" class="errors" runat="server" visible="false">File must be JPG, PNG or TIFF.</label>
        <label id="picSaved" class="errors" runat="server" visible="false">All changes saved successfully.</label>
        <br />
        <asp:Button ID="updatePic" runat="server" Text="UPDATE CHANGES" onclick="updatePic_Click" /></td>
        
        </tr>
        </table>
        <br /><br /><br />
    </div>
    
    </div>
    </form>

      <script>
          $(function () {
              $("#Nav-Settings").load("navBar.aspx");
          });

          function TBFocus(temp) {
              if (temp == 1) {
                  document.forms["form1"]["pwd"].placeholder = "enter your password here";
                  document.forms["form1"]["pwd"].style.backgroundColor = "#f0f0f0";
              }
              if (temp == 2) {
                  document.forms["form1"]["uname"].placeholder = "enter your username";
                  document.forms["form1"]["uname"].style.backgroundColor = "#f0f0f0";
              }
              if (temp == 3) {
                  document.forms["form1"]["prof"].placeholder = "enter profession";
                  document.forms["form1"]["prof"].style.backgroundColor = "#f0f0f0";
              }
              if (temp == 4) {
                  document.forms["form1"]["number"].placeholder = "enter your mobile number";
                  document.forms["form1"]["number"].style.backgroundColor = "#f0f0f0";
              }
              if (temp == 5) {
                  document.forms["form1"]["city"].placeholder = "enter your city";
                  document.forms["form1"]["city"].style.backgroundColor = "#f0f0f0";
              }

              if (temp == 6) {
                  document.forms["form1"]["country"].placeholder = "enter your country";
                  document.forms["form1"]["country"].style.backgroundColor = "#f0f0f0";
              }
              if (temp == 7) {
                  document.forms["form1"]["newPwd"].placeholder = "enter your password";
                  document.forms["form1"]["newPwd"].style.backgroundColor = "#f0f0f0";
              }

              if (temp == 8) {
                  document.forms["form1"]["newPwd1"].placeholder = "re-enter your password";
                  document.forms["form1"]["newPwd1"].style.backgroundColor = "#f0f0f0";
              }
          }

          function CheckEmpty() {
              var temp = document.forms["form1"]["pwd"].value;

              if (temp == "") {
                  document.getElementById("pwd").style.backgroundColor = "#f4898e";
                  document.getElementById("pwd").placeholder = "must fillout this field";
              }

              if (temp != "") {
                  $('#verifyPwd').trigger('click');
              }
          }

          function Validate_Sec1() {
            var uname =  document.forms["form1"]["uname"].value;
            var number = document.forms["form1"]["number"].value;

        if (uname == "") {
            document.getElementById("uname").style.backgroundColor = "#f5898e";
            document.getElementById("uname").placeholder = "must fillout this field";
        }
        if (number == "") {
            document.getElementById("number").style.backgroundColor = "#f5898e";
            document.getElementById("number").placeholder = "must fillout this field";
        }

        if (uname != "" && number != "") {
            $('#updatePersonalInfo').trigger('click');
        }
    }



    function Validate_Sec2() {
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
