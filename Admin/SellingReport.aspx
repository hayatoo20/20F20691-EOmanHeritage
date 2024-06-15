﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SellingReport.aspx.cs" Inherits="EShopping.Admin.SellingReport" %>

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
                <div class="card-header">
                    <div class="container">
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label>From Date</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    ErrorMessage="*" SetFocusOnError="true" Display="Dynamic"
                                    ControlToValidate="txtFromDate">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-4">
                                <label>To Date</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                    ErrorMessage="*" SetFocusOnError="true" Display="Dynamic"
                                    ControlToValidate="txtToDate">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-4 mt-2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mt-md-4"
                                    OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card-body">
                    <h4 class="card-title">Selling Report</h4>
                    <div class="table-responsive">
                        <asp:Repeater ID="rReport" runat="server">
                            <HeaderTemplate>
                                <table class="table data-table-export table-hover nowrap">
                                    <thead>
                                        <tr>
                                            <th class="table-plus">SrNo</th>
                                            <th>Full Name</th>
                                            <th>Email</th>
                                            <th>Item Orders</th>
                                            <th>Total Cost</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="table-plus"><%# Eval("SrNo") %></td>
                                    <td>
                                        <%# Eval("Name") %>
                                    </td>
                                    <td>
                                        <%# Eval("Email") %>
                                    </td>
                                    <td>
                                        <%# Eval("TotalOrders") %>
                                    </td>
                                    <td>OMR <%# Eval("TotalPrice") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="row pl-4">
                        <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
