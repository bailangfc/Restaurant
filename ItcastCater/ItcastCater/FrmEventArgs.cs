﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater
{
    /// <summary>
    /// 窗体传值用的类
    /// </summary>
    public class FrmEventArgs:EventArgs
    {
        /// <summary>
        /// 表示
        /// </summary>
        public int Temp { get; set; }
        /// <summary>
        /// 对象
        /// </summary>
        public object obj { get; set; }

        /// <summary>
        /// 存钱
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
