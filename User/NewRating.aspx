<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRating.aspx.cs" Inherits="EShopping.User.NewRating" %>

<%--<%@ Register Assembly="AjaxControlToolkit" TagName="AjaxControlToolkit" TagPrefix="asp" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../UserTemplate/css/style.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"  rel="stylesheet"/>
    <style>
        .starEmpty {
            background-image: url(../Images/Star/emptyStar.png);
            background-size:contain;
            width: 18px;
            height: 18px;
            margin-right:3px;
        }

        .starWaiting {
            background-image: url(../Images/Star/waitingStar.png);
            width: 18px;
            height: 18px;
            margin-right:3px;
        }

        .starFilled {
            background-image: url(../../Images/Star/filledStar.png);
            background-size:contain;
            width: 18px;
            height: 18px;
            margin-right:3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ajaxToolkit:Rating ID="Rating1" runat="server" StarCssClass="starEmpty" FilledStarCssClass="starFilled"
                EmptyStarCssClass="starEmpty" WaitingStarCssClass="starFilled" CurrentRating="1" MaxRating="5" >
            </ajaxToolkit:Rating>
            <div>
                <asp:Button ID="submit" runat="server" Text="click" OnClick="submit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
