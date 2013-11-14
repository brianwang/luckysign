using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using AppCmn;
using WebMonitor;
using AppMod.Fate;
using AppBll.Fate;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Data;

namespace PPLive.Astro
{
    public class AstroBiz
    {
        private AstroBiz()
        {
        }
        private static AstroBiz _instance;
        public static AstroBiz GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AstroBiz();
            }
            return _instance;
        }

        /// <summary>
        /// 根据命盘实体返回ID
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public string SetGraphicID(AstroMod mod)
        {
            string argument = SetAstrologArgument(mod);
            return argument.Replace(" ", "_").Replace(":", ";");
        }

        /// <summary>
        /// 根据命盘实体返回Astrolog参数
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        private string SetAstrologArgument(AstroMod mod)
        {
            string argument = "";

            if (mod.type == PublicValue.AstroType.benming)
            {
                argument += "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                                mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.position.Lng + " " + mod.position.Lat;
            }
            else if (mod.type == PublicValue.AstroType.hepan)
            {
                mod.composeFile1 = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\C" + CommonTools.GetRandomString(4);
                mod.composeFile2 = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\C" + CommonTools.GetRandomString(4);
                argument += "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                            mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.position.Lng + " " + mod.position.Lat;
                argument += " -o file1";
                argument += "$-qb " + mod.birth1.Month + " " + mod.birth1.Day + " " + mod.birth1.Year + " " +
                        mod.birth1.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight1 + " " + mod.zone1 + " " + mod.position1.Lng + " " + mod.position1.Lat;
                argument += " -o file2";
                if (mod.compose == PublicValue.AstroZuhe.bijiao)
                {
                    argument += "$-r0 file1 file2";
                }
                else if (mod.compose == PublicValue.AstroZuhe.zuhe)
                {
                    argument += "$-rc file1 file2";
                }
                else if (mod.compose == PublicValue.AstroZuhe.shikong)
                {
                    argument += "$-rm file1 file2";
                }
                else if (mod.compose == PublicValue.AstroZuhe.hebing)
                {
                    argument += "$-r file1 file2";
                }
            }
            else if (mod.type == PublicValue.AstroType.tuiyun)
            {
                if (mod.transit == PublicValue.AstroTuiyun.xingyun)
                {
                    mod.composeFile1 = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\C" + CommonTools.GetRandomString(4);
                    mod.composeFile2 = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\C" + CommonTools.GetRandomString(4);
                    argument += "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                            mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.position.Lng + " " + mod.position.Lat;
                    argument += " -o file1";
                    argument += "$-qb " + mod.transitTime.Month + " " + mod.transitTime.Day + " " + mod.transitTime.Year + " " +
                            mod.transitTime.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.transitPosition.Lng + " " + mod.transitPosition.Lat;
                    argument += " -o file2";
                    argument += "$-r0 file1 file2";
                }
                else if (mod.transit == PublicValue.AstroTuiyun.cixian)
                {
                    argument += "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                                mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.position.Lng + " " + mod.position.Lat;
                    argument += " -pd 365.25636 -p " + mod.transitTime.Month + " " + mod.transitTime.Day + " " + mod.transitTime.Year;
                }
                else if (mod.transit == PublicValue.AstroTuiyun.sanxian)
                {
                    argument += "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                                                   mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.position.Lng + " " + mod.position.Lat;
                    argument += " -pd 29.530588 -p " + mod.transitTime.Month + " " + mod.transitTime.Day + " " + mod.transitTime.Year;
                }
                else if (mod.transit == PublicValue.AstroTuiyun.rifanzhao)
                {
                    string file = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\R" + CommonTools.GetRandomString(5);
                    DateTime lastbirth = mod.birth;
                    for (int i = 1; i > 0; i++)
                    {
                        if (lastbirth.AddYears(1) > mod.transitTime)
                        {
                            break;
                        }
                        lastbirth = lastbirth.AddYears(1);
                    }
                    //DateTime tmpbirth = mod.birth.AddHours(-mod.zone);
                    string tmparg = "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                                mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " 0 " + mod.position.Lng + " " + mod.position.Lat;
                    tmparg += " -tY " + lastbirth.AddYears(-1).Year + " 3 -R0 sun -RT0 sun > " + file;
                    RunAstrolog(tmparg);

                    #region 分析文件
                    if (!File.Exists(file))
                    {
                        return null;
                    }
                    StreamReader smRead = new StreamReader(file, System.Text.Encoding.Default);
                    string line;
                    while ((line = smRead.ReadLine()) != null)
                    {
                        if (line.Contains("Solar Return"))
                        {
                            TimeSpan tmp = new DateTime(int.Parse(line.Substring(6,4)),int.Parse(line.Substring(0,2)),int.Parse(line.Substring(3,2)))-
                                lastbirth;
                            if (tmp.Days < 5&& tmp.Days>-5)
                            {
                                break;
                            }
                        }
                    }
                    smRead.Dispose();
                    #endregion

                    DateTime returndate = new DateTime(int.Parse(line.Substring(6, 4)), int.Parse(line.Substring(0, 2)), int.Parse(line.Substring(3, 2)),
                        int.Parse(line.Substring(11, 2)), int.Parse(line.Substring(14, 2)), 0);
                    if (line.Contains("pm"))
                    {
                        returndate = returndate.AddHours(12);
                    }
                    argument += "-qb " + returndate.Month + " " + returndate.Day + " " + returndate.Year + " " +
                            returndate.ToString("HH:mm:ss") + " 0 " + mod.zone + " " + mod.transitPosition.Lng + " " + mod.transitPosition.Lat;
                    File.Delete(file);

                }
                else if (mod.transit == PublicValue.AstroTuiyun.yuefanzhao)
                {
                    string file = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\R" + CommonTools.GetRandomString(5);
                    DateTime lastbirth = mod.birth;
                    for (int i = 1; i > 0; i++)
                    {
                        if (lastbirth.AddYears(1) > mod.transitTime)
                        {
                            break;
                        }
                        lastbirth = lastbirth.AddYears(1);
                    }
                    string tmparg = "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                                mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " 0 " + mod.position.Lng + " " + mod.position.Lat;
                    tmparg += " -tY " + lastbirth.AddYears(-1).Year + " 3 -R0 moon -RT0 moon > " + file;
                    RunAstrolog(tmparg);

                    #region 分析文件
                    if (!File.Exists(file))
                    {
                        return null;
                    }
                    StreamReader smRead = new StreamReader(file, System.Text.Encoding.Default);
                    string line;
                    DateTime returndate = AppConst.DateTimeNull;
                    while ((line = smRead.ReadLine()) != null)
                    {
                        if (line.Contains("Lunar Return"))
                        {
                            if (returndate != AppConst.DateTimeNull && new DateTime(int.Parse(line.Substring(6, 4)), int.Parse(line.Substring(0, 2)), int.Parse(line.Substring(3, 2)),
                                int.Parse(line.Substring(11, 2)), int.Parse(line.Substring(14, 2)), 0) > mod.transitTime)
                            {
                                break;
                            }
                            returndate = new DateTime(int.Parse(line.Substring(6, 4)), int.Parse(line.Substring(0, 2)), int.Parse(line.Substring(3, 2)),
                                int.Parse(line.Substring(11, 2)), int.Parse(line.Substring(14, 2)), 0);
                        }
                    }
                    smRead.Dispose();
                    #endregion

                    if (line.Contains("pm"))
                    {
                        returndate = returndate.AddHours(12);
                    }
                    argument += "-qb " + returndate.Month + " " + returndate.Day + " " + returndate.Year + " " +
                            returndate.ToString("HH:mm:ss") + " 0 " + mod.zone + " " + mod.transitPosition.Lng + " " + mod.transitPosition.Lat;
                    File.Delete(file);
                }
                else if (mod.transit == PublicValue.AstroTuiyun.taiyanghu)
                {
                    argument += "-qb " + mod.birth.Month + " " + mod.birth.Day + " " + mod.birth.Year + " " +
                                                                      mod.birth.ToString("HH:mm:ss") + " " + (int)mod.IsDaylight + " " + mod.zone + " " + mod.position.Lng + " " + mod.position.Lat;
                    argument += " -p0 " + mod.transitTime.Month + " " + mod.transitTime.Day + " " + mod.transitTime.Year;
                }
            }
            
            argument += " -c " + mod.houseSystem;//分宫法
            #region 容许度
            argument += " -YAo 1 5";
            foreach (int key in mod.aspectsShow.Keys)
            {
                argument += " " + mod.aspectsShow[key].ToString("0");
            }
            #endregion
            #region 星体显示
            argument += " -R0";
            foreach (int key in mod.startsShow.Keys)
            {
                argument += " " + key;
            }
            #endregion


            //argument += " -Xr";//反白
            //argument += " -Xw 400 400";//设置输出尺寸

            return argument;
        }

        /// <summary>
        ///  根据ID生成临时图片
        /// </summary>
        /// <param name="GraphicID"></param>
        public void GetGraphic(AstroMod mod)
        {
            if (mod.graphicID == "")
            {
                return;
            }
            string argument = mod.graphicID.Replace("_", " ").Replace(";", ":");

            FATE_AstroMod m_astro = FATE_AstroBll.GetInstance().GetModel(mod.graphicID);
            if (m_astro != null && m_astro.DR == (int)AppEnum.State.normal)
            {
                m_astro.LastTime = DateTime.Now;
                FATE_AstroBll.GetInstance().UpDate(m_astro);
                return;
            }
            string tmpname = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\" + CommonTools.GetRandomString(5);
            argument += " -Xbb -Xo " + tmpname;//输出
            argument += " -o0 " + AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"TextInfo\C" + DateTime.Now.ToString("yyyyMMddHHmmss") + CommonTools.GetRandomString(4);

            argument = argument.Replace("file1", mod.composeFile1);
            argument = argument.Replace("file2", mod.composeFile2);

            try
            {
                string[] args = argument.Split(new char[] { '$' });
                for (int i = 0; i < args.Length; i++)
                {
                    RunAstrolog(args[i]);
                }
                //星盘信息加入数据库
                FATE_AstroMod new_astro = new FATE_AstroMod();
                new_astro.ID = mod.graphicID;
                new_astro.LastTime = DateTime.Now;
                FATE_AstroBll.GetInstance().Add(new_astro);
                //while (!File.Exists(tmpname) || IsUsed(tmpname))
                //{ }

                //处理临时文件
                SetGraphicColor(mod.graphicID, tmpname);

                //删除排盘临时文件
                if (mod.composeFile1 != "")
                {
                    File.Delete(mod.composeFile1);
                }
                if (mod.composeFile2 != "")
                {
                    File.Delete(mod.composeFile2);
                }
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "PPLive.Astro", "");
                return;
            }
        }


        /// <summary>
        ///  根据ID获取星盘参数
        /// </summary>
        /// <param name="GraphicID"></param>
        public void GetParamters(ref AstroMod mod)
        {
            mod.graphicID = SetGraphicID(mod);
            if (mod.graphicID == "")
            {
                return ;
            }
            string argument = mod.graphicID.Replace("_", " ").Replace(";", ":");

            string tmpname = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\" + CommonTools.GetRandomString(5);
            argument += " -o0 " + tmpname;//输出

            argument = argument.Replace("file1", mod.composeFile1);
            argument = argument.Replace("file2", mod.composeFile2);

            try
            {
                string[] args = argument.Split(new char[] { '$' });
                for (int i = 0; i < args.Length; i++)
                {
                    RunAstrolog(args[i]);
                }

                //生成临时参数文件
                SetParas(ref mod, tmpname);

                //删除排盘临时文件
                if (mod.composeFile1 != "")
                {
                    File.Delete(mod.composeFile1);
                }
                if (mod.composeFile2 != "")
                {
                    File.Delete(mod.composeFile2);
                }
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "PPLive.Astro", "");
                return;
            }
        }

        public void RunAstrolog(string argument)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstrologPath()))
            {
                using (Process cmd = new Process())
                {
                    cmd.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstrologPath();

                    //将cmd的标准输入和输出全部重定向到.NET的程序里

                    //cmd.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常

                    //cmd.StartInfo.RedirectStandardInput = true; //标准输入
                    //cmd.StartInfo.RedirectStandardOutput = false; //标准输出
                    cmd.StartInfo.WorkingDirectory = cmd.StartInfo.FileName.Replace("astrolog.exe", "");
                    cmd.StartInfo.Arguments = argument;
                    //不显示命令行窗口界面
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    
                    cmd.Start(); //启动进程
                    cmd.WaitForExit();//等待控制台程序执行完成
                    cmd.Close();//关闭该进程
                    //cmd.Kill();
                }
                return;
            }
            else
            {
                LogManagement.getInstance().WriteException("Astrolog程序文件不存在");
                return;
            }
        }


         /// <summary>
        /// 根据ID处理临时参数文件
        /// </summary>
        /// <param name="GraphicID"></param>
        public void SetParas(ref AstroMod mod, string tmpname)
        {
            if (mod.graphicID == "")
            {
                return;
            }

            string newName = tmpname;
            #region 分析文件
            if (!File.Exists(newName))
            {
                return;
            }
            StreamReader smRead = new StreamReader(newName, System.Text.Encoding.Default);
            string content = "";
            string line;
            while ((line = smRead.ReadLine()) != null)
            {
                content += line;
            }
            smRead.Dispose();
            File.Delete(newName);

            string[] regstr = new string[5];
            string p = @"YF (?<star>[\S]+?):[\s]+?(?<degree>[\S]+?)[\s]+?(?<const>[\S]+?)[\s]+?(?<cent>[\S]+?),[\s]+?[\S]+?[\s]+?[\S]+?,[\s]+?(?<progress>[\S]+?)[\s]+?";
            string varstr = "star|degree|const|cent|progress";
            string[] var = varstr.Split(new char[] { '|' });
            MatchCollection mMCollection = Regex.Matches(content, p, RegexOptions.IgnoreCase);
            if (mMCollection.Count > 1)
            {
                int i = 0;
                foreach (Match m in mMCollection)
                {
                    Astro.Star tmp_star = new Star((int)((PublicValue.AstroStar)Enum.Parse(typeof(PublicValue.AstroStar),
                        m.Groups["star"].Value.Replace("12t", "Twelveth").Replace("11t", "Eleventh").Replace("9","Nin")
                        .Replace("8","Eigh").Replace("6","Six").Replace("5","Fif").Replace("3","Thi").Replace("2","Seco"))));
                    tmp_star.Degree = int.Parse(m.Groups["degree"].Value);
                    tmp_star.Constellation = (PublicValue.Constellation)Enum.Parse(typeof(PublicValue.Constellation), m.Groups["const"].Value);
                    tmp_star.Cent = decimal.Parse(m.Groups["cent"].Value);
                    tmp_star.Progress = decimal.Parse(m.Groups["progress"].Value);
                    mod.Stars[(int)tmp_star.StarName-1] = tmp_star;
                    i++;
                }
            }

            for (int i = 0; i < mod.Stars.Length; i++)
            {
                if(mod.Stars[i]==null)
                {
                    continue;
                }
                if (mod.Stars[i].StarName == PublicValue.AstroStar.Asc)
                {
                    break;
                }
                decimal tmpdegree = Convert.ToDecimal(mod.Stars[i].Degree) + mod.Stars[i].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[i].Constellation * 100));
                bool isgong = false;
                int asc = 20;
                for (int j = 0; j < mod.Stars.Length; j++)
                {
                    try
                    {
                        if (mod.Stars[j]!=null&&mod.Stars[j].StarName == PublicValue.AstroStar.Second)
                        {
                            isgong = true;
                            asc = j - 1;
                        }
                        if (isgong)
                        {

                            if ((tmpdegree <= Convert.ToDecimal(mod.Stars[j].Degree) + mod.Stars[j].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[j].Constellation * 100))) &&
                                (tmpdegree >= Convert.ToDecimal(mod.Stars[j - 1].Degree) + mod.Stars[j - 1].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[j - 1].Constellation * 100))))
                            {
                                mod.Stars[i].Gong = j - asc;
                                break;
                            }
                            else if (Convert.ToDecimal(mod.Stars[j].Degree) + mod.Stars[j].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[j].Constellation * 100)) < Convert.ToDecimal(mod.Stars[j - 1].Degree) + mod.Stars[j - 1].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[j - 1].Constellation * 100))
                                && tmpdegree <= Convert.ToDecimal(mod.Stars[j].Degree) + mod.Stars[j].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[j].Constellation * 100)))
                            {
                                mod.Stars[i].Gong = j - asc;
                                break;
                            }
                            else if ((tmpdegree <= Convert.ToDecimal(mod.Stars[20].Degree) + mod.Stars[20].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[20].Constellation * 100))) &&
                                (tmpdegree >= Convert.ToDecimal(mod.Stars[31].Degree) + mod.Stars[31].Cent / (decimal)100 + Convert.ToDecimal(((int)mod.Stars[31].Constellation * 100))))
                            {
                                mod.Stars[i].Gong = 12;
                                break;
                            }



                        }
                    }
                    catch
                    {
                        mod.Stars[i].Gong = 12;
                        break;
                    }
                }
            }


            #endregion

        }
        /// <summary>
        /// 根据ID处理临时图片
        /// </summary>
        /// <param name="GraphicID"></param>
        public void SetGraphicColor(string GraphicID, string tmpname)
        {
            if (GraphicID == "")
            {
                return;
            }
            string fileName = tmpname;
            string newName = GetGraphicPath(GraphicID);

            Image img = Image.FromFile(fileName);

            Bitmap btm = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g1 = Graphics.FromImage(btm))
            {
                g1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g1.DrawImage(img, 0, 0);
            }

            #region 颜色替换
            //for (int x = 0; x < btm.Width; x++)
            //{
            //    for (int y = 0; y < btm.Height; y++)
            //    {
            //        Color cTmp = btm.GetPixel(x, y);
            //        Color c = ColorTranslator.FromHtml("#ffffff");
            //        if (cTmp.ToArgb() == c.ToArgb())
            //        {
            //            btm.SetPixel(x, y, ColorTranslator.FromHtml("#C0C0C0"));
            //        }
            //    }
            //}
            #endregion

            #region 加水印
            Graphics g = Graphics.FromImage(btm);
            ImageHelper m_img = new ImageHelper();
            m_img.addWatermarkImage(g, AppDomain.CurrentDomain.BaseDirectory + AppConfig.WaterMarkPath, 0, 0, 119, 68);
            #endregion
            btm.Save(newName, ImageFormat.Gif);
            btm.Dispose();
            img.Dispose();
            File.Delete(fileName);
        }

        public string GetGraphicPath(string GraphicID)
        {
            if (GraphicID == AppConst.StringNull)
            {
                return AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"null.gif";
            }
            else
            {
                if (GraphicID.Contains("-r"))
                {
                    return AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Relation\" + GraphicID + ".gif";
                }
                else if (GraphicID.Contains("-t"))
                {
                    return AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Transit\" + GraphicID + ".gif";
                }
                else
                {
                    return AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Single\" + GraphicID + ".gif";
                }
            }
        }


        /// <summary>
        /// 判断文件是否被其他程序占用
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        public bool IsUsed(String fileName)
        {
            bool result = false;

            try
            {
                FileStream fs = File.OpenWrite(fileName);
                fs.Close();
            }
            catch
            {
                result = true;
            }
            return result;
        }

        public string GetFile(string filepath)
        {
            StringBuilder ret = new StringBuilder();
            if (!File.Exists(filepath))
            {
                return null;
            }
            StreamReader smRead = new StreamReader(filepath, System.Text.Encoding.Default);
            string line;
            while ((line = smRead.ReadLine()) != null)
            {
                ret.Append(line);
            }
            smRead.Dispose();
            return ret.ToString();
        }

        public DataSet GetSameFamous(AstroMod m_astro)
        {
 DataSet m_ds = new DataSet();
            using (SQLData data = new SQLData())
            {
                string sql = "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where degree=" + m_astro.Stars[0].Degree + " and Constellation=" + (int)m_astro.Stars[0].Constellation+ " and star=" + (int)PublicValue.AstroStar.Sun + " and IsTop=1;" +
                    "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where degree=" + m_astro.Stars[1].Degree + " and Constellation=" + (int)m_astro.Stars[1].Constellation + " and star=" + (int)PublicValue.AstroStar.Moo + " and IsTop=1;" +
                     "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where degree=" + m_astro.Stars[2].Degree + " and Constellation=" + (int)m_astro.Stars[2].Constellation + " and star=" + (int)PublicValue.AstroStar.Mer + " and IsTop=1;" +
                      "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where degree=" + m_astro.Stars[3].Degree + " and Constellation=" + (int)m_astro.Stars[3].Constellation + " and star=" + (int)PublicValue.AstroStar.Ven + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where degree=" + m_astro.Stars[4].Degree + " and Constellation=" + (int)m_astro.Stars[4].Constellation + " and star=" + (int)PublicValue.AstroStar.Mar + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[0].Gong + " and star=" + (int)PublicValue.AstroStar.Sun + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[1].Gong + " and star=" + (int)PublicValue.AstroStar.Moo + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[2].Gong + " and star=" + (int)PublicValue.AstroStar.Mer + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[3].Gong + " and star=" + (int)PublicValue.AstroStar.Ven + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[4].Gong + " and star=" + (int)PublicValue.AstroStar.Mar + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[5].Gong + " and star=" + (int)PublicValue.AstroStar.Jup + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[6].Gong + " and star=" + (int)PublicValue.AstroStar.Sat + " and IsTop=1;" +
                       "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[7].Gong + " and star=" + (int)PublicValue.AstroStar.Ura + " and IsTop=1;" +
                        "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[8].Gong + " and star=" + (int)PublicValue.AstroStar.Nep + " and IsTop=1;" +
                         "select top 3 Sys_Famous.name,Sys_Famous.sysno from Sys_Famous_AstroStar left join Sys_Famous on Sys_Famous.sysno = famoussysno where gong=" + m_astro.Stars[9].Gong + " and star=" + (int)PublicValue.AstroStar.Plu + " and IsTop=1;";
                try
                {
                    m_ds = data.CmdtoDataSet(sql);
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
                return m_ds;
            }
        }
    }
}
