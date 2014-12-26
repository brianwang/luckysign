using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppCmn;
using System.Xml;
using AppBll.Apps;
using AppMod.Apps;
using PPLive;

namespace WebForApps.AstroDice
{
    public partial class IndexForQQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string content = "#占星骰子# #" + Literal1.Text + "# “" + flashtitle.Value + "”，求占卜师解答！";
            //string[] tmp = HiddenField1.Value.Split(new char[] { '|' });
            //for (int i = 0; i < tmp.Length; i++)
            //{
            //    if (tmp[i] != "")
            //    {
            //        content += " @" + tmp[i];
            //    }
            //}
            //content += " 亲们也来试试吧！";
            //string content = TextBox1.Text.Split(new char[] { '@' })[0] + "@iamsnowsnow @linda7862 @shenrry776 @susan1114 @god82953378";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "share", "document.forms[0].target='_blank';WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('Button3', '', false, '', 'http://share.v.t.qq.com/index.php?c=share&a=index&url=" + Server.UrlEncode("http://app.t.qq.com/app/play/801272340") +
            //    "&pic=" + Server.UrlEncode("http://app.ssqian.com/WebResources/DicePic/" + filename.Value + ".jpg") + "&appkey=801402959&title=" + Server.UrlEncode(TextBox1.Text.Trim()) + "&line1=&line2=&line3=', false, false));document.forms[0].action= document.location.href;", true);
        }

        protected void BindData()
        {
            IndexForQQt m_qqt = new IndexForQQt();
            DataTable m_dt = m_qqt.GetReplys(Request.UserHostAddress);
            int index = 0x3;
            if (m_dt != null)
            {
                while (m_dt.Rows.Count > index)
                {
                    m_dt.Rows.RemoveAt(index);
                }
                Repeater2.DataSource = m_dt;
                Repeater2.DataBind();
            }
            //DataTable m_dt1 = m_qqt.GetTopic(Request.UserHostAddress);
            //while (m_dt1.Rows.Count > index)
            //{
            //    m_dt1.Rows.RemoveAt(index);
            //}
            //Repeater1.DataSource = m_dt1;
            //Repeater1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                AstroDiceMod model = new AstroDiceMod
                {
                    House = ((((-(int.Parse(this.gong.Value) / 30) + 4) + 12) - 1) % 12) + 1,
                    Constellation = ((((360 - ((int.Parse(this.gong.Value) - 90) - Convert.ToInt16(Math.Floor(decimal.Parse(this.xingzuo.Value))))) / 30) + 12) % 12) + 1,
                    Question = this.flashtitle.Value
                };
                Literal2.Text = stars[int.Parse(this.dice.Value)] + "<br />";
                if (this.dice.Value == "10")
                {
                    this.dice.Value = "15";
                }
                else if (this.dice.Value == "11")
                {
                    this.dice.Value = "32";
                }
                model.Star = int.Parse(this.dice.Value) + 1;
                this.ViewState["Pic"] = model.Pic;
                AstroDiceBll.GetInstance().Add(model);
                this.dice.Value = model.Star.ToString();
                this.gong.Value = model.House.ToString();
                this.xingzuo.Value = model.Constellation.ToString();
                Literal1.Text = PublicValue.GetAstroStar(model.Star) + "  " + model.House + "宫  " + PublicValue.GetConstellation(model.Constellation);

                
                Literal2.Text += house[model.House-1]+ "<br />";
                Literal2.Text += constellation[model.Constellation-1];

                string content = "#占星骰子# #" + Literal1.Text + "# “" + flashtitle.Value + "”，求占卜师解答！";
                //string[] tmp = HiddenField1.Value.Split(new char[] { '|' });
                //for (int i = 0; i < tmp.Length; i++)
                //{
                //    if (tmp[i] != "")
                //    {
                //        content += " @" + tmp[i];
                //    }
                //}
                content += " @蓝雪鳳兒 @青花 @一然 @采薇 @山有扶苏 @黄小鞋";
                TextBox1.Text = content;

                Button1.PostBackUrl = "http://share.v.t.qq.com/index.php?c=share&a=index&url=" + Server.UrlEncode("http://astro.fashion.qq.com/app/astrodice.htm") +
                    "&pic=" + Server.UrlEncode("http://app.ssqian.com/WebResources/DicePic/" + filename.Value + ".jpg") + "&appkey=801402959&title=" + Server.UrlEncode(content.Replace("@蓝雪鳳兒 @青花 @一然 @采薇 @山有扶苏 @黄小鞋", "@iamsnowsnow @bubuzhanxing @yiraneasy @susan1114 @god82953378 @yellowlittleshoes") + " 好玩好准的占星骰子，亲们也来试试：") + "&line1=&line2=&line3=";
            
            }
            catch
            {
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string content = TextBox1.Text;
                Button1.PostBackUrl = "http://share.v.t.qq.com/index.php?c=share&a=index&url=" + Server.UrlEncode("http://astro.fashion.qq.com/app/astrodice.htm") +
                        "&pic=" + Server.UrlEncode("http://app.ssqian.com/WebResources/DicePic/" + filename.Value + ".jpg") + "&appkey=801402959&title=" + Server.UrlEncode(content.Replace("@蓝雪鳳兒 @青花 @一然 @采薇 @山有扶苏 @黄小鞋", "@iamsnowsnow @bubuzhanxing @yiraneasy @susan1114 @god82953378 @yellowlittleshoes") + " 好玩好准的占星骰子，亲们也来试试：") + "&line1=&line2=&line3=";
            }
            catch { }
        }

        #region 解释

        private string[] constellation = new string[] { 
            "白羊座：实现，快乐，对立，秩序，软弱", 
            "金牛座：稳定，自信，舒适，炫耀",
            "双子座：变化，吸纳，表达，理性，卓越", //，迎合
            "巨蟹座：任性，放纵，新奇，骄傲，讨好", 
            "狮子座：固执，分享，气势，神秘", 
            "处女座：自恋，细致，奉献，艰苦，自我",//，圆满 
            "天秤座：包容，理解，退让，谅解，轻松",//，逃避，刻意 
            "天蝎座：欲望，敏锐，沉迷，魅力", 
            "射手座：粗心，单纯，机遇，自由，荣誉", 
            "摩羯座：权威，责任，尊重",
            "水瓶座：圆滑，功利，妥帖", 
            "双鱼座：灵感，美化，可怜，奉献" };
        private string[] house = new string[] { 
            "第一宫：自我，天分，议价，流言，性格魅力", 
            "第二宫：金钱，机器，占有欲，奢侈品，经营", 
            "第三宫：客观规律，科学，创新，智力游戏，自然，旅游，搬家，文字，交流，亲戚", 
            "第四宫：父母，家庭，故乡", 
            "第五宫：子女，娱乐，收藏，赌博，爱情，偶然事物", 
            "第六宫：健康，服务，承诺，工作", 
            "第七宫：伴侣，合作，贵人", 
            "第八宫：失败，性，魅力，交易，背叛，疾病，意外",
            "第九宫：异地，国外，文化，信仰，过去", 
            "第十宫：权威，事业", 
            "第十一宫：朋友，信息，炒股",
            "第十二宫：幻想，犯罪，欺骗" };
        private string[] stars = new string[] { 
            "太阳：重视，原则", 
            "月亮：依赖", 
            "水星：交流，行动", 
            "金星：自如，妥协，幽默", 
            "火星：对抗，着急，自私，草率", 
            "木星：单纯，顺利，坚持", 
            "土星：压力，距离感，厌恶，实际", 
            "天王星：操纵，固执，友善，分离", 
            "海王星：迷茫，欺骗，伤痛，落空", 
            "冥王星：不满情绪，质疑，不屑", 
            "北交点：提前，认可，好意", 
            "南交点：推迟，不认可，恶意" };
        

        #endregion

    }
}