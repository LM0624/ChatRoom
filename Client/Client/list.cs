using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class list : Form
    {
        public string UID { get; set; }
        public string Username { get; set; }
        public string sign { get;set; }
        public string Users { get; set; }
        public int Port { get; set; }
        public BinaryReader Br { get; set; }
        public BinaryWriter Bw { get; set; }
        private TcpClient tc = null;
        private UdpClient uc = null;
        private Socket socketClient;
        private NetworkStream ns;
        //private BinaryReader Br;
        //private BinaryWriter Bw;
        public string ServerIP;
        public string ServerPort;

        public string IP { get; set; }

        public List<User> UserList = new List<User>();
        //聊天窗口List
        public static List<Talking> TalkList = new List<Talking>();
        //请求窗口List
        public static List<Friendreq> FriendreqList = new List<Friendreq>();
        public static List<Addfriend> addfmList = new List<Addfriend>();
        //好友菜单窗口List
        public static List<frdgroupcg> frdgrpcgList = new List<frdgroupcg>();
        public static List<Userstate> userstateList = new List<Userstate>();
        //未读消息List
        public static List<noread> readList = new List<noread>();
        public static List<Groupnoread> grpreadList = new List<Groupnoread>();
        //锁List
        public static List<reqlock> lockList = new List<reqlock>();
        public static List<Grouplock> grplockList = new List<Grouplock>();
        //好友请求List
        public static List<User> frdreqList = new List<User>();
        public static List<User> putfrdreqList = new List<User>();
        //群组请求List
        public static List<Mureq> mureqList = new List<Mureq>();
        public static List<Mureq> putmureqList = new List<Mureq>();
        //好友分组List
        public static List<String> GroupList = new List<string>();
        public static List<String> muGroupList = new List<string>();
        

        bool iswork = false;
        public list()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        private void list_Load(object sender, EventArgs e)
        {
            this.Text = UID + ":" + Username;
            lb_UID.Text = UID;
            lb_Username.Text = Username;
            Start();
            //获取主界面列表
            Get_Friend();
            Get_Groups();
            //获取请求
            Get_Friendreq();
            Get_Putreq();
            //获取未读消息
            loadnoread();
            lv_friends.Columns.Add("账号", 40, HorizontalAlignment.Left);
            lv_friends.Columns.Add("昵称", 40, HorizontalAlignment.Left);
            lv_friends.Columns.Add("分组", 60, HorizontalAlignment.Left);
            lv_friends.Columns.Add("状态", 60, HorizontalAlignment.Left);
            lv_friends.Columns[0].Width = 100;
            lv_friends.Columns[1].Width = 100;
            lv_friends.Columns[2].Width = 100;
            lv_friends.Columns[3].Width = 100;
        }

        private void Start()
        {
            iswork = true;
            //tcp消息监听
            Thread tcpth = new Thread(TcpListen);
            tcpth.IsBackground = true;
            tcpth.Start();
        }

        //监听服务器端发来的消息
        private void TcpListen()
        {
            while (iswork)
            {
                string receiveMsg = null;
                try
                {
                    receiveMsg = Br.ReadString();
                }
                catch (Exception)
                {
                }
                if (receiveMsg != null)
                {
                    string command = string.Empty;
                    string[] splitStrings = receiveMsg.Split('#');
                    command = splitStrings[0];
                    switch (command)
                    {
                        case "friends":
                            {
                                string[] frienditem = splitStrings[1].Split('/');
                                lockList.Clear();
                                foreach (string s in frienditem)
                                {
                                    if (s != ".ed")
                                    {
                                        string[] _index = s.Split(';');
                                        ListViewItem lvitem = new ListViewItem();
                                        lvitem.ImageIndex = 0;
                                        lvitem.Text = _index[0];
                                        lvitem.SubItems.Add(_index[1]);
                                        lvitem.SubItems.Add(_index[2]);
                                        lvitem.SubItems.Add(_index[4]);
                                        lvitem.Tag = _index[3];
                                        lv_friends.Items.Add(lvitem);
                                        reqlock n_lock = new reqlock(_index[0]);
                                        lockList.Add(n_lock);
                                    }
                                }
                                break;
                            }
                            
                        case "newmsg":
                            foreach (reqlock l in lockList)
                            {
                                if (l.UID == splitStrings[1])
                                {
                                    lock (l.newmsglock)
                                    {
                                        l.newmsg++;
                                        noread reader = new noread(splitStrings[1], splitStrings[2], splitStrings[3], splitStrings[4]);
                                        readList.Add(reader);
                                        remind(splitStrings[1]);
                                        Monitor.Pulse(l.newmsglock);
                                    }
                                }
                            }
                            break;
                        case "friendreq":
                            //格式：friendreq#UID1;username1/UID2;username2/.ed
                            string[] reqitem = splitStrings[1].Split('/');
                            frdreqList.Clear();
                            foreach (string s in reqitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] frdr = s.Split(';');
                                    User newusr = new User(frdr[0], frdr[1]);
                                    frdreqList.Add(newusr);
                                }

                            }
                            if (isHaveFrdrq() != null)
                            {
                                isHaveFrdrq().reloadreqitem();
                            }
                            break;
                        case "putreq":
                            //格式：friendreq#UID1;username1/UID2;username2/.ed
                            string[] putreqitem = splitStrings[1].Split('/');
                            putfrdreqList.Clear();
                            foreach (string s in putreqitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] pfrdr = s.Split(';');
                                    User pnewusr = new User(pfrdr[0], pfrdr[1]);
                                    putfrdreqList.Add(pnewusr);
                                }

                            }
                            if (isHaveFrdrq() != null)
                            {
                                isHaveFrdrq().reloadputreqitem();
                            }
                            break;
                        
                        case "groups":
                            string[] groupitem = splitStrings[1].Split(';');
                            foreach (string s in groupitem)
                            {
                                if (s != ".ed")
                                {
                                    GroupList.Add(s);
                                }
                            }
                            break;
                        case "mugroups":
                            string[] mugroupitem = splitStrings[1].Split(';');
                            foreach (string s in mugroupitem)
                            {
                                if (s != ".ed")
                                {
                                    muGroupList.Add(s);
                                }
                            }
                            break;
                        case "reloadlist":
                            lv_friends.Items.Clear();
                            Get_Friend();
                            //foreach(mutualTalk mt in mutualTalkList)
                            //{
                            //    mt.get_member();
                            //}
                            Get_Friendreq();
                            Get_Putreq();
                            break;
                        case "addreturn":
                            switch (splitStrings[1])
                            {
                                case "msg":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(splitStrings[2]);
                                    }
                                    break;
                                case "true":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_true();
                                    }
                                    break;
                                case "mumsg":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_mumsg(splitStrings[2]);
                                    }
                                    break;
                                case "mutrue":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_mutrue();
                                    }
                                    break;
                                default:
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(receiveMsg);
                                    }
                                    break;
                            }
                            break;
                        case "addmureturn":
                            switch (splitStrings[1])
                            {
                                case "msg":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(splitStrings[2]);
                                    }
                                    break;
                                case "true":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_true();
                                    }
                                    break;
                                default:
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(receiveMsg);
                                    }
                                    break;
                            }
                            break;
                        case "userstate":
                            {
                                Username = splitStrings[1];
                                sign = splitStrings[2];
                                lb_Username.Text = Username;
                                break;
                                /*case "mustate":
                                    mustate(splitStrings[1], splitStrings[2], splitStrings[3]);
                                    break;*/

                            }
                        default:
                            MessageBox.Show(receiveMsg);
                            break;
                    }
                }
            }
        }

        //获取列表
        private void Get_Friend()
        {
            try
            {
                Bw.Write("getfriends");
            }
            catch
            {
                MessageBox.Show("获取好友列表失败");
            }
        }
        private void Get_Groups()
        {
            try
            {
                Bw.Write("getgroups");
            }
            catch
            {
                MessageBox.Show("获取好友分组失败");
            }
        }

        //获取请求
        public void Get_Friendreq()
        {
            try
            {
                Bw.Write("getfriendreq");
            }
            catch
            {
                MessageBox.Show("获取好友列表失败");
            }
        }
        public void Get_Putreq()
        {
            try
            {
                Bw.Write("getputreq");
            }
            catch
            {
                MessageBox.Show("获取发送的好友列表失败");
            }
        }

        private void loadnoread()
        {
            string sndmsg = "getnoread#";
            try
            {
                Bw.Write(sndmsg);
            }
            catch
            {
                MessageBox.Show("获取消息失败");
            }

        }
        private void remind(String UID)
        {
            foreach (ListViewItem item in this.lv_friends.Items)
            {
                if (isHaveTalk(UID) != null)
                {
                    break;
                }
                else
                {
                    if (item.Text == UID)
                    {
                        item.SubItems[0].ForeColor = Color.Red;
                    }
                }
            }
        }
        //private void muremind(String GID)
        //{
        //    foreach (ListViewItem item in this.lv_group.Items)
        //    {
        //        if (isHavemutualTalk(GID) != null)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            if (item.Text == GID)
        //            {
        //                item.SubItems[0].BackColor = Color.Red;
        //            }
        //        }
        //    }
        //}
        //修改属性
        /*private void mustate(string GID,string groupname,string sign)
        {
            foreach (ListViewItem item in this.lv_group.Items)
            {
                if (item.Text == GID)
                {
                    item.SubItems[1].Text = groupname;
                    item.SubItems[4].Text = sign;
                }    
            }
        }
        private void state(string UID,string username,string sign)
        {

        }*/
        //关闭窗口
        private void list_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string sendmsg = "logout#" + UID;
                Bw.Write(sendmsg);
                Bw.Flush();
                iswork = false;
                Br.Close();
                Bw.Close();
            }
            catch
            { }
            Application.Exit();
        }

        private void lv_friends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_friends.SelectedItems[0];
                string toUID = lvitem.Text;
                string toname = lvitem.SubItems[1].Text;
                string toips = lvitem.Tag.ToString();
                Talking t = isHaveTalk(toUID);
                if (t != null)
                {
                    t.Focus();
                }
                else
                {
                    this.lv_friends.SelectedItems[0].SubItems[0].BackColor = Color.Transparent;
                    Talking talk = new Talking();
                    talk.UID = toUID;
                    talk.UserName = Username;
                    talk.ToName = toname;
                    talk.Br = Br;
                    talk.Bw = Bw;
                    TalkList.Add(talk);
                    talk.Show();
                }
            }
        }
        private Talking isHaveTalk(string toUID)
        {
            foreach (Talking tk in TalkList)
            {
                if (tk.UID == toUID)
                    return tk;
            }
            return null;
        }
        public static void RemoveTalking(Talking _talk)
        {
            foreach (Talking tk in TalkList)
            {
                if (tk.UID == _talk.UID)
                {
                    TalkList.Remove(_talk);
                    return;
                }
            }
        }

        private void frdreq_btn_Click(object sender, EventArgs e)
        {
            Friendreq f = isHaveFrdrq();
            if (f != null)
            {
                f.Focus();
            }
            else
            {
                Friendreq frq = new Friendreq();
                frq.iswork = true;
                frq.Bw = Bw;
                FriendreqList.Add(frq);
                frq.Show();
            }

        }
        private Friendreq isHaveFrdrq()
        {
            foreach (Friendreq frq in FriendreqList)
            {
                if (frq.iswork == true)
                    return frq;
            }
            return null;
        }
        public static void RemoveFriendreq()
        {
            foreach (Friendreq f in FriendreqList)
            {
                if (f.iswork == true)
                {
                    FriendreqList.Remove(f);
                    return;
                }
            }
        }

        private void addfrd_btn_Click(object sender, EventArgs e)
        {
            Addfriend f = isHaveAddfrd();
            if (f != null)
            {
                f.Focus();
            }
            else
            {
                Addfriend adf = new Addfriend();
                adf.iswork = true;
                adf.Bw = Bw;
                addfmList.Add(adf);
                adf.Show();
            }
        }
        private Addfriend isHaveAddfrd()
        {
            foreach (Addfriend adf in addfmList)
            {
                if (adf.iswork == true)
                    return adf;
            }
            return null;
        }
        public static void RemoveAddfrd()
        {
            foreach (Addfriend a in addfmList)
            {
                if (a.iswork == true)
                {
                    addfmList.Remove(a);
                    return;
                }
            }
        }
        //弹出菜单
        private void lv_friends_MouseClick(object sender, MouseEventArgs e)
        {
            lv_friends.MultiSelect = false;
            if (e.Button == MouseButtons.Right)
            {
                string UID = lv_friends.SelectedItems[0].Text;
                Point p = new Point(e.X, e.Y);
                cm_frd.Show(lv_friends, p);
            }
        }
        //删除好友
        private void frddelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_friends.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定删除好友吗？", "提示:",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("delfriends#" + lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
            //MessageBox.Show(lvitm.SubItems[1].Text);         
        }
        //修改好友分组
        private void frdgrpcgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_friends.SelectedItems[0];
                string UID = lvitem.Text;
                frdgroupcg f = isHavefrdgrpcg();
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    frdgroupcg fgcg = new frdgroupcg();
                    fgcg.iswork = true;
                    fgcg.UID = UID;
                    fgcg.Bw = Bw;
                    frdgrpcgList.Add(fgcg);
                    fgcg.Show();
                }
            }
        }
        private frdgroupcg isHavefrdgrpcg()
        {
            foreach (frdgroupcg frq in frdgrpcgList)
            {
                if (frq.iswork == true)
                    return frq;
            }
            return null;
        }
        public static void Removefrdgrpcg()
        {
            foreach (frdgroupcg frq in frdgrpcgList)
            {
                if (frq.iswork == true)
                {
                    frdgrpcgList.Remove(frq);
                    return;
                }
            }
        }
        //查看用户信息
        private void frdstateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_friends.SelectedItems[0];
                string UID1 = lvitem.Text;
                Userstate us = isHaveuserstate(UID1);
                if (us != null)
                {
                    us.Focus();
                }
                else
                {
                    Userstate ust = new Userstate();
                    ust.UID = UID1;
                    if (UID1 == UID)
                    {
                        ust.isself = true;
                    }
                    else
                    {
                        ust.isself = false;
                    }
                    ust.Bw = Bw;
                    ust.username = lvitem.SubItems[1].Text;
                    ust.sign = lvitem.Tag.ToString();
                    userstateList.Add(ust);
                    ust.Show();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Userstate us = isHaveuserstate(UID);
            if (us != null)
            {
                us.Focus();
            }
            else
            {
                Userstate ust = new Userstate();
                ust.UID = UID;
                ust.isself = true;
                ust.Bw = Bw;
                ust.username = Username;
                ust.sign = sign;
                userstateList.Add(ust);
                ust.Show();
            }
        }

        private Userstate isHaveuserstate(string UID)
        {
            foreach (Userstate ust in userstateList)
            {
                if (ust.UID == UID)
                    return ust;
            }
            return null;
        }
        public static void Removeuserstate(string UID)
        {
            foreach (Userstate ust in userstateList)
            {
                if (ust.UID == UID)
                {
                    userstateList.Remove(ust);
                    return;
                }
            }
        }

        private void lv_friends_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class noread
    {

        public string UID { get; set; }
        public string user { get; set; }
        public string time { get; set; }
        public string words { get; set; }
        public noread(string userid, string u, string t, string w)
        {
            UID = userid;
            user = u;
            time = t;
            words = w;
        }


    }
    public class reqlock
    {
        public string UID { get; set; }
        public object newmsglock { get; set; }
        public int newmsg { get; set; }
        public reqlock(string userid)
        {
            UID = userid;
            newmsg = 0;
            newmsglock = new object();
        }
    }

    public class Groupnoread
    {
        public string GID { get; set; }
        public string UID { get; set; }
        public string user { get; set; }
        public string time { get; set; }
        public string words { get; set; }
        public Groupnoread(string grpid, string userid, string u, string t, string w)
        {
            GID = grpid;
            UID = userid;
            user = u;
            time = t;
            words = w;
        }
    }

    public class Grouplock
    {
        public string GID { get; set; }
        public object newmsglock { get; set; }
        public int newmsg { get; set; }
        public Grouplock(string grpid)
        {
            GID = grpid;
            newmsg = 0;
            newmsglock = new object();
        }

    }

    public class Mureq
    {
        private string uid;
        private string username;
        private string gid;
        private string groupname;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string UID
        {
            get { return uid; }
            set { uid = value; }
        }
        public string Groupname
        {
            get { return groupname; }
            set { groupname = value; }
        }
        public string GID
        {
            get { return gid; }
            set { gid = value; }
        }
        public Mureq(String UID,String Username,String GID,String Groupname)
        {
            uid = UID;
            username = Username;
            gid = GID;
            groupname = Groupname;
        }

    }
}



public class User
{
    private string uid;
    private string username;
    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    public string UID
    {
        get { return uid; }
        set { uid = value; }
    }
    private string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    private string ip;
    public string IP
    {
        get { return ip; }
        set { ip = value; }
    }
    private int port;
    public int Port
    {
        get { return port; }
        set { port = value; }
    }
    public User(string ID,string Usrname)
    {
        uid = ID;
        username = Usrname;
    }
}