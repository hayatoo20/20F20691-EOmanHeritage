<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="EShopping.Admin.Training" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

\\\\\\\\\\\\\\\\\\
<label>From Date</label>
<!-- Label for date input -->
<ItemTemplate>
<!-- Start item template -->
<tr>
<!-- Table row start -->
<td class="table-plus"><%# Eval("SrNo") %></td>
<!-- Display serial number -->
<td><%# Eval("Name") %></td>
<!-- Display user name -->
<td><%# Eval("Email") %></td>
<!-- Display email address -->
<td><%# Eval("Subject") %></td>
<!-- Display message subject -->
<td><%# Eval("Message") %></td>
<!-- Display user message -->
<td><%# Eval("CreatedDate") %></td>
<!-- Display creation date -->
<td>
<!-- Table cell start -->
<asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CommandName="delete"
CssClass="badge bg-danger" CommandArgument='<%# Eval("ContactId") %>'
OnClientClick="return confirm('Do you want to delete this record?');"
CausesValidation="false">
<!-- Delete button configuration -->
<i class="fas fa-trash-alt"></i>
<!-- Trash icon for delete -->
</asp:LinkButton>
<!-- End delete button -->
</td>
<!-- Table cell end -->
</tr>
<!-- Table row end -->
</ItemTemplate>
<!-- End item template -->
  


  



