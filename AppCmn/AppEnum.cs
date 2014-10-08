using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Runtime.Serialization;

namespace AppCmn
{
    [DataContract]
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
        [DataContract]public enum Gender
        {
            [EnumMember][Description("女")]
            female = 0,
            [EnumMember][Description("男")]
            male = 1,
            [EnumMember][Description("保密")]
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
        [DataContract]public enum ReadType
        {
            [EnumMember][Description("所有人可见")]
            Public = 1,
            [EnumMember][Description("仅好友可见")]
            Friend = 2,
            [EnumMember][Description("凭密码访问")]
            Protect = 3,
            [EnumMember][Description("私密内容")]
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
        [DataContract]public enum State
        {
            [EnumMember][Description("全部")]
            all = 100,
            [EnumMember][Description("正常")]
            normal = 0,
            [EnumMember][Description("已删除")]
            deleted = 1,
            [EnumMember][Description("审核中")]
            prepare = 2,
            [EnumMember][Description("已冻结")]
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
        [DataContract]public enum BOOL
        {
            [EnumMember][Description("否")]
            False = 0,
            [EnumMember][Description("是")]
            True = 1,
            [EnumMember][Description("全部")]
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
        [DataContract]public enum DistrictType   //District.usetype
        {
            [EnumMember][Description("国内")]
            domestic = 1,
            [EnumMember][Description("国外")]
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
        [DataContract]public enum TimeUnknown
        {
            [EnumMember][Description("时间未知")]
            False = 0,
            [EnumMember][Description("时间精确")]
            True = 1,
            [EnumMember][Description("精确到时辰")]
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
        [DataContract]
        public enum FateType
        {
            [EnumMember][Description("西洋占星术")]
            astro = 1,
            [EnumMember][Description("紫微斗数")]
            ziwei = 2,
            [EnumMember][Description("四柱八字")]
            bazi = 3,
            //[EnumMember][Description("塔罗牌")]
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
        [DataContract]public enum ChartType
        {
            [EnumMember][Description("个人运势")]
            personal = 1,
            [EnumMember][Description("两人关系")]
            relation = 2,
            //[EnumMember][Description("占星骰子")]
            //astrodice = 3,
            //[EnumMember][Description("塔罗牌阵")]
            //tarot = 4
            [EnumMember][Description("不排盘")]
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
        [DataContract]
        public enum TheoryChart
        {
            [EnumMember][Description("占星术")]
            astro = 1,
            [EnumMember][Description("八字")]
            bazi = 2,
            [EnumMember][Description("紫薇")]
            ziwei = 3,
            [EnumMember][Description("六爻")]
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
        [DataContract]public enum ActionType
        {
            [EnumMember][Description("发布文章")]
            AddBlog = 11,
            [EnumMember][Description("删除文章")]
            DelBlog = 12,
            [EnumMember][Description("修改文章")]
            EditBlog = 12,
            [EnumMember][Description("评论文章")]
            ReplyBlog = 14,
            [EnumMember][Description("发布图片")]
            AddPic = 21,
            [EnumMember][Description("修改图片")]
            EditPic = 22,
            [EnumMember][Description("删除图片")]
            DelPic = 23,
            [EnumMember][Description("评论图片")]
            ReplyPic = 24,
            [EnumMember][Description("发布共享文件")]
            AddFile = 31,
            [EnumMember][Description("修改共享文件")]
            EditFile = 32,
            [EnumMember][Description("删除共享文件")]
            DelFile = 33,
            [EnumMember][Description("评论共享文件")]
            ReplyFile = 34,
            [EnumMember][Description("发布链接")]
            AddLink = 41,
            [EnumMember][Description("修改链接")]
            EditLink = 42,
            [EnumMember][Description("删除链接")]
            DelLink = 43,
            [EnumMember][Description("评论链接")]
            ReplyLink = 44,
            [EnumMember][Description("发布命盘")]
            AddChart = 51,
            [EnumMember][Description("修改命盘")]
            EditChart = 52,
            [EnumMember][Description("删除命盘")]
            DelChart = 53,
            [EnumMember][Description("评论命盘")]
            ReplyChart = 54,

            [EnumMember][Description("发布问题")]
            AddQuest = 61,
            [EnumMember][Description("回答问题")]
            ReplyQuest = 62,
            [EnumMember][Description("评论回答")]
            ReplyAnswer = 63,
            [EnumMember][Description("关闭问题")]
            EndQuest = 64,


            [EnumMember]
            [Description("发布报价")]
            SetOrder = 71,
            [EnumMember]
            [Description("购买报价")]
            BuyOrder = 72,
            [EnumMember]
            [Description("兑现咨询结果")]
            SendResult = 73,
            [EnumMember]
            [Description("评价咨询结果")]
            PriceOrder = 74,
            [EnumMember]
            [Description("取消报价")]
            CancelOrder = 75,
            [EnumMember]
            [Description("修改报价")]
            UpdateOrder = 76,
            [EnumMember]
            [Description("发起投诉退款")]
            ComplainOrder = 77,

            [EnumMember][Description("评论文章")]
            ReplyArticle = 81,

            [EnumMember][Description("收藏命盘")]
            CollectChart = 111,
            [EnumMember][Description("删除收藏命盘")]
            DelCollectChart = 112,
            [EnumMember][Description("收藏问答")]
            CollectQuest = 121,
            [EnumMember][Description("删除收藏问答")]
            DelCollectQuest = 122,
            [EnumMember][Description("收藏文章")]
            CollectArticle = 131,
            [EnumMember][Description("删除收藏文章")]
            DelCollectArticle = 132,
            [EnumMember][Description("收藏名人")]
            CollectFamous = 141,
            [EnumMember][Description("删除收藏名人")]
            DelCollectFamous = 142,
            [EnumMember][Description("收藏页面")]
            CollectUrl = 151,
            [EnumMember][Description("删除收藏页面")]
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
        [DataContract]public enum BlogArticleType
        {
            [EnumMember][Description("文章")]
            Article = 1,
            [EnumMember][Description("图片")]
            Picture = 2,
            [EnumMember][Description("共享文件")]
            File = 3,
            [EnumMember][Description("链接")]
            Link = 4,
            [EnumMember][Description("命盘")]
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
        [DataContract]public enum ArticleLimit
        {
            [EnumMember][Description("所有人可见")]
            everyone = 0,
            [EnumMember][Description("仅会员可见")]
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
        [DataContract]public enum CollectionType
        {
            [EnumMember][Description("命盘")]
            chart = 1,
            [EnumMember][Description("问答")]
            quest = 2,
            [EnumMember][Description("文章")]
            article = 3,
            [EnumMember][Description("名人")]
            famous = 4,
            [EnumMember][Description("页面")]
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
        [DataContract]public enum AppsSourceType
        {
            [EnumMember][Description("本站")]
            self = 1,
            [EnumMember][Description("腾讯")]
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
        [DataContract]public enum ErrorType
        {
            [EnumMember][Description("错误的账号类型")]
            wrongAccountType = 1,
            [EnumMember][Description("账号或密码错误")]
            WrongAccount = 2,
            [EnumMember][Description("您没有查看该页面的权限")]
            NoPermission = 3,
            [EnumMember][Description("账号不存在")]
            NoSuchAccount = 4,
            [EnumMember][Description("验证码错误")]
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
        [DataContract]public enum FileType
        {
            [EnumMember][Description("RAR")]
            rar = 1,
            [EnumMember][Description("MP3")]
            mp3 = 2,
            [EnumMember][Description("您没有查看该页面的权限")]
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
        [DataContract]public enum AdvTopicType
        {
            [EnumMember][Description("RAR")]
            rar = 1,
            [EnumMember][Description("MP3")]
            mp3 = 2,
            [EnumMember][Description("您没有查看该页面的权限")]
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
        [DataContract]public enum AppSource
        {
            [EnumMember][Description("QQWeiBo")]
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
        [DataContract]public enum MessageType
        {
            [EnumMember][Description("站内信")]
            nomal = 3,
            [EnumMember][Description("站内公告")]
            notice = 1,
            [EnumMember][Description("系统通知")]
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
        [DataContract]public enum Apps
        {
            [EnumMember][Description("金星星座爱情分析器")]
            venus = 0,
            [EnumMember][Description("占星骰子")]
            astrodice = 1,
            [EnumMember]
            [Description("爱情花")]
            loverose = 2,
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
        [DataContract]public enum QuestLevel
        {
            [EnumMember][Description("新手上路")]
            one = 0,
            [EnumMember][Description("占星骰子")]
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
        [DataContract]public enum ThirdLoginType
        {
            [EnumMember][Description("微博")]
            weibo = 1,
            [EnumMember][Description("QQ")]
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
        [DataContract]public enum UserMedalType
        {
            [EnumMember][Description("问答")]
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

        #region 目录类型（数据库中用户关联目录的关联表中的类型区分）
        [DataContract]public enum CategoryType
        {
            [EnumMember][Description("问答")]
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

        #region 咨询报价单状态
        [DataContract]
        public enum ConsultOrderStatus
        {
            [EnumMember]
            [Description("等待购买")]
            beforepay = 1,
            [EnumMember]
            [Description("已购买")]
            payed = 2,
            [EnumMember]
            [Description("等待评价")]
            beforeconfirm = 3,
            [EnumMember]
            [Description("交易成功")]
            confirmed = 4,
            [EnumMember]
            [Description("交易关闭")]
            canceled = 0,
            [EnumMember]
            [Description("已退款")]
            returned = 5,
        }
        public static SortedList GetConsultOrderStatus()
        {
            return GetStatus(typeof(ConsultOrderStatus));
        }
        public static string GetConsultOrderStatus(object v)
        {
            return GetDescription(typeof(ConsultOrderStatus), v);
        }
        #endregion

        #region 灵签交易订单状态
        [DataContract]
        public enum PointOrderStatus
        {
            [EnumMember]
            [Description("待支付")]
            beforepay = 1,
            [EnumMember]
            [Description("交易成功")]
            succed = 2,
            [EnumMember]
            [Description("交易失败")]
            failed = 3,
            [EnumMember]
            [Description("退款中")]
            returing = 4,
            [EnumMember]
            [Description("已退款")]
            returned = 5,
        }
        public static SortedList GetPointOrderStatus()
        {
            return GetStatus(typeof(PointOrderStatus));
        }
        public static string GetPointOrderStatus(object v)
        {
            return GetDescription(typeof(PointOrderStatus), v);
        }
        #endregion

        #region 现金交易订单状态
        [DataContract]
        public enum CashOrderStatus
        {
            [EnumMember]
            [Description("待支付")]
            beforepay = 1,
            [EnumMember]
            [Description("交易成功")]
            succed = 2,
            [EnumMember]
            [Description("交易失败")]
            failed = 3,
            [EnumMember]
            [Description("退款中")]
            returing = 4,
            [EnumMember]
            [Description("已退款")]
            returned = 5,
            [EnumMember]
            [Description("待确认")]
            confirming = 6,
        }
        public static SortedList GetCashOrderStatus()
        {
            return GetStatus(typeof(CashOrderStatus));
        }
        public static string GetCashOrderStatus(object v)
        {
            return GetDescription(typeof(CashOrderStatus), v);
        }
        #endregion
        
        #region 灵签收支记录类型
        [DataContract]
        public enum PointOrderType
        {
            [EnumMember]
            [Description("网银充值")]
            buy = 1,
            [EnumMember]
            [Description("系统奖励")]
            systemadd = 2,
            [EnumMember]
            [Description("应用消费")]
            appconsume = 3,
            [EnumMember]
            [Description("问答悬赏")]
            questaward = 4,
            [EnumMember]
            [Description("系统退还")]
            systemreturn = 5,
        }
        public static SortedList GetPointOrderType()
        {
            return GetStatus(typeof(PointOrderType));
        }
        public static string GetPointOrderType(object v)
        {
            return GetDescription(typeof(PointOrderType), v);
        }
        #endregion

        #region 现金收支记录类型
        [DataContract]
        public enum CashOrderType
        {
            [EnumMember]
            [Description("充值")]
            recharge = 1,
            [EnumMember]
            [Description("付费咨询获取")]
            consultget = 2,
            [EnumMember]
            [Description("付费咨询支付")]
            consultpay = 3,
            [EnumMember]
            [Description("系统奖励")]
            systemadd = 4,
            [EnumMember]
            [Description("系统退还")]
            systemreturn = 5,
        }
        public static SortedList GetCashOrderType()
        {
            return GetStatus(typeof(CashOrderType));
        }
        public static string GetCashOrderType(object v)
        {
            return GetDescription(typeof(CashOrderType), v);
        }
        #endregion

        #region 现金退款单状态
        [DataContract]
        public enum CashReturnStatus
        {
            [EnumMember]
            [Description("待确认")]
            confirming = 1,
            [EnumMember]
            [Description("被拒绝")]
            refused = 2,
            [EnumMember]
            [Description("待评估")]
            judging = 3,
            [EnumMember]
            [Description("已取消")]
            canceled = 4,
            [EnumMember]
            [Description("已退款")]
            returned = 5,
            [EnumMember]
            [Description("被驳回")]
            rejected = 6,
        }
        public static SortedList GetCashReturnStatus()
        {
            return GetStatus(typeof(CashReturnStatus));
        }
        public static string GetCashReturnStatus(object v)
        {
            return GetDescription(typeof(CashReturnStatus), v);
        }
        #endregion

        #region 现金退款原因
        [DataContract]
        public enum CashReturnReason
        {
            [EnumMember]
            [Description("充值")]
            recharge = 1,
            [EnumMember]
            [Description("付费咨询获取")]
            consultget = 2,
            [EnumMember]
            [Description("付费咨询支付")]
            consultpay = 3,
            [EnumMember]
            [Description("系统奖励")]
            systemadd = 4,
            [EnumMember]
            [Description("其他")]
            other = 99,
        }
        public static SortedList GetCashReturnReason()
        {
            return GetStatus(typeof(CashReturnReason));
        }
        public static string GetCashReturnReason(object v)
        {
            return GetDescription(typeof(CashReturnReason), v);
        }
        #endregion
    }
}
