<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EShopping.User.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
/*For disappearing alert message*/
window.onload = function () {
var seconds = 5;
setTimeout(function () {
document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
}, seconds * 1000);
};
</script>
<script type="text/javascript">
function ImagePreview(input) {
if (input.files && input.files[0]) {
$('#<%=imgUser.ClientID %>').show();
var reader = new FileReader();
reader.onload = function (e) {
$('#<%=imgUser.ClientID%>').prop('src', e.target.result)
.width(200)
.height(200);
};
reader.readAsDataURL(input.files[0]);
}
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container pt-5">
<div class="align-self-end mb-4">
<asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
</div>
        <div class="text-center mb-5 pt-4">
            <h2 class="section-title px-5">
                <span class="px-2">
                    <asp:Label ID="lblHeaderMsg" runat="server" Text="USER REGISTRATION"></asp:Label>
                </span>
            </h2>
        </div>
        <div class="row px-xl-5">
            <div class="col-md-6">
                <div class="contact-form">
                    <div id="success"></div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Your Name" ControlToValidate="txtName"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name"
                            ToolTip="Full Name"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Your Name Must Be in Characters Only"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$"
                            ControlToValidate="txtName" Font-Size="Small">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Please Enter Your UserName" Font-Size="Small"
                            ControlToValidate="txtUsername" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter UserName"
                            ToolTip="Username"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Your Email" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter Email"
                            ToolTip="Email"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="Please Enter Your Mobile No" ControlToValidate="txtMobile"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter Mobile Number"
                            ToolTip="Mobile Number"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Your Mobile No With 8 digits Only,,,"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[0-9]{8}$"
                            ControlToValidate="txtMobile" Font-Size="Small">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="contact-form">
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter Your Address" ControlToValidate="txtAddress"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"
                            placeholder="Enter Address" ToolTip="Address"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="Please Enter Your Post_Code" ControlToValidate="txtPostCode"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPostCode" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter Postcode"
                            ToolTip="Post/Zip Code"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPostCode"
                            ErrorMessage="Please Enter Your Post_Code With 6 digits,,," ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                            ValidationExpression="[0-9]{6}" Font-Size="Small"></asp:RegularExpressionValidator>
                    </div>
                    <div class="pb-3">
                        <asp:FileUpload ID="fuUserImage" runat="server" CssClass="form-control" ToolTip="User Image"
                            onchange="ImagePreview(this);" />
                    </div>
                    <div class="pb-3">
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter Your PassWord,,," ControlToValidate="txtPassword"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"
                            ToolTip="Password"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row pl-4 mb-5">
                <div class="ml-2">
                    <asp:Button ID="btnRegisterOrUpdate" runat="server" Text="Register" CssClass="btn btn-primary py-2 px-4"
                        OnClick="btnRegisterOrUpdate_Click" />
                    <asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100"
                        Text="Already registered? <a href='Login.aspx' class='badge badge-info'>Login here..</a>">
                    </asp:Label>
                </div>
                <asp:Image ID="imgUser" runat="server" CssClass="img-thumbnail ml-2 mt-2" AlternateText="image" Style="display: none;" />
            </div>
        </div>

    </div>

</asp:Content>
