using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace YF.BLL
{
    public class FriendListManager
    {
        public static bool Edit(string num, YF.Model.User stu)
        {
            bool flag = true;

            //string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            //using (MySqlConnection conn = new MySqlConnection(constr))
            //{
            //    string sql = "update t_student set name='" + stu.Name + "',class='" + stu.Class + "',major='" + stu.Major
            //        + "',grade='" + stu.Grade + "',score='" + stu.Score + "',college='" + stu.College + "' where num='" + stu.Num + "'";
            //    MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    conn.Open();
            //    int count = cmd.ExecuteNonQuery();
            //    if (count != 1)
            //    {
            //        flag = false;
            //    }
            //    Console.WriteLine(count);

            //    conn.Close();
            //}

            return flag;
        }

        public static bool add(YF.Model.User stu)
        {
            bool flag = true;

            //string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            //using (MySqlConnection conn = new MySqlConnection(constr))
            //{
            //    string sql = "insert t_student (num,name,college,major,class,grade,score) values " +
            //        "('" + stu.Num + "','" + stu.Name + "','" + stu.College + "','" + stu.Major + "','" + stu.Class + "','" + stu.Grade + "','" + stu.Score + "')";
            //    MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    conn.Open();
            //    int count = cmd.ExecuteNonQuery();
            //    if (count != 1)
            //    {
            //        flag = false;
            //    }
            //    Console.WriteLine(count);

            //    conn.Close();
            //}

            return flag;
        }

        public static bool check(string num)
        {
            bool flag = true;


            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                object o = null;
                string sql = "select num from t_student where num='" + num + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                o = cmd.ExecuteScalar();
                if (o != null)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
                conn.Close();
            }


            return flag;
        }

        public static bool delete(string num)
        {
            bool flag = true;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "delete from t_student where num='" + num + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count != 1)
                {
                    flag = false;
                }
                Console.WriteLine(count);

                conn.Close();
            }

            return flag;
        }

        public static List<string> searchfriend(string UID1)
        {
            List<string> list = new List<string>();
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sqlstr = "select * from friends user where (UID1='" + UID1 + "');";
                MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, conn);
                DataSet myds = new DataSet();
                conn.Open();
                myda.Fill(myds);
                DataTable dt = new DataTable();
                dt = myds.Tables[0];
                int count = dt.Rows.Count;
                while (count != 0)
                {
                    DataRow dr = dt.NewRow();
                    dr = dt.Rows[count - 1];
                    list.Add(dr["UID2"].ToString());
                    count--;
                }
                Console.WriteLine(count);
                conn.Close();
                return list;
            }
        }

        public static bool addFriendreq(string UID1, string UID2)
        {
            bool flag = true;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "INSERT INTO frdreq (UID1,UID2,expgroup) VALUES ('" + UID1 + "','" + UID2 + "','我的好友');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count != 1)
                {
                    flag = false;
                }
                Console.WriteLine(count);

                conn.Close();
            }

            return flag;
        }

        public static bool delFriendreq(string UID1, string UID2)
        {
            bool flag = true;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "delete from frdreq where UID1='" + UID1 + "' and UID2='" + UID2 + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count != 1)
                {
                    flag = false;
                }
                Console.WriteLine(count);

                conn.Close();
            }

            return flag;
        }

        public static bool addFriend(string UID1,string UID2)
        {
            bool flag = true;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "INSERT INTO friends (UID1,UID2,`groups`) VALUES ('" + UID1 + "','" + UID2 +"','我的好友');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count != 1)
                {
                    flag = false;
                }
                Console.WriteLine(count);

                conn.Close();
            }

            return flag;
        }
    }
}
