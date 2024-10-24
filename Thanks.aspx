<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thanks.aspx.cs" Inherits="Shopping_Website_Project.Thanks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You</title>
    <style>
        body {
            text-align: center;
            margin-top: 100px;
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
        }
        h1 {
            color: green;
            font-size: 2.5em;
        }
        p {
            font-size: 1.2em;
            color: #555;
        }
        .button {
            display: inline-block;
            padding: 15px 30px;
            margin: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
            font-size: 1.1em;
            transition: background-color 0.3s;
        }
        .button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Thanks for choosing us!</h1>
            <a href="Products.aspx" class="button">Continue Shopping</a>
            <a href="UserCart.aspx" class="button">Check My Cart</a>
        </div>
    </form>
</body>
</html>
