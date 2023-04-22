<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBookShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Assests/Lib/css/bootstrap.min.css" />

</head>
<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-8">
                                <img src="../Assests/Images/books.jpg" height="500"/>
                            </div>
                        </div>
                    </div>

                    <div class="mt-3">
                        <label for="" class="form-label">User Name</label>
                        <input type="email" placeholder="Enter your Email" autocomplete="off" class="form-control" runat="server" id="txtUserName" />
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">Password</label>
                        <input type="password" placeholder="Password" autocomplete="off" class="form-control" runat="server" id="txtPassword" />
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label><br />
                        <asp:Button Text="Login" runat="server" class="btn-success btn" ID="btnLogin" OnClick="btnLogin_Click" />
                    </div>
                </form>
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>

</body>
</html>
