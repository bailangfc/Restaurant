using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    public class CategoryInfo
    {
        #region Model
        private int _catid;
        private string _catname;
        private string _catnum;
        private string _remark;
        private int? _delflag;
        private DateTime? _subtime;
        private int? _subby;

        public int Catid
        {
            get
            {
                return _catid;
            }

            set
            {
                _catid = value;
            }
        }

        public string Catname
        {
            get
            {
                return _catname;
            }

            set
            {
                _catname = value;
            }
        }

        public string Catnum
        {
            get
            {
                return _catnum;
            }

            set
            {
                _catnum = value;
            }
        }

        public string Remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
            }
        }

        public int? Delflag
        {
            get
            {
                return _delflag;
            }

            set
            {
                _delflag = value;
            }
        }

        public DateTime? Subtime
        {
            get
            {
                return _subtime;
            }

            set
            {
                _subtime = value;
            }
        }

        public int? Subby
        {
            get
            {
                return _subby;
            }

            set
            {
                _subby = value;
            }
        }
        #endregion
    }
}
