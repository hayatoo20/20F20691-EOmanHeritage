<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="EShopping.Admin.Product" %>
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
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var controlName = input.id.substr(input.id.indexOf("_") + 1);
                    if (controlName == 'fuFirstImage') {
                        OMR('#<%=imgProduct1.ClientID %>').show();
                        OMR('#<%=imgProduct1.ClientID%>').prop('src', e.target.result).width(200).height(200);
                    } else if (controlName == 'fuSecondImage') {
                        OMR('#<%=imgProduct2.ClientID %>').show();
                        OMR('#<%=imgProduct2.ClientID%>').prop('src', e.target.result).width(200).height(200);
                    } else if (controlName == 'fuThirdImage') {
                        OMR('#<%=imgProduct3.ClientID %>').show();
                        OMR('#<%=imgProduct3.ClientID%>').prop('src', e.target.result).width(200).height(200);
                    } else {
                        OMR('#<%=imgProduct4.ClientID %>').show();
                        OMR('#<%=imgProduct4.ClientID%>').prop('src', e.target.result).width(200).height(200);
                    }
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
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
                    <h4 class="card-title">Product</h4>
                    <hr />
                    <div class="form-body">

                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Product Name </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"
                                        placeholder="Enter Product Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ForeColor="Red"
                                        ControlToValidate="txtProductName" ErrorMessage="Product Name is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Category </label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ForeColor="Red"
                                        ControlToValidate="ddlCategory" ErrorMessage="Category is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>SubCategory </label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlSubCategory" runat="server" AppendDataBoundItems="true"
                                        CssClass="form-control">
                                        <%--<asp:ListItem Value="0">Select SubCategory</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvSubCategory" runat="server" ForeColor="Red"
                                        ControlToValidate="ddlSubCategory" ErrorMessage="SubCategory is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true" InitialValue="Select SubCategory">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Price </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Enter Product Price" 
                                        TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ForeColor="Red" ControlToValidate="txtPrice" 
                                        ErrorMessage="Price is required" Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                                        ValidationExpression="\d+(?:.\d{1,2})?" ErrorMessage="Product Price is invalid" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Smaller"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Color </label>
                                <div class="form-group">
                                    <asp:ListBox ID="lboxColor" runat="server" CssClass="form-control" SelectionMode="Multiple"
                                        ToolTip="Use CTRL key to select multiple items">
                                        <asp:ListItem Value="1">Blue</asp:ListItem>
                                        <asp:ListItem Value="2">Red</asp:ListItem>
                                        <asp:ListItem Value="3">Pink</asp:ListItem>
                                        <asp:ListItem Value="4">Purple</asp:ListItem>
                                        <asp:ListItem Value="5">Brown</asp:ListItem>
                                        <asp:ListItem Value="6">Gray</asp:ListItem>
                                        <asp:ListItem Value="7">Green</asp:ListItem>
                                        <asp:ListItem Value="8">Yellow</asp:ListItem>
                                        <asp:ListItem Value="9">White</asp:ListItem>
                                        <asp:ListItem Value="10">Black</asp:ListItem>
                                    </asp:ListBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvColor" runat="server" ForeColor="Red"
                                        ControlToValidate="lboxColor" ErrorMessage="Color is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true" InitialValue="">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Size </label>
                                <div class="form-group">
                                    <asp:ListBox ID="lboxSize" runat="server" CssClass="form-control" SelectionMode="Multiple"
                                        ToolTip="Use CTRL key to select multiple items">
                                        <asp:ListItem Value="1">XS</asp:ListItem>
                                        <asp:ListItem Value="2">SM</asp:ListItem>
                                        <asp:ListItem Value="3">M</asp:ListItem>
                                        <asp:ListItem Value="4">L</asp:ListItem>
                                        <asp:ListItem Value="5">XL</asp:ListItem>
                                        <asp:ListItem Value="6">XXL</asp:ListItem>
                                    </asp:ListBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvSize" runat="server" ForeColor="Red"
                                        ControlToValidate="lboxSize" ErrorMessage="Size is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true" InitialValue="">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Quantity </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number"
                                        placeholder="Enter Product Quantity"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ForeColor="Red" ControlToValidate="txtQuantity" 
                                        ErrorMessage="Quantity is required" Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Company Name </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"
                                        placeholder="Enter Product Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor="Red"
                                        ControlToValidate="txtCompanyName" ErrorMessage="Company Name is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Short Description </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtShortDescription" runat="server" CssClass="form-control" TextMode="MultiLine"
                                        placeholder="Enter Short Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ForeColor="Red"
                                        ControlToValidate="txtShortDescription" ErrorMessage="Short Description is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Long Description </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtLongDescription" runat="server" CssClass="form-control" TextMode="MultiLine"
                                        placeholder="Enter Long Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLongDescription" runat="server" ForeColor="Red"
                                        ControlToValidate="txtLongDescription" ErrorMessage="Long Description is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Additional Description </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtAdditionalDescription" runat="server" CssClass="form-control" TextMode="MultiLine"
                                        placeholder="Enter Additional Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAdditionalDescription" runat="server" ForeColor="Red"
                                        ControlToValidate="txtAdditionalDescription" ErrorMessage="Additional Description is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Tags(Search Keyword) </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtTags" runat="server" CssClass="form-control"
                                        placeholder="Enter Tags"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTags" runat="server" ForeColor="Red"
                                        ControlToValidate="txtTags" ErrorMessage="Product Tags is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Product Image 1 </label>
                                <div class="form-group">
                                    <asp:FileUpload ID="fuFirstImage" runat="server" CssClass="form-control" ToolTip=".jpg, .png, .jpeg image only"
                                        onchange="ImagePreview(this);"/>
                                    <%--<asp:RequiredFieldValidator ID="rfvFirstImage" runat="server" ForeColor="Red"
                                        ControlToValidate="fuFirstImage" ErrorMessage="Product Image 1 is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Product Image 2 </label>
                                <div class="form-group">
                                    <asp:FileUpload ID="fuSecondImage" runat="server" CssClass="form-control" ToolTip=".jpg, .png, .jpeg image only"
                                        onchange="ImagePreview(this);"/>
                                    <%--<asp:RequiredFieldValidator ID="rfvSecondImage" runat="server" ForeColor="Red"
                                        ControlToValidate="fuSecondImage" ErrorMessage="Product Image 2 is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Product Image 3 </label>
                                <div class="form-group">
                                    <asp:FileUpload ID="fuThirdImage" runat="server" CssClass="form-control" ToolTip=".jpg, .png, .jpeg image only"
                                        onchange="ImagePreview(this);"/>
                                    <%--<asp:RequiredFieldValidator ID="rfvThirdImage" runat="server" ForeColor="Red"
                                        ControlToValidate="fuThirdImage" ErrorMessage="Product Image 3 is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Product Image 4 </label>
                                <div class="form-group">
                                    <asp:FileUpload ID="fuFourthImage" runat="server" CssClass="form-control" ToolTip=".jpg, .png, .jpeg image only"
                                        onchange="ImagePreview(this);"/>
                                    <%--<asp:RequiredFieldValidator ID="rfvFourthImage" runat="server" ForeColor="Red"
                                        ControlToValidate="fuFourthImage" ErrorMessage="Product Image 4 is required"
                                        Font-Size="Small" Display="Dynamic" SetFocusOnError="true">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Default Image </label>
                                <div class="form-group">
                                    <asp:RadioButtonList ID="rblDefaultImage" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Value="1">&nbsp; First &nbsp;</asp:ListItem>
                                        <asp:ListItem Value="2">&nbsp; Second &nbsp;</asp:ListItem>
                                        <asp:ListItem Value="3">&nbsp; Third &nbsp;</asp:ListItem>
                                        <asp:ListItem Value="4">&nbsp; Fourth</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="rfvDefaultImage" runat="server" ControlToValidate="rblDefaultImage"
                                        ErrorMessage="Default Image is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" 
                                        Font-Size="Smaller">
                                    </asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hfDefImgagePos" runat="server" Value="0" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Customized </label>
                                <div class="form-group">
                                    <asp:CheckBox ID="cbIsCustomized" runat="server" Text="&nbsp; IsCustomized" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Active </label>
                                <div class="form-group">
                                    <asp:CheckBox ID="cbIsActive" runat="server" Text="&nbsp; IsActive" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-col-12 align-content-sm-beteween pl-3">
                                <span>
                                    <asp:Image ID="imgProduct1" runat="server" CssClass="img-thumbnail" style="display:none;"/>
                                </span>
                                <span>
                                    <asp:Image ID="imgProduct2" runat="server" CssClass="img-thumbnail" style="display:none;"/>
                                </span>
                                <span>
                                    <asp:Image ID="imgProduct3" runat="server" CssClass="img-thumbnail" style="display:none;"/>
                                </span>
                                <span>
                                    <asp:Image ID="imgProduct4" runat="server" CssClass="img-thumbnail" style="display:none;"/>
                                </span>
                            </div>
                        </div>

                    </div>
                    <div class="form-actions pt-4">
                        <div class="text-left">
                            <asp:Button ID="btnAddOrUpdate" runat="server" CssClass="btn btn-info" Text="Add" OnClick="btnAddOrUpdate_Click"/>
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-dark" Text="Reset" OnClick="btnClear_Click"
                                CausesValidation="false"/>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
  
    </div>

</asp:Content>