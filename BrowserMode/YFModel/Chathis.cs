using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YF.Model
{
    public class Chathis
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _UID1;
        public string UID1
        {
            get { return _UID1; }
            set { _UID1 = value; }
        }

        private string _UID2;
        public string UID2
        {
            get { return _UID2; }
            set { _UID2 = value; }
        }

        private int _isread;
        public int Isread
        {
            get { return _isread; }
            set { _isread = value; }
        }

        private string _sendTime;
        public string SendTime
        {
            get { return _sendTime; }
            set { _sendTime = value; }
        }

        private string _sendwords;
        public string Sendwords
        {
            get { return _sendwords; }
            set { _sendwords = value; }
        }
    }
}
