using AstroCSharpLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 CALCTest 的测试类，旨在
    ///包含所有 CALCTest 单元测试
    ///</summary>
    [TestClass()]
    public class CALCTest
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
        ///CastChart 的测试
        ///</summary>
        [TestMethod()]
        public void CastChartTest()
        {
            CALC target = new CALC(); // TODO: 初始化为适当的值
            DateTime dt = DateTime.Now;
            target.ciCore = new AstroCSharpLib.Model.ChartInfo
            {
                mon = dt.Month,
                day = dt.Day,
                yea = dt.Year,
                tim = Math.Round((dt.Hour + dt.Minute / 60.0), 2),
                dst = 0.0,
                zon = -8.0,
                lon = 116.42,
                lat = 39.93,
                nam = "",
                loc = ""
            };
            bool fDate = true; // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            actual = target.CastChart(fDate);

            StringBuilder sb = new StringBuilder();
            //fprintf(file, "@0203  ; %s chart positions.\n", szAppName);
            //fprintf(file, "%czi \"%s\" \"%s\"\n", chSwitch, ciMain.nam, ciMain.loc);
            //for (i = 1; i <= 32; i++)
            //{
            //    if (i <= oNorm)
            //        fprintf(file, "%c%c%c", chObj3(i));
            //    rT = FBetween(i, cuspLo - 1 + 4, cuspLo - 1 + 9) ?
            //      chouse[i - (cuspLo - 1)] : planet[i];
            //    j = (int)rT;
            //    fprintf(file, ":%3d %c%c%c%13.9f,%4d%13.9f,",
            //      j % 30, chSig3(j / 30 + 1), RFract(rT) * 60.0,
            //      (int)planetalt[i], RFract(RAbs(planetalt[i])) * 60.0);
            //    rT = i > oNorm ? 999.0 : (i == oMoo && !us.fPlacalc ? 0.0026 :
            //      RSqr(spacex[i] * spacex[i] + spacey[i] * spacey[i] + spacez[i] * spacez[i]));
            //    fprintf(file, "%14.9f%14.9f\n", DFromR(ret[i]), rT);
            //}

            XMS.Core.Container.LogService.Info(XMS.Core.Json.JsonSerializer.Serialize(target.cp));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
