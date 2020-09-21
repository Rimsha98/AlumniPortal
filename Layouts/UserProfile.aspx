<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="FypWeb.UserProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media=screen href="~/css/user-profile-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>
    <title>UoK Alumni | Profile</title>
</head>

<body>
<div id="Nav-Profile"></div>
<div class="container">
    <div class="left">
        <div class="overlay">
            <div class="centered">
                <h1 style="margin: 0; margin-bottom: 0.5vw;">ALUMNI WEB PORTAL</h1>
                <div class="MainText">
                    <p>Welcome to the Official Alumni Web Portal of University of Karachi, unarguably the most                     renowned academic institution of Pakistan.</p>
                </div><br />
                <a href="www.uok.edu.pk" id="websiteLink">www.uok.edu.pk</a>
            </div>
        </div>
    </div>
    <div class="right">
    
    <div class="vbar">
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
    </div>
    <div class="content">
    <asp:Image ID="ProfilePic" runat="server"></asp:Image>
        <h1 id="fullname" runat="server" class="adjustment" style="font-size: 2vw;">Full Name</h1>
        <p id="prof" runat="server" class="adjustment">Profession</p>
        <hr style="border-top: 0.15vw dashed #154420; width: 50%"/>
        <div style="width: 75%; margin: 0 auto 0 auto; padding: 1vw;">
        <p class="adjustment"><span class="boldtext">Full Name: </span><label id="name" runat="server" class="adjustment"> </label> </p>
        <p class="adjustment"><span class="boldtext">Father's Name: </span><label id="fname" runat="server" class="adjustment"> </label> </p>
        <p class="adjustment"><span class="boldtext">Department: </span><label id="depart" runat="server"></label> </p>
        <p class="adjustment"><span class="boldtext">Degree: </span><label id="deg" runat="server"></label>  </p>
        <p class="adjustment"><span class="boldtext">City: </span><label id="city" runat="server">Not Added Yet!</label> </p>
        <p class="adjustment"><span class="boldtext">Country: </span><label id="country" runat="server">Not Added Yet!</label> </p>
        </div>
    </div>
    </div>
</div>

<script>
    $(function () {
        $("#Nav-Profile").load("navBar.aspx");
    });
</script>
</body>
</html>
