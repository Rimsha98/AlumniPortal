<%@ Page MaintainScrollPositionOnPostback=true Language="C#" AutoEventWireup="true" CodeBehind="UpdateCV.aspx.cs" Inherits="FypWeb.cv" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" media="screen" runat="server" href="~/css/update-cv-styles.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <script src="jquery/jquery311.js"></script>
    <script src="jquery/jquery1102.js"></script>
    <script src="jquery/jquery123.js"></script>
    <title>UoK Alumni | Update CV</title>
</head>

<body onload="javascript:document.getElementById('cvDiv').scrollTop = document.getElementById('scroll').value;" >
    <div id="Nav-UpdateCV"></div>
    
    <div class="Main-Section">
    <form id="form1" runat="server">
        <div id="cvDiv" runat="server">
            <input type="hidden" id="scroll" runat="server" />
            <p> All your recorded information has been loaded in the fields below.</p>

            <!----- Section One ----->
            <div class="EditCVHeads">General Information</div>
            <table cellspacing=0 style="width: 100%;">
            <tr>
                <td class="col-left"><label>Profession: </label></td>
                <td class="col-right"><asp:TextBox ID="profession" class="InputTBoxes" runat="server" MaxLength="45" placeholder="enter your current profession here"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="col-left"><label>About: </label></td>
                <td class="col-right"><asp:TextBox ID="about" class="InputTBoxes" runat="server" TextMode="MultiLine" MaxLength="400" placeholder="enter something career related about you"></asp:TextBox></td>
            </tr>
            </table><br />

            <!----- Section Two ----->
            <div class="EditCVHeads">Contact Information</div>
            <table cellspacing=0 style="width: 100%;">
            <tr>
                <td class="col-left"><label>Address: </label></td>
                <td class="col-right"><asp:TextBox ID="address" class="InputTBoxes" runat="server" TextMode="MultiLine" MaxLength="100" placeholder="enter your residential address"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="col-left"><label>Contact Number: </label></td>
                <td class="col-right"><asp:TextBox ID="cellPhone" class="InputTBoxes" runat="server" MaxLength="13" placeholder="enter your mobile number" onfocus="TBFocus(1)"></asp:TextBox><br />
                <label id="WrongNumber" runat="server" visible="false" class="ErrorMsg">Mobile number must be in correct format.</label>
                </td>
            </tr>
            <tr>
                <td class="col-left"><label>Email ID: </label></td>
                <td class="col-right"><asp:TextBox ID="email" class="InputTBoxes" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            </table><br />

            <!----- Section Three ----->
            <div class="EditCVHeads">Professional Skills</div>
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>New Skill: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="profSkill" class="InputTBoxes" runat="server" MaxLength="150" placeholder="enter your professional skill" onfocus="TBFocus(2)"></asp:TextBox>
                    <asp:Button ID="addSkill" class="AddButtons" runat="server" type="button" onclick="addSkill_Click" Text="+ADD" />
                    </td>
                </tr>
                <tr>
                    <td class="col-left"></td>
                    <td class="col-right">
                    <asp:Table ID="skillCvTable" runat="server" class="DynTable">
                        <asp:TableRow ID="TableRow1" runat="server" GridLines="Both" >
                            <asp:TableCell ID="TableCell1" runat="server"><b>Professional Skills List: </b></asp:TableCell>
                            <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    </td>
                </tr>
            </table><br />

            <!----- Section Four ----->
            <div class="EditCVHeads">Languages</div>
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>New Language: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="lang" class="InputTBoxes" runat="server" MaxLength="30" placeholder="enter the language(s) you speak" onfocus="TBFocus(3)"></asp:TextBox>
                    <asp:Button ID="addLang" class="AddButtons" runat="server" type="button" Text="+ADD" OnClick="addLang_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="col-left"></td>
                    <td class="col-right">
                    <asp:Table ID="langCvTable" runat="server" class="DynTable">
                        <asp:TableRow ID="TableRow2" runat="server">
                            <asp:TableCell ID="TableCell3" runat="server"><b>Languages List: </b></asp:TableCell>
                            <asp:TableCell ID="TableCell4" runat="server"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    </td>
                </tr>
            </table><br />

            <!----- Section Five ----->
            <div class="EditCVHeads">Work Experience</div>
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>New Experience: </label></td>
                    <td class="col-right"><asp:TextBox ID="workExp" class="InputTBoxes" runat="server" placeholder="enter your work experience" onfocus="TBFocus(4)" MaxLength="100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="col-left"><label>Description: </label></td>
                    <td class="col-right"><asp:TextBox ID="workDes" class="InputTBoxes" runat="server" TextMode="MultiLine" placeholder="describe your work experience" onfocus="TBFocus(5)" MaxLength="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="col-left"><label>Years active: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="workYear1" class="InputTBoxes" runat="server"  data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(6)"></asp:TextBox>
                    <label> to </label>
                    <asp:TextBox ID="workYear2" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(7)"></asp:TextBox>
                    <asp:Button ID="addExp" runat="server" class="AddButtons" type="button" Text="+ADD" OnClick="addExp_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="col-left"></td>
                    <td class="col-right">
                    <asp:Table ID="expCvTable" runat="server" class="DynTable">
                        <asp:TableRow ID="TableRow3" runat="server">
                            <asp:TableCell ID="TableCell5" runat="server"><b>Title</b></asp:TableCell>
                            <asp:TableCell ID="TableCell6" runat="server"><b>Description</b></asp:TableCell>
                            <asp:TableCell ID="TableCell7" runat="server"><b>From</b></asp:TableCell>
                            <asp:TableCell ID="TableCell8" runat="server"><b>To</b></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    </td>
                </tr>
            </table><br />


            <!----- Section Six ----->
            <div class="EditCVHeads">Education</div>
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>University: </label></td>
                    <td class="col-right"><input id="uniName" class="InputTBoxes" type="text" runat="server" placeholder="enter your university name" onfocus="TBFocus(8)" maxlength="200"/></td>
                </tr>
                <tr>
                    <td class="col-left"><label>Degree: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="uniDegree" class="InputTBoxes" runat="server" placeholder="enter your degree" onfocus="TBFocus(9)" MaxLength="50"></asp:TextBox>
                    <label style="margin-left: 2.4vw; ">Major: </label>
                    <input id="uniMajor" class="InputTBoxes" type="text" runat="server" placeholder="enter your major" onfocus="TBFocus(10)" maxlength="50"/>
                    </td>
                </tr>
                <tr>
                    <td class="col-left"><label>Years: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="uniYear1" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(11)"></asp:TextBox>
                    <label> to </label>
                    <asp:TextBox ID="uniYear2" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(12)"></asp:TextBox>
                    <asp:Button ID="addUni" class="AddButtons" runat="server" type="button" Text="+ADD" OnClick="addUni_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="col-left"></td>
                    <td class="col-right">
                        <br />
                        <asp:Table ID="uniCvTable" runat="server" >
                            <asp:TableRow ID="TableRow4" runat="server">
                                <asp:TableCell ID="TableCell9" runat="server">University</asp:TableCell>
                                <asp:TableCell ID="TableCell10" runat="server">Major</asp:TableCell>
                                <asp:TableCell ID="TableCell11" runat="server">Degree</asp:TableCell>
                                <asp:TableCell ID="TableCell12" runat="server">From</asp:TableCell>
                                <asp:TableCell ID="TableCell13" runat="server">To</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </td>
                </tr>
            </table>
 
            <br /><hr />
                
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>High School: </label></td>
                    <td class="col-right"><input id="clgName" class="InputTBoxes" type="text" runat="server"  maxlength="200" placeholder="enter your high school name" onfocus="TBFocus(13)"/></td>
                </tr>
                <tr>
                    <td class="col-left"><label>Degree: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="clgDegree" class="InputTBoxes" runat="server" MaxLength="50" placeholder="enter your degree" onfocus="TBFocus(14)"></asp:TextBox>
                    <label style="margin-left: 2.4vw; ">Major: </label>
                    <input id="clgMajor" class="InputTBoxes" type="text" runat="server" maxlength="50" placeholder="enter your degree" onfocus="TBFocus(15)"/>
                    </td>
                </tr>
                <tr>
                    <td class="col-left"><label>Years: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="clgYear1" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" placeholder="0000" MaxLength="4" onfocus="TBFocus(16)"></asp:TextBox>
                    <label> to </label>
                    <asp:TextBox ID="clgYear2" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" placeholder="0000" MaxLength="4" onfocus="TBFocus(17)"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br /><hr />
                
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>School: </label></td>
                    <td class="col-right"><input id="schName" class="InputTBoxes" type="text" runat="server"  maxlength="200" placeholder="enter your school name" onfocus="TBFocus(18)"/></td>
                </tr>
                <tr>
                    <td class="col-left"><label>Degree: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="schDegree" class="InputTBoxes" runat="server" MaxLength="50" placeholder="enter your degree" onfocus="TBFocus(19)"></asp:TextBox>
                    <label style="margin-left: 2.4vw; ">Major: </label>
                    <input id="schMajor" class="InputTBoxes" type="text" runat="server" maxlength="50" placeholder="enter your major" onfocus="TBFocus(20)"/>
                    </td>
                </tr>
                <tr>
                    <td class="col-left"><label>Years: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="schYear1" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(21)"></asp:TextBox>
                    <label> to </label>
                    <asp:TextBox ID="schYear2" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(22)"></asp:TextBox>
                    </td>
                </tr>
            </table><br />

            <!----- Section Seven ----->
            <div class="EditCVHeads">Certification</div>
            <table cellspacing=0 style="width: 100%;">
                <tr>
                    <td class="col-left"><label>Certificate: </label></td>
                    <td class="col-right"><input id="cerTitle" class="InputTBoxes" type="text" runat="server" maxlength="120" placeholder="enter the certification you achieved" onfocus="TBFocus(23)"/></td>
                </tr>
                <tr>
                    <td class="col-left"><label>Years: </label></td>
                    <td class="col-right">
                    <asp:TextBox ID="cerYear1" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(24)"></asp:TextBox>
                    <label> to </label>
                    <asp:TextBox ID="cerYear2" class="InputTBoxes" runat="server" data-inputmask="'mask': '9999'" MaxLength="4" placeholder="0000" onfocus="TBFocus(25)"></asp:TextBox>
                    <asp:Button ID="addCertification" class="AddButtons" runat="server" type="button" Text="+ADD" OnClick="addCertification_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="col-left"></td>
                    <td class="col-right">
                        <asp:Table ID="certificationCvTable" runat="server">
                        <asp:TableRow ID="TableRow5" runat="server">
                            <asp:TableCell ID="TableCell14" runat="server">Title</asp:TableCell>
                            <asp:TableCell ID="TableCell15" runat="server">From</asp:TableCell>
                            <asp:TableCell ID="TableCell16" runat="server">To</asp:TableCell>
                        </asp:TableRow>
                     </asp:Table>
                    </td>
                </tr>
                </table>

                <br /><br />
            <asp:Button ID="saveChanges" class="AddButtons" runat="server" Text="SAVE CHANGES" onclick="saveChanges_Click"/>
            <asp:Button ID="CancelChanges" class="AddButtons" runat="server" Text="CANCEL" OnClick="Cancel_Changes"/>
            <br />
            </div>
            <br /><br />
            <div visible=false id="saved" runat=server>
                <p id="para" style="margin: 0;">All changes were made successfully.</p>
                <p id="para" style="color: Red; margin: 0; vertical-align: middle;">Redirecting you to your CV now . . . </p>
            </div>
    </form>
    <br /><br />
    </div>

    <script src="jquery/jquery311.js"></script>
<script src="jquery/jqueryinputmask.js"></script>

    <script>

        $("#workYear1").inputmask();
        $("#workYear2").inputmask();
        $("#uniYear1").inputmask();
        $("#uniYear2").inputmask();
        $("#clgYear1").inputmask();
        $("#clgYear2").inputmask();
        $("#schYear1").inputmask();
        $("#schYear2").inputmask();
        $("#cerYear1").inputmask();
        $("#cerYear2").inputmask();


        $(function () {
            $("#Nav-UpdateCV").load("navBar.aspx");
        });

        function TBFocus(temp) {
            if (temp == 1) {
                document.forms["form1"]["cellPhone"].placeholder = "enter your mobile number";
                document.forms["form1"]["cellPhone"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 2) {
                document.forms["form1"]["profSkill"].placeholder = "enter your professional skill";
                document.forms["form1"]["profSkill"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 3) {
                document.forms["form1"]["lang"].placeholder = "enter the language(s) you speak";
                document.forms["form1"]["lang"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 4) {
                document.forms["form1"]["workExp"].placeholder = "enter your work experience";
                document.forms["form1"]["workExp"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 5) {
                document.forms["form1"]["workDes"].placeholder = "describe your work experience";
                document.forms["form1"]["workDes"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 6) {
                document.forms["form1"]["workYear1"].placeholder = "0000";
                document.forms["form1"]["workYear1"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 7) {
                document.forms["form1"]["workYear2"].placeholder = "0000";
                document.forms["form1"]["workYear2"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 8) {
                document.forms["form1"]["uniName"].placeholder = "enter your university name";
                document.forms["form1"]["uniName"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 9) {
                document.forms["form1"]["uniDegree"].placeholder = "enter your degree";
                document.forms["form1"]["uniDegree"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 10) {
                document.forms["form1"]["uniMajor"].placeholder = "enter your major";
                document.forms["form1"]["uniMajor"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 11) {
                document.forms["form1"]["uniYear1"].placeholder = "0000";
                document.forms["form1"]["uniYear1"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 12) {
                document.forms["form1"]["uniYear2"].placeholder = "0000";
                document.forms["form1"]["uniYear2"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 13) {
                document.forms["form1"]["clgName"].placeholder = "enter your high school name";
                document.forms["form1"]["clgName"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 14) {
                document.forms["form1"]["clgDegree"].placeholder = "enter your degree";
                document.forms["form1"]["clgDegree"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 15) {
                document.forms["form1"]["clgMajor"].placeholder = "enter your major";
                document.forms["form1"]["clgMajor"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 16) {
                document.forms["form1"]["clgYear1"].placeholder = "0000";
                document.forms["form1"]["clgYear1"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 17) {
                document.forms["form1"]["clgYear2"].placeholder = "0000";
                document.forms["form1"]["clgYear2"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 18) {
                document.forms["form1"]["schName"].placeholder = "enter your school name";
                document.forms["form1"]["schName"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 19) {
                document.forms["form1"]["schDegree"].placeholder = "enter your degree";
                document.forms["form1"]["schDegree"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 20) {
                document.forms["form1"]["schMajor"].placeholder = "enter your major";
                document.forms["form1"]["schMajor"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 21) {
                document.forms["form1"]["schYear1"].placeholder = "0000";
                document.forms["form1"]["schYear1"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 22) {
                document.forms["form1"]["schYear2"].placeholder = "0000";
                document.forms["form1"]["schYear2"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 23) {
                document.forms["form1"]["cerTitle"].placeholder = "enter your certification you achieved";
                document.forms["form1"]["cerTitle"].style.backgroundColor = "#f0f0f0";
            }

            if (temp == 24) {
                document.forms["form1"]["cerYear1"].placeholder = "0000";
                document.forms["form1"]["cerYear1"].style.backgroundColor = "#f0f0f0";
            }
            if (temp == 25) {
                document.forms["form1"]["cerYear2"].placeholder = "0000";
                document.forms["form1"]["cerYear2"].style.backgroundColor = "#f0f0f0";
            }
        }




</script>
</body>
</html>
