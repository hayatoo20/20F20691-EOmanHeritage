<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ShopDetail.aspx.cs" Inherits="EShopping.User.ShopDetail" %>

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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Shop Detail</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Shop Detail</p>
            </div>
        </div>
    </div>
    <!-- Page Header End -->

    <div class="ml-5">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <!-- Shop Detail Start -->
    <div class="container-fluid py-5">
        
        <asp:Repeater ID="rProductDetails" runat="server" OnItemDataBound="rProductDetails_ItemDataBound"
            OnItemCommand="rProductDetails_ItemCommand">
            <ItemTemplate>

                <div class="row px-xl-5">
                    <div class="col-lg-5 pb-5">
                        <div id="product-carousel" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner border">
                                <div class="carousel-item active">
                                    <img class="w-100 h-100" src="../<%# Eval("Image1").ToString().Substring(0, Eval("Image1").ToString().IndexOf(":")) %>" alt="Image">
                                </div>
                                <div class="carousel-item">
                                    <img class="w-100 h-100" src="../<%# Eval("Image2").ToString().Substring(0, Eval("Image2").ToString().IndexOf(":")) %>" alt="Image">
                                </div>
                                <div class="carousel-item">
                                    <img class="w-100 h-100" src="../<%# Eval("Image3").ToString().Substring(0, Eval("Image3").ToString().IndexOf(":")) %>" alt="Image">
                                </div>
                                <div class="carousel-item">
                                    <img class="w-100 h-100" src="../<%# Eval("Image4").ToString().Substring(0, Eval("Image4").ToString().IndexOf(":")) %>" alt="Image">
                                </div>
                            </div>
                            <a class="carousel-control-prev" href="#product-carousel" data-slide="prev">
                                <i class="fa fa-2x fa-angle-left text-dark"></i>
                            </a>
                            <a class="carousel-control-next" href="#product-carousel" data-slide="next">
                                <i class="fa fa-2x fa-angle-right text-dark"></i>
                            </a>
                        </div>
                    </div>

                    <div class="col-lg-7 pb-5">
                        <h3 class="font-weight-semi-bold"><%# Eval("ProductName") %></h3>
                        <div class="d-flex mb-3">
                            <div class="text-primary mr-2">
                                <%--<small class="fas fa-star"></small>
                                <small class="fas fa-star"></small>
                                <small class="fas fa-star"></small>
                                <small class="fas fa-star-half-alt"></small>
                                <small class="far fa-star"></small>--%>
                                <ajaxToolkit:Rating ID="userRating2" runat="server" StarCssClass="starEmpty"
                                    FilledStarCssClass="starFilled" EmptyStarCssClass="starEmpty"
                                    WaitingStarCssClass="starFilled" MaxRating="5" ReadOnly="true">
                                </ajaxToolkit:Rating>
                            </div>
                            <small class="pt-1">(<%Response.Write(Session["reviewCount"]); %> Reviews)</small>
                        </div>
                        <div class="d-flex mb-3">
                            <p class="text-dark font-weight-medium mb-0 mr-2">Brand:</p>
                            <%# Eval("CompanyName") %>
                        </div>
                        <h3 class="font-weight-semi-bold mb-4">OMR <%# Eval("Price") %></h3>
                        <p class="mb-4"><%# Eval("ShortDescription") %> </p>

                        <div class="d-flex mb-3">
                            <p class="text-dark font-weight-medium mb-0 mr-2">Category:</p>
                            <%# Eval("CategoryName") %>
                        </div>

                        <div class="d-flex mb-3">
                            <p class="text-dark font-weight-medium mb-0 mr-2">Sub-Category:</p>
                            <%# Eval("SubCategoryName") %>
                        </div>

                        <div class='<%# (Eval("Size").ToString() != string.Empty ? "d-flex mb-3" : null) %>'
                            style='<%# "display:" + (Eval("Size").ToString() == string.Empty ? "none" : null) + ";" %>'>
                            <p class="text-dark font-weight-medium mb-0 mr-3">Sizes:</p>
                            <div>
                                <asp:RadioButtonList ID="rblSizes" runat="server" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvSizes" runat="server" ErrorMessage="Select any size" ForeColor="Red"
                                    ControlToValidate="rblSizes" ValidationGroup="customText" Display="Dynamic" SetFocusOnError="true"
                                    Font-Size="Small">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class='<%# (Eval("Color").ToString() != string.Empty ? "d-flex mb-4" : null) %>' 
                            style='<%# "display:" + (Eval("Color").ToString() == string.Empty ? "none" : null) + ";" %>' >
                            <p class="text-dark font-weight-medium mb-0 mr-3">Colors:</p>
                            <div>
                                <asp:RadioButtonList ID="rblColors" runat="server" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvColors" runat="server" ErrorMessage="Select any color" ForeColor="Red"
                                    ControlToValidate="rblColors" ValidationGroup="customText" Display="Dynamic" SetFocusOnError="true"
                                    Font-Size="Small">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class='<%# (Convert.ToBoolean(Eval("IsCustomized").ToString()) == true ? "d-flex mb-4" : "") %>'
                            style='<%# "display:" + (Convert.ToBoolean(Eval("IsCustomized").ToString()) == false ? "none" : null) + ";" %>' >
                            <p class="text-dark font-weight-medium mb-0 mr-3">Custom Text:</p>
                            <div>
                                <asp:TextBox ID="txtCustomText" runat="server" CssClass="form-control" placeholder="Ex: Ms.Hayat"
                                    required></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCustomText" runat="server" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txtCustomText" ErrorMessage="Customized text message is required"
                                    Font-Size="Small" SetFocusOnError="true" ValidationGroup="customText"
                                    Enabled='<%# Convert.ToBoolean(Eval("IsCustomized").ToString())  %>'></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="d-flex align-items-center mb-4 pt-2">
                            <div class="input-group quantity mr-3" style="width: 130px;">
                                <div class="input-group-btn">
                                    <span class="btn btn-primary btn-minus">
                                        <i class="fa fa-minus"></i>
                                    </span>
                                </div>
                                <input type="text" id="txtQuantity" runat="server" class="form-control bg-secondary text-center" value="1">
                                <%--<asp:TextBox ID="txtQuantity" CssClass="form-control bg-secondary text-center" runat="server" TextMode="Number"></asp:TextBox>--%>
                                <div class="input-group-btn">
                                    <span class="btn btn-primary btn-plus">
                                        <i class="fa fa-plus"></i>
                                    </span>
                                </div>
                            </div>
                            <%--<button class="btn btn-primary px-3 mr-3"><i class="fa fa-shopping-cart mr-1"></i>Add To Cart</button>--%>
                            <asp:LinkButton ID="lbAddToCart" runat="server" CssClass="btn btn-primary px-3 mr-3" CommandName="addToCart"
                                CommandArgument='<%# Eval("ProductId") %>' ValidationGroup="customText">
                                <i class="fa fa-shopping-cart mr-1"></i>Add To Cart</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbWishlist" CssClass="btn btn-primary" CausesValidation="false"
                                CommandName="addToWishlist" CommandArgument='<%# Eval("ProductId") %>'>
                                        <i class="fa fa-heart"></i>
                            </asp:LinkButton>
                        </div>
                        <div class="d-flex pt-2">
                            <p class="text-dark font-weight-medium mb-0 mr-2">Share on:</p>
                            <div class="d-inline-flex">
                                <a class="text-dark px-2" href="">
                                    <i class="fab fa-facebook-f"></i>
                                </a>
                                <a class="text-dark px-2" href="">
                                    <i class="fab fa-twitter"></i>
                                </a>
                                <a class="text-dark px-2" href="">
                                    <i class="fab fa-linkedin-in"></i>
                                </a>
                                <a class="text-dark px-2" href="">
                                    <i class="fab fa-pinterest"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row px-xl-5">
                    <div class="col">
                        <div class="nav nav-tabs justify-content-center border-secondary mb-4">
                            <a class="nav-item nav-link active" data-toggle="tab" href="#tab-pane-1">Description</a>
                            <a class="nav-item nav-link" data-toggle="tab" href="#tab-pane-2">Information</a>
                            <a class="nav-item nav-link" data-toggle="tab" href="#tab-pane-3">Reviews (<%Response.Write(Session["reviewCount"]); %>)</a>
                        </div>
                        <div class="tab-content">
                            <div class="tab-pane fade show active" id="tab-pane-1">
                                <h4 class="mb-3">Product Description</h4>
                                <p><%# Eval("LongDescription") %></p>
                            </div>
                            <div class="tab-pane fade" id="tab-pane-2">
                                <h4 class="mb-3">Additional Information</h4>
                                <p><%# Eval("AdditionalDescription") %></p>

                            </div>
                            <div class="tab-pane fade" id="tab-pane-3">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h6 class="mb-4"><%Response.Write(Session["reviewCount"]); %> review for "<%# Eval("ProductName") %>"</h6>
                                        <asp:Repeater ID="rReview" runat="server">
                                            <ItemTemplate>
                                                <div class="media mb-4">
                                                    <img src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>" alt="Image" class="img-fluid mr-3 mt-1" style="width: 45px;">
                                                    <div class="media-body">
                                                        <h6><%# Eval("Name") %><small> - <i><%# Eval("CreatedDate") %></i></small></h6>
                                                        <div class="text-primary mb-2">
                                                            <%--<i class="fas fa-star"></i>
                                                            <i class="fas fa-star"></i>
                                                            <i class="fas fa-star"></i>
                                                            <i class="fas fa-star-half-alt"></i>
                                                            <i class="far fa-star"></i>--%>
                                                            <ajaxToolkit:Rating ID="userRating1" runat="server" StarCssClass="starEmpty"
                                                                FilledStarCssClass="starFilled" EmptyStarCssClass="starEmpty"
                                                                WaitingStarCssClass="starFilled" CurrentRating='<%# Eval("Rating") %>'
                                                                MaxRating="5" ReadOnly="true">
                                                            </ajaxToolkit:Rating>
                                                            <br />
                                                        </div>
                                                        <p style="font-size: 13px;"><%# Eval("Comment") %></p>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                    <div class="col-md-6">
                                        <h4 class="mb-4">Leave a review</h4>
                                        <%--<small>Your email address will not be published. Required fields are marked *</small>--%>
                                        <div class="d-flex my-3">
                                            <p class="mb-0 mr-2">Your Rating * :</p>
                                            <div class="text-primary">
                                                <%--<i class="far fa-star"></i>
                                                <i class="far fa-star"></i>
                                                <i class="far fa-star"></i>
                                                <i class="far fa-star"></i>
                                                <i class="far fa-star"></i>--%>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <ajaxToolkit:Rating ID="userRating" runat="server" StarCssClass="starEmpty"
                                                    FilledStarCssClass="starFilled" EmptyStarCssClass="starEmpty"
                                                    WaitingStarCssClass="starFilled" CurrentRating="1" MaxRating="5">
                                                </ajaxToolkit:Rating>
                                            </div>

                                        </div>
                                        <div>
                                            <div class="form-group">
                                                <label for="message">Your Review *</label>
                                                <%--<textarea id="message" cols="30" rows="5" class="form-control"></textarea>--%>
                                                <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine"
                                                    Rows="5"></asp:TextBox>
                                            </div>
                                            <%--<div class="form-group">
                                                <label for="name">Your Name *</label>
                                                <input type="text" class="form-control" id="name">
                                            </div>
                                            <div class="form-group">
                                                <label for="email">Your Email *</label>
                                                <input type="email" class="form-control" id="email">
                                            </div>--%>
                                            <div class="form-group mb-0">
                                                <%--<input type="submit" value="Leave Your Review" class="btn btn-primary px-3">--%>
                                                <asp:LinkButton ID="lbAddReview" runat="server" CssClass="btn btn-primary px-3"
                                                    CommandName="addReview" CommandArgument='<%# Eval("ProductId") %>'>
                                                    Leave Your Review</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>
    <!-- Shop Detail End -->


    <!-- Products Start -->
    <div class="container-fluid py-5">
        <div class="text-center mb-4">
            <h2 class="section-title px-5"><span class="px-2">You May Also Like</span></h2>
        </div>
        <div class="row px-xl-5">
            <div class="col">
                <div class="owl-carousel related-carousel">

                    <asp:Repeater ID="rTop5Products" runat="server" OnItemCommand="rTop5Products_ItemCommand">
                        <ItemTemplate>
                            <div class="card product-item border-0">
                                <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                                    <img class="img-fluid w-100" src="../<%# Eval("ImageUrl") %>" alt="">
                                </div>
                                <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                                    <h6 class="text-truncate mb-3"><%# Eval("ProductName") %> </h6>
                                    <div class="d-flex justify-content-center">
                                        <h6>OMR <%# Eval("Price") %> </h6>
                                        <%--<h6 class="text-muted ml-2"><del>OMR123.00</del></h6>--%>
                                    </div>
                                </div>
                                <div class="card-footer d-flex justify-content-between bg-light border">
                                    <a href='<%# "ShopDetail.aspx?id=" +Eval("ProductId") %>' class="btn btn-sm text-dark p-0"><i class="fas fa-eye text-primary mr-1"></i>View Detail</a>
                                    <%--<a href="" class="btn btn-sm text-dark p-0"><i class="fas fa-shopping-cart text-primary mr-1"></i>Add To Cart</a>--%>
                                    <asp:LinkButton ID="lbAddToCart" runat="server" CssClass="btn btn-sm text-dark p-0" CommandName="addToCart"
                                        CommandArgument='<%# Eval("ProductId") %>'>
                                        <i class="fas fa-shopping-cart text-primary mr-1"></i>Add To Cart
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>

        </div>
    </div>
    <!-- Products End -->

</asp:Content>
