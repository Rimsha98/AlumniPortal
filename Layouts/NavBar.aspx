<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NavBar.aspx.cs" Inherits="FypWeb.NavBar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body { margin: 0; padding: 0; }
        .nav_bar{
            background-color: #154420;
            width: 100%;
            height: 2.7vw;
            color: #fcfcfc;
            font-size: 0;
        }   
        .Button-Modified{
            height: 2.7vw;
            margin: 0;
            font-size: 1vw;
            color: #fcfcfc;
            background-color: transparent;
            font-family: Lucida Sans Unicode;
            border: none;
            cursor: pointer;
            padding: 0.5vw 1vw 0.5vw 1vw;
            font-weight: normal;
            outline: none;
        }
        .Button-Modified:hover {background-color: #2e7a40;}
    </style>
</head>

<body>
    <form id="NavigationForm" runat="server">
    <div class="nav_bar">
        <asp:Button class="Button-Modified" OnClick="ProfilePage" style="margin-left: 0.2vw;" runat="server" Text="MY PROFILE"/>
        <asp:Button class="Button-Modified" OnClick="ViewCV" runat="server" Text="VIEW CV"/>
        <asp:Button class="Button-Modified" OnClick="EditCV" runat="server" Text="EDIT CV"/>
        <asp:Button class="Button-Modified" OnClick="Messages" runat="server" Text="MESSAGES"/>
        <asp:Button class="Button-Modified" OnClick="Jobs" runat="server" Text="JOBS"/>
        <asp:Button class="Button-Modified" OnClick="Newsfeed" runat="server" Text="NEWSFEED"/>
        <asp:Button class="Button-Modified" OnClick="Settings" runat="server" Text="ACCOUNT SETTINGS"/>
     <!--   <div style="display: inline-block;">
            <asp:TextBox id="SearchInput" placeholder="Search..." runat="server"></asp:TextBox>
            <button class="SearchBtn" runat="server"><img id="SearchImg" src="images/SearchIco.png"/></button>
        </div> -->
        <asp:Button class="Button-Modified" OnClick="Logout" style="float: right; margin-right: 0.2vw;" runat="server" Text="LOGOUT"/>
    </div>
    </form>
</body>
</html>
