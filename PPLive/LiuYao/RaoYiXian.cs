using System;
using System.Data;
using System.Configuration;
using System.Web;
using AppCmn;

namespace PPLive.LiuYao
{
    /// <summary>
    /// 饶宜献六爻判断
    /// </summary>
    public class RaoYiXian
    {
        public RaoYiXian()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private string[,] _yao;
        private string[,] _wrongyao;
        private string[] _bazi;
        int yongyao = 0;
        int wrongyongyao = 0;
        string yaoguagong = "";
        string wrongyaoguagong = "";
        public string step = "";
        int rui = 0;
        int ruj = 0;
        bool rupower = true;

        private PublicDeal m_dl = new PublicDeal();

        public string[,] yao
        {
            get
            {
                return _yao;
            }
            set
            {
                _yao = value;
            }
        }

        public string[,] wrongyao
        {
            get
            {
                return _wrongyao;
            }
            set
            {
                _wrongyao = value;
            }
        }

        public string[] bazi
        {
            get
            {
                return _bazi;
            }
            set
            {
                _bazi = value;
            }
        }



        /// <summary>
        /// 选卦
        /// </summary>
        /// <returns>0为无效，1为正卦,2为错卦</returns>
        public string SelectGua()
        {
            bool selectyao = false;
            bool selectwrongyao = false;
            yaoguagong = GetGuaGong(_yao);
            wrongyaoguagong = GetGuaGong(_wrongyao);
            string ret = "0";
            int tmpbegin = 1;
            int tmpend = 4;
            string yongyaoZ = "";
            string wrongyongyaoZ = "";
            step = "选卦1.判断用爻上卦之卦";
            //1
            //yao
            if (yaoguagong == "震")
            {
                tmpbegin = 1;
                tmpend = 4;
                if (int.Parse(yao[1, 0].ToString()) > 2)
                {
                    tmpbegin = 4;
                    tmpend = 7;
                }
                for (int i = tmpbegin; i < tmpend; i++)
                {
                    if (GetLiuQing(yao, 2, i) == "妻财" || (GetLiuQing(yao, 7, i) == "妻财" && yao[0, i] == "1"))
                    {
                        selectyao = true;
                        yongyao = i;
                        break;
                    }
                }
            }
            else
            {
                tmpbegin = 1;
                tmpend = 4;
                if (int.Parse(yao[2, 0].ToString()) > 2)
                {
                    tmpbegin = 4;
                    tmpend = 7;
                }
                for (int i = tmpbegin; i < tmpend; i++)
                {
                    if (GetLiuQing(yao, 2, i) == "妻财" || (GetLiuQing(yao, 7, i) == "妻财" && yao[0, i] == "1"))
                    {
                        selectyao = true;
                        yongyao = i;
                        break;
                    }
                }
            }
            //wrongyao
            if (wrongyaoguagong == "震")
            {
                tmpbegin = 1;
                tmpend = 4;
                if (int.Parse(wrongyao[1, 0].ToString()) > 2)
                {
                    tmpbegin = 4;
                    tmpend = 7;
                }
                for (int i = tmpbegin; i < tmpend; i++)
                {
                    if (GetLiuQing(wrongyao, 2, i) == "妻财" || (GetLiuQing(wrongyao, 7, i) == "妻财" && wrongyao[0, i] == "1"))
                    {
                        selectwrongyao = true;
                        wrongyongyao = i;
                        break;
                    }
                }
            }
            else
            {
                tmpbegin = 1;
                tmpend = 4;
                if (int.Parse(wrongyao[2, 0].ToString()) > 2)
                {
                    tmpbegin = 4;
                    tmpend = 7;
                }
                for (int i = tmpbegin; i < tmpend; i++)
                {
                    if (GetLiuQing(wrongyao, 2, i) == "妻财" || (GetLiuQing(wrongyao, 7, i) == "妻财" && wrongyao[0, i] == "1"))
                    {
                        selectwrongyao = true;
                        wrongyongyao = i;
                        break;
                    }
                }
            }
            if (selectyao == true && selectwrongyao == false)
            {
                ret = "1";
                return ret;
            }
            else if (selectyao == true && selectwrongyao == false)
            {
                ret = "2";
                return ret;
            }

            if (selectyao == true && selectwrongyao == true)
            {
                step = "选卦2.选取用爻为偏财爻";
                //2
                if ((GZyinyang(yao[2, yongyao]) == GZyinyang(GetGuaGongWuXing(yaoguagong))) || GZyinyang(yao[7, yongyao]) == GZyinyang(GetGuaGongWuXing(yaoguagong))
                     && (GZyinyang(wrongyao[2, wrongyongyao]) != GZyinyang(GetGuaGongWuXing(wrongyaoguagong)) || GZyinyang(wrongyao[7, wrongyongyao]) != GZyinyang(GetGuaGongWuXing(wrongyaoguagong))))
                {
                    ret = "1";
                    return ret;
                }
                else if ((GZyinyang(yao[2, yongyao]) != GZyinyang(GetGuaGongWuXing(yaoguagong)) || GZyinyang(yao[7, yongyao]) == GZyinyang(GetGuaGongWuXing(yaoguagong)))
                     && (GZyinyang(wrongyao[2, wrongyongyao]) == GZyinyang(GetGuaGongWuXing(wrongyaoguagong)) || GZyinyang(wrongyao[7, wrongyongyao]) == GZyinyang(GetGuaGongWuXing(wrongyaoguagong))))
                {
                    ret = "2";
                    return ret;
                }
                step = "选卦3.选取用爻天人感应";
                //3
                if (GetLiuQing(yao, 2, yongyao) == "妻财")
                {
                    yongyaoZ = yao[2, yongyao];
                }
                else if (GetLiuQing(yao, 7, yongyao) == "妻财")
                {
                    yongyaoZ = yao[7, yongyao];
                }
                if (GetLiuQing(wrongyao, 2, wrongyongyao) == "妻财")
                {
                    wrongyongyaoZ = wrongyao[2, wrongyongyao];
                }
                else if (GetLiuQing(wrongyao, 7, wrongyongyao) == "妻财")
                {
                    wrongyongyaoZ = wrongyao[7, wrongyongyao];
                }

                if (bazi[7] == yongyaoZ && bazi[7] != wrongyongyaoZ)
                {
                    ret = "1";
                    return ret;
                }
                else if (bazi[7] != yongyaoZ && bazi[7] == wrongyongyaoZ)
                {
                    ret = "2";
                    return ret;
                }
                if (bazi[5] == yongyaoZ && bazi[5] != wrongyongyaoZ)
                {
                    ret = "1";
                    return ret;
                }
                else if (bazi[5] != yongyaoZ && bazi[5] == wrongyongyaoZ)
                {
                    ret = "2";
                    return ret;
                }
                if (bazi[3] == yongyaoZ && bazi[3] != wrongyongyaoZ)
                {
                    ret = "1";
                    return ret;
                }
                else if (bazi[3] != yongyaoZ && bazi[3] == wrongyongyaoZ)
                {
                    ret = "2";
                    return ret;
                }
                if (bazi[1] == yongyaoZ && bazi[1] != wrongyongyaoZ)
                {
                    ret = "1";
                    return ret;
                }
                else if (bazi[1] != yongyaoZ && bazi[1] == wrongyongyaoZ)
                {
                    ret = "2";
                    return ret;
                }
                step = "选卦4.选取用爻动必有因";
                //4
                if (yao[0, yongyao] == "1" && wrongyao[0, wrongyongyao] != "1")
                {
                    ret = "1";
                    return ret;
                }
                else if (yao[0, yongyao] != "1" && wrongyao[0, wrongyongyao] == "1")
                {
                    ret = "2";
                    return ret;
                }
            }
            step = "选卦5.选取世爻天人感应";
            //5
            if (bazi[7] == yao[2, int.Parse(yao[1, 0])] && bazi[7] != wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[7] != yao[2, int.Parse(yao[1, 0])] && bazi[7] == wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "2";
                return ret;
            }
            if (bazi[5] == yao[2, int.Parse(yao[1, 0])] && bazi[5] != wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[5] != yao[2, int.Parse(yao[1, 0])] && bazi[5] == wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "2";
                return ret;
            }
            if (bazi[3] == yao[2, int.Parse(yao[1, 0])] && bazi[3] != wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[3] != yao[2, int.Parse(yao[1, 0])] && bazi[3] == wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "2";
                return ret;
            }
            if (bazi[1] == yao[2, int.Parse(yao[1, 0])] && bazi[1] != wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[1] != yao[2, int.Parse(yao[1, 0])] && bazi[1] == wrongyao[2, int.Parse(wrongyao[1, 0])])
            {
                ret = "2";
                return ret;
            }

            if (bazi[7] == yao[2, int.Parse(yao[2, 0])] && bazi[7] != wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[7] != yao[2, int.Parse(yao[2, 0])] && bazi[7] == wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "2";
                return ret;
            }
            if (bazi[5] == yao[2, int.Parse(yao[2, 0])] && bazi[5] != wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[5] != yao[2, int.Parse(yao[2, 0])] && bazi[5] == wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "2";
                return ret;
            }
            if (bazi[3] == yao[2, int.Parse(yao[2, 0])] && bazi[3] != wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[3] != yao[2, int.Parse(yao[2, 0])] && bazi[3] == wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "2";
                return ret;
            }
            if (bazi[1] == yao[2, int.Parse(yao[2, 0])] && bazi[1] != wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "1";
                return ret;
            }
            else if (bazi[1] != yao[2, int.Parse(yao[2, 0])] && bazi[1] == wrongyao[2, int.Parse(wrongyao[2, 0])])
            {
                ret = "2";
                return ret;
            }
            step = "选卦6.选取用爻与月令同性";
            //6
            if (GZyinyang(yongyaoZ) == GZyinyang(bazi[3]) && GZyinyang(wrongyongyaoZ) != GZyinyang(bazi[3]))
            {
                ret = "1";
                return ret;
            }
            else if (GZyinyang(yongyaoZ) != GZyinyang(bazi[3]) && GZyinyang(wrongyongyaoZ) == GZyinyang(bazi[3]))
            {
                ret = "2";
                return ret;
            }
            step = "选卦7.选取有财爻即可";
            //7
            if (selectyao == false && selectwrongyao == false)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (GetLiuQing(yao, 2, yongyao) == "妻财" || GetLiuQing(yao, 7, yongyao) == "妻财" || GetLiuQing(yao, 5, yongyao) == "妻财")
                    {
                        selectyao = true;
                        break;
                    }
                }
                for (int i = 1; i < 7; i++)
                {
                    if (GetLiuQing(wrongyao, 2, wrongyongyao) == "妻财" || GetLiuQing(wrongyao, 7, wrongyongyao) == "妻财" || GetLiuQing(wrongyao, 5, wrongyongyao) == "妻财")
                    {
                        selectwrongyao = true;
                        break;
                    }
                }
                if (selectyao == true && selectwrongyao == false)
                {
                    ret = "1";
                    return ret;
                }
                else if (selectyao == false && selectwrongyao == true)
                {
                    ret = "2";
                    return ret;
                }
            }
            return ret;
        }

        /// <summary>
        /// 判喜恶
        /// </summary>
        /// <param name="tmpyao"></param>
        /// <returns></returns>
        public string JiXiong(string[,] tmpyao)
        {
            string ret = "";
            DataTable m_dt = new DataTable();
            string tmpguagong = GetGuaGong(tmpyao);
            switch (tmpguagong)
            {
                case "乾":
                    tmpguagong = "qian";
                    break;
                case "坤":
                    tmpguagong = "kun";
                    break;
                case "兑":
                    tmpguagong = "dui";
                    break;
                case "离":
                    tmpguagong = "li";
                    break;
                case "巽":
                    tmpguagong = "xun";
                    break;
                case "震":
                    tmpguagong = "zhen";
                    break;
                case "坎":
                    tmpguagong = "kan";
                    break;
                case "艮":
                    tmpguagong = "gen";
                    break;
            }
            using (AccData m_data = new AccData("../App_Data/cate.mdb"))
            {
                m_dt = m_data.CmdtoDataTable("select " + tmpguagong + " from guapower where year = '" + bazi[1] + "' and month = '" + bazi[3] + "' and day = '" + bazi[5] + "' and hour = '" + bazi[7] + "';");
            }
            if (m_dt.Rows[0]["strong"].ToString() == "强" || m_dt.Rows[0]["strong"].ToString() == "从弱")
            {
                if (LYLiangHua(m_dl.GZWuXing(yao[2, yongyao], GetGuaGongWuXing(yaoguagong))) == "-")
                {
                    ret = "喜";
                }
                else
                {
                    ret = "恶";
                }
            }
            else if (m_dt.Rows[0]["strong"].ToString() == "从强" || m_dt.Rows[0]["strong"].ToString() == "弱")
            {
                if (LYLiangHua(m_dl.GZWuXing(yao[2, yongyao], GetGuaGongWuXing(yaoguagong))) == "+")
                {
                    ret = "喜";
                }
                else
                {
                    ret = "恶";
                }
            }

            //真空反断

            //强极反断

            //化泄反断

            //化空反断
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpyao"></param>
        /// <returns></returns>
        public string DuanGua(string[,] tmpyao, string jixiong)
        {
            string ret = "";
            //1
            if (ZhenKong(tmpyao, bazi) == "1")
            {
                if (jixiong == "喜")
                {
                    ret = "0";
                }
                else
                {
                    ret = "1";
                }
                return ret;
            }
            //2

            return ret;
        }


        #region 通用判断
        /// <summary>
        /// 获取卦宫名
        /// </summary>
        /// <param name="yao"></param>
        /// <returns></returns>
        public static string GetGuaGong(string[,] ayao)
        {
            return ayao[9, 0];
        }

        /// <summary>
        /// 获取卦宫五行
        /// </summary>
        /// <param name="GuaGong"></param>
        /// <returns></returns>
        public static string GetGuaGongWuXing(string GuaGong)
        {
            string ret = "";
            switch (GuaGong)
            {
                case "乾":
                    ret = "申";
                    break;
                case "坤":
                    ret = "丑";
                    break;
                case "兑":
                    ret = "酉";
                    break;
                case "离":
                    ret = "午";
                    break;
                case "巽":
                    ret = "卯";
                    break;
                case "震":
                    ret = "寅";
                    break;
                case "坎":
                    ret = "子";
                    break;
                case "艮":
                    ret = "戌";
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 六爻五行量化判断,返回+ ,-,(同,异)耗,(同,异)帮克,(同,异)帮耗,生合(增减)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string LYLiangHua(string a)
        {
            string ret = a;
            if (a == "同帮" || a == "异帮" || a == "同生" || a == "异生" || a == "合增")
                ret = "+";
            if (a == "同克" || a == "异克" || a == "同晦" || a == "异晦" || a == "同脆" || a == "异脆" || a == "同泄" || a == "异泄" || a == "对冲" || a == "互刑" || a == "相害" || a == "合减")
                ret = "-";
            return ret;
        }

        public string OppEnergy(string putin)
        {
            string ret = "";
            if (putin == "+")
            {
                ret = "-";
            }
            else if (putin == "-")
            {
                ret = "+";
            }

            if (putin == "喜")
            {
                ret = "恶";
            }
            else if (putin == "恶")
            {
                ret = "喜";
            }

            return ret;
        }

        public string GZyinyang(string putin)
        {
            string ret = "";
            if (putin == "子" || putin == "寅" || putin == "辰" || putin == "午" || putin == "申" || putin == "戌")
            {
                ret = "阳";
            }
            else if (putin == "丑" || putin == "卯" || putin == "巳" || putin == "未" || putin == "酉" || putin == "亥")
            {
                ret = "阴";
            }
            return ret;
        }

        public string ZhenKong(string[,] tmpyao, string[] tmpbazi)
        {
            string ret = "0";

            if (tmpyao[2, int.Parse(tmpyao[1, 0])] == tmpbazi[8] || tmpyao[2, int.Parse(tmpyao[1, 0])] == tmpbazi[9])
            {
                string neighbour = GetNeighbour(tmpyao, 2, int.Parse(yao[1, 0]));
                bool nbplus = false;
                for (int k = 0; k < neighbour.Length; k++)
                {
                    if (LYLiangHua(m_dl.GZWuXing(neighbour.Substring(k, 1), tmpyao[2, int.Parse(tmpyao[1, 0])])) == "+")
                    {
                        nbplus = true;
                        break;
                    }
                }
                if (!nbplus)
                {
                    string tmpguagong = GetGuaGong(tmpyao);
                    if (LYLiangHua(m_dl.GZWuXing(tmpguagong, tmpyao[2, int.Parse(tmpyao[1, 0])])) != "+")
                    {
                        if (tmpyao[2, int.Parse(tmpyao[1, 0])] != tmpbazi[1] && tmpyao[2, int.Parse(tmpyao[1, 0])] != tmpbazi[3] &&
                            tmpyao[2, int.Parse(tmpyao[1, 0])] != tmpbazi[5] && tmpyao[2, int.Parse(tmpyao[1, 0])] != tmpbazi[7])
                        {
                            ret = "1";
                        }
                    }
                }
            }
            return ret;
        }

        public string GetNeighbour(string[,] tmpyao, int i, int j)
        {
            string ret = "";
            if (j != 1)
            {
                ret += tmpyao[i, j - 1];
            }
            if (j != 6)
            {
                ret += tmpyao[i, j + 1];
            }
            if (i == 2)
            {
                ret += tmpyao[5, j];
            }
            else if (i == 7)
            {
                ret += tmpyao[2, j];
            }
            if (i == 2)
            {
                ret += tmpyao[7, j];
            }
            else if (i == 5)
            {
                ret += tmpyao[2, j];
            }
            return ret;
        }

        public string GetLiuQing(string[,] tmpyao, int i, int j)
        {
            string ret = "";
            switch (tmpyao[9, int.Parse(tmpyao[1, 0])])
            {
                case "兄弟":
                    if (m_dl.GZWuXing(tmpyao[9, int.Parse(tmpyao[1, 0])], tmpyao[i, j]).Contains("克"))
                    {
                        ret = "妻财";
                    }
                    break;
                case "父母":
                    if (m_dl.GZWuXing(tmpyao[i, j], tmpyao[9, int.Parse(tmpyao[1, 0])]).Contains("克"))
                    {
                        ret = "妻财";
                    }
                    break;
                case "子孙":
                    if (m_dl.GZWuXing(tmpyao[9, int.Parse(tmpyao[1, 0])], tmpyao[i, j]).Contains("生"))
                    {
                        ret = "妻财";
                    }
                    break;
                case "妻财":
                    if (m_dl.GZWuXing(tmpyao[9, int.Parse(tmpyao[1, 0])], tmpyao[i, j]).Contains("帮"))
                    {
                        ret = "妻财";
                    }
                    break;
                case "官鬼":
                    if (m_dl.GZWuXing(tmpyao[i, j], tmpyao[9, int.Parse(tmpyao[1, 0])]).Contains("生"))
                    {
                        ret = "妻财";
                    }
                    break;
            }
            return ret;
        }

        public string GetSanHeHui(string[,] tmpyao, string[] tmpbazi, bool getian)
        {
            string ret = "";
            string[] plussizhi = { "申辰", "寅午", "寅戌", "亥未", "巳酉", "巳丑", "寅辰", "卯辰", "巳午", "巳未", "未午", "申戌", "酉戌", "亥丑", "子丑" };
            string[] plusyao = { "子", "戌", "午", "卯", "丑", "酉", "卯", "寅", "未", "午", "巳", "酉", "申", "子", "亥" };
            string[] minusesizhi = { "申子", "子辰", "午戌", "亥卯", "卯未", "酉丑", "寅卯", "申酉", "亥子" };
            string[] minuseyao = { "辰", "申", "寅", "未", "亥", "巳", "辰", "戌", "丑" };
            string tmpbazis = tmpbazi[1] + tmpbazi[3] + tmpbazi[5] + tmpbazi[7];
            string sanhe = "";

            for (int i = 0; i < plussizhi.Length; i++)
            {
                if (tmpbazis.Contains(plussizhi[i]) || tmpbazis.Contains(Exchange(plussizhi[i])))
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        if (tmpyao[2, j] == plusyao[i])
                        {
                            rui = 2;
                            ruj = j;
                            rupower = true;
                            sanhe = plussizhi[i] + plusyao[i];
                        }
                        else if (tmpyao[5, j] == plusyao[i])
                        {
                            rui = 5;
                            ruj = j;
                            rupower = true;
                            sanhe = plussizhi[i] + plusyao[i];
                        }
                        else if (tmpyao[7, j] == plusyao[i])
                        {
                            rui = 7;
                            ruj = j;
                            rupower = true;
                            sanhe = plussizhi[i] + plusyao[i];
                        }
                    }
                }
                if (tmpbazis.Contains(minusesizhi[i]) || tmpbazis.Contains(Exchange(minusesizhi[i])))
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        if (tmpyao[2, j] == minuseyao[i])
                        {
                            rui = 2;
                            ruj = j;
                            rupower = false;
                            sanhe = minusesizhi[i] + minuseyao[i];
                        }
                        else if (tmpyao[5, j] == minuseyao[i])
                        {
                            rui = 5;
                            ruj = j;
                            rupower = false;
                            sanhe = minusesizhi[i] + minuseyao[i];
                        }
                        else if (tmpyao[7, j] == minuseyao[i])
                        {
                            rui = 7;
                            ruj = j;
                            rupower = false;
                            sanhe = minusesizhi[i] + minuseyao[i];
                        }
                    }
                }
            }
            //无效
            for (int i = 1; i <= 6; i++)
            {
                if (!getian)
                {
                    if ((tmpbazi[7] + tmpbazi[5]).Contains(tmpyao[7, i]) || ((tmpbazi[7] + tmpbazi[5]).Contains(tmpyao[2, i]) && tmpyao[0, i] == "1"))
                    {
                        rui = 0;
                        ruj = 0;
                    }
                }
                else
                {
                    if (tmpbazi[5] == tmpyao[7, i] || (tmpbazi[5] == tmpyao[2, i] && tmpyao[0, i] == "1"))
                    {
                        rui = 0;
                        ruj = 0;
                    }
                }
            }
            //反意
            if (rui != 0 && ruj != 0)
            {
                if (m_dl.GZWuXing(tmpyao[rui, ruj], tmpbazi[7]).Contains("冲") || m_dl.GZWuXing(tmpyao[rui, ruj], tmpbazi[5]).Contains("冲")
                    || m_dl.GZWuXing(tmpyao[rui, ruj], tmpbazi[3]).Contains("冲") || m_dl.GZWuXing(tmpyao[rui, ruj], tmpbazi[1]).Contains("冲"))
                {
                    rupower = !rupower;
                }
                else if (m_dl.GZWuXing(tmpbazi[3], sanhe.Substring(0, 1)).Contains("合") || m_dl.GZWuXing(tmpbazi[3], sanhe.Substring(1, 1)).Contains("合") || m_dl.GZWuXing(tmpbazi[3], sanhe.Substring(2, 1)).Contains("合"))
                {
                    rupower = !rupower;
                }
                else if (tmpbazi[7] == tmpbazi[8] || tmpbazi[7] == tmpbazi[9])
                {
                    rupower = !rupower;
                }
            }
            return ret;
        }

        public string ruyao(string[,] tmpyao, string[] tmpbazi, bool getian)
        {
            string ret = "";
            rui = 0;
            ruj = 0;
            //时支入爻
            string tmpsizhi = tmpbazi[7];
            ret = GetBaziPower(tmpbazi, 7, tmpyao);
            for (int i = 1; i <= 6; i++)
            {
                if (tmpsizhi == tmpyao[2, i] && tmpyao[0, i] == "1")
                {
                    rui = 2;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (tmpsizhi == tmpyao[7, i])
                {
                    rui = 7;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (tmpsizhi == tmpyao[7, i] && tmpyao[0, i] == "1")
                {
                    rui = 7;
                    ruj = i;
                }
            }
            if (rui != 0)
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpyao[rui, i] == tmpbazi[1])
                    {
                        ret = GetBaziPower(tmpbazi, 1, tmpyao);
                        ruj = i;
                    }
                    else if (tmpyao[rui, i] == tmpbazi[3])
                    {
                        ret = GetBaziPower(tmpbazi, 3, tmpyao);
                        ruj = i;
                    }
                    else if (tmpyao[rui, i] == tmpbazi[5])
                    {
                        ret = GetBaziPower(tmpbazi, 5, tmpyao);
                        ruj = i;
                    }
                }
                if (rui == 7 && tmpyao[0, ruj] != "1")
                {
                    ret = OppEnergy(ret);
                }
                return ret;
            }


            //日支入爻
            tmpsizhi = tmpbazi[5];
            ret = GetBaziPower(tmpbazi, 5, tmpyao);
            for (int i = 1; i <= 6; i++)
            {
                if (tmpsizhi == tmpyao[2, i] && tmpyao[0, i] == "1")
                {
                    rui = 2;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (tmpsizhi == tmpyao[7, i])
                {
                    rui = 7;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (tmpsizhi == tmpyao[7, i] && tmpyao[0, i] == "1")
                {
                    rui = 7;
                    ruj = i;
                }
            }
            if (rui != 0)
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpyao[rui, i] == tmpbazi[1])
                    {
                        ret = GetBaziPower(tmpbazi, 1,tmpyao);
                        ruj = i;
                    }
                    else if (tmpyao[rui, i] == tmpbazi[3])
                    {
                        ret = GetBaziPower(tmpbazi, 3, tmpyao);
                        ruj = i;
                    }
                }
                if (rui == 7 && tmpyao[0, ruj] != "1")
                {
                    ret = OppEnergy(ret);
                }
                return ret;
            }
            //时支合爻
            tmpsizhi = tmpbazi[7];
            ret = GetBaziPower(tmpbazi, 7, tmpyao);
            for (int i = 1; i <= 6; i++)
            {
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合"))
                {
                    rui = 2;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[5, i]).Contains("合"))
                {
                    rui = 5;
                    ruj = i;
                }
            }
            if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, int.Parse(tmpyao[1, 0])]).Contains("合"))
            {
                rui = 2;
                ruj = int.Parse(tmpyao[1, 0]);
            }
            for (int i = 1; i <= 6; i++)
            {
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合") && tmpyao[0, i] == "1")
                {
                    rui = 2;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合"))
                {
                    rui = 7;
                    ruj = i;
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合") && tmpyao[0, i] == "1")
                {
                    rui = 7;
                    ruj = i;
                }
            }
            if (rui != 0)
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpbazi[1], tmpyao[rui, i]).Contains("合"))
                    {
                        ret = GetBaziPower(tmpbazi, 1, tmpyao);
                        ruj = i;
                    }
                    else if (tmpyao[rui, i] == tmpbazi[3])
                    {
                        ret = GetBaziPower(tmpbazi, 3, tmpyao);
                        ruj = i;
                    }
                }
                if (rui == 7 && tmpyao[0, ruj] != "1")
                {
                    ret = OppEnergy(ret);
                }

                //日支合爻
                tmpsizhi = tmpbazi[5];
                ret = GetBaziPower(tmpbazi, 5, tmpyao);
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合"))
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[5, i]).Contains("合"))
                    {
                        rui = 5;
                        ruj = i;
                    }
                }
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, int.Parse(tmpyao[1, 0])]).Contains("合"))
                {
                    rui = 2;
                    ruj = int.Parse(tmpyao[1, 0]);
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合") && tmpyao[0, i] == "1")
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合"))
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合") && tmpyao[0, i] == "1")
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                //月令入爻
                tmpsizhi = tmpbazi[3];
                ret = GetBaziPower(tmpbazi, 3, tmpyao);
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[2, i] && tmpyao[0, i] == "1")
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[7, i])
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[7, i] && tmpyao[0, i] == "1")
                    {
                        rui = 7;
                        ruj = i;
                    }
                }

                //月令合爻
                tmpsizhi = tmpbazi[3];
                ret = GetBaziPower(tmpbazi, 3, tmpyao);
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合"))
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[5, i]).Contains("合"))
                    {
                        rui = 5;
                        ruj = i;
                    }
                }
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, int.Parse(tmpyao[1, 0])]).Contains("合"))
                {
                    rui = 2;
                    ruj = int.Parse(tmpyao[1, 0]);
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合") && tmpyao[0, i] == "1")
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合"))
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合") && tmpyao[0, i] == "1")
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                //年支入爻
                tmpsizhi = tmpbazi[3];
                ret = GetBaziPower(tmpbazi, 3, tmpyao);
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[2, i])
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[5, i])
                    {
                        rui = 5;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[2, i] && tmpyao[0, i] == "1")
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[7, i])
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (tmpsizhi == tmpyao[7, i] && tmpyao[0, i] == "1")
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                //年支合爻
                tmpsizhi = tmpbazi[3];
                ret = GetBaziPower(tmpbazi, 3, tmpyao);
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合"))
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[5, i]).Contains("合"))
                    {
                        rui = 5;
                        ruj = i;
                    }
                }
                if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, int.Parse(tmpyao[1, 0])]).Contains("合"))
                {
                    rui = 2;
                    ruj = int.Parse(tmpyao[1, 0]);
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[2, i]).Contains("合") && tmpyao[0, i] == "1")
                    {
                        rui = 2;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合"))
                    {
                        rui = 7;
                        ruj = i;
                    }
                }
                for (int i = 1; i <= 6; i++)
                {
                    if (m_dl.GZWuXing(tmpsizhi, tmpyao[7, i]).Contains("合") && tmpyao[0, i] == "1")
                    {
                        rui = 7;
                        ruj = i;
                    }
                }



            } return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpbazi"></param>
        /// <param name="offset"></param>
        /// <param name="yao"></param>
        /// <returns></returns>
        public string GetBaziPower(string[] tmpbazi, int offset, string[,] yao)
        {
            string ret = "";
            //时
            if (offset == 7)
            {
                if (tmpbazi[offset] == tmpbazi[8] || tmpbazi[offset] == tmpbazi[9])
                {
                    ret = "+";
                    return ret;
                }
                if (tmpbazi[offset] == yao[2, int.Parse(yao[1, 0])] || tmpbazi[offset] == yao[5, int.Parse(yao[1, 0])] || tmpbazi[offset] == yao[7, int.Parse(yao[1, 0])])
                {
                    string tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[1], tmpbazi[3]));
                    if (tmpv == "+")
                    {
                        tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[3], tmpbazi[5]));
                    }
                    else
                    {
                        tmpv = OppEnergy(LYLiangHua(m_dl.GZWuXing(tmpbazi[3], tmpbazi[5])));
                    }
                    if (tmpv == "+")
                    {
                        tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[7]));
                    }
                    else
                    {
                        tmpv = OppEnergy(LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[7])));
                    }
                    ret = tmpv;
                }
                else
                {
                    ret = LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[offset]));
                }
            }
            //日
            else if (offset == 5)
            {
                string tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[7], tmpbazi[5]));
                ret = tmpv;
            }
            //月
            else if (offset == 3)
            {
                if (tmpbazi[offset] == yao[2, int.Parse(yao[1, 0])] || tmpbazi[offset] == yao[5, int.Parse(yao[1, 0])] || tmpbazi[offset] == yao[7, int.Parse(yao[1, 0])])
                {
                    string tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[1], tmpbazi[3]));
                    ret = tmpv;
                }
                else
                {
                    string tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[7], tmpbazi[5]));
                    if (tmpv == "+")
                    {
                        tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[3]));
                    }
                    else
                    {
                        tmpv = OppEnergy(LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[3])));
                    }
                    ret = tmpv;
                }
            }
            //年
            else if (offset == 1)
            {
                if (tmpbazi[offset] == tmpbazi[8] || tmpbazi[offset] == tmpbazi[9])
                {
                    ret = "+";
                    return ret;
                }
                string tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[7], tmpbazi[5]));
                if (tmpv == "+")
                {
                    tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[3]));
                }
                else
                {
                    tmpv = OppEnergy(LYLiangHua(m_dl.GZWuXing(tmpbazi[5], tmpbazi[3])));
                }
                if (tmpv == "+")
                {
                    tmpv = LYLiangHua(m_dl.GZWuXing(tmpbazi[3], tmpbazi[1]));
                }
                else
                {
                    tmpv = OppEnergy(LYLiangHua(m_dl.GZWuXing(tmpbazi[3], tmpbazi[1])));
                }
                ret = tmpv;
            }
            return ret;
        }

        public string Exchange(string input)
        {
            string ret = "";
            ret = input.Substring(1, 1) + input.Substring(0, 1);
            return ret;
        }

        #endregion
    }
}