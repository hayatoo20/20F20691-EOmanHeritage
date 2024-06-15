<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="EShopping.User.OrderHistory" %>
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
<h1 class="font-weight-semi-bold text-uppercase mb-3">Order History</h1>
<div class="d-inline-flex">
<p class="m-0"><a href="Default.aspx">Home</a></p>
<p class="m-0 px-2">-</p>
<p class="m-0">Order History</p>
</div>
</div>
</div>
<!-- Page Header End -->
<div class="ml-5">
<asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
</div>
<div class="container-fluid pt-5">
<div class="row px-xl-5">
<div class="col-lg-12 table-responsive mb-5">
<asp:Repeater ID="rPurchaseHistory" runat="server" OnItemDataBound="rPurchaseHistory_ItemDataBound">
                    <ItemTemplate>
                        <div class="container">
                            <div class="row pt-1 pb-1 bg-secondary" >
                                <div class="col-4">
                                    <span class="badge badge-pill badge-primary text-white">
                                        <%# Eval("SrNo") %>
                                    </span>
                                    Payment Mode: <%# Eval("PaymentMode").ToString() == "cod" ? "Cash On Delivery" : Eval("PaymentMode").ToString().ToUpper() %>
                                </div>
                                <div class="col-6">
                                    <%# string.IsNullOrEmpty( Eval("CardNo").ToString() ) ? "" : "Card No: "+ Eval("CardNo") %>
                                </div>
                                <div class="col-2" style="text-align: end">
                                    <a href="Invoice.aspx?id=<%# Eval("PaymentId") %>" class="btn btn-primary btn-sm"><i class="fa fa-download mr-2"></i>Invoice</a>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnPaymentId" Value='<%# Eval("PaymentId") %>' runat="server" />

                            <asp:Repeater ID="rOrders" runat="server" OnItemCommand="rOrders_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table data-table-export table-responsive-sm table-bordered table-hover">
                                        <thead class="bg-primary text-black-50">
                                            <tr>
                                                <th>Product Name</th>
                                                <th>Unit Price</th>
                                                <th>Qty</th>
                                                <th>Total Price</th>
                                                <th>OrderId</th>
                                                <th>Status</th>
                                                <th>Cancel</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hfProductId" runat="server" Value='<%# Eval("ProductId") %>' />
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# string.IsNullOrEmpty( Eval("Price").ToString() ) ? "" : "OMR"+ Eval("Price") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                        </td>
                                        <td>OMR <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'
                                                CssClass='<%# Eval("Status").ToString() == "Delivered" ? "badge badge-success" : Eval("Status").ToString() == "Cancelled" ? "badge badge-danger" : "badge badge-warning" %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sm btn-primary" CommandName="cancel"
                                                CommandArgument='<%# Eval("OrderDetailsId") %>' CausesValidation="false" ToolTip="Cancel your order"
                                                Visible='<%# Eval("Status").ToString() == "Delivered" ? false : (bool)Eval("IsCancel") == false ? true : (bool)Eval("IsCancel") == true ? false : false %>'>
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
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
