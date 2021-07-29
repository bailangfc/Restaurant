using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    public class UserInfo
    {
        private int _userId;
        private string _userName;
        private string _loginUserName;
        private string _pwd;
        private DateTime? _lastLoginTime;
        private string _lastLoginIp;
        private int _delFlag;
        private DateTime? _subTime;

        public DateTime? SubTime
        {
            get
            {
                return _subTime;
            }

            set
            {
                _subTime = value;
            }
        }

        public int DelFlag
        {
            get
            {
                return _delFlag;
            }

            set
            {
                _delFlag = value;
            }
        }

        public string LastLoginIp
        {
            get
            {
                return _lastLoginIp;
            }

            set
            {
                _lastLoginIp = value;
            }
        }

        public DateTime? LastLoginTime
        {
            get
            {
                return _lastLoginTime;
            }

            set
            {
                _lastLoginTime = value;
            }
        }

        public string Pwd
        {
            get
            {
                return _pwd;
            }

            set
            {
                _pwd = value;
            }
        }

        public string LoginUserName
        {
            get
            {
                return _loginUserName;
            }

            set
            {
                _loginUserName = value;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }
    }
}
