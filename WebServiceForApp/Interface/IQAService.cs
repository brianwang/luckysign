using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.IO;
using XMS.Core;
using AppMod.User;
using AppMod.QA;
using AppMod.WebSys;
using AppDal.QA;

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
        ReturnValue<List<USR_CustomerMaintain>> GetStarsList(int catesysno);

        [OperationContract, WebGet(UriTemplate = "/GetQuestList?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        [Description("获取问题列表,/GetQuestionList?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        ReturnValue<PageInfo<QA_QuestionShowMini>> GetQuestionList(int pagesize, int pageindex, string key, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestion?sysno={sysno}")]
        [Description("获取问题详情,/GetQuestion?sysno={sysno}")]
        ReturnValue<QA_QuestionShow> GetQuestion(int sysno);

        [OperationContract, WebGet(UriTemplate = "/AddQuestion")]
        [Description("发布问题,/AddQuestion")]
        ReturnValue<USR_CustomerMaintain> AddQuestion(Stream openPageData);

        [OperationContract, WebGet(UriTemplate = "/GetAnswerByQuest?sysno={sysno}&pagesize={pagesize}&pageindex={pageindex}")]
        [Description("获取问题的回复列表,/GetAnswerByQuest?sysno={sysno}&pagesize={pagesize}&pageindex={pageindex}")]
        ReturnValue<PageInfo<QA_AnswerShow>> GetAnswerByQuest(int pagesize, int pageindex, int sysno);

        [OperationContract, WebGet(UriTemplate = "/AddAnswer?CustomerSysNo={CustomerSysNo}&QuestionSysNo={QuestionSysNo}&Title={Title}&Context={Context}")]
        [Description("发布回复,/AddAnswer?CustomerSysNo={CustomerSysNo}&QuestionSysNo={QuestionSysNo}&Title={Title}&Context={Context}")]
        ReturnValue<USR_CustomerMaintain> AddAnswer(int CustomerSysNo, int QuestionSysNo, string Title, string Context);

        [OperationContract, WebGet(UriTemplate = "/SetAward?answersysno={answersysno}&score={score}&msg={msg}")]
        [Description("设置悬赏,/SetAward?answersysno={answersysno}&score={score}&msg={msg}")]
        ReturnValue<QA_QuestionShow> SetAward(int answersysno, int score, string msg);

        [OperationContract, WebGet(UriTemplate = "/AddComment?CustomerSysNo={CustomerSysNo}&AnswerSysNo={AnswerSysNo}&QuestionSysNo={QuestionSysNo}&Context={Context}")]
        [Description("发布评论,/AddComment?sysno={sysno}")]
        ReturnValue<USR_CustomerMaintain> AddComment(int AnswerSysNo, int CustomerSysNo, int QuestionSysNo, string Context);

        [OperationContract, WebGet(UriTemplate = "/GetCommentByAnswer?sysno={sysno}")]
        [Description("获取某回复的评论列表,/GetCommentByAnswer?sysno={sysno}")]
        ReturnValue<List<QA_CommentShow>> GetCommentByAnswer(int sysno);

    }

}
