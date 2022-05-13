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
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Friendreq : Form
    {
        public bool iswork { get; set; }
        public BinaryWriter Bw { get; set; }
        public static List<Friendreqitem> frdformList = new List<Friendreqitem>();
        public Friendreq()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //好友申请
            lv_frdreq.Columns.Add("请求ID", 60, HorizontalAlignment.Left);
            lv_frdreq.Columns.Add("昵称", 60, HorizontalAlignment.Left);
            lv_frdreq.Columns.Add("请求状态", 60, HorizontalAlignment.Left);
            //发送的好友申请
            lv_frdputreq.Columns.Add("请求ID", 60, HorizontalAlignment.Left);
            lv_frdputreq.Columns.Add("昵称", 60, HorizontalAlignment.Left);
            lv_frdputreq.Columns.Add("请求状态", 60, HorizontalAlignment.Left);
        }
        private void Friendreq_Load(object sender, EventArgs e)
        {
            addreqitem();
            addputreqitem();
        }

        public void addreqitem()
        {
            for (int i = 0; i < list.frdreqList.Count; i++)
            {
                
                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageIndex = 0;
                lvitem.Text = list.frdreqList[i].UID;
                lvitem.SubItems.Add(list.frdreqList[i].Username);
                lvitem.SubItems.Add("未处理");
                lvitem.Tag = 0;
                lv_frdreq.Items.Add(lvitem);
            }
        }
        public void addputreqitem()
        {
            for (int i = 0; i < list.putfrdreqList.Count; i++)
            {

                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageIndex = 0;
                lvitem.Text = list.putfrdreqList[i].UID;
                lvitem.SubItems.Add(list.putfrdreqList[i].Username);
                lvitem.SubItems.Add("未处理");
                lvitem.Tag = 0;
                lv_frdputreq.Items.Add(lvitem);
            }
        }
        
        
        public void reloadreqitem()
        {
            //MessageBox.Show("trytoclear");
            lv_frdreq.Items.Clear();
            addreqitem();
        }
        public void reloadputreqitem()
        {
            //MessageBox.Show("trytoclear");
            lv_frdputreq.Items.Clear();
            addputreqitem();
        }
        private void lv_frdreq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lv_frdreq.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_frdreq.SelectedItems[0];
                string toUID = lvitem.Text;
                //string toips = lvitem.Tag.ToString();
                Friendreqitem f = isHaveFriendreqitem(toUID);
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    Friendreqitem frditm = new Friendreqitem();
                    frditm.toUID = toUID;
                    frditm.toName = lvitem.SubItems[1].Text;
                    frditm.Bw = Bw;
                    frdformList.Add(frditm);
                    frditm.Show();
                }
            }
        }
        
        private void Friendreq_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.RemoveFriendreq();
        }

        private Friendreqitem isHaveFriendreqitem(String toUID)
        {
            foreach (Friendreqitem frqitm in frdformList)
            {
                if (frqitm.toUID == toUID)
                    return frqitm;
            }
            return null;
        }
        public static void removeFriendreqitem(String toUID)
        {
            foreach(Friendreqitem frq in frdformList)
            {
                if (frq.toUID == toUID)
                {
                    frdformList.Remove(frq);
                    return;
                }
            }
        }

        private void Friendreq_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*for (int i = 0; i < frdformList.Count; i++)
            {

            }*/
        }

        private void lv_frdputreq_MouseClick(object sender, MouseEventArgs e)
        {
            lv_frdputreq.MultiSelect = false;
            //鼠标右键  
            if (e.Button == MouseButtons.Right)
            {
                //filesList.ContextMenuStrip = contextMenuStrip1;  
                //选中列表中数据才显示 空白处不显示  
                string UID = lv_frdputreq.SelectedItems[0].Text;   
                Point p = new Point(e.X, e.Y);
                contextMenuStrip1.Show(lv_frdputreq, p);
            }
        }
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_frdputreq.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_frdputreq.SelectedItems[0];
            //MessageBox.Show(lvitm.SubItems[1].Text);
            Bw.Write("cancelfrdreq#" + lvitm.SubItems[0].Text);
        }


        
    }
}
