<%@ Page Title="" Language="C#" MasterPageFile="~/TMS_Site.Master" AutoEventWireup="true" CodeBehind="Tutor_Login.aspx.cs" Inherits="Tutor_Managment_System_Project.Tutor_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-4 mx-auto" style="box-shadow: 1px 2px 25px 0px rgba(0,0,0,0.75); -webkit-box-shadow: 1px 2px 25px 0px rgba(0,0,0,0.75); -moz-box-shadow: 1px 2px 25px 0px rgba(0,0,0,0.75);">
                <br />
                <div class="jumbotron text-center text-white bg-primary">
                    <h2>Tutor Login</h2>
                </div>
                <asp:TextBox ID="UsernameText" placeholder="Username" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UsernameText" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ErrorMessage="Enter username"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="passwordText" placeholder="password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="passwordText" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ErrorMessage="Enter password"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="StudentLoginButton" runat="server" OnClick="StudentLoginButton_Click" Text="Login" CssClass="btn btn-primary btn-block"  />
                <div class="text-center">
                    <a href="Student_Login.aspx" class="text-center">Student Login? click here</a>
                </div>
                <br />

            </div>
        </div>
    </div>
</asp:Content>