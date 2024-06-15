<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EShopping.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container pt-5 pb-5">
        <div class="align-self-end mb-4">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="text-center mb-4 pt-4">
            <h2 class="section-title px-5">
                <span class="px-2">
                    <asp:Label ID="lblHeaderMsg" runat="server" Text="Login"></asp:Label>
                </span>
            </h2>
        </div>
        <div class="row px-xl-5">
            <div class="col-md-7">
                <img id="userLogin" src="../Images/Loginn.jpg" alt="" class="img-thumbnail" />    
            </div>
            <div class="col-md-5 pt-sm-2">
                <div class="contact-form">
                    <div id="success"></div>
                    <div class="pb-4">
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Please Enter your UserName" Font-Size="Small"
                            ControlToValidate="txtUsername" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"
                            ToolTip="Username"></asp:TextBox>
                    </div>
                    <div class="pb-4">
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter your Password" ControlToValidate="txtPassword"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"
                            ToolTip="Password"></asp:TextBox>
                    </div>
                    <div class="btn_box">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary py-2 px-4" 
                            OnClick="btnLogin_Click"/>
                        <asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100"
                            Text="Forgot Password? <a href='ForgotPassword.aspx' class='badge badge-info'>Click here..</a>">
                        </asp:Label>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
