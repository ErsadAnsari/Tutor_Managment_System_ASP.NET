<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="Tutor_Managment_System_Project.admin.Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
        <link href="~/assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="sweetalert2.min.css"> 

</head>
<body style="background-color:whitesmoke;">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 mx-auto" style="box-shadow: 1px 2px 25px 0px rgba(0,0,0,0.75);
-webkit-box-shadow: 1px 2px 25px 0px rgba(0,0,0,0.75);
-moz-box-shadow: 1px 2px 25px 0px rgba(0,0,0,0.75);">
                    <div class="jumbotron text-center text-white bg-primary">
                        <h2>Admin Login</h2>
                    </div>
                    <asp:TextBox ID="UsernameText" placeholder="Username" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UsernameText" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ErrorMessage="Enter username"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="passwordText" placeholder="password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="passwordText" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ErrorMessage="Enter password"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="LoginButton_Click" />
                   <div  style="text-align:center"><a href="../Default.aspx"  runat="server">Home</a></div>
                   
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </form>
    <script src="~/assets/vendor/jquery/js/jquery.min.js"></script>
     <script src="~/assets/vendor/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
