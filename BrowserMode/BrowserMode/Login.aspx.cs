using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace BrowserMode
{
    public partial class Login : System.Web.UI.Page
    {
        private TcpClient tc;
        //声明网络流
        private NetworkStream ns;
        private BinaryReader br;
        private BinaryWriter bw;
        private String IP;
        private String port;

        protected void Page_Load(object sender, EventArgs e)
        {
            IP = "127.0.0.1";
            port = "9999";
        }

        public void Login_Click(object sender, EventArgs e)
        {
            string account = username.Value;
            string password = tb_password.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append("login#");
            sb.Append(account + "#" + password);

            try
            {
                lb_ShowMsg.Text = "正在连接到主机";
                tc = new TcpClient(IP, int.Parse(port));
                //实例化网络流对象
                ns = tc.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                bw.Write(sb.ToString());
                bw.Flush();
                string info = null;
                try
                {
                    info = br.ReadString();
                }
                catch (Exception)
                {
                    lb_ShowMsg.Text = "服务器无响应";
                }
                if (info == null)
                {
                    lb_ShowMsg.Text = "登陆失败";
                }
                else
                {
                    string[] splitString = info.Split('#');
                    switch (splitString[0])
                    {
                        case "login fail":
                            lb_ShowMsg.Text = "用户名或密码错误";
                            break;
                        case "already login":
                            lb_ShowMsg.Text = "请不要重复登陆";
                            break;
                        case "user":
                            //格式：user#UID#UserName
                            //MessageBox.Show("登陆成功");
                            lb_ShowMsg.Text = "登陆成功";
                            list main = new list();
                            main.UID = splitString[1];
                            main.Username = splitString[2];
                            main.sign = splitString[3];
                            //main.Users = info;
                            main.ServerIP = IP;
                            main.ServerPort = port;
                            main.Br = br;
                            main.Bw = bw;
                            Session["list"] = main;
                            Session["CurrentUser"] = splitString[1];
                            YF.Utility.JsHelper.Redirect("index.aspx");
                            break;
                        default:
                            YF.Utility.JsHelper.Alert(info);
                            break;
                    }
                }
            }
            catch
            {
                lb_ShowMsg.Text = "无法连接到主机";
            }
        }

        protected void reg_Click(object sender, EventArgs e)
        {
            YF.Utility.JsHelper.Redirect("Reg.aspx");
        }
    }
}