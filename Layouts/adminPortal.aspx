<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPortal.aspx.cs" Inherits="FypWeb.adminPortal" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral,
PublicKeyToken=B03F5F7F11D50A3A" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/admin-portal-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <title>UoK Alumni | Admin Portal</title>
    <script src="jquery/jquery340.js"></script>
</head>

<body>
    <form id="form1" runat="server" autocomplete="off">
    <div id="Navigation-Bar">
        <div id="adminNameBG"><label id="adminName" runat="server"></label></div>
        <asp:Button ID="newsPost" class="NavButtons" runat="server" Text="POST NEWS" OnClick="newsPost_Click" />
        <asp:Button ID="SearchUsers" class="NavButtons" runat="server" Text="SEARCH ALUMNI" OnClick="back1_Click"/>
        <asp:Button ID="accSetting" class="NavButtons" runat="server" Text="ACCOUNT SETTINGS" onclick="accSetting_Click"/>
        <asp:Button ID="adminLogout" class="NavButtons" runat="server" Text="LOGOUT" OnClick="adminLogout_Click" />
    </div>

    <div id="container">
        <div id="left-container">
            <div id="head">SEARCHING CRITERIA</div>      
            <div id="elements">
                <asp:Label ID="nameLabel" runat="server" Text="Alumni Name:"></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="nameTextbox" runat="server"></asp:TextBox><br />

                <asp:Label ID="departLabel" runat="server" Text="Department: "></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="departName" runat="server"></asp:TextBox><br />

                <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="emailTextbox" runat="server" ></asp:TextBox><br />

                <asp:Label ID="emailLabel4" runat="server" Text="Major"></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="major" runat="server" ></asp:TextBox><br />

                <asp:Label ID="enrollLabel" runat="server" Text="Enrollment Number"></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="enrol" runat="server"></asp:TextBox><br />

                <asp:Label ID="emailLabel1" runat="server" Text="CNIC"></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="cnic" runat="server" ></asp:TextBox><br />

                <asp:Label ID="emailLabel2" runat="server" Text="Profession"></asp:Label>
                <asp:TextBox class="Custom-TextBox" ID="prof" runat="server" ></asp:TextBox><br />

                <asp:Label ID="emailLabel3" runat="server" Text="City: "></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="city" runat="server" ></asp:TextBox><br />

                <asp:Label ID="clabel" runat="server" Text="Country:"></asp:Label><br />
                <asp:TextBox class="Custom-TextBox" ID="country" runat="server"></asp:TextBox><br />

                <asp:Button class="Left-Buttons" ID="search" runat="server" onclick="search_Click" Text="Search" />
                <asp:Button class="Left-Buttons" ID="reset"  runat="server" onclick="reset_Click"  Text="Reset"  />
            </div>
        </div>

        <div id="right-container">
            <!-------------------- Main Search Table -------------------->
            <div id="searchDiv" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" 
                DataKeyNames="userId" ForeColor="#313131" GridLines="None" Width="100%" CssClass="gridView"
                onselectedindexchanged="GridView1_SelectedIndexChanged" onrowdatabound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ItemStyle-Width="1%" ButtonType="Image" 
                    SelectText="select" SelectImageUrl="images/selecticon.png" ControlStyle-Width="15" 
                    ControlStyle-Height="15" HeaderStyle-Width="3%">
                        <ControlStyle Height="15px" Width="15px"></ControlStyle>
                        <HeaderStyle Width="3%"></HeaderStyle>
                        <ItemStyle Width="1%"></ItemStyle>
                    </asp:CommandField>

                    <asp:BoundField DataField="userId" HeaderText="ID" InsertVisible="False" 
                        ReadOnly="True" SortExpression="userId" ItemStyle-Width="2%" HeaderStyle-Width="3%">
<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle Width="2%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="enrolment" HeaderText="Enrolment" SortExpression="enrolment" />
                    <asp:BoundField DataField="cnic" HeaderText="CNIC" SortExpression="cnic" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="fatherName" HeaderText="Father Name" SortExpression="fatherName" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" ItemStyle-Width="10%" HeaderStyle-Width="10%">
<HeaderStyle Width="10%"></HeaderStyle>

                    <ItemStyle CssClass="col" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cellPhone" HeaderText="Cell Phone" SortExpression="cellPhone" HeaderStyle-Width="7%" ItemStyle-Width="7%">
<HeaderStyle Width="7%"></HeaderStyle>

                    <ItemStyle CssClass="col" />
                    </asp:BoundField>
                    <asp:BoundField DataField="profession" HeaderText="Profession" SortExpression="profession" />
                    <asp:BoundField DataField="username" HeaderText="User Name" SortExpression="username">
                    <ItemStyle CssClass="col" />
                    </asp:BoundField>
                    <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                    <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                    <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
                    <asp:BoundField DataField="class" HeaderText="Major" SortExpression="class" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#353535" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:Button ID="report" runat="server" Text="Generate Report" onclick="report_Click" Visible="true"/>
            </div>

            <!-------------------- Generated Report -------------------->
            <div id="Div1" runat="server" visible="False">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
                    CssClass="reportTable" Height="450px">
                    <LocalReport ReportPath="Report1.rdlc"></LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="FypWeb.DBSETTableAdapters."></asp:ObjectDataSource>
                <br />
            </div>

            <!-------------------- Alumni Separate Report -------------------->
            <div id="userview" runat="server" visible="False">
                <asp:Button ID="download" runat="server" onclick="Button1_Click" Text="Download PDF" />
                <asp:Button ID="back1" runat="server" onclick="back1_Click" Text="BACK" />
                <br />
                <div id="userReport" runat="server" visible="True">
                <table style="width: 70vw;" >
                <tr><td>
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Alumni Name: "></asp:Label></b></font>
                    <asp:Label ID="name" runat="server" Text="Label"></asp:Label></td>
                <td class="TablePadding">
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Father's Name: "></asp:Label></b></font>
                    <asp:Label ID="fname" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr><td>
                    <font color="#1f662f"><b><asp:Label runat="server" Text="CNIC Number: "></asp:Label></b></font>
                    <asp:Label ID="nic" runat="server" Text="Label"></asp:Label></td>
                <td class="TablePadding">
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Email ID: "></asp:Label></b></font>
                    <asp:Label ID="email" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr><td>
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Department: "></asp:Label></b></font>
                    <asp:Label ID="depart" runat="server" Text="Label"></asp:Label></td>
                <td class="TablePadding">
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Major: "></asp:Label></b></font>
                    <asp:Label ID="maj" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr><td>
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Contact Number: "></asp:Label></b></font>
                    <asp:Label ID="cellphone" runat="server" Text="Label"></asp:Label></td>
                <td class="TablePadding">
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Profession: "></asp:Label></b></font>
                    <asp:Label ID="profession" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr><td>
                    <font color="#1f662f"><b><asp:Label runat="server" Text="Address: "></asp:Label></b></font>
                    <asp:Label ID="address" runat="server"></asp:Label>
                    </td>
                <td class="TablePadding"></td>
                </tr>


                <tr>
                <td valign=top>
                <br />
                <label id="eduLabel" runat="server"><font color="#1f662f"><b>Education:</b></font></label>
                <asp:Table ID="eduTable" runat="server"></asp:Table><br />
                </td>
                <td class="TablePadding" valign=top>
                <br />
                <label id="langLabel" runat="server"><font color="#1f662f"><b>Language(s):</b></font></label><br />
                <asp:Table ID="langTable" runat="server"></asp:Table><br />
                </td>
                </tr>

                <tr>
                <td  valign=top>
                <label id="we" runat="server"><font color="#1f662f"><b>Work Experience: </b></font></label>
                <asp:Table ID="workTable" runat="server"></asp:Table><br />
                </td>

                <td class="TablePadding"  valign=top>
                <label id="profLabel" runat="server"><font color="#1f662f"><b>Professional Skill(s): </b></font></label><br />
                <asp:Table ID="profTable" runat="server"></asp:Table><br />
                </td>
                </tr>

                <tr>
                <td  valign=top><label id="cerLabel" runat="server"><font color="#1f662f"><b>Certification: </b></font></label><br />
                <asp:Table ID="cerTable" runat="server"></asp:Table><br /></td>
                <td class="TablePadding"></td>
                </tr>
                </table>
                <br />
                </div>
            </div>
        <br />
        <br />    



        </div> <!--- right ends here --->
    
    </div>
    <br /><br />
    
     
     
    </form>
</body>
</html>
