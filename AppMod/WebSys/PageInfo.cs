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
        private bool _hasNextPage;
        private List<T> _list;

        /// <summary>
        /// 总数
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

        [DataMember(Name = "hasNextPage")]
        public bool HasNextPage
        {
            get
            {
                return _hasNextPage;
            }
            set
            {
                _hasNextPage = value;
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
