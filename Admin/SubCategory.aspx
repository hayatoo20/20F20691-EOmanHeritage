﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SubCategory.aspx.cs" Inherits="EShopping.Admin.SubCategory" %>
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
        <div class="col-sm-12 col-md-4">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Sub-Category</h4>
                    <hr />
                    <div class="form-body">

                        <label>SubCategory Name </label>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:TextBox ID="txtSubCategoryName" runat="server" CssClass="form-control"
                                        placeholder="Enter Sub-Category Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSubCategoryName" runat="server" ForeColor="Red"
                                        ControlToValidate="txtSubCategoryName" ErrorMessage="Sub-Category Name is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <label>Category </label>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true"
                                        CssClass="form-control">
                                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ForeColor="Red"
                                        ControlToValidate="ddlCategory" ErrorMessage="Category is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:CheckBox ID="cbIsActive" runat="server" Text="&nbsp; IsActive" />
                                    <asp:HiddenField ID="hfSubCategoryId" runat="server" Value="0" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="form-actions pb-5">
                        <div class="text-left">
                            <asp:Button ID="btnAddOrUpdate" runat="server" CssClass="btn btn-info" Text="Add"
                                OnClick="btnAddOrUpdate_Click"/>
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-dark" Text="Reset"
                                OnClick="btnClear_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12 col-md-8">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Sub-Category List</h4>

                    <div class="table-responsive">
                        <asp:Repeater ID="rSubCategory" runat="server" OnItemCommand="rSubCategory_ItemCommand">
                            <HeaderTemplate>
                                <table class="table data-table-export table-hover nowrap">
                                    <thead>
                                        <tr>
                                            <th class="table-plus">SubCategory</th>
                                            <th>Category</th>
                                            <th>IsActive</th>
                                            <th>CreatedDate</th>
                                            <th class="datatable-nosort">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>

                                <tr>
                                    <td class="table-plus"><%# Eval("SubCategoryName") %></td>
                                    <td>
                                        <%# Eval("CategoryName") %></td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# ((bool)Eval("IsActive")) == true ? "Active" : "In-Active" %>'
                                            CssClass='<%# ((bool)Eval("IsActive")) == true ? "badge badge-success" 
                                                : "badge badge-danger" %>' ></asp:Label>
                                    </td>
                                    <td><%# Eval("CreatedDate") %></td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CssClass="badge badge-primary"
                                            CommandArgument='<%# Eval("SubCategoryId") %>' CommandName="edit" CausesValidation="false">
                                            <i class="fas fa-edit"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CommandName="delete"
                                            CssClass="badge bg-danger" CommandArgument='<%# Eval("SubCategoryId") %>'
                                            OnClientClick="return confirm('Do you want to delete this sub-category?');"
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
