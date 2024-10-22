<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shopping_Website_Project.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to Shopping</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .login-panel {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .login-heading {
            background-color: #343a40;
            color: #fff;
            padding: 10px;
            border-radius: 10px 10px 0 0;
            text-align: center;
        }

        .my-color {
            background-color: #808080;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container my-color">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <asp:Panel ID="LoginPanel" runat="server" CssClass="login-panel">
                        <div class="login-heading">
                            <h2>Login Panel</h2>
                        </div>
                        <div class="card mt-4">
                            <div class="card-body">
                                <div class="form-group">
                                    <label for="emailID">Email ID:</label>
                                    <asp:TextBox ID="emailID" runat="server" CssClass="form-control" Placeholder="Enter your email ID"  />
                                </div>
                                <div class="form-group mt-3">
                                    <label for="password">Password:</label>
                                    <asp:TextBox  ID="password"  runat="server"  CssClass="form-control"  placeholder="Enter your password" />
                                </div>
                                <div class="form-group text-center mt-4">

                                    <div class="form-group text-center mt-4">
                                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Log In" OnClick="btnLogin_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary btn-block" Text="Cancel" />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="text-center mt-3">
                        <p>Don't have an account? <a href="SignUp.aspx">Sign Up</a></p>
                    </div>
                </div>s
            </div>
        </div>
    </form>
</body>
</html>
