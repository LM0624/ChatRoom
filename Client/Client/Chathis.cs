using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Chathis : Form
    {
        public string UserName;
        public string ToName;
        public string UID;
        public Chathis()
        {
            InitializeComponent();
        }

        public Chathis(string UserName, string ToName, string UID)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.ToName = ToName;
            this.UID = UID;
            BindData();
        }

        private void BindData()
        {
            string constr = "server=localhost;user id=root;password=A12344321a;database=chatroom;Charset=utf8";
            //绑定GridView
            string sqlstr = "SELECT * FROM CHATHIS order by Sendtime desc;";
            MySqlConnection sqlcon = new MySqlConnection(constr);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlcon.Open();
            myda.Fill(myds);
            DataTable dt = new DataTable();
            dt = myds.Tables[0];
            int count = dt.Rows.Count;
            while (count!=0)
            {
                DataRow dr = dt.NewRow();
                dr = dt.Rows[count-1];
                string message = dr["Sendwords"].ToString();
                string time = dr["Sendtime"].ToString();
                string sender = dr["UID1"].ToString();
                bool isuser;
                if (sender == UID)
                {
                    isuser = true;
                }
                else
                {
                    isuser = false;
                }
                AddMessage(message, isuser, time);
                count--;
            }
            sqlcon.Close();
        }

        public void AddMessage(string str, bool isuser, string time)
        {
            int startindex = this.rtb_ShowMsg.Text.Length;

            string message = string.Empty;

            if (isuser)
                message = "【" + ToName + "】  " + time + "\n" + str + "\n";
            else
                message = "【" + UserName + "】  " + time + "\n" + str + "\n";
            this.rtb_ShowMsg.AppendText(message);
            this.rtb_ShowMsg.Select(startindex, message.Length);
            if (isuser)
            {
                this.rtb_ShowMsg.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                this.rtb_ShowMsg.SelectionAlignment = HorizontalAlignment.Right;
            }
            this.rtb_ShowMsg.Select(this.rtb_ShowMsg.Text.Length, 0);
        }
    }
}
