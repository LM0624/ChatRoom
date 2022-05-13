using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YF.Model
{
    public class User
    {
        private string _UID;
        public string UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        private string _account;
        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _nickname;
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        private string _sign;
        public string Sex
        {
            get { return _sign; }
            set { _sign = value; }
        }

    }
}
