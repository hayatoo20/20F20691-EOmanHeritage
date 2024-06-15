<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="EShopping.User.Invoice" %>

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
            <h1 class="font-weight-semi-bold text-uppercase mb-3">Invoice</h1>
            <div class="d-inline-flex">
                <p class="m-0"><a href="Default.aspx">Home</a></p>
                <p class="m-0 px-2">-</p>
                <p class="m-0">Invoice</p>
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
                <asp:Repeater ID="rOrderItem" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered text-center mb-0">
                            <thead class="bg-secondary text-dark">
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Order Number</th>
                                    <th>Item Name</th>
                                    <th>Unit Price</th>
                                    <th>Quantity</th>
                                    <th>Total Price</th>
                                </tr>
                            </thead>
                            <tbody class="align-middle">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="align-middle">
                                <%# Eval("SrNo") %>
                            </td>
                            <td class="align-middle">
                                <%# Eval("OrderNo") %>
                            </td>
                            <td class="align-middle">
                                <%# Eval("ProductName") %>
                            </td>
                            <td class="align-middle">
                                <%# string.IsNullOrEmpty( Eval("Price").ToString() ) ? "" : "OMR"+ Eval("Price") %>
                            </td>
                            <td class="align-middle">
                                <%# Eval("Quantity") %>
                            </td>
                            <td class="align-middle">OMR <%# Eval("TotalPrice") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="text-center mt-3">
                    <asp:LinkButton ID="lbDownloadInvoice" runat="server" CssClass="btn btn-primary px-3" OnClick="lbDownloadInvoice_Click">
                        <i class="fas fa-file-pdf-o mr-2"></i> Download Invoice</asp:LinkButton>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
