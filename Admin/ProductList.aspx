<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EShopping.Admin.ProductList" %>

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

    <div class="mb-4">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>

    <div class="row">
        <div class="col-sm-12 col-md-12">
            <div class="card">
                <div class="card-body">
                    <%--<h4 class="card-title">Manage Product</h4>--%>
                    <a href="Product.aspx" class="card-title text-primary  m-0 d-flex align-items-end justify-content-end">
                        <i class="fas fa-plus-circle">Add New</i>
                    </a>

                    <div class="table-responsive">
                        <asp:Repeater ID="rProductList" runat="server" OnItemCommand="rProductList_ItemCommand" OnItemDataBound="rProductList_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table data-table-export table-hover nowrap" style="font-size: 13px">
                                    <thead>
                                        <tr>
                                            <th class="table-plus">Name</th>
                                            <th>Image</th>
                                            <th>Price</th>
                                            <th>Qty</th>
                                            <th>Sold</th>
                                            <th>Categroy</th>
                                            <th>SCategroy</th>
                                            <th>Active</th>
                                            <th>CreatedDate</th>
                                            <th class="datatable-nosort">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>

                                <tr>
                                    <td class="table-plus"><%# Eval("ProductName") %></td>
                                    <td>
                                        <img width="40" src="<%# Utils.GetImageUrl( Eval("ImageUrl")) %>"
                                            alt="Image">
                                    </td>
                                    <td> <%# Eval("Price") %> </td>
                                    <td>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                    </td>
                                    <td> <%# Eval("Sold") %> </td>
                                    <td> <%# Eval("CategoryName") %> </td>
                                    <td> <%# Eval("SubCategoryName") %> </td>
                                    <td>
                                        <asp:Label ID="lblIsActive" runat="server"
                                            Text='<%# ((bool)Eval("IsActive")) == true ? "Active" : "In-Active" %>'
                                            CssClass='<%# ((bool)Eval("IsActive")) == true ? "badge badge-success" 
                                                : "badge badge-danger" %>'></asp:Label>
                                    </td>
                                    <td> <%# Eval("CreatedDate") %> </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CssClass="badge badge-primary"
                                            CommandArgument='<%# Eval("ProductId") %>' CommandName="edit" CausesValidation="false">
                                            <i class="fas fa-edit"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CommandName="delete"
                                            CssClass="badge bg-danger" CommandArgument='<%# Eval("ProductId") %>'
                                            OnClientClick="return confirm('Do you want to delete this product?');"
                                            CausesValidation="false">
                                            <i class="fas fa-trash-alt"></i>
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
    </div>

</asp:Content>
