<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="FypWeb.Messages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <link id="Link1" rel="stylesheet" runat="server" media="screen" href="~/css/messages.css" />
    <title>UoK Alumni | Messages</title>
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>
</head>
<body>
    <div id="Nav-Messages"></div>

    <div class="Main-Section">
    <form id="form1" runat="server">

<div class="container">
<div class="Left-Panel">
<div class="MyUsersList">NETWORKS</div>
<div style="margin-bottom: 0.3vw">
<asp:TextBox id="SearchInput" placeholder="Search..." runat="server"></asp:TextBox>
<button type="button" id="Button1" class="SearchBtn" runat="server" onclick="SearchFunction()"><img id="SearchImg" src="images/SearchIco.png"/></button>
<div style="display: none;"><asp:Button ID="searchBackend" runat="server" Text="search" OnClick="search_click"/></div>
   </div>
    <div id="users" runat="server"> </div>
    </div>
<div class="Right-Panel" id="rp" runat="server"> 
<div class="MyMessages">CONVERSATION</div>
<div id="upperPart" runat="server">
    <div id="imageBG" style="float: left;"><asp:Image ID="recImage" runat="server"/></div>
   <div style="float: left; background-color: #154420; height: 3vw; width: 77.3%; line-height: 3vw;"> <asp:Label ID="recName" runat="server" style="color: #fcfcfc"></asp:Label> </div>
    <asp:Label ID="recId" runat="server" Visible="False"></asp:Label>
    <div style="height: 3vw; float:left;"><asp:Button ID="viewProf" runat="server" 
        Text="View Profile" onclick="viewProf_Click" /></div>
    </div>
    <br />
    <asp:Panel ID="msgPanel" runat="server" ScrollBars="Auto" style="margin: 1vw 0 1vw 0;">
    </asp:Panel>
<div>
    
        <textarea ID="msg" runat="server" rows="1" style="float: left;"></textarea>
        <asp:Button ID="send"  runat="server" style="float: right;" Text="SEND" onclick="send_Click" />

    </div>
</div>


</div>

   

    </form>
</div>
    <script>
        $(function () {
            $("#Nav-Messages").load("navBar.aspx");
        });

        var objDiv = document.getElementById("msgPanel");
        objDiv.scrollTop = objDiv.scrollHeight;

        function SearchFunction() {
            $('#searchBackend').trigger('click');
        }
    </script>
</body>
</html>
