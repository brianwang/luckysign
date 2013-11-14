using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppCmn;
using System.ComponentModel;
using AppMod.Fate;
using AppBll.Fate;

namespace WebForMain.ControlLibrary
{
    public partial class ComboShow : System.Web.UI.UserControl
    {
        public DataTable DataList
        {
            get
            {
                return _datalist;
            }
            set
            {
                _datalist = value;
            }
        }
        public ComboShowType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public bool IsWide
        {
            get
            {
                return _iswide;
            }
            set
            {
                _iswide = value;
            }
        }

        public enum ComboShowType
        {
            [Description("文章")]
            Article = 1,
            [Description("链接")]
            Link = 2,
            [Description("命盘")]
            Chart = 3,
            [Description("问答")]
            Quest = 4,
            [Description("名人")]
            Famous = 5,
            [Description("全部")]//用于首页，包括文章，图片，文件，链接，命盘
            All = 6,
        }
        
        private DataTable _datalist = new DataTable();
        private ComboShowType _type = ComboShowType.Article;
        private bool _iswide = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            _datalist.Columns.Add("TitleShow");
            _datalist.Columns.Add("ImgShow");
            _datalist.Columns.Add("ContentShow");
            _datalist.Columns.Add("ReadShow");
            _datalist.Columns.Add("CommentShow");
            _datalist.Columns.Add("PhotoID");
            _datalist.Columns.Add("PersonID");
            _datalist.Columns.Add("ifshowphoto");
            _datalist.Columns.Add("width");
            
            if (!_datalist.Columns.Contains("Photo"))
            {
                _datalist.Columns.Add("Photo");
            }
            if (!_datalist.Columns.Contains("NickName"))
            {
                _datalist.Columns.Add("NickName");
            }

            switch (_type)
            {
                case ComboShowType.Article:
                    for (int i = 0; i < _datalist.Rows.Count; i++)
                    {
                        _datalist.Rows[i]["TitleShow"] = @"<a href=""../Atricle/Content.aspx?id=" + _datalist.Rows[i]["ArticleSysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                        _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Description"].ToString();
                        _datalist.Rows[i]["ReadShow"] = @"<a href=""../Atricle/Content.aspx?id=" + _datalist.Rows[i]["ArticleSysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />阅读(" + _datalist.Rows[i]["ReadCount"].ToString() + ")</a>";
                        _datalist.Rows[i]["CommentShow"] = @"";
                    }
                    break;
                case ComboShowType.Chart:
                    for (int i = 0; i < _datalist.Rows.Count; i++)
                    {
                        _datalist.Rows[i]["TitleShow"] = _datalist.Rows[i]["Name"].ToString();
                        _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Detail"].ToString(); ;
                        _datalist.Rows[i]["ReadShow"] = @"<a href=""javascript:void(0)"" onclick=""javascript:var chart = document.getElementById('chartdiv" + i + @"');if(chart.style.display == '') chart.style.display = 'none'; else chart.style.display = '';"">
                            <img id='showpic" + i + @"' src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />命盘</a>";
                        _datalist.Rows[i]["CommentShow"] = @"";
                        _datalist.Rows[i]["PhotoID"] = @"photoid" + i + @""" style=""display:none;";
                        _datalist.Rows[i]["PersonID"] = @"personid" + i + @""" style=""display:none;";
                        _datalist.Rows[i]["Photo"] = @"";
                        _datalist.Rows[i]["NickName"] = @"";
                        rptCombo.ItemDataBound += new RepeaterItemEventHandler(rptCombo_ItemDataBound);
                    }
                    break;
                case ComboShowType.Famous:
                    for (int i = 0; i < _datalist.Rows.Count; i++)
                    {
                        _datalist.Rows[i]["TitleShow"] = @"<a href=""../Famous/Detail.aspx?id=" + CommonTools.Encode(_datalist.Rows[i]["RefSysNo"].ToString()) + @""">" + _datalist.Rows[i]["FamousName"].ToString() + "</a>";
                        _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Description"].ToString();
                        _datalist.Rows[i]["ReadShow"] = @"<a href=""../Famous/Detail.aspx?id=" + CommonTools.Encode(_datalist.Rows[i]["RefSysNo"].ToString()) + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />关注度(" + _datalist.Rows[i]["CollectCount"].ToString() + ")</a>";
                        _datalist.Rows[i]["CommentShow"] = @"";
                    }
                    break;
                case ComboShowType.Link:
                    for (int i = 0; i < _datalist.Rows.Count; i++)
                    {
                        _datalist.Rows[i]["TitleShow"] = @"<a target='_blank' href=""" + _datalist.Rows[i]["RefUrl"].ToString() + @""">" + _datalist.Rows[i]["Name"].ToString() + "</a>";
                        _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Detail"].ToString();
                        _datalist.Rows[i]["ReadShow"] = @"<a target='_blank' href=""" + _datalist.Rows[i]["RefUrl"].ToString() + @""">打开页面</a>";
                        _datalist.Rows[i]["CommentShow"] = @"";
                        _datalist.Rows[i]["PhotoID"] = @"photoid" + i + @""" style=""display:none;";
                        _datalist.Rows[i]["PersonID"] = @"personid" + i + @""" style=""display:none;";
                        _datalist.Rows[i]["Photo"] = @"";
                    }
                    break;
                case ComboShowType.Quest:
                    for (int i = 0; i < _datalist.Rows.Count; i++)
                    {
                        _datalist.Rows[i]["TitleShow"] = @"<a href=""../Quest/Question.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                        _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Context"].ToString();
                        _datalist.Rows[i]["ReadShow"] = @"<a href=""../Quest/Question.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />悬赏(" + _datalist.Rows[i]["Award"].ToString() + ")</a>";
                        _datalist.Rows[i]["CommentShow"] = @"<a href=""../Quest/Question.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">回复(" + _datalist.Rows[i]["ReplyCount"].ToString() + ")</a>";
                    }
                    break;
                case ComboShowType.All:
                default:
                    for (int i = 0; i < _datalist.Rows.Count; i++)
                    {
                        switch (int.Parse(_datalist.Rows[i]["Type"].ToString()))
                        {
                            case (int)AppEnum.BlogArticleType.Article:
                                _datalist.Rows[i]["TitleShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                                _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Context"].ToString();
                                _datalist.Rows[i]["ReadShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />评论(" + _datalist.Rows[i]["CommentCount"].ToString() + ")</a>";
                                _datalist.Rows[i]["CommentShow"] = @"";
                                break;
                            case (int)AppEnum.BlogArticleType.Chart:
                                _datalist.Rows[i]["TitleShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                                _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Context"].ToString();
                                _datalist.Rows[i]["ReadShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />评论(" + _datalist.Rows[i]["CommentCount"].ToString() + ")</a>";
                                _datalist.Rows[i]["CommentShow"] = @"";
                                rptCombo.ItemDataBound += new RepeaterItemEventHandler(rptCombo_ItemDataBound);
                                break;
                            case (int)AppEnum.BlogArticleType.File:
                                _datalist.Rows[i]["TitleShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                                string[] tmps = _datalist.Rows[i]["TargetUrl"].ToString().Split(new char[] { '|' });
                                foreach (string tmp in tmps)
                                {
                                    if (tmp != "")
                                    {
                                        string lastname = tmp.Substring(tmp.LastIndexOf(".") + 1);
                                        _datalist.Rows[i]["ContentShow"] += @"<a href=""" + tmp + @""" target='_blank'><img src=""../WebResources/" + GetFileIcon(lastname) + @""" /></a>";
                                    }
                                }
                                _datalist.Rows[i]["ContentShow"] += "<br />" + _datalist.Rows[i]["Context"].ToString();
                                _datalist.Rows[i]["ReadShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />评论(" + _datalist.Rows[i]["CommentCount"].ToString() + ")</a>";
                                _datalist.Rows[i]["CommentShow"] = @"";
                                break;
                            case (int)AppEnum.BlogArticleType.Link:
                                _datalist.Rows[i]["TitleShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                                _datalist.Rows[i]["ContentShow"] = @"<a href=""" + _datalist.Rows[i]["TargetUrl"].ToString() + @""" target='_blank'>"
                                    + _datalist.Rows[i]["TargetUrl"].ToString() + "</a><br />" + _datalist.Rows[i]["Context"].ToString();
                                _datalist.Rows[i]["ReadShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />评论(" + _datalist.Rows[i]["CommentCount"].ToString() + ")</a>";
                                _datalist.Rows[i]["CommentShow"] = @"";
                                break;
                            case (int)AppEnum.BlogArticleType.Picture:
                                _datalist.Rows[i]["TitleShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">" + _datalist.Rows[i]["Title"].ToString() + "</a>";
                                _datalist.Rows[i]["ImgShow"] = @"<div class=""page_person_image"">
                            <img src=""" + _datalist.Rows[i]["TargetUrl"].ToString() + @""" /></div>";
                                _datalist.Rows[i]["ContentShow"] = _datalist.Rows[i]["Context"].ToString();
                                _datalist.Rows[i]["ReadShow"] = @"<a href=""Atricle.aspx?id=" + _datalist.Rows[i]["SysNo"].ToString() + @""">
                            <img src=""../WebResources/img/page/read.gif"" align=""absmiddle"" />评论(" + _datalist.Rows[i]["CommentCount"].ToString() + ")</a>";
                                _datalist.Rows[i]["CommentShow"] = @"";
                                break;
                        }
                    }

                    break;
            }

            if (_iswide)
            {
                for (int i = 0; i < _datalist.Rows.Count; i++)
                {
                    _datalist.Rows[i]["width"] = i + "' style='width:690px;padding-left:0px;";
                    _datalist.Rows[i]["ifshowphoto"] = i + "' style='display:none;";
                }
            }

            rptCombo.DataSource = _datalist;
            rptCombo.DataBind();
        }

        protected void rptCombo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            PageBase m_pb = new PageBase();
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            int fatesysno = Convert.ToInt32(rowv["refsysno"]);
            FATE_ChartMod m_chart = FATE_ChartBll.GetInstance().GetModel(fatesysno);
            try
            {
                switch (m_pb.GetSession().CustomerEntity.FateType)
                {
                    case (int)AppEnum.FateType.astro:
                        AstroForQuest Astro1 = (AstroForQuest)e.Item.FindControl("Astro1");
                        Astro1.input = m_chart;
                        Astro1.Visible = true;
                        break;
                    case (int)AppEnum.FateType.ziwei:
                        ZiWeiForQuest Ziwei1 = (ZiWeiForQuest)e.Item.FindControl("Ziwei1");
                        Ziwei1.input = m_chart;
                        Ziwei1.Visible = true;
                        break;
                    case (int)AppEnum.FateType.bazi:
                        BaZiForQuest Bazi1 = (BaZiForQuest)e.Item.FindControl("Bazi1");
                        Bazi1.input = m_chart;
                        Bazi1.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        private string GetFileIcon(string input)
        {
            return input;
        }
    }
}