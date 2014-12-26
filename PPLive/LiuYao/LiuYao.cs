using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace PPLive.LiuYao
{
    /// <summary>
    /// LiuYao 的摘要说明
    /// </summary>
    public class LiuYao
    {
        public LiuYao()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        
        /// <summary>
        /// 输入六位二进制,及动爻,排卦
        /// 卦结构:
        /// 0   1  2  3    4   5     6  7  8   9  
        /// 动  主 主 主   伏  伏    动 动 动  主   
        ///     干 支 爻   干  支    干 支 爻  亲  
       ///0伏吟 世 应 名  主宫 动宫  世 应 名　卦强
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="yao"></param>
        public void BitToYao(bool a,bool b,bool c,bool d,bool e,bool f,ref string [,] yao)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ppconn"].ConnectionString;
            string cmdTexta = "SELECT * FROM Sign_64 WHERE firstbit = " + a + " AND secondbit = " + b + " AND thirdbit = " + c + " AND forthbit = " + d + " AND fifthbit = " + e + " AND sixthbit = " + f;
            

            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand commanda = new OleDbCommand(cmdTexta, conn);
            conn.Open();

            OleDbDataReader myreadera = commanda.ExecuteReader();
            
            myreadera.Read();
            string aaa = myreadera["guahao"].ToString();
            int temp = Int32.Parse(myreadera["guahao"].ToString()); 
            string cmdTextb = "";
            if (temp % 10 == 1)
            {
                bool oa = opp(a);
                bool ob = opp(b);
                bool oc = opp(c);
                bool od = opp(d);
                bool oe = opp(e);
                bool of = opp(f);
                cmdTextb = "SELECT * FROM Sign_64 WHERE firstbit = " + oa + " AND secondbit = " + ob + " AND thirdbit = " + oc + " AND forthbit = " + od + " AND fifthbit = " + oe + " AND sixthbit = " + of ;

            }
            else
            {    
                temp = (temp / 10) * 10 + 1;
                cmdTextb = @"SELECT * FROM Sign_64 WHERE guahao = " + temp.ToString() ;

            }


             for (int i = 1; i <= 6; i++)
            {
                if (yao[0, i] == "1")
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


            string cmdTextc = "SELECT * FROM Sign_64 WHERE firstbit = " + a + " AND secondbit = " + b + " AND thirdbit = " + c + " AND forthbit = " + d + " AND fifthbit = " + e + " AND sixthbit = " + f ;

            
            

           

//主
            yao[1, 1] = myreadera[14].ToString();
            yao[1, 2] = myreadera[15].ToString();
            yao[1, 3] = myreadera[16].ToString();
            yao[1, 4] = myreadera[17].ToString();
            yao[1, 5] = myreadera[18].ToString();
            yao[1, 6] = myreadera[19].ToString();

            yao[2, 1] = myreadera[2].ToString();
            yao[2, 2] = myreadera[3].ToString();
            yao[2, 3] = myreadera[4].ToString();
            yao[2, 4] = myreadera[5].ToString();
            yao[2, 5] = myreadera[6].ToString();
            yao[2, 6] = myreadera[7].ToString();

            yao[3, 1] = myreadera[8].ToString();
            yao[3, 2] = myreadera[9].ToString();
            yao[3, 3] = myreadera[10].ToString();
            yao[3, 4] = myreadera[11].ToString();
            yao[3, 5] = myreadera[12].ToString();
            yao[3, 6] = myreadera[13].ToString();

            yao[1, 0] = myreadera[20].ToString();
            yao[2, 0] = myreadera[21].ToString();
            yao[3, 0] = myreadera[1].ToString();

            yao[9, 1] = myreadera["firstlq"].ToString();
            yao[9, 2] = myreadera["secondlq"].ToString();
            yao[9, 3] = myreadera["thirdlq"].ToString();
            yao[9, 4] = myreadera["forthlq"].ToString();
            yao[9, 5] = myreadera["fifthlq"].ToString();
            yao[9, 6] = myreadera["sixthlq"].ToString();

            yao[9, 0] = myreadera["strong"].ToString();

            temp = Int32.Parse(myreadera[0].ToString());
            temp = temp / 10;
            yao[4, 0] = temp.ToString();

            commanda.Dispose();
            myreadera.Close();
            myreadera.Dispose();
            OleDbCommand commandb = new OleDbCommand(cmdTextb, conn);
            OleDbCommand commandc = new OleDbCommand(cmdTextc, conn);

            OleDbDataReader myreaderc = commandc.ExecuteReader();
            myreaderc.Read();
//动
            yao[6, 1] = myreaderc.GetString(14);
            yao[6, 2] = myreaderc.GetString(15);
            yao[6, 3] = myreaderc.GetString(16);
            yao[6, 4] = myreaderc.GetString(17);
            yao[6, 5] = myreaderc.GetString(18);
            yao[6, 6] = myreaderc.GetString(19);

            yao[7, 1] = myreaderc.GetString(2);
            yao[7, 2] = myreaderc.GetString(3);
            yao[7, 3] = myreaderc.GetString(4);
            yao[7, 4] = myreaderc.GetString(5);
            yao[7, 5] = myreaderc.GetString(6);
            yao[7, 6] = myreaderc.GetString(7);

            yao[8, 1] = myreaderc[8].ToString();
            yao[8, 2] = myreaderc[9].ToString();
            yao[8, 3] = myreaderc[10].ToString();
            yao[8, 4] = myreaderc[11].ToString();
            yao[8, 5] = myreaderc[12].ToString();
            yao[8, 6] = myreaderc[13].ToString();

            yao[6, 0] = myreaderc[20].ToString();
            yao[7, 0] = myreaderc[21].ToString();
            yao[8, 0] = myreaderc[1].ToString();
            temp = Int32.Parse(myreaderc[0].ToString());
            temp = temp / 10;
            yao[5, 0] = temp.ToString();

            commandc.Dispose();
            myreaderc.Close();
            myreaderc.Dispose();

            OleDbDataReader myreaderb = commandb.ExecuteReader(); 
            myreaderb.Read();

//伏
            yao[4, 1] = myreaderb.GetString(14);
            yao[4, 2] = myreaderb.GetString(15);
            yao[4, 3] = myreaderb.GetString(16);
            yao[4, 4] = myreaderb.GetString(17);
            yao[4, 5] = myreaderb.GetString(18);
            yao[4, 6] = myreaderb.GetString(19);

            yao[5, 1] = myreaderb.GetString(2);
            yao[5, 2] = myreaderb.GetString(3);
            yao[5, 3] = myreaderb.GetString(4);
            yao[5, 4] = myreaderb.GetString(5);
            yao[5, 5] = myreaderb.GetString(6);
            yao[5, 6] = myreaderb.GetString(7);

            conn.Close();
            
            conn.Dispose();
            commandb.Dispose();
            
            myreaderb.Close();
            myreaderb.Dispose();
            
        }

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

        public string GetGong(int a)
        {
            a = a / 10;
            string ret = "";
            switch (a)
            {
                case 1:
                    ret = "丑";
                    break;
                case 2:
                    ret = "丑";
                    break;
                case 3:
                    ret = "丑";
                    break;
                case 4:
                    ret = "丑";
                    break;
                case 5:
                    ret = "丑";
                    break;
                case 6:
                    ret = "丑";
                    break;
             
            }
            return ret;
        }

        private string accbool(bool sendin)
    {
        string ret ="";
        if(sendin)
            ret = "-1";
        else
            ret = "0";
        return ret;
    }

        /// <summary>
        /// 数字起卦，设置BOOL，动爻位置
        /// </summary>
        /// <param name="num"></param>
        /// <param name="ret"></param>
        /// <param name="yao"></param>
        public void NumToBool(int num, ref bool [] ret, ref string[,] yao)
        {
            int [] tempnum = new int[6]; 
            tempnum[5] = num%10;
            tempnum[4] = (num/10)%10;
            tempnum[3] = (num/100)%10;
            tempnum[2] = (num/1000)%10;
            tempnum[1] = (num/10000)%10;
            tempnum[0] = (num/100000)%10;
            for(int i = 0;i<=5;i++)
            {
                if(tempnum[i] >= 6)
                    yao[0, i+1] = "1";
                else 
                    yao[0, i+1] = "0";
                if(tempnum[i]%2 == 0)
                    ret [i] = false;
                else 
                    ret [i] = true;
            
            }
           
 
        }

        /// <summary>
        /// 上卦数下卦数起卦，设置BOOL，动爻位置
        /// </summary>
        /// <param name="numa"></param>
        /// <param name="numb"></param>
        /// <param name="ret"></param>
        /// <param name="yao"></param>
        public void NumsToBool(string numa, string numb, ref bool[] ret, ref string[,] yao)
        {
            int temp = 0;
            string temps ="";
            for (int i = 0; i < numa.Length; i++)
            {
                temps = numa.Substring(i, 1);
                if(temps=="1" || temps=="2" || temps=="3" || temps=="4" || temps=="5" || temps=="6" || temps=="7" || temps=="8" || temps=="9" || temps=="0")
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
                    yao[0, i] = "1";
                else
                    yao[0, i] = "0";
            }
            
        }
/// <summary>
/// 
/// </summary>
/// <param name="num">输入数字</param>
/// <param name="updown">上下卦,下为0,上为1</param>
/// <param name="retbool"></param>
/// <returns></returns>
        private void NumsTogua(int num,bool updown,ref bool [] retbool)
        {
            int i = 0;
            if(updown)
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

        public void XuanBaziToYao12(string[] bazi, string num, ref string[,] yao)
        {
            int upnum = 0;int downnum = 0;
            for (int i = 0; i <= 6; i=i+2)
            {
                upnum = upnum + XuanGZToNum(bazi[i].ToString());
                downnum = downnum + XuanGZToNum(bazi[i + 1].ToString());
            }
            int dong = upnum + downnum;
            if (num != "")
            {
                int tempnum = Int32.Parse(num.ToString());
                //tempnum = tempnum % 12;
                upnum = upnum + XuanNumUp12(tempnum,bazi[6]);
                downnum = downnum + XuanNumDown12(tempnum);
                dong = dong + XuanNumUp12(tempnum,bazi[6]) + XuanNumDown12(tempnum);
            }
            
            
            dong = dong % 6;
            if (dong == 0)
                dong = 6;
            upnum = upnum % 8;
            downnum = downnum % 8;
            for (int i = 1; i <= 6; i++)
            {
                if (i == dong)
                    yao[0, i] = "1";
                else
                    yao[0, i] = "0";
            }
            bool[] tempbool = new bool[6];
            NumsTogua(upnum, true, ref tempbool);
            NumsTogua(downnum, false, ref tempbool);
            BitToYao(tempbool[0], tempbool[1], tempbool[2], tempbool[3], tempbool[4], tempbool[5], ref yao);
        }

        private int XuanNumUp12(int num,string shigan)
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

        public void XuanBaziToYao30(string[] bazi, string num, ref string[,] yao)
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
                    yao[0, i] = "1";
                else
                    yao[0, i] = "0";
            }
            bool[] tempbool = new bool[6];
            NumsTogua(upnum, true, ref tempbool);
            NumsTogua(downnum, false, ref tempbool);
            BitToYao(tempbool[0], tempbool[1], tempbool[2], tempbool[3], tempbool[4], tempbool[5], ref yao);
        }

        private int XuanNumUp30(int num, string shigan)
        {
            int ret = 0;
			if(num == 0)
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

    }
}