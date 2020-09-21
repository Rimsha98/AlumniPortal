<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="FypWeb.Jobs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UoK Alumni | Jobs</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <link id="Link1" rel="stylesheet" runat="server" media="screen" href="~/css/JobsFeed.css" />
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>
</head>
<body>
    <div id="Nav-JobsPage"></div>
    <div id="Main-Section">
    <form id="form1" runat="server">
    <div style="height: 100%; padding: 0.5vw">
    <div class="Custom-SearchBar" style="width: 30vw; float: left; margin-left: 1.6vw">
    <div class="col1"><asp:TextBox ID="SearchBar" runat="server" placeholder="search here..."></asp:TextBox></div>
    <div class="col3"><asp:Button ID="SearchButton" runat=server Text="Q" OnClick="searchJob_Click"/></div>
    </div>
    <asp:Button ID="newsFeed" runat="server" Text="JOBS FEED" onclick="newsFeed_Click" />
    <asp:Button ID="myPost" runat="server" Text="MY POSTS" onclick="myPost_Click" />
    </div>
    <br /><br />
    <asp:Panel ID="jobPanel" runat="server">
    <div id="JobHead" runat=server><label style="color: #fcfcfc; margin-left: 2vw; font-weight: bold;">POST A JOB </label></div>
    <div id="jobPostDiv" runat="server" style="padding: 1vw 2vw 1vw 2vw; border-bottom: 0.1vw solid #868686; border-top: 0.1vw solid #868686;"> 
    <label>Job Title: </label><br />
        <asp:TextBox ID="jobTitle" runat="server" onfocus="TBFocus(1)" placeholder="enter job title here"></asp:TextBox><br />
  <label>Job Description: </label><br />
        <textarea ID="jobDes" name="S1" runat="server" onfocus="TBFocus(2)" placeholder="enter job description here"></textarea><br />
        <label>Job related Image: </label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <label runat="server" id="jobimagerror" visible="false" style="font-size: 1.3vw; color: Red;">Kindly select a png, jpg or tiff file</label>
        <br />
        <button type="button" id="postButton" runat="server" onclick="CheckFields()">POST JOB</button>
        <div style="display: none;"><asp:Button ID="post" runat="server" Text="POST JOB" onclick="post_Click" /></div>
        <br />
    </div>
    </asp:Panel>
    
    </form>
    </div>
<script>
    $(function () {
        $("#Nav-JobsPage").load("navBar.aspx");
    });

    $(window).on('beforeunload', function () {
        $(window).scrollTop(0);
    });

    function TBFocus(temp) {
        if (temp == 1) {
            document.forms["form1"]["jobTitle"].placeholder = "enter job title here";
            document.forms["form1"]["jobTitle"].style.backgroundColor = "#e1e1e1";
        }
        if (temp == 2) {
            document.forms["form1"]["jobDes"].placeholder = "enter job description here";
            document.forms["form1"]["jobDes"].style.backgroundColor = "#e1e1e1";
        }
    }

    function CheckFields() {
        var title = document.forms["form1"]["jobTitle"].value;
        var desc = document.forms["form1"]["jobDes"].value;

        if (title == "") {
            document.getElementById("jobTitle").style.backgroundColor = "#f4898e";
            document.getElementById("jobTitle").placeholder = "must fillout this field";
        }

        if (desc == "") {
            document.getElementById("jobDes").style.backgroundColor = "#f4898e";
            document.getElementById("jobDes").placeholder = "must fillout this field";
        }

        if (title != "" && desc != "") {
            $('#post').trigger('click');
        }
    }
</script>
</body>
</html>
