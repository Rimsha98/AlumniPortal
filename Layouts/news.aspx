<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="FypWeb.news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/admin-portal-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <title>UoK Alumni | Newsfeed</title>
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>

     <style>
        body { background-color: #e1e1e1; margin: 0; padding : 0; font-family: Lucida Sans Unicode; font-size: 1.3vw;
               overflow-y: scroll; }
    #Main-Section{
	background-color: #fcfcfc;
	margin: 0 auto 0 auto;
	overflow: hidden;
    width: 75vw;
	max-width: 75vw;
    height: 100%;
    max-height: 100%;
    box-shadow: 0px 0px 0px 0.1vw rgba(0,0,0,0.3); 
      position: relative;
    }

    #JobHead { background-color: #154420; font-size: 1.3vw; padding: 0.3vw 0 0.3vw 0; } 
      .Custom-SearchBar:after {
  content: "";
  display: table;
  clear: both;
}

.col1 , .col3 
{
    float: left;
}

.col1 { width: 75%; } 
.col3 { width: 25%; }

textarea{ resize: none; }

 #newsDes
    {       
    border-radius: 0.2vw;
    width: 69vw;
    max-width: 69vw;
    height: 3vw;
    background-color: #f0f0f0;
    border: none;
    font-size: 1.2vw;
    padding: 0% 1% 0% 1%;
    margin: 0;
    border-radius: 0.2vw;
    box-shadow: 0px 0px 0px 0.1vw rgba(0,0,0,0.3); 
    outline-color: #154420;
    margin-bottom: 1vw;
    font-family: Lucida Sans Unicode;
    }
    
    #newsDes { height: 6vw; }


 #SearchBar
    {
        height: 2.3vw;
        width: 22vw;
        border: none;
        border-top-left-radius: 0.2vw;
    border-bottom-left-radius: 0.2vw;
    background-color: #f0f0f0;
    font-size: 1.2vw;
    padding: 0% 1% 0% 1%;
    margin: 0;
    border-radius: 0.2vw;
    outline-color: #154420;
    font-family: Lucida Sans Unicode;
    border: 0.1vw solid #154420;
        
    }
    
    
    
    #SearchButton
    {
         border-radius: 0.2vw;
    width: 10vw;
    height: 2.3vw;
    background-color: #154420;
    color: #fcfcfc;
    font-family: Lucida Sans Unicode;
    border: none;
    cursor: pointer;
    font-size: 1.1vw;
    font-weight: bold;
    margin: 0;
    float: right;
    }
    
    #SearchButton { float: none; width: 2.6vw; height: 2.5vw; border: 0.1vw solid #154420; border-radius: 0; border-top-right-radius: 0.2vw;
    border-bottom-right-radius: 0.2vw; }
    
    #postButton
    {
         border-radius: 0.2vw;
    width: 10vw;
    height: 2.3vw;
    background-color: #154420;
    color: #fcfcfc;
    font-family: Lucida Sans Unicode;
    border: none;
    cursor: pointer;
    font-size: 1.1vw;
    font-weight: bold;
    margin: 0;
    float: right;
    }
    #postButton { margin-top: 0; margin-right: 0.5vw; }
    #postButton:hover {  background-color: #2e7a40; }
    
    
    </style>
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


    <div id="Main-Section">
    <div style="height: 100%; padding: 0.5vw">
    <br />
    <div class="Custom-SearchBar" style="width: 30vw; float: left; margin-left: 1.6vw">
    <div class="col1"><asp:TextBox ID="SearchBar" runat="server" placeholder="search here..."></asp:TextBox></div>
    <div class="col3"><asp:Button ID="SearchButton" runat=server Text="Q" OnClick="searchNews_Click"/></div>
    </div>
    </div>
    <br />
    <div>
     <br />
    <asp:Panel ID="newsPanel" runat="server">
    <div id="newsPostDiv" runat="server"> 
        <div id="JobHead" runat=server><label style="color: #fcfcfc; margin-left: 2vw; font-weight: bold;">POST NEWS </label></div>
        <div id="jobPostDiv" runat="server" style="padding: 1vw 2vw 1vw 2vw; border-bottom: 0.1vw solid #868686; border-top: 0.1vw solid #868686;"> 
        <label><b>News Description: </b></label><br />
        <textarea ID="newsDes" name="S1" runat="server" placeholder="enter news descripton here" onfocus="TBFocus(1)"></textarea><br />
        <label><b>News related Image: </b></label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <label runat="server" id="jobimagerror" visible="false" style="font-size: 1.3vw; color: Red;">Kindly select a png, jpg or tiff file</label>
        <br />
        <button type="button" id="postButton" runat="server" onclick="CheckFields()">POST NEWS</button>
        <div style="display: none;"><asp:Button ID="postNews" runat="server" Text="Post" onclick="postNews_Click"  /></div>
        <br />
        
        </div>
        <br />
    </div>
    </asp:Panel>
    </div>
    </div>
    </form>

    <script>
        function TBFocus(temp) {
            if (temp == 1) {
                document.forms["form1"]["newsDes"].placeholder = "enter news description here";
                document.forms["form1"]["newsDes"].style.backgroundColor = "#f0f0f0";
            }
        }

        function CheckFields() {
            var desc = document.forms["form1"]["newsDes"].value;
            if (desc == "") {
                document.getElementById("newsDes").style.backgroundColor = "#f4898e";
                document.getElementById("newsDes").placeholder = "must fillout this field";
            }

            if (desc != "") {
                $('#postNews').trigger('click');
            }
        }
    </script>
</body>
</html>
