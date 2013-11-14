using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForAdmin.ControlLibrary
{
    public partial class Pagination : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initialpager();
        }

        public void initialpager()
        {
            int numstart = 1;
            int numend = total;
            if (index - numlenth > numstart)
            {
                numstart = index - numlenth;
            }
            if (numstart + numlenth * 2 < numend)
            {
                numend = numstart + numlenth * 2;
            }
            if (numend == total)
            {
                if (numend - numlenth * 2 > 1)
                {
                    numstart = numend - numlenth * 2;
                }
                else
                {
                    numstart = 1;
                }
            }
            ltrnum.Text = "";
            for (int i = numstart; i <= numend; i++)
            {
                if (index == i)
                {
                    ltrnum.Text += @"<a href=""" + _url + i.ToString() + @""" class=""number current"" title=""" + i.ToString() + @""">" + i.ToString() + "</a>";
                }
                else
                {
                    ltrnum.Text += @"<a href=""" + _url + i.ToString() + @""" class=""number"" title=""" + i.ToString() + @""">" + i.ToString() + "</a>";
                }
            }
            if (numend != total)
            {
                ltrnum.Text += @"...";
            }
            if (numstart != 1)
            {
                ltrnum.Text = @"..." + ltrnum.Text;
            }


            if (index == 1)
            {
                ltrpre.Text = @"<a href=""" + _url + @"1"" title=""首页"">&laquo; 首页</a>&laquo; 上一页";
            }
            else
            {
                ltrpre.Text = @"<a href=""" + _url + @"1"" title=""首页"">&laquo; 首页</a><a href=""" + _url + (index - 1).ToString() + @""" title=""上一页"">&laquo; 上一页</a>";
            }


            if (index == total || total == 0)
            {
                ltrnext.Text = @"下一页 &raquo;<a href=""" + _url + (index).ToString() + @""" title=""尾页"">尾页 &raquo;</a>";
            }
            else
            {
                ltrnext.Text = @"<a href=""" + _url + (index + 1).ToString() + @""" title=""下一页"">下一页 &raquo;</a><a href=""" + _url + total.ToString() + @""" title=""尾页"">尾页 &raquo;</a>";
            }
        }

        private int _numlenth = AppCmn.AppConst.PageButtonCount;//数字个数半长
        public int numlenth
        {
            set { _numlenth = value; }
            get { return _numlenth; }
        }

        private string _url = "";//除页数的URL
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }

        private int _total = 1;//总页数
        public int total
        {
            set { _total = value; }
            get { return _total; }
        }

        private int _index = 1;
        public int index
        {
            set { _index = value; }
            get { return _index; }
        }

        private int _pagesize = AppCmn.AppConst.PageSize;
        public int pagesize
        {
            set { _pagesize = value; }
            get { return _pagesize; }
        }
    }
}