using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;

namespace AppMod.WebSys
{
   
    [Serializable]
    public class PageInfo<T>
    {
        private int _total;
        private List<T> _list;

        /// <summary>
        /// 是否第一页
        /// </summary>
        [DataMember(Name = "total")]
        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        [DataMember(Name = "list")]
        public List<T> List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }
    }
}
