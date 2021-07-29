using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    public class MemmberType
    {
        private int _memType;

        private string _memTpName;

        public string MemTpName
        {
            get
            {
                return _memTpName;
            }

            set
            {
                _memTpName = value;
            }
        }

        public int MemType
        {
            get
            {
                return _memType;
            }

            set
            {
                _memType = value;
            }
        }
    }
}
