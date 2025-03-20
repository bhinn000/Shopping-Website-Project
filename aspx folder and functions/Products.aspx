<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Shopping_Website_Project.Products" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Products</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center">Available Products</h2>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames="productID">
                <Columns>
                    <asp:BoundField DataField="productID" HeaderText="Product ID" />
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
