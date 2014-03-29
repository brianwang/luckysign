using AstroCSharpLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using PPLive.Astro;

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
            DateTime dt = new System.DateTime(2014, 3, 25, 14, 12, 13);
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

            using (StreamWriter sw = new StreamWriter("D:\\456"))
            {
                //fprintf(file, "@0203  ; %s chart positions.\n", szAppName);
                //fprintf(file, "%czi \"%s\" \"%s\"\n", chSwitch, ciMain.nam, ciMain.loc);
                for (int i = 1; i <= 32; i++)
                {

                    double rT = 0;
                    if (i >= 24 && i <= 29)
                    {
                        rT = target.cp.cusp[i - 20];
                    }
                    else
                    {
                        rT = target.cp.obj[i];
                    }

                    int j = (int)rT;
                    sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t,", i,
                      j % 30, (j / 30 + 1), Math.Round((RFract(rT) * 60.0), 9),
                      (int)target.cp.alt[i], Math.Round((RFract(Math.Abs(target.cp.alt[i])) * 60.0), 9));
                    if (false)
                    {
                        rT = Math.Sqrt(target.spacex[i] * target.spacex[i] + target.spacey[i] * target.spacey[i] + target.spacez[i] * target.spacez[i]);
                    }
                    sw.WriteLine("{0}\t{1}", Math.Round(target.DFromR(target.cp.dir[i]),9), Math.Round(rT,9));
                }
            }
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        private double RFract(double rT)
        {
            return rT - (int)rT;
        }
    }
}
