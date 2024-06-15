<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="EShopping.Admin.OrderStatus" %>

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

    <div class="mb-4">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <div class="row">
        <div class="col-sm-6 col-md-8">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Order List</h4>
                    <div class="table-responsive">
                        <asp:Repeater ID="rOrderStatus" runat="server" OnItemCommand="rOrderStatus_ItemCommand">
                            <HeaderTemplate>
                                <table class="table data-table-export table-hover nowrap" style="font-size: 13px">
                                    <thead>
                                        <tr>
                                            <th class="table-plus">Order No.</th>
                                            <th>Order Date</th>
                                            <th>Status</th>
                                            <th>Product Name</th>
                                            <th>Total Price</th>
                                            <th>Payment Mode</th>
                                            <th class="datatable-nosort">Edit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>

                                <tr>
                                    <td class="table-plus"><%# Eval("OrderNo") %></td>
                                    <td><%# Eval("OrderDate") %></td>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'
                                            CssClass='<%# Eval("Status").ToString() == "Delivered" ? "badge badge-success" 
                                                : Eval("Status").ToString() == "Cancelled" ? "badge badge-danger" : 
                                                "badge badge-warning" %>'>
                                        </asp:Label>
                                    </td>
                                    <td><%# Eval("ProductName") %></td>
                                    <td>
                                        <%--<asp:Label ID="lblTotalPrice" runat="server" Text=''></asp:Label>--%>
                                        <%# Eval("TotalPrice") %>
                                    </td>
                                    <td><%# Eval("PaymentMode").ToString().ToUpper() %></td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="edit" CausesValidation="false"
                                            CssClass="badge badge-primary" CommandArgument='<%# Eval("OrderDetailsId") %>'
                                            Enabled='<%# Eval("Status").ToString() == "Cancelled" ? false : true %>'>
                                            <i class="fas fa-edit"></i>
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

                </div>
            </div>
        </div>
        <div class="col-sm-6 col-md-4">
            <div class="card">
                <div class="card-body">
                    <asp:Panel ID="pUpdateOrderStatus" runat="server">
                        <h4 class="card-title">Update Status</h4>
                        <div>
                            <div class="form-group">
                                <label>Order Status</label>
                                <div>
                                    <asp:DropDownList ID="ddlOrderStatus" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Select Status</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Dispatched</asp:ListItem>
                                        <asp:ListItem>Out For Delivery</asp:ListItem>
                                        <asp:ListItem>Delivered</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvOrderStatus" runat="server" ForeColor="Red"
                                        ErrorMessage="Order Status is required" SetFocusOnError="true" Display="Dynamic"
                                        ControlToValidate="ddlOrderStatus" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hdnId" runat="server" Value="0" />
                                </div>
                            </div>
                            <div class="pb-5">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
