<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BrowserMode.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="style/Login.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>聊天室网页端</title>
</head>
<body>
    <div id="nav">
        聊天室网页端</div>
    <div id="nav1">
    </div>
    <div id="main">
        <div id="img">
        </div>
        <div id="login">
            <form id="form1" runat="server">
            <table class="logintable">
                <tbody>
                    <tr>
                        <td>
                            账号
                        </td>
                        <td>
                            <input id="username" type="text" class="logininput" runat="server" required="required"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码
                        </td>
                        <td>
                            <input id="tb_password" type="password" class="logininput" runat="server" required="required"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuth" runat="server" Width="150" CssClass="logininput"></asp:TextBox>
                            <img src="/Page/P_Public/YZM.aspx" alt="验证码" onclick="this.src='/Page/P_Public/YZM.aspx?'+ Math.random()"
                                width="50" height="25" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnLogin" runat="server" CssClass="loginbtn" Text="登录" OnClick="Login_Click"
                                OnClientClick="return Checked()" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="reg" runat="server" CssClass="loginbtn" Text="注册" OnClick="reg_Click"
                                OnClientClick="return Checked()" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lb_ShowMsg" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
</body>
</html>