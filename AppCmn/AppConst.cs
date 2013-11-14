using System;
using System.Collections;

namespace AppCmn
{
    /// <summary>
    /// Summary description for AppConst.
    /// </summary>
    public class AppConst
    {
        #region 系统中判断未赋值的判断，只可以用于比较判断，不能用于赋值

        public const string StringNull = "";
        public const int IntNull = -999999;
        public const decimal DecimalNull = -999999;

        public static DateTime DateTimeNull = DateTime.Parse("8000-01-01");

        #endregion

        public const string AllSelectString = "--- ALL ---";
        public const string DecimalToInt = "#########0"; //用于point的显示，一般来说currentprice应该没有分。
        public const string DecimalFormat = "#########0.00";
        public const string DecimalFormatWithGroup = "#,###,###,##0.00";
        public const string IntFormatWithGroup = "#,###,###,##0";
        public const string DecimalFormatWithCurrency = "￥#########0.00";
        public const string DateFormat = "yyyy-MM-dd";
        public const string DateFormatLong = "yyyy-MM-dd HH:mm:ss";

        //用于DataGrid中每页的记录数
        public const int PageSize = 20;

        //用于DataGrid中每页按钮的数目
        public const int PageButtonCount = 4;

        //前台用户注册初始头像路径
        public const string OriginalPhoto = @"~\WebResources\Images\tx_03.jpg";
        //前台用户注册初始等级SysNo
        public const int OriginalGrade = 1;
        
        //前台用户注册初始个人介绍
        public const string OriginalIntro = "";
        //前台用户注册初始个人签名
        public const string OriginalSign = "";


        //名人库默认头像
        public const string OriginalFamousPhoto = "";


        #region cachename

        public const string HomePageNewCeQuest = "HomePageNewCeQuest";
        public const string HomePageNewCeAnswer = "HomePageNewCeAnswer";
        public const string HomePageNewStudyQuest = "HomePageNewStudyQuest";
        public const string HomePageNewStudyAnswer = "HomePageNewStudyAnswer";

        public const string HomePageArticle = "HomePageArticle";
        public const string HomePageFamous = "HomePageFamous";
        public const string HomePageFamousKey = "HomePageFamousKey";

        public const string AstroDiceNewQuest = "AstroDiceNewQuest";
        public const string AstroDiceNewAnswer = "AstroDiceNewAnswer";
        public const string AstroDiceAricle = "AstroDiceAricle";
        #endregion cachename

        #region 默认系统消息
        //注册欢迎站内信
        public const string NewUserWelcome = @"<p>亲爱的@nickname，欢迎加入上上签！</p><p>您可以从<a target='_blank' href='@userinfourl'>这里</a>完善自己的个人信息便于大家更好地认识您，灵签在站内各处都有比较大的用处，您可以点击<a target='_blank' href='@pointhelpurl'>这里</a>了解如何获取灵签。上上签是一个中立平台，旨在为命理爱好者与求测者提供更好的服务，有任何建议或问题请点击这里联系站长，祝您在上上签愉快！</p>";
        //问题被回答时的通知
        public const string AnswerReport = @"有人对您发布的问题<a target='_blank' href='@url'>“@question”</a>发表了回答。";
        //回答被评论时的通知
        public const string FeedbackReport = @"<a target='_blank' href='@url'>“@question”</a>问题的楼主对您的回答做了反馈。";
        //回答被评论时的通知
        public const string CommentReport = @"有人对您的回答发表了评论，<a target='_blank' href='@url'>点击查看</a>";
        #endregion

        #region 奖励积分，经验值
        //前台用户注册初始积分
        public const int OriginalPoint = 20;
        //发表回答奖励积分
        public const int AnswerPoint = 1;
        //发表回答奖励经验
        public const int AnswerExp = 1;
        //发表评论回答奖励积分
        public const int CommentPoint = 1;
        //发表评论回答奖励经验
        public const int CommentExp = 1;
        //楼主反馈附加奖励积分
        public const int ReplyPoint = 1;
        //楼主反馈附加奖励经验
        public const int ReplyExp = 1;
        //被删帖去除积分
        public const int DeletePoint = -2;
        //被删帖去除经验
        public const int DeleteExp = -2;
        //发布话题奖励积分
        public const int TalkPoint = 2;
        //发布话题奖励经验
        public const int TalkExp = 2;
        #endregion
    }
}
