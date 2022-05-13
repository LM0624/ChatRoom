using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;

namespace BrowserMode
{
    public partial class index1 : System.Web.UI.Page
    {
        string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            FullfillMenu();
        }

        protected void FullfillMenu()
        {
            user = Session["CurrentUser"].ToString();
            //根据用户确定菜单栏
            StringBuilder strMenu = new StringBuilder();
            string l1;
            string l2;
            string url;
            if (user=="1")
            {
                //用户管理
                l1 = "管理列表";
                l2 = "用户管理";
                url = "Pages/UserManage.aspx";
                strMenu.Append(@"<li> <h4>" + l1 + @"</h4>");
                this.appendHtml(strMenu, l2, url);

                l2 = "注册管理";
                url = "Pages/RegManage.aspx";
                this.appendHtml(strMenu, l2, url);

                l2 = "聊天管理";
                url = "Pages/chatManage.aspx";
                this.appendHtml(strMenu, l2, url);
                strMenu.Append(@" </li>");
            }
            else
            {
                //物品管理
                l1 = "聊天功能";
                l2 = "好友列表";
                url = "Pages/FriendList.aspx";
                strMenu.Append(@"<li> <h4>" + l1 + @"</h4>");
                this.appendHtml(strMenu, l2, url);
                l2 = "添加好友";
                url = "Pages/Addfriend.aspx";
                this.appendHtml(strMenu, l2, url);
                l2 = "好友申请";
                url = "Pages/Friendreq.aspx";
                this.appendHtml(strMenu, l2, url);
                strMenu.Append(@" </li>");
            }

            J_navlist.InnerHtml = strMenu.ToString();
        }

        private void appendHtml(StringBuilder strMenu, string l2, string url)
        {
            strMenu.Append(@"<div>");
            strMenu.Append(@"  <p> <a style=""background-color:aliceblue; font-size:12px"" href=""" + @""" onclick="" return setUrl('" + url + @"')"">" + l2 + @"</a></p>");
            strMenu.Append(@" </div>");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            YF.Utility.JsHelper.Redirect("Login.aspx");
        }
    }
}