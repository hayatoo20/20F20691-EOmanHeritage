<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="EShopping.User.Wishlist" %>
<%@ Import Namespace="EShopping" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Page Header Start -->
    <div class="container-fluid bg-secondary mb-5">
        <div class="d-flex flex-column align-items-center justify-content-center" style="min-height: 300px">
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Wishlist</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Wishlist</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <!-- Wishlist Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5">
            <div class="col-lg-12 table-responsive mb-5">
                <asp:Repeater ID="rWishlist" runat="server" OnItemCommand="rWishlist_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered text-center mb-0">
                    <thead class="bg-secondary text-dark">
                        <tr>
                            <th>Image</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody class="align-middle">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="align-middle">
                                <a href='<%# "ShopDetail.aspx?id=" + Eval("ProductId") %>'>
                                    <img src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="" style="width: 50px;">
                                </a>
                            </td>
                            <td class="align-middle">
                                <a href='<%# "ShopDetail.aspx?id=" + Eval("ProductId") %>'><%# Eval("ProductName") %></a>
                            </td>
                            <td class="align-middle"> OMR <%# Eval("Price") %> </td>
                            <td class="align-middle"> <%# Convert.ToInt32(Eval("Quantity")) > 1 ? "In stock" : "Out of stock" %> </td>
                            <td class="align-middle">
                                <asp:LinkButton ID="lbAddToCart" runat="server" CssClass="btn btn-primary px-3 mr-3" CommandName="addToCart"
                                        CommandArgument='<%# Eval("ProductId") %>'>
                                <i class="fa fa-shopping-cart mr-1"></i>Add To Cart</asp:LinkButton>
                            </td>
                            <td class="align-middle">
                                <%--<button class="btn btn-sm btn-primary"><i class="fa fa-times"></i></button>--%>
                                <asp:LinkButton ID="lbRemove" runat="server" CssClass="btn btn-sm btn-primary" CommandName="remove" 
                                    CommandArgument='<%# Eval("WishlistId") %>' CausesValidation="false">
                                    <i class="fa fa-times"></i>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <%--<table class="table table-bordered text-center mb-0">
                    <thead class="bg-secondary text-dark">
                        <tr>
                            <th>Products</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody class="align-middle">
                        <tr>
                            <td class="align-middle"><img src="../UserTemplate/img/product-1.jpg" alt="" style="width: 50px;"> Colorful Stylish Shirt</td>
                            <td class="align-middle">OMR 150</td>
                            <td class="align-middle"><%# Convert.ToInt32(Eval("Quantity")) > 1 ? "In stock" : "Out of stock" %></td>
                            <td class="align-middle">
                                <asp:LinkButton ID="lbAddToCart" runat="server" CssClass="btn btn-primary px-3 mr-3" CommandName="addToCart"
                                        CommandArgument='<%# Eval("ProductId") %>'>
                                <i class="fa fa-shopping-cart mr-1"></i>Add To Cart</asp:LinkButton>
                            </td>
                            <td class="align-middle"><button class="btn btn-sm btn-primary"><i class="fa fa-times"></i></button></td>
                        </tr>
                        
                    </tbody>
                </table>--%>
            </div>

        </div>
    </div>
    <!-- Wishlist End -->

</asp:Content>
