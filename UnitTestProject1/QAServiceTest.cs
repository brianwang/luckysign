﻿using WebServiceForApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PPLive.BaZi;
using AppMod.QA;
using AppMod.WebSys;
using XMS.Core;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 QAServiceTest 的测试类，旨在
    ///包含所有 QAServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class QAServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GetQuestionListForBaZi 的测试
        ///</summary>
        [TestMethod()]
        public void GetQuestionListForBaZiTest()
        {
            QAService target = new QAService(); // TODO: 初始化为适当的值
            int pagesize = 1; // TODO: 初始化为适当的值
            int pageindex = 15; // TODO: 初始化为适当的值
            string key = string.Empty; // TODO: 初始化为适当的值
            int cate = 0; // TODO: 初始化为适当的值
            string orderby = string.Empty; // TODO: 初始化为适当的值
            ReturnValue<PageInfo<QA_QuestionShowMini<BaZiMod>>> expected = null; // TODO: 初始化为适当的值
            ReturnValue<PageInfo<QA_QuestionShowMini<BaZiMod>>> actual;
            actual = target.GetQuestionListForBaZi(pagesize, pageindex, key, cate, orderby);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
