<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsFeed.aspx.cs" Inherits="FypWeb.NewsFeed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <title>UoK Alumni | Jobs</title>
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>

    <style>
        body { background-color: #f0f0f0; font-family: Lucida Sans Unicode; font-size: 1.3vw;}
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
    
    
    
    </style>
</head>
<body>
    <div id="Nav-Newsfeed"></div>
    <div id="Main-Section">

    <form id="form2" runat="server">
    <br />
    <div class="Custom-SearchBar" style="width: 30vw; float: left; margin-left: 1.6vw">
    <div class="col1"><asp:TextBox ID="SearchBar" runat="server" placeholder="search here..."></asp:TextBox></div>
    <div class="col3"><asp:Button ID="SearchButton" runat=server Text="Q" OnClick="searchNews_Click"/></div>
    </div>
    <br /><br />
    
    <asp:Panel ID="newsPanel" runat="server">
    
    <div id="JobHead" runat=server><label style="color: #fcfcfc; margin-left: 2vw; font-weight: bold;">LATEST NEWS</label></div>
    <br />
    </asp:Panel>
    
    </form>
    </div>
<script>
    $(function () {
        $("#Nav-Newsfeed").load("navBar.aspx");
    });
</script>
</body>
</html>
