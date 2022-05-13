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
    public class ChathisManager
    {
        public static bool add(YF.Model.Chathis chathis)
        {
            bool flag = true;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "INSERT INTO chathis (UID1,UID2,isread,Sendtime,Sendwords) VALUES ('" + chathis.UID1 + "','" + chathis.UID2 +
                    "','0','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + chathis.Sendwords + "');";
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

        public static bool delete(string id)
        {
            bool flag = true;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "delete from chathis where ID='" + id + "'";
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

        public static List<YF.Model.Chathis> search(string UID1, string UID2)
        {
            List<YF.Model.Chathis> list = new List<Model.Chathis>();
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sqlstr = "select * from chathis where (UID1='" + UID1 + "' and UID2='" + UID2 + "') " +
                    "or (UID1='" + UID2 + "' and UID2='" + UID1 + "') order by Sendtime desc;";
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
                    YF.Model.Chathis chathis = new Model.Chathis();
                    dr = dt.Rows[count - 1];
                    chathis.UID1 = dr["UID1"].ToString();
                    chathis.UID2 = dr["UID2"].ToString();
                    chathis.SendTime = dr["Sendtime"].ToString();
                    chathis.Sendwords = dr["Sendwords"].ToString();
                    list.Add(chathis);
                    count--;
                }
                Console.WriteLine(count);
                conn.Close();
                return list;
            }
        }

        public static bool setRead(string UID1, string UID2)
        {
            bool flag = false;

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sql = "update chathis set isread=1 where (UID1='" + UID2 + "' and UID2='" + UID1 + "') and isread=0;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                Console.WriteLine(count);

                conn.Close();
            }

            return flag;
        }

        public static List<YF.Model.Chathis> searchNoRead(string UID1, string UID2)
        {
            List<YF.Model.Chathis> list = new List<Model.Chathis>();
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string sqlstr = "select * from chathis where (UID1='" + UID2 + "' and UID2='" + UID1 + "') and isread=0 " +
                    " order by Sendtime desc;";
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
                    YF.Model.Chathis chathis = new Model.Chathis();
                    dr = dt.Rows[count - 1];
                    chathis.UID1 = dr["UID1"].ToString();
                    chathis.UID2 = dr["UID2"].ToString();
                    chathis.SendTime = dr["Sendtime"].ToString();
                    chathis.Sendwords = dr["Sendwords"].ToString();
                    list.Add(chathis);
                    count--;
                }
                Console.WriteLine(count);
                conn.Close();
                return list;
            }
        }

        
    }
}
