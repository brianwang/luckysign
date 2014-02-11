using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

using XMS.Core;

using AppMod.QA;
using AppMod.User;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/QA")]
    public interface IQAService
    {
        [OperationContract, WebGet(UriTemplate = "/GetCates?parent={parent}")]
        [Description("获取分类列表,/GetCates?parent={parent}")]
        ReturnValue<List<QA_CategoryMod>> GetCates(int parent);

        [OperationContract, WebGet(UriTemplate = "/GetStarsList?catesysno={catesysno}")]
        [Description("获取明星列表,/GetStarsList?catesysno={catesysno}")]
        ReturnValue<List<QA_StarShow>> GetStarsList(int count,int fatetype);

        [OperationContract, WebGet(UriTemplate = "/GetQuestList?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        [Description("获取问题列表,/GetQuestionList?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        ReturnValue<List<QA_QuestShowMini>> GetQuestionList(int pagesize, int pageindex, string key, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestion?sysno={sysno}")]
        [Description("获取问题详情,/GetQuestion?sysno={sysno}")]
        ReturnValue<QA_QuestionShow> GetQuestion(int sysno);

        [OperationContract, WebGet(UriTemplate = "/AddQuestion?sysno={sysno}")]
        [Description("发布问题,/AddQuestion?sysno={sysno}")]
        ReturnValue<USR_CustomerMaintain> AddQuestion(int sysno);

        [OperationContract, WebGet(UriTemplate = "/GetAnswerByQuest?sysno={sysno}&pagesize={pagesize}&pageindex={pageindex}")]
        [Description("获取问题的回复列表,/AddQuestion?sysno={sysno}&pagesize={pagesize}&pageindex={pageindex}")]
        ReturnValue<List<QA_AnswerShow>> AddQuestion(int pagesize, int pageindex,int sysno);

        [OperationContract, WebGet(UriTemplate = "/AddAnswer?sysno={sysno}")]
        [Description("发布回复,/AddAnswer?sysno={sysno}")]
        ReturnValue<USR_CustomerMaintain> AddAnswer(int sysno);

        [OperationContract, WebGet(UriTemplate = "/SetAward?questsysno={sysno}&answersysno={answersysno}&score={score}&msg={msg}")]
        [Description("设置悬赏,/SetAward?questsysno={sysno}&answersysno={answersysno}&score={score}&msg={msg}")]
        ReturnValue<QA_QuestionShow> AddAnswer(int questsysno, int questsysno, int score, string msg);

        [OperationContract, WebGet(UriTemplate = "/AddComment?sysno={sysno}")]
        [Description("发布回复,/AddComment?sysno={sysno}")]
        ReturnValue<USR_CustomerMaintain> AddComment(int sysno);

        [OperationContract, WebGet(UriTemplate = "/GetCommentByAnswer?sysno={sysno}")]
        [Description("获取问题的回复列表,/GetCommentByAnswer?sysno={sysno}")]
        ReturnValue<List<QA_CommentShow>> GetCommentByAnswer(int sysno);

    }

}
