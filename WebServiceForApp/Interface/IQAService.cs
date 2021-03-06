﻿using System;
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
using PPLive.Astro;
using PPLive.BaZi;
using PPLive.ZiWei;

namespace WebServiceForApp
{
     [ServiceContract(Namespace = "http://api.ssqian.com/QA")]
    public interface IQAService
    {
        [OperationContract, WebGet(UriTemplate = "/GetCates?parent={parent}")]
        [Description("获取分类列表,/GetCates?parent={parent}")]
        ReturnValue<List<QA_CategoryShow>> GetCates(int parent);

        [OperationContract, WebGet(UriTemplate = "/GetStarsList?catesysno={catesysno}")]
        [Description("获取明星列表,/GetStarsList?catesysno={catesysno}")]
        ReturnValue<List<USR_CustomerShow>> GetStarsList(int catesysno);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionListForAstro?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        [Description("获取问题列表(占星),/GetQuestionListForAstro?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>> GetQuestionListForAstro(int pagesize, int pageindex, string key, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionListForBaZi?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        [Description("获取问题列表（八字）,/GetQuestionListForBaZi?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        ReturnValue<PageInfo<QA_QuestionShowMini<BaZiMod>>> GetQuestionListForBaZi(int pagesize, int pageindex, string key, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionListForZiWei?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        [Description("获取问题列表（紫薇）,/GetQuestionListForZiWei?pagesize={pagesize}&pageindex={pageindex}&key={key}&cate={cate}&orderby={orderby}")]
        ReturnValue<PageInfo<QA_QuestionShowMini<ZiWeiMod>>> GetQuestionListForZiWei(int pagesize, int pageindex, string key, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionListByUserAnswer?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}&cate={cate}&orderby={orderby}")]
        [Description("获取用户所回复的问题列表,/GetQuestionListByUserAnswer?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}&cate={cate}&orderby={orderby}")]
        ReturnValue<PageInfo<QA_AnswerShow>> GetQuestionListByUserAnswer(int pagesize, int pageindex, int customersysno, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionListByUserAsk?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}&cate={cate}&orderby={orderby}")]
        [Description("获取用户所发布的问题列表,/GetQuestionListByUserAsk?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}&cate={cate}&orderby={orderby}")]
        ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>> GetQuestionListByUserAsk(int pagesize, int pageindex, int customersysno, int cate, string orderby);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionForAstro?sysno={sysno}")]
        [Description("获取问题详情(占星),/GetQuestionForAstro?sysno={sysno}")]
        ReturnValue<QA_QuestionShow<AstroMod>> GetQuestionForAstro(int sysno);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionForBaZi?sysno={sysno}")]
        [Description("获取问题详情（八字）,/GetQuestionForBaZi?sysno={sysno}")]
        ReturnValue<QA_QuestionShow<BaZiMod>> GetQuestionForBaZi(int sysno);

        [OperationContract, WebGet(UriTemplate = "/GetQuestionForZiWei?sysno={sysno}")]
        [Description("获取问题详情（紫薇）,/GetQuestionForZiWei?sysno={sysno}")]
        ReturnValue<QA_QuestionShow<ZiWeiMod>> GetQuestionForZiWei(int sysno);

        [OperationContract, WebGet(UriTemplate = "/GetAnswerByQuest?sysno={sysno}&pagesize={pagesize}&pageindex={pageindex}")]
        [Description("获取问题的回复列表,/GetAnswerByQuest?sysno={sysno}&pagesize={pagesize}&pageindex={pageindex}")]
        ReturnValue<PageInfo<QA_AnswerShow>> GetAnswerByQuest(int pagesize, int pageindex, int sysno);

        [OperationContract, WebGet(UriTemplate = "/AddAnswer?CustomerSysNo={CustomerSysNo}&QuestionSysNo={QuestionSysNo}&Title={Title}&Context={Context}")]
        [Description("发布回复,/AddAnswer?CustomerSysNo={CustomerSysNo}&QuestionSysNo={QuestionSysNo}&Title={Title}&Context={Context}")]
        ReturnValue<USR_CustomerShow> AddAnswer(int CustomerSysNo, int QuestionSysNo, string Title, string Context);

        [OperationContract, WebGet(UriTemplate = "/RemoveAnswer?AnswerSysNo={AnswerSysNo}")]
        [Description("删除回复,/RemoveAnswer?AnswerSysNo={AnswerSysNo}")]
        ReturnValue<bool> RemoveAnswer(int AnswerSysNo);

        [OperationContract, WebGet(UriTemplate = "/SetAward?answersysno={answersysno}&score={score}&msg={msg}")]
        [Description("设置悬赏,/SetAward?answersysno={answersysno}&score={score}&msg={msg}")]
        ReturnValue<QA_QuestionShow<AstroMod>> SetAward(int answersysno, int score, string msg);

        [OperationContract, WebGet(UriTemplate = "/AddComment?CustomerSysNo={CustomerSysNo}&AnswerSysNo={AnswerSysNo}&QuestionSysNo={QuestionSysNo}&Context={Context}")]
        [Description("发布评论,/AddComment?CustomerSysNo={CustomerSysNo}&AnswerSysNo={AnswerSysNo}&QuestionSysNo={QuestionSysNo}&Context={Context}")]
        ReturnValue<USR_CustomerShow> AddComment(int AnswerSysNo, int CustomerSysNo, int QuestionSysNo, string Context);

        [OperationContract, WebGet(UriTemplate = "/RemoveComment?CommentSysNo={CommentSysNo}")]
        [Description("删除评论,/RemoveComment?CommentSysNo={CommentSysNo}")]
        ReturnValue<bool> RemoveComment(int CommentSysNo);

        [OperationContract, WebGet(UriTemplate = "/GetCommentByAnswer?sysno={sysno}")]
        [Description("获取某回复的评论列表,/GetCommentByAnswer?sysno={sysno}")]
        ReturnValue<List<QA_CommentShow>> GetCommentByAnswer(int sysno);

    }

}
