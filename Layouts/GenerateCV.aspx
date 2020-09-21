<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateCV.aspx.cs" Inherits="FypWeb.GenerateCV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head id="Head1" runat="server">
    <link id="Link1" rel="stylesheet" runat="server" media="screen" href="~/css/cv-template-style.css" />
    <link rel="shortcut icon" type="image/x-icon" href="~/icons/iconalumni.ico">
    <title>Alumnus CV</title>
    <script src="jquery/jquery135.js"></script>
    <script src="jquery/jquery1124.js"></script>
</head>

<body>
<div id="Nav-CV"></div>
<div class="Main-Section">
<h1 id="CVH1">USER CV</h1>
<p id="CVP1" style="margin: 0; margin-left: 0.5vw;">Following is the CV we have generated using the information you have provided.
<br />* Note: This CV is for <span style="color: Red;">your</span> view only.</p>
<input type="button" id="create_pdf" value="DOWNLOAD PDF" >  
<button id="edit_cv" onclick="EditCVPage()">EDIT CV</button>

<form class="form">
    <div class="CV-Layout">
        <div class="Left-Panel">
            <div class="Name-Section">
                <h1 id="CV_Name" runat="server"></h1>
                <h2 id="CV_Profession" runat="server"></h2>
            </div>
            
            <div class="Contact-Section">
                <div class="heading"><h1>Contact Information</h1></div>
                <h1 class="sub-heading">Phone</h1>
                    <p id="CV_Phone" runat="server"></p>
                <h1 class="sub-heading">Email</h1>
                    <p id="CV_Email" runat="server"></p>
                <h1 class="sub-heading" runat="server" id="address_label">Address</h1>
                    <p id="CV_Address" runat="server"></p>
            </div>

            <div runat="server" class="Skills-Section" id="Skills_Div">
                <div class="heading"><h1>Professional Skills</h1></div>
                        <p id="CV_Skill" runat="server"></p>
                </div> 
             
            <div runat="server" class="Lang-Section" id="Lang_Div">
                <div class="heading"><h1>Languages</h1></div>
            </div>
        </div>
    
        <div class="Right-Panel">
            <div class="TopDesc-Section">
                <p id="CV_InitParahgraph" runat="server"></p>
            </div>

            <div class="Main-heading">
                <h1>Work Experience</h1>
                <hr class="partition"/>
            </div>

            <div class="Work-Section">
             <p id="CV_Exp" runat="server"></p>
             <table cellspacing="0" id="CV_ExpTable" runat="server">
                </table>
            </div>

            <div class="Main-heading">
                <h1>Education</h1>
                <hr class="partition"/>
            </div>

            <div class="Work-Section">
                <table cellspacing="0" style="margin-top: 0.6vw" id="CV_EducationTable" runat="server">
                </table>
            </div>

            <div class="Main-heading">
                <h1>Certification</h1>
                <hr class="partition"/>
            </div>

            <div class="Work-Section">
             <p id="CV_Certi" runat="server"></p>
             <table cellspacing="0" style="margin-top: 0.6vw" id="CV_CertTable" runat="server">
             </table>
             </div>
        </div>
    </div>
</form>  
</div>

<script src="https://code.jquery.com/jquery-1.12.4.min.js" integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ=" crossorigin="anonymous"></script>  
<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.5/jspdf.min.js"></script>
  

<script>
    (function () {
        var 
         form = $('.form'),
         cache_width = form.width(),
         a4 = [595.28, 841.89]; // for a4 size paper width and height  

        $('#create_pdf').on('click', function () {
            $('CV-Layout').scrollTop(0);
            createPDF();
        });

        function createPDF() {
            getCanvas().then(function (canvas) {
                var 
                 img = canvas.toDataURL("image/png"),
                 doc = new jsPDF({
                     unit: 'px',
                     format: 'a4'
                 });
                doc.addImage(img, 'JPEG', 20, 20);
                 doc.save('Test.pdf');
                form.width(cache_width);
            });
        }

        // create canvas object  
        function getCanvas() {
            form.width((a4[0] * 1.33333) - 80).css('max-width', 'none');
            return html2canvas(form, {
                imageTimeout: 2000,
                removeContainer: true
            });
        }

    } ());  
</script>

<script>
    $(function () {
        $("#Nav-CV").load("navBar.aspx");
    });

    function EditCVPage() {
        location.replace("UpdateCV.aspx");
    }
</script>

  
<%--<script type="text/javascript">
    /* 
    * jQuery helper plugin for examples and tests 
    */
    (function ($) {
        $.fn.html2canvas = function (options) {
            var date = new Date(),
            $message = null,
            timeoutTimer = false,
            timer = date.getTime();
            html2canvas.logging = options && options.logging;
            html2canvas.Preload(this[0], $.extend({
                complete: function (images) {
                    var queue = html2canvas.Parse(this[0], images, options),
                    $canvas = $(html2canvas.Renderer(queue, options)),
                    finishTime = new Date();

                    $canvas.css({ position: 'absolute', left: 0, top: 0 }).appendTo(document.body);
                    $canvas.siblings().toggle();

                    $(window).click(function () {
                        if (!$canvas.is(':visible')) {
                            $canvas.toggle().siblings().toggle();
                            throwMessage("Canvas Render visible");
                        } else {
                            $canvas.siblings().toggle();
                            $canvas.toggle();
                            throwMessage("Canvas Render hidden");
                        }
                    });
                    throwMessage('Screenshot created in ' + ((finishTime.getTime() - timer) / 1000) + " seconds<br />", 4000);
                }
            }, options));

            function throwMessage(msg, duration) {
                window.clearTimeout(timeoutTimer);
                timeoutTimer = window.setTimeout(function () {
                    $message.fadeOut(function () {
                        $message.remove();
                    });
                }, duration || 2000);
                if ($message)
                    $message.remove();
                $message = $('<div ></div>').html(msg).css({
                    margin: 0,
                    padding: 10,
                    background: "#000",
                    opacity: 0.7,
                    position: "fixed",
                    top: 10,
                    right: 10,
                    fontFamily: 'Tahoma',
                    color: '#fff',
                    fontSize: 12,
                    borderRadius: 12,
                    width: 'auto',
                    height: 'auto',
                    textAlign: 'center',
                    textDecoration: 'none'
                }).hide().fadeIn().appendTo('body');
            }
        };
    })(jQuery);  
  
</script>  --%>
</body>
</html>