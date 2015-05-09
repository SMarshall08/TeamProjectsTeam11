<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Site.master.cs" Inherits="Team11.SiteMaster" %>

<!DOCTYPE html>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">

<head runat="server">
    
    <title>Timetabling System</title>
    
    <!-- Favicon -->
    <link rel="icon" type="image/png" href="Resources/lulogo.png" />

    <!-- Google Font -->
    <link href="http://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css" />

    <!-- Latest compiled and minified CSS -->
    <link rel="Stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" />

    <!-- Site Css -->
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

    <!-- Jquery -->
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <!-- Latest compiled and minified Javascript -->
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>

    <!-- Loaded .aspx header content -->
    <asp:ContentPlaceHolder ID="HeadContent" runat="server">
    </asp:ContentPlaceHolder>
    
    <!-- Bootstrap Navbar -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>

    <style type="text/css">
        .auto-style1 {
            margin-left: auto;
            margin-right: 58;
            text-align: center;
            width: 96%;
        }
    </style>

</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         
         <!-- Navbar
         --------------------------------------------------------->
        <!-- <div class="navbar">
            <!--<div class="center"> -->
               <!-- <ul class="auto-style1">
                    <li><img alt="Loughborough University Logo" class="navlogo" src="Resources/lulogo-internal.jpg" /></li>
                    <li><a href="CreateRequest.aspx">Request</a></li>
                    <li><a href="ViewRequest.aspx">View Request</a></li>
                    <li><a href="Availibility.aspx">Ad Hoc</a></li>
                    <li><a href="Schedule.aspx">Schedule</a></li>
                    <li><a href="AddEditModule.aspx">Modules</a></li>
                    <li><a href="Preference.aspx">Preferences</a></li>
                    <li><a href="Manage.aspx">Manage</a></li>
                    <li><a href="Admin.aspx">Admin</a></li>
                    <li><a href="Default.aspx">Logout</a></li>
                  
                </ul>    
            <!--</div>-->    
       <!-- </div> -->
         

<script type="text/javascript">
$(document).ready(function () {
    var url = window.location;
    $('ul.nav a[href="' + url + '"]').parent().addClass('active');
    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('active').parent().parent().addClass('active');
});
</script>

<nav class="navbar navbar-custom">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#"> 
          <img alt="Loughborough University Logo" class="navlogo" src="Resources/lulogo-internal.jpg" />
      </a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <li><a href="CreateRequest.aspx">Request</a></li>
        <li><a href="ViewRequest.aspx">View Request</a></li>
        <li><a href="Availibility.aspx">Ad Hoc</a></li>
        <li><a href="Schedule.aspx">Schedule</a></li>
        <li><a href="AddEditModule.aspx">Modules</a></li>
        <li><a href="Preference.aspx">Preferences</a></li>
        <li><a href="Manage.aspx">Manage</a></li>
      </ul>
      <ul class="nav navbar-nav navbar-right">
        <!--<li><a href="Admin.aspx">Admin</a></li> -->
        <li><a href="Default.aspx">Logout</a></li>
      </ul>
    </div>
  </div>
</nav>
        

        <!-- Overall page container -->
        <div class="page">
            <div class="header">
                <asp:ContentPlaceHolder ID="TitleContent" runat="server"/>
            </div>
            
            <!-- Load .aspx body content -->
            <div class="main">
                <asp:ContentPlaceHolder ID="MainContent" runat="server"/>
            </div>
            <div class="clear"></div>
        </div><!-- ./page -->
    </form>
    <div class="navbar navbar-inverse narbar-fixed-bottom" role="navigation">
        <div class="container">
            <div class="navbar-text pull-left">

                <div id="displayRound" runat="server"></div>
            </div>
            
        </div>


    </div>
</body>
</html>
