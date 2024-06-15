<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="EShopping.User.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EShopping - Forget Password</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <!-- Favicon -->
    <link href="../UserTemplate/img/favicon.ico" rel="icon" />

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />

    <script>
        /*For disappearing alert message*/
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <br />
        <br />
        <div class="container">
            <div style="margin-bottom:20px;">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="row">
                <div class="row">
                    <div class="col-md-4 col-md-offset-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="text-center">
                                    <h3><i class="fa fa-lock fa-4x"></i></h3>
                                    <h2 class="text-center">Forgot Password?</h2>
                                    <p>Your Password Will Be Sent to Your Registered Email"Please Check"</p>
                                    <div class="panel-body">

                                        <div class="form">
                                            <fieldset>
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-at"></i></span>
                                                        <input id="txtUsername" runat="server" placeholder="Enter Username" class="form-control" type="text" required="" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                                                        Text="Send My Password" OnClick="btnSubmit_Click" />
                                                </div>
                                                <div class="form-group">
                                                    <div>
                                                        <a href="Login.aspx" class="badge badge-primary">Login Here..</a>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
