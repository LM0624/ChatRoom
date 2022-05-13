<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BrowserMode.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/style/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.8.0.js" type="text/javascript"></script>
    <script src="js/showlist.js" type="text/javascript"></script>
    <title>办公用品管理系统</title>
    <style type="text/css">
        /*解决抖动问题*/
        html
        {
            overflow-y: scroll;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
        <div id="logo">
        </div>
        <div id="operate">
            当前登录者：<asp:Label ID="LoginUser" runat="server"></asp:Label>
            <a href="#" onclick="setUrl('/Page/P_Public/ChangePassword.aspx')">修改密码</a>
            <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">登出</asp:LinkButton>
        </div>
    </div>
    <div id="nav">
    </div>
    <div id="main">
        <div id="container">
            <div id="content">
                <div id="ContentPlace">
                    <div>
                        <iframe id="ipage" frameborder="0" scrolling="no" width="100%" src="Pages/Main.aspx">
                        </iframe>
                    </div>
                </div>
            </div>
        </div>
        <div id="sider">
            <div class="operate">
                <h3>
                    功能清单
                </h3>
                <ul id="J_navlist" runat="server">
                </ul>
                <script type="text/javascript">                    navList();</script>
            </div>
        </div>
        <div id="clear">
        </div>
    </div>
    <div id="footer">
        
        CopyRight 2021 , All Rights Reserved&reg; Recommended Resolution 1366×768
    </div>
        <asp:Literal ID="ItaMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
