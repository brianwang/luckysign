using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using AppMod.Fate;

namespace AppMod.QA
{
    [Serializable]
    public class  QA_QuestionShow: QA_QuestionMod
    {

        #region 父类属性

        
        //public int SysNo
        //{
        //    set { _SysNo = value; }
        //    get { return _SysNo; }
        //}

        //public int CateSysNo
        //{
        //    set { _CateSysNo = value; }
        //    get { return _CateSysNo; }
        //}

        //public int CustomerSysNo
        //{
        //    set { _CustomerSysNo = value; }
        //    get { return _CustomerSysNo; }
        //}

        //public string Title
        //{
        //    set { _Title = value; }
        //    get { return _Title; }
        //}

        //public string Context
        //{
        //    set { _Context = value; }
        //    get { return _Context; }
        //}

        //public int Award
        //{
        //    set { _Award = value; }
        //    get { return _Award; }
        //}

        public new DateTime EndTime
        {
            set { base.EndTime = value; }
            get { return base.EndTime; }
        }

        public new int IsSecret
        {
            set { base.IsSecret = value; }
        }

        //public DateTime LastReplyTime
        //{
        //    set { _LastReplyTime = value; }
        //    get { return _LastReplyTime; }
        //}

        //public int LastReplyUser
        //{
        //    set { _LastReplyUser = value; }
        //    get { return _LastReplyUser; }
        //}

        //public int ReplyCount
        //{
        //    set { _ReplyCount = value; }
        //    get { return _ReplyCount; }
        //}

        //public int ReadCount
        //{
        //    set { _ReadCount = value; }
        //    get { return _ReadCount; }
        //}

        public new int DR
        {
            set { base.DR = value; }
            get { return base.DR; }
        }

        //public DateTime TS
        //{
        //    set { _TS = value; }
        //    get { return _TS; }
        //}


        #endregion

        #region 扩展属性

        private FATE_ChartMod _chart = new FATE_ChartMod();
        public FATE_ChartMod Chart
        {
            get { return _chart ; }
            set { _chart = value; }
        }

        public string LastReplyTimeShow
        {
            get { return base.LastReplyTime.ToString("yyyy-MM-dd HH:mm"); }
        }

        public string TSShow
        {
            get { return base.TS.ToString("yyyy-MM-dd HH:mm"); }
        }

        #endregion


    }

}
