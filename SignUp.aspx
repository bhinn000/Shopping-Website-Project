<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Shopping_Website_Project.SignUp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup to Shopping</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
    <style>
        .panel-body {
            padding: 15px;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 5px;
            margin-top: 50px;
        }

            .panel-body h2 {
                text-align: center;
                font-size: 24px;
                margin-bottom: 20px;
            }

        .form-group {
            margin-bottom: 15px;
        }

        .btn-primary, .btn-danger {
            width: 100%;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="panel-body">
                   

                        <div class="form-group">
                            <label for="name">Full name:</label>
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Enter your full name"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="gender" >Gender:</label>
                            <asp:DropDownList ID="dropdown" runat="server">
                                <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label for="address">Address:</label>
                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Enter your address"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="email">Email Id:</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Enter your email"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="userId">User Id:</label>
                            <asp:TextBox ID="txtUserId" CssClass="form-control" runat="server" placeholder="Enter your userid"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="password">Password:</label>
                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-2">
                                <asp:Button ID="btnSignup" runat="server" CssClass="btn btn-primary w-100" Text="Sign Up" OnClick="btnSignup_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger w-100" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


