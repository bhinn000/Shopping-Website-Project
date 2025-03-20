<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCart.aspx.cs" Inherits="Shopping_Website_Project.UserCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Cart</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        th {
            background-color: #f2f2f2;
        }

        tr:hover {
            background-color: #f5f5f5;
        }

        .logout-button {
            background-color: #4CAF50; 
            color: white; 
            padding: 10px 20px; 
            border: none;
            border-radius: 5px; 
            cursor: pointer; 
            font-size: 16px;
            margin-top: 10px;
        }

        .logout-button:hover {
            background-color: #45a049; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Your Cart</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="productID" HeaderText="Product ID" />
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-button" />
        </div>
    </form>
</body>
</html>
