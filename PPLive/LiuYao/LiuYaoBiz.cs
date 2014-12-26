using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AppCmn;

namespace PPLive.LiuYao
{
    /// <summary>
    /// LiuYao 的摘要说明
    /// </summary>
    public class LiuYaoBiz
    {
        public LiuYaoBiz()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 输入六位二进制,及动爻,排卦
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="yao"></param>
        public void BitToYao(bool a, bool b, bool c, bool d, bool e, bool f, ref LiuYaoMod mod)
        {
            string connectionString = AppConfig.ConnectionString;

            #region 设置主卦
            string cmdTexta = "SELECT * FROM Sign_64 WHERE firstbit = " + a + " AND secondbit = " + b + " AND thirdbit = " + c + " AND forthbit = " + d + " AND fifthbit = " + e + " AND sixthbit = " + f;

            using (SqlDataReader myreadera = SqlHelper.ExecuteReader(connectionString, CommandType.Text, cmdTexta))
            {
                myreadera.Read();

                mod.ZhuGua.Yaos[0].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreadera[14].ToString());
                mod.ZhuGua.Yaos[1].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreadera[15].ToString());
                mod.ZhuGua.Yaos[2].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreadera[16].ToString());
                mod.ZhuGua.Yaos[3].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreadera[17].ToString());
                mod.ZhuGua.Yaos[4].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreadera[18].ToString());
                mod.ZhuGua.Yaos[5].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreadera[19].ToString());

                mod.ZhuGua.Yaos[0].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreadera[2].ToString());
                mod.ZhuGua.Yaos[1].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreadera[3].ToString());
                mod.ZhuGua.Yaos[2].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreadera[4].ToString());
                mod.ZhuGua.Yaos[3].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreadera[5].ToString());
                mod.ZhuGua.Yaos[4].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreadera[6].ToString());
                mod.ZhuGua.Yaos[5].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreadera[7].ToString());

                mod.ZhuGua.Yaos[0].YaoType = (bool)myreadera[8];
                mod.ZhuGua.Yaos[1].YaoType = (bool)myreadera[9];
                mod.ZhuGua.Yaos[2].YaoType = (bool)myreadera[10];
                mod.ZhuGua.Yaos[3].YaoType = (bool)myreadera[11];
                mod.ZhuGua.Yaos[4].YaoType = (bool)myreadera[12];
                mod.ZhuGua.Yaos[5].YaoType = (bool)myreadera[13];

                mod.ZhuGua.ShiYao = (int)myreadera[20];
                mod.ZhuGua.YingYao = (int)myreadera[21];
                mod.ZhuGua.GuaMing = myreadera[1].ToString();

                mod.ZhuGua.Yaos[0].LiuQin = (PublicValue.LYLiuQin)Enum.Parse(typeof(PublicValue.LYLiuQin), myreadera["firstlq"].ToString());
                mod.ZhuGua.Yaos[1].LiuQin = (PublicValue.LYLiuQin)Enum.Parse(typeof(PublicValue.LYLiuQin), myreadera["secondlq"].ToString());
                mod.ZhuGua.Yaos[2].LiuQin = (PublicValue.LYLiuQin)Enum.Parse(typeof(PublicValue.LYLiuQin), myreadera["thirdlq"].ToString());
                mod.ZhuGua.Yaos[3].LiuQin = (PublicValue.LYLiuQin)Enum.Parse(typeof(PublicValue.LYLiuQin), myreadera["forthlq"].ToString());
                mod.ZhuGua.Yaos[4].LiuQin = (PublicValue.LYLiuQin)Enum.Parse(typeof(PublicValue.LYLiuQin), myreadera["fifthlq"].ToString());
                mod.ZhuGua.Yaos[5].LiuQin = (PublicValue.LYLiuQin)Enum.Parse(typeof(PublicValue.LYLiuQin), myreadera["sixthlq"].ToString());

                //yao[9, 0] = myreadera["strong"].ToString();

                mod.ZhuGua.GuaHao = Int32.Parse(myreadera[0].ToString());
            }
            #endregion

            #region 设置伏卦
            int temp = mod.ZhuGua.GuaHao;
            string cmdTextb = "";
            if (temp % 10 == 1)
            {
                bool oa = opp(a);
                bool ob = opp(b);
                bool oc = opp(c);
                bool od = opp(d);
                bool oe = opp(e);
                bool of = opp(f);
                cmdTextb = "SELECT * FROM Sign_64 WHERE firstbit = " + oa + " AND secondbit = " + ob + " AND thirdbit = " + oc + " AND forthbit = " + od + " AND fifthbit = " + oe + " AND sixthbit = " + of;
            }
            else
            {
                temp = (temp / 10) * 10 + 1;
                cmdTextb = @"SELECT * FROM Sign_64 WHERE guahao = " + temp.ToString();
            }

            using (SqlDataReader myreaderb = SqlHelper.ExecuteReader(connectionString, CommandType.Text, cmdTextb))
            {
                myreaderb.Read();

                mod.FuGua.Yaos[0].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderb[14].ToString());
                mod.FuGua.Yaos[1].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderb[15].ToString());
                mod.FuGua.Yaos[2].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderb[16].ToString());
                mod.FuGua.Yaos[3].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderb[17].ToString());
                mod.FuGua.Yaos[4].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderb[18].ToString());
                mod.FuGua.Yaos[5].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderb[19].ToString());

                mod.FuGua.Yaos[0].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderb[2].ToString());
                mod.FuGua.Yaos[1].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderb[3].ToString());
                mod.FuGua.Yaos[2].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderb[4].ToString());
                mod.FuGua.Yaos[3].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderb[5].ToString());
                mod.FuGua.Yaos[4].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderb[6].ToString());
                mod.FuGua.Yaos[5].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderb[7].ToString());
            }
            #endregion

            #region 设置变卦
            for (int i = 1; i <= 6; i++)
            {
                if (mod.ZhuGua.Yaos[i].Dong == true)
                {
                    switch (i)
                    {
                        case 1:
                            a = opp(a);
                            break;
                        case 2:
                            b = opp(b);
                            break;
                        case 3:
                            c = opp(c);
                            break;
                        case 4:
                            d = opp(d);
                            break;
                        case 5:
                            e = opp(e);
                            break;
                        case 6:
                            f = opp(f);
                            break;
                    }
                }
            }
            string cmdTextc = "SELECT * FROM Sign_64 WHERE firstbit = " + a + " AND secondbit = " + b + " AND thirdbit = " + c + " AND forthbit = " + d + " AND fifthbit = " + e + " AND sixthbit = " + f;

            using (SqlDataReader myreaderc = SqlHelper.ExecuteReader(connectionString, CommandType.Text, cmdTextc))
            {
                myreaderc.Read();

                mod.BianGua.Yaos[0].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderc[14].ToString());
                mod.BianGua.Yaos[1].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderc[15].ToString());
                mod.BianGua.Yaos[2].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderc[16].ToString());
                mod.BianGua.Yaos[3].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderc[17].ToString());
                mod.BianGua.Yaos[4].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderc[18].ToString());
                mod.BianGua.Yaos[5].YaoTG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), myreaderc[19].ToString());

                mod.BianGua.Yaos[0].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderc[2].ToString());
                mod.BianGua.Yaos[1].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderc[3].ToString());
                mod.BianGua.Yaos[2].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderc[4].ToString());
                mod.BianGua.Yaos[3].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderc[5].ToString());
                mod.BianGua.Yaos[4].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderc[6].ToString());
                mod.BianGua.Yaos[5].YaoDZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), myreaderc[7].ToString());

                mod.BianGua.Yaos[0].YaoType = (bool)myreaderc[8];
                mod.BianGua.Yaos[1].YaoType = (bool)myreaderc[9];
                mod.BianGua.Yaos[2].YaoType = (bool)myreaderc[10];
                mod.BianGua.Yaos[3].YaoType = (bool)myreaderc[11];
                mod.BianGua.Yaos[4].YaoType = (bool)myreaderc[12];
                mod.BianGua.Yaos[5].YaoType = (bool)myreaderc[13];

                mod.BianGua.ShiYao = (int)myreaderc[20];
                mod.BianGua.YingYao = (int)myreaderc[21];
                mod.BianGua.GuaMing = myreaderc[1].ToString();

                mod.BianGua.GuaHao = Int32.Parse(myreaderc[0].ToString());
            }
            #endregion
        }

        /// <summary>
        /// 6位数字奇偶起卦，设置BOOL，动爻位置
        /// </summary>
        /// <param name="num"></param>
        /// <param name="ret"></param>
        /// <param name="yao"></param>
        public void NumToBool(int num, ref LiuYaoMod mod)
        {
            bool[] ret = new bool[6];
            int[] tempnum = new int[6];
            tempnum[5] = num % 10;
            tempnum[4] = (num / 10) % 10;
            tempnum[3] = (num / 100) % 10;
            tempnum[2] = (num / 1000) % 10;
            tempnum[1] = (num / 10000) % 10;
            tempnum[0] = (num / 100000) % 10;
            for (int i = 0; i <= 5; i++)
            {
                if (tempnum[i] >= 6)
                    mod.ZhuGua.Yaos[i+1].Dong = true;
                else
                    mod.ZhuGua.Yaos[i + 1].Dong = false;
                if (tempnum[i] % 2 == 0)
                    ret[i] = false;
                else
                    ret[i] = true;
            }
            BitToYao(ret[0], ret[1], ret[2], ret[3], ret[4], ret[5], ref mod);
        }

        /// <summary>
        /// 上卦数下卦数起卦，设置BOOL，动爻位置
        /// </summary>
        /// <param name="numa"></param>
        /// <param name="numb"></param>
        /// <param name="ret"></param>
        /// <param name="yao"></param>
        public void NumsToBool(string numa, string numb, ref LiuYaoMod mod)
        {
            int temp = 0;
            string temps = "";
            bool[] ret = new bool[6];
            for (int i = 0; i < numa.Length; i++)
            {
                temps = numa.Substring(i, 1);
                if (temps == "1" || temps == "2" || temps == "3" || temps == "4" || temps == "5" || temps == "6" || temps == "7" || temps == "8" || temps == "9" || temps == "0")
                    temp = temp + Int16.Parse(temps);
            }
            int numaa = temp % 8;
            int dong = temp;
            NumsTogua(numaa, true, ref ret);
            temp = 0;
            for (int i = 0; i < numb.Length; i++)
            {
                temps = numb.Substring(i, 1);
                if (temps == "1" || temps == "2" || temps == "3" || temps == "4" || temps == "5" || temps == "6" || temps == "7" || temps == "8" || temps == "9" || temps == "0")
                    temp = temp + Int16.Parse(temps);
            }
            int numbb = temp % 8;
            NumsTogua(numbb, false, ref ret);
            dong = dong + temp;
            dong = dong % 6;
            if (dong == 0)
                dong = 6;
            for (int i = 1; i <= 6; i++)
            {
                if (i == dong)
                    mod.ZhuGua.Yaos[i].Dong = true;
                else
                    mod.ZhuGua.Yaos[i].Dong = false;
            }
            BitToYao(ret[0], ret[1], ret[2], ret[3], ret[4], ret[5], ref mod);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">输入数字</param>
        /// <param name="updown">上下卦,下为0,上为1</param>
        /// <param name="retbool"></param>
        /// <returns></returns>
        private void NumsTogua(int num, bool updown, ref bool[] retbool)
        {
            int i = 0;
            if (updown)
                i = 3;
            switch (num)
            {
                case 1:
                    {
                        retbool[i + 2] = true;
                        retbool[i + 1] = true;
                        retbool[i] = true;
                        //111
                        break;
                    }
                case 2:
                    {
                        retbool[i + 2] = false;
                        retbool[i + 1] = true;
                        retbool[i] = true;
                        //011
                        break;
                    }
                case 3:
                    {
                        retbool[i + 2] = true;
                        retbool[i + 1] = false;
                        retbool[i] = true;
                        //101
                        break;
                    }
                case 4:
                    {
                        retbool[i + 2] = false;
                        retbool[i + 1] = false;
                        retbool[i] = true;
                        //001
                        break;
                    }
                case 5:
                    {
                        retbool[i + 2] = true;
                        retbool[i + 1] = true;
                        retbool[i] = false;
                        //ret = "110";
                        break;
                    }
                case 6:
                    {
                        retbool[i + 2] = false;
                        retbool[i + 1] = true;
                        retbool[i] = false;
                        //ret = "010";
                        break;
                    }
                case 7:
                    {
                        retbool[i + 2] = true;
                        retbool[i + 1] = false;
                        retbool[i] = false;
                        //ret = "100";
                        break;
                    }
                case 0:
                    {
                        retbool[i + 2] = false;
                        retbool[i + 1] = false;
                        retbool[i] = false;
                        //ret = "000";
                        break;
                    }

            }

        }


        public void XuanBaziToYao12(string[] bazi, string num, ref LiuYaoMod mod)
        {
            int upnum = 0; int downnum = 0;
            for (int i = 0; i <= 6; i = i + 2)
            {
                upnum = upnum + XuanGZToNum(bazi[i].ToString());
                downnum = downnum + XuanGZToNum(bazi[i + 1].ToString());
            }
            int dong = upnum + downnum;
            if (num != "")
            {
                int tempnum = Int32.Parse(num.ToString());
                //tempnum = tempnum % 12;
                upnum = upnum + XuanNumUp12(tempnum, bazi[6]);
                downnum = downnum + XuanNumDown12(tempnum);
                dong = dong + XuanNumUp12(tempnum, bazi[6]) + XuanNumDown12(tempnum);
            }


            dong = dong % 6;
            if (dong == 0)
                dong = 6;
            upnum = upnum % 8;
            downnum = downnum % 8;
            for (int i = 1; i <= 6; i++)
            {
                if (i == dong)
                    mod.ZhuGua.Yaos[i].Dong = true;
                else
                    mod.ZhuGua.Yaos[i].Dong = false;
            }
            bool[] tempbool = new bool[6];
            NumsTogua(upnum, true, ref tempbool);
            NumsTogua(downnum, false, ref tempbool);
            BitToYao(tempbool[0], tempbool[1], tempbool[2], tempbool[3], tempbool[4], tempbool[5], ref mod);
        }

        private int XuanNumUp12(int num, string shigan)
        {
            int ret = 0;
            if (shigan == "甲" || shigan == "己")
            {
                switch (num)
                {
                    case 1:
                        ret = 9;
                        break;
                    case 2:
                        ret = 8;
                        break;
                    case 3:
                        ret = 7;
                        break;
                    case 4:
                        ret = 6;
                        break;
                    case 5:
                        ret = 5;
                        break;
                    case 6:
                        ret = 9;
                        break;
                    case 7:
                        ret = 8;
                        break;
                    case 8:
                        ret = 7;
                        break;
                    case 9:
                        ret = 6;
                        break;
                    case 10:
                        ret = 5;
                        break;
                    case 11:
                        ret = 9;
                        break;
                    case 0:
                        ret = 8;
                        break;
                }
            }
            if (shigan == "乙" || shigan == "庚")
            {
                switch (num)
                {
                    case 1:
                        ret = 7;
                        break;
                    case 2:
                        ret = 6;
                        break;
                    case 3:
                        ret = 5;
                        break;
                    case 4:
                        ret = 9;
                        break;
                    case 5:
                        ret = 8;
                        break;
                    case 6:
                        ret = 7;
                        break;
                    case 7:
                        ret = 6;
                        break;
                    case 8:
                        ret = 5;
                        break;
                    case 9:
                        ret = 9;
                        break;
                    case 10:
                        ret = 8;
                        break;
                    case 11:
                        ret = 7;
                        break;
                    case 0:
                        ret = 6;
                        break;
                }
            }
            if (shigan == "丙" || shigan == "辛")
            {
                switch (num)
                {
                    case 1:
                        ret = 5;
                        break;
                    case 2:
                        ret = 9;
                        break;
                    case 3:
                        ret = 8;
                        break;
                    case 4:
                        ret = 7;
                        break;
                    case 5:
                        ret = 6;
                        break;
                    case 6:
                        ret = 5;
                        break;
                    case 7:
                        ret = 9;
                        break;
                    case 8:
                        ret = 8;
                        break;
                    case 9:
                        ret = 7;
                        break;
                    case 10:
                        ret = 6;
                        break;
                    case 11:
                        ret = 5;
                        break;
                    case 0:
                        ret = 9;
                        break;
                }
            }
            if (shigan == "丁" || shigan == "壬")
            {
                switch (num)
                {
                    case 1:
                        ret = 8;
                        break;
                    case 2:
                        ret = 7;
                        break;
                    case 3:
                        ret = 6;
                        break;
                    case 4:
                        ret = 5;
                        break;
                    case 5:
                        ret = 9;
                        break;
                    case 6:
                        ret = 8;
                        break;
                    case 7:
                        ret = 7;
                        break;
                    case 8:
                        ret = 6;
                        break;
                    case 9:
                        ret = 5;
                        break;
                    case 10:
                        ret = 9;
                        break;
                    case 11:
                        ret = 8;
                        break;
                    case 0:
                        ret = 7;
                        break;
                }
            }
            if (shigan == "戊" || shigan == "癸")
            {
                switch (num)
                {
                    case 1:
                        ret = 6;
                        break;
                    case 2:
                        ret = 5;
                        break;
                    case 3:
                        ret = 9;
                        break;
                    case 4:
                        ret = 8;
                        break;
                    case 5:
                        ret = 7;
                        break;
                    case 6:
                        ret = 6;
                        break;
                    case 7:
                        ret = 5;
                        break;
                    case 8:
                        ret = 9;
                        break;
                    case 9:
                        ret = 8;
                        break;
                    case 10:
                        ret = 7;
                        break;
                    case 11:
                        ret = 6;
                        break;
                    case 0:
                        ret = 5;
                        break;
                }
            }
            return ret;
        }

        private int XuanNumDown12(int num)
        {
            int ret = 0;
            switch (num)
            {
                case 1:
                    ret = 9;
                    break;
                case 2:
                    ret = 8;
                    break;
                case 3:
                    ret = 7;
                    break;
                case 4:
                    ret = 6;
                    break;
                case 5:
                    ret = 5;
                    break;
                case 6:
                    ret = 4;
                    break;
                case 7:
                    ret = 9;
                    break;
                case 8:
                    ret = 8;
                    break;
                case 9:
                    ret = 7;
                    break;
                case 10:
                    ret = 6;
                    break;
                case 11:
                    ret = 5;
                    break;
                case 0:
                    ret = 4;
                    break;
            }
            return ret;
        }


        public void XuanBaziToYao30(string[] bazi, string num, ref LiuYaoMod mod)
        {
            int upnum = 0; int downnum = 0;
            for (int i = 0; i <= 6; i = i + 2)
            {
                upnum = upnum + XuanGZToNum(bazi[i].ToString());
                downnum = downnum + XuanGZToNum(bazi[i + 1].ToString());
            }
            int dong = upnum + downnum;
            if (num != "")
            {
                int tempnum = Int32.Parse(num.ToString());
                //tempnum = tempnum % 30;
                upnum = upnum + XuanNumUp30(tempnum, bazi[6]);
                downnum = downnum + XuanNumDown30(tempnum);
                dong = dong + XuanNumUp30(tempnum, bazi[6]) + XuanNumDown30(tempnum);
            }


            dong = dong % 6;
            if (dong == 0)
                dong = 6;
            upnum = upnum % 8;
            downnum = downnum % 8;
            for (int i = 1; i <= 6; i++)
            {
                if (i == dong)
                    mod.ZhuGua.Yaos[i].Dong = true;
                else
                    mod.ZhuGua.Yaos[i].Dong = false;
            }
            bool[] tempbool = new bool[6];
            NumsTogua(upnum, true, ref tempbool);
            NumsTogua(downnum, false, ref tempbool);
            BitToYao(tempbool[0], tempbool[1], tempbool[2], tempbool[3], tempbool[4], tempbool[5], ref mod);
        }

        private int XuanNumUp30(int num, string shigan)
        {
            int ret = 0;
            if (num == 0)
                num = 12;
            num = num % 5;
            if (shigan == "甲" || shigan == "己")
            {
                switch (num)
                {
                    case 1:
                        ret = 9;
                        break;
                    case 2:
                        ret = 8;
                        break;
                    case 3:
                        ret = 7;
                        break;
                    case 4:
                        ret = 6;
                        break;
                    case 0:
                        ret = 5;
                        break;

                }
            }
            if (shigan == "乙" || shigan == "庚")
            {
                switch (num)
                {
                    case 1:
                        ret = 7;
                        break;
                    case 2:
                        ret = 6;
                        break;
                    case 3:
                        ret = 5;
                        break;
                    case 4:
                        ret = 9;
                        break;

                    case 0:
                        ret = 8;
                        break;
                }
            }
            if (shigan == "丙" || shigan == "辛")
            {
                switch (num)
                {
                    case 1:
                        ret = 5;
                        break;
                    case 2:
                        ret = 9;
                        break;
                    case 3:
                        ret = 8;
                        break;
                    case 4:
                        ret = 7;
                        break;

                    case 0:
                        ret = 6;
                        break;
                }
            }
            if (shigan == "丁" || shigan == "壬")
            {
                switch (num)
                {
                    case 1:
                        ret = 8;
                        break;
                    case 2:
                        ret = 7;
                        break;
                    case 3:
                        ret = 6;
                        break;
                    case 4:
                        ret = 5;
                        break;

                    case 0:
                        ret = 9;
                        break;
                }
            }
            if (shigan == "戊" || shigan == "癸")
            {
                switch (num)
                {
                    case 1:
                        ret = 6;
                        break;
                    case 2:
                        ret = 5;
                        break;
                    case 3:
                        ret = 9;
                        break;
                    case 4:
                        ret = 8;
                        break;

                    case 0:
                        ret = 7;
                        break;
                }
            }
            return ret;
        }

        private int XuanNumDown30(int num)
        {
            int ret = 0;
            num = num % 6;
            switch (num)
            {
                case 1:
                    ret = 9;
                    break;
                case 2:
                    ret = 8;
                    break;
                case 3:
                    ret = 7;
                    break;
                case 4:
                    ret = 6;
                    break;
                case 5:
                    ret = 5;
                    break;

                case 0:
                    ret = 4;
                    break;
            }
            return ret;
        }

        #region 细节算法
        private bool opp(bool a)
        {
            if (a == true)
                return false;
            else
                return true;
        }

        public string PrintYao(string a)
        {
            string temp;
            if (a == "True")
                temp = "———";
            else
                temp = "—　—";
            return temp;
        }

        private string accbool(bool sendin)
        {
            string ret = "";
            if (sendin)
                ret = "-1";
            else
                ret = "0";
            return ret;
        }

        private int XuanGZToNum(string gz)
        {
            int ret = 4;
            if (gz == "甲" || gz == "己" || gz == "子" || gz == "午")
                ret = 9;
            if (gz == "乙" || gz == "庚" || gz == "丑" || gz == "未")
                ret = 8;
            if (gz == "丙" || gz == "辛" || gz == "寅" || gz == "申")
                ret = 7;
            if (gz == "丁" || gz == "壬" || gz == "卯" || gz == "酉")
                ret = 6;
            if (gz == "戊" || gz == "癸" || gz == "辰" || gz == "戌")
                ret = 5;

            return ret;
        }
        #endregion
    }
}