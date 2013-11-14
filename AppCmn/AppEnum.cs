using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace AppCmn
{
    public static class AppEnum
    {
        #region 工具函数

        private static SortedList GetStatus(System.Type t)
        {
            SortedList list = new SortedList();

            Array a = Enum.GetValues(t);
            for (int i = 0; i < a.Length; i++)
            {
                string enumName = a.GetValue(i).ToString();
                int enumKey = (int)System.Enum.Parse(t, enumName);
                string enumDescription = GetDescription(t, enumKey);
                list.Add(enumKey, enumDescription);
            }
            return list;
        }

        private static string GetName(System.Type t, object v)
        {
            try
            {
                return Enum.GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 返回指定枚举类型的指定值的描述
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        private static string GetDescription(System.Type t, object v)
        {
            try
            {
                FieldInfo fi = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }
        #endregion

        #region 性别
        public enum Gender
        {
            [Description("女")]
            female = 0,
            [Description("男")]
            male = 1,
            [Description("保密")]
            none = 2
        }
        public static SortedList GetGender()
        {
            return GetStatus(typeof(Gender));
        }
        public static string GetGender(object v)
        {
            return GetDescription(typeof(Gender), v);
        }
        #endregion

        #region 普通查看权限类型
        public enum ReadType
        {
            [Description("所有人可见")]
            Public = 1,
            [Description("仅好友可见")]
            Friend = 2,
            [Description("凭密码访问")]
            Protect = 3,
            [Description("私密内容")]
            Private = 4
        }
        public static SortedList GetReadType()
        {
            return GetStatus(typeof(ReadType));
        }
        public static string GetReadType(object v)
        {
            return GetDescription(typeof(ReadType), v);
        }
        #endregion

        #region 通用状态
        public enum State
        {
            [Description("全部")]
            all = 100,
            [Description("正常")]
            normal = 0,
            [Description("已删除")]
            deleted = 1,
            [Description("审核中")]
            prepare = 2,
            [Description("已冻结")]
            frozen = 3,
        }
        public static SortedList GetState()
        {
            return GetStatus(typeof(State));
        }
        public static string GetState(object v)
        {
            return GetDescription(typeof(State), v);
        }
        #endregion

        #region 通用BOOL
        public enum BOOL
        {
            [Description("否")]
            False = 0,
            [Description("是")]
            True = 1,
            [Description("全部")]
            All = 2
        }
        public static SortedList GetBOOL()
        {
            return GetStatus(typeof(BOOL));
        }
        public static string GetBOOL(object v)
        {
            return GetDescription(typeof(BOOL), v);
        }
        #endregion

        #region 一级地区类型
        public enum DistrictType   //District.usetype
        {
            [Description("国内")]
            domestic = 1,
            [Description("国外")]
            abroad = 2,
        }
        public static SortedList GetDistrictType()
        {
            return GetStatus(typeof(DistrictType));
        }
        public static string GetDistrictType(object v)
        {
            return GetDescription(typeof(DistrictType), v);
        }
        #endregion

        #region 时间精确性
        public enum TimeUnknown
        {
            [Description("时间未知")]
            False = 0,
            [Description("时间精确")]
            True = 1,
            [Description("精确到时辰")]
            All = 2
        }
        public static SortedList GetTimeUnknown()
        {
            return GetStatus(typeof(TimeUnknown));
        }
        public static string GetTimeUnknown(object v)
        {
            return GetDescription(typeof(TimeUnknown), v);
        }
        #endregion

        #region 用户默认排盘类型
        public enum FateType
        {
            [Description("西洋占星术")]
            astro = 1,
            [Description("紫微斗数")]
            ziwei = 2,
            [Description("四柱八字")]
            bazi = 3,
            //[Description("塔罗牌")]
            //tarot = 4
        }
        public static SortedList GetFateType()
        {
            return GetStatus(typeof(FateType));
        }
        public static string GetFateType(object v)
        {
            return GetDescription(typeof(FateType), v);
        }
        #endregion

        #region FateChart表中的盘类型
        public enum ChartType
        {
            [Description("个人运势")]
            personal = 1,
            [Description("两人关系")]
            relation = 2,
            //[Description("推运")]
            //transit = 3,
            //[Description("塔罗牌")]
            //tarot = 4
            [Description("不排盘")]
            nochart = 0,
        }
        public static SortedList GetChartType()
        {
            return GetStatus(typeof(ChartType));
        }
        public static string GetChartType(object v)
        {
            return GetDescription(typeof(ChartType), v);
        }
        #endregion

        #region FateChart表中的盘默认理论类型
        public enum TheoryChart
        {
            [Description("占星术")]
            astro = 1,
            [Description("八字")]
            bazi = 2,
            [Description("紫薇")]
            ziwei = 3,
            [Description("六爻")]
            liuyao = 4
        }
        public static SortedList GetTheoryChart()
        {
            return GetStatus(typeof(TheoryChart));
        }
        public static string GetTheoryChart(object v)
        {
            return GetDescription(typeof(TheoryChart), v);
        }
        #endregion

        #region 用户行为类型 Action表与Record表共用
        public enum ActionType
        {
            [Description("发布文章")]
            AddBlog = 11,
            [Description("删除文章")]
            DelBlog = 12,
            [Description("修改文章")]
            EditBlog = 12,
            [Description("评论文章")]
            ReplyBlog = 14,
            [Description("发布图片")]
            AddPic = 21,
            [Description("修改图片")]
            EditPic = 22,
            [Description("删除图片")]
            DelPic = 23,
            [Description("评论图片")]
            ReplyPic = 24,
            [Description("发布共享文件")]
            AddFile = 31,
            [Description("修改共享文件")]
            EditFile = 32,
            [Description("删除共享文件")]
            DelFile = 33,
            [Description("评论共享文件")]
            ReplyFile = 34,
            [Description("发布链接")]
            AddLink = 41,
            [Description("修改链接")]
            EditLink = 42,
            [Description("删除链接")]
            DelLink = 43,
            [Description("评论链接")]
            ReplyLink = 44,
            [Description("发布命盘")]
            AddChart = 51,
            [Description("修改命盘")]
            EditChart = 52,
            [Description("删除命盘")]
            DelChart = 53,
            [Description("评论命盘")]
            ReplyChart = 54,

            [Description("发布问题")]
            AddQuest = 61,
            [Description("回答问题")]
            ReplyQuest = 62,
            [Description("评论回答")]
            ReplyAnswer = 63,
            [Description("关闭问题")]
            EndQuest = 64,

            [Description("评论文章")]
            ReplyArticle = 71,

            [Description("收藏命盘")]
            CollectChart = 111,
            [Description("删除收藏命盘")]
            DelCollectChart = 112,
            [Description("收藏问答")]
            CollectQuest = 121,
            [Description("删除收藏问答")]
            DelCollectQuest = 122,
            [Description("收藏文章")]
            CollectArticle = 131,
            [Description("删除收藏文章")]
            DelCollectArticle = 132,
            [Description("收藏名人")]
            CollectFamous = 141,
            [Description("删除收藏名人")]
            DelCollectFamous = 142,
            [Description("收藏页面")]
            CollectUrl = 151,
            [Description("删除收藏页面")]
            DelCollectUrl = 152,
        }
        public static SortedList GetActionType()
        {
            return GetStatus(typeof(ActionType));
        }
        public static string GetActionType(object v)
        {
            return GetDescription(typeof(ActionType), v);
        }
        #endregion

        #region 轻博客文章类型
        public enum BlogArticleType
        {
            [Description("文章")]
            Article = 1,
            [Description("图片")]
            Picture = 2,
            [Description("共享文件")]
            File = 3,
            [Description("链接")]
            Link = 4,
            [Description("命盘")]
            Chart = 5,
        }
        public static SortedList GetBlogArticleType()
        {
            return GetStatus(typeof(BlogArticleType));
        }
        public static string GetBlogArticleType(object v)
        {
            return GetDescription(typeof(BlogArticleType), v);
        }
        #endregion

        #region 文章阅读权限类型
        public enum ArticleLimit
        {
            [Description("所有人可见")]
            everyone = 0,
            [Description("仅会员可见")]
            customeronly = 2,
        }
        public static SortedList GetArticleLimit()
        {
            return GetStatus(typeof(ArticleLimit));
        }
        public static string GetArticleLimit(object v)
        {
            return GetDescription(typeof(ArticleLimit), v);
        }
        #endregion

        #region 轻博客收藏类型
        public enum CollectionType
        {
            [Description("命盘")]
            chart = 1,
            [Description("问答")]
            quest = 2,
            [Description("文章")]
            article = 3,
            [Description("名人")]
            famous = 4,
            [Description("页面")]
            url = 5,
        }
        public static SortedList GetCollectionType()
        {
            return GetStatus(typeof(CollectionType));
        }
        public static string GetCollectionType(object v)
        {
            return GetDescription(typeof(CollectionType), v);
        }
        #endregion

        #region App调用来源记录类型
        public enum AppsSourceType
        {
            [Description("本站")]
            self = 1,
            [Description("腾讯")]
            qq = 2,
        }
        public static SortedList GetAppsSourceType()
        {
            return GetStatus(typeof(AppsSourceType));
        }
        public static string GetAppsSourceType(object v)
        {
            return GetDescription(typeof(AppsSourceType), v);
        }
        #endregion

        #region 页面错误类型
        public enum ErrorType
        {
            [Description("错误的账号类型")]
            wrongAccountType = 1,
            [Description("账号或密码错误")]
            WrongAccount = 2,
            [Description("您没有查看该页面的权限")]
            NoPermission = 3,
            [Description("账号不存在")]
            NoSuchAccount = 4,
            [Description("验证码错误")]
            WrongValidateCode = 5,
        }
        public static SortedList GetErrorType()
        {
            return GetStatus(typeof(ErrorType));
        }
        public static string GetErrorType(object v)
        {
            return GetDescription(typeof(ErrorType), v);
        }
        #endregion

        #region 上传文件类型
        public enum FileType
        {
            [Description("RAR")]
            rar = 1,
            [Description("MP3")]
            mp3 = 2,
            [Description("您没有查看该页面的权限")]
            NoPermission = 3,
        }
        public static SortedList GetFileType()
        {
            return GetStatus(typeof(FileType));
        }
        public static string GetFileType(object v)
        {
            return GetDescription(typeof(FileType), v);
        }
        #endregion

        #region 推广主题类型
        public enum AdvTopicType
        {
            [Description("RAR")]
            rar = 1,
            [Description("MP3")]
            mp3 = 2,
            [Description("您没有查看该页面的权限")]
            NoPermission = 3,
        }
        public static SortedList GetAdvTopicType()
        {
            return GetStatus(typeof(AdvTopicType));
        }
        public static string GetAdvTopicType(object v)
        {
            return GetDescription(typeof(AdvTopicType), v);
        }
        #endregion

        #region 应用调用来源
        public enum AppSource
        {
            [Description("QQWeiBo")]
            qqwb = 1,

        }
        public static SortedList GetAppSource()
        {
            return GetStatus(typeof(AppSource));
        }
        public static string GetAppSource(object v)
        {
            return GetDescription(typeof(AppSource), v);
        }
        #endregion

        #region 站内信类型
        public enum MessageType
        {
            [Description("站内信")]
            nomal = 3,
            [Description("站内公告")]
            notice = 1,
            [Description("系统通知")]
            system = 2,
        }
        public static SortedList GetMessageType()
        {
            return GetStatus(typeof(MessageType));
        }
        public static string GetMessageType(object v)
        {
            return GetDescription(typeof(MessageType), v);
        }
        #endregion

        #region APP应用集合
        public enum Apps
        {
            [Description("金星星座爱情分析器")]
            venus = 0,
            [Description("占星骰子")]
            astrodice = 1,
        }
        public static SortedList GetApps()
        {
            return GetStatus(typeof(Apps));
        }
        public static string GetApps(object v)
        {
            return GetDescription(typeof(Apps), v);
        }
        #endregion

        #region 问答等级
        public enum QuestLevel
        {
            [Description("新手上路")]
            one = 0,
            [Description("占星骰子")]
            two = 1,
        }
        public static SortedList GetQuestLevel()
        {
            return GetStatus(typeof(QuestLevel));
        }
        public static string GetQuestLevel(object v)
        {
            return GetDescription(typeof(QuestLevel), v);
        }
        #endregion

        #region 第三方登录类型
        public enum ThirdLoginType
        {
            [Description("微博")]
            weibo = 1,
            [Description("QQ")]
            qq = 2,
        }
        public static SortedList GetThirdLoginType()
        {
            return GetStatus(typeof(ThirdLoginType));
        }
        public static string GetThirdLoginType(object v)
        {
            return GetDescription(typeof(ThirdLoginType), v);
        }
        #endregion

        #region 用户勋章类型
        public enum UserMedalType
        {
            [Description("问答")]
            QA = 1,
        }
        public static SortedList GetUserMedalType()
        {
            return GetStatus(typeof(UserMedalType));
        }
        public static string GetUserMedalType(object v)
        {
            return GetDescription(typeof(UserMedalType), v);
        }
        #endregion

        #region 目录类型（用户数据库中关联目录的关联表中的类型区分）
        public enum CategoryType
        {
            [Description("问答")]
            QA = 1,
        }
        public static SortedList GetCategoryType()
        {
            return GetStatus(typeof(CategoryType));
        }
        public static string GetCategoryType(object v)
        {
            return GetDescription(typeof(CategoryType), v);
        }
        #endregion

    }
}
