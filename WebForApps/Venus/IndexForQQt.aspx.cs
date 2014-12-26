using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive;
using PPLive.Astro;
using AppCmn;
using AppBll.WebSys;
using AppMod.Apps;
using AppBll.Apps;

namespace WebForApps.Venus
{
    public partial class IndexForQQt : System.Web.UI.Page
    {
        private string[] contexts = new string[] { "在这个纸醉金迷的拜金时代，你是难得天真的爱情尤物。爱就要轰轰烈烈，物质，现实都是扯淡，爱不需要附加条件，想爱就爱吧！感觉才是最重要，别人的看法你才懒得理。对你来说最大的麻烦是如何在勇敢的时候不去伤及无辜。无论那个他是心有所属还是名花有主，你都不care~ 结果成了小三小四，真是勇气可嘉有待反思！你是爱情里的乐天派，传递正能量，享受甜蜜与激情，烦恼，苦闷统统go out！如果爱情没有了快乐还有神马意思？你最怕恋人让你做这做那，愁眉不展，抱怨不休，你是快乐的天使不是救世主！", "金星入庙金牛座，可谓自家人帮自家人，在挑选对象方面，放心，你绝对不会亏待自己！外型正点，气场强大，关键是要能HOLD的住自己！而害羞的正太，懦弱的大叔则难入你的法眼。名车，豪宅，千万积蓄，更是加分的利器！没饭开锅哪有空来谈情说爱！现实？放心，你一定是的！一旦爱上，便对所爱的人无条件付出，做牛做马！专情稳定也有点迟钝，有时候对方变心了你还摸不着头脑，伤心复原期更是别人的两倍，但最终你会认清现实，咬牙切齿对天发誓：“哼！你算哪根葱？失去我是你的损失！我一定要过得比你好！”", "你从来不乏异性缘，跟人谈情说爱就像跟陌生人说话一样简单，只是关系更深一层而已啦！对待别人的殷勤，你只是想就当交个朋友嘛，却难免被人误会，什么？暧昧？真心没有啦。你对型男靓女实在不是太感冒，美女与野兽的故事反而时常发生。WHY? 双子顾名思义就是两个孩子！你更重视彼此的沟通与交流，经历与陪伴，最好你们可以一起哭一起笑一起疯一起闹，无话不说，亲密无间，好情侣好知己！如果对方见多识广，博学多才，啥事儿都能帮你摆平，那就最能打动你的芳心了！", "“我不想我不想我不想长大！”这就是你了，在爱情中永远拒绝长大的小孩！所以你会钟情年纪较大的另一半，你希望对方把你捧在手心，爱你迁就你，你的任性撒娇，你的有恃无恐，都只是爱中另类的调味品，其实你只是想得到对方全方位的重视罢了。犹如巨蟹始终高举的两个大钳子，其实你是非常胆小和设防的，尤其在恋爱之初，你反而可能因为真心喜欢而掉头逃跑，你更希望对方识破你的不安与慌张，跟你主动告白。提一提，你太过敏感和猜忌，又怕被伤害，so勇敢点吧！", "你有种贵族气质，与其说是你去追求爱人，不如说是你要吸引爱人！你主动出击却又不会轻易表白，不能因为里子丢了面子。如果人一定要空气，那你一定要爱情！而谈这场恋爱，更必须浪漫的要死！而浪漫的程度，就差点不会走过去问别人，能不能拍成《泰坦尼克号》了。你是热烈的恋人，一旦得到爱人的肯定，更会毫不吝啬的释放自己，好像聚光灯下的男（女）主角，show出你的爱。你也会告照天下，你多幸福，你恋爱了！", "正因如此，你常常把自己逼入穷巷，爱的很苦。你总是要求太高又自我感觉太过良好，殊不知梦想很丰满，现实很骨感呀！而失望之后，你又不敢面对，总把责任都推到对方身上，继续期待心中那个理想对象。你总在自我的错误定位和对他人的完美要求中寻找交集，真是别人笑我太疯癫，我笑别人看不穿啊！说到底，不如自己跟自己谈场恋爱好了！如果你不是超级自恋狂，又或者多一点自知之明~ 那绝对是剩男剩女里的抢手货。", "再没有比跟你恋爱更惬意的事情了！你就像是天生的爱情达人，追的巧妙，爱的轻松，断的干脆。你从不吝啬赞美之词，不管是时尚的发型，还是有范儿的搭配，就连细致皮肤看不见的小毛孔，你都不忘赞美一番，你总能发现对方的优点，然后最合时宜的表达出来，让人不知不觉心花怒放。只要不是太麻烦，又或者太过分，你顺得人的好脾气很会包容对方，让每一次的吵架拌嘴和好如初都成为感情的增稠剂，真是很会迁就对方的另一半。为了保持和谐，你宁可做个看似好捏的软柿子，但如果对方一再挑战你的底线，到了一忍再忍忍无可忍的时候，对方通常还没发现问题的严重性，你已经另有新欢了。", "别不好意思，你渴望被爱，传说中的闷骚就是你！表面上风平浪静，内心里波涛汹涌！明明很喜欢却又装作不在意，总是希望那个他会自己发现这个秘密。如果在你犹豫要不要给他短信的时候突然收到他的讯息，这无疑已将你秒杀，纵使老虎也变大猫了！但你爱的越多也要的越多，多疑，猜忌，占有欲，让你成了危险的情人，你太过炙热的爱有时也会把人烧伤。你爱得太深难以割舍，在这个拍拖甩拖都轻而易举的时代，你仍相信爱是恒久坚持，很好，但真的很伤，纵然已经物是人非，你仍留在过去的梦里难以平息，不是不能，而是不愿，不舍！", "对你来说，最大的麻烦是如何不要爱上太多人！天知道什么时候，你就有了爱的感觉，就在回眸一笑间，惊鸿一瞥间，举手投足间！阳光的正太或天真的萝莉，是你的最爱。你主动搭讪，夸张表白，偷袭强吻，却又逃之夭夭，有点玩世不恭，放荡不羁，其实只是想等待对方一个肯定的答案，因为你太怕被拒绝。爱情除了感觉，难道还有责任？爱情最好像风筝，不远不近，若即若离。你很难深入一段感情，就像你无法停止爱上，或许你不爱任何人，只是爱上了爱的感觉。情深不寿，或许只是想掩饰你拒绝长大和内心缺乏的安全感。", "拜托能不能轻松一点，爱也是在理性的时候才会发生。对方的身高体重，年龄学历，家世背景，性格匹配，能力潜质，你都会一一打分，你甚至会把结婚后可能遇到的种种问题都考虑周全，然后才会考虑要不要开始。有没有人跟你说过，你在爱情上面真的少跟筋。你拍拖通常比较迟，因为你总认为拍拖的那个就是结婚的那个，不以结婚为目的的恋爱就是耍流氓！你不想浪费时间在无聊的人身上，所以也钟爱成熟稳重的人，因为对你而言，爱了就要负责任，会为了两人的共同目标不懈努力。说到谈婚论嫁，你实在有种让人买了双保险的安全感！", "你是爱情里的现实主义者，从来不做亏本生意，什么默默付出不计回报的事怎么也不可能发生在你身上。对你而言，不爱你的你不爱，没有回应的爱情多可悲，单恋不是爱。你并非外貌协会，反而更看着对方的内在气质。那种古灵精怪，脱俗独立，见解独到的异性让你最为心动。你的爱情通常发生在青梅竹马时，青春校园里，朝夕工作中，因为你的理性睿智会很快发现别人的缺点，所以很难在第一时间爱上对方，而会在长期的相知相伴中慢慢青眯。你总能游刃有余的捕捉爱情，即使再喜欢，也不会给对方太多压力，然后顺其自然收获爱情。", "你通常很早便对爱情有所憧憬，不管是《人鱼公主》的凄美童话，还是《罗马假日》的浪漫故事，亦或《非诚勿扰》的综艺相亲，都会让你在夜深人静时勾勒出那份属于自己的爱情。所以一旦坠入爱河，你就会无怨无悔的牺牲付出。你时常会说：“如果我爱别人了，你会不会生气？”“如果我们分手了，你还会不会想起我？”你总会想些问些有的没的来考验对方，然后自我感动自我陶醉。对你而言，你爱的就是最好的，你眼里的他总要好过真正的他，要知道幻想也是感情升温的催化剂！往好里说是小梦幻，小天真，往坏里说是小傻瓜，大白痴，被人卖了还帮人数钱，你往往就是传说中被劈腿了到最后才知道的那个人，口中还念念有词：“他不会这样对待我，这都不是真的。。。”上帝保佑，遇到一个真心人吧！" };
        private DateTime expire = DateTime.Now;
        private string oauth2token = "";
        private string openid = "";
        private string openkey = "";
        private string[] titles = new string[] { "金星在白羊座：爱得义无反顾！", "金星在金牛座：我的爱情，天长地久！", "金星在双子座：浪漫就是“在一起”！", "金星在巨蟹座：我要你爱我爱我最爱我！", "金星在狮子座：我要轰轰烈烈爱一次！", "金星在处女座：我要一个完美的情人！", "金星在天秤座：亲密伴侣守护爱情！", "金星在天蝎座：我要！我要！我要你的爱！", "金星在射手座：爱上爱的感觉！", "金星在摩羯座：爱你的责任！", "金星在水瓶座：我的爱人与众不同！", "金星在双鱼座：爱在想象中完美！" };
        private string wb_name = "";
        private string wb_nick = "";

        // Methods
        protected void Button1_Click(object sender, EventArgs e)
        {
            AstroMod mod = new AstroMod
            {
                type = PublicValue.AstroType.benming,
                birth = new DateTime(int.Parse(this.hfYear.Value), int.Parse(this.hfMonth.Value), int.Parse(this.hfDay.Value), int.Parse(this.hfHour.Value), 0, 0),
                position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(0x856)),
                IsDayLight = AppEnum.BOOL.False,
                zone = -8
            };
            for (int i = 1; i < 0x15; i++)
            {
                mod.startsShow.Add(i, "");
            }
            mod.aspectsShow.Clear();
            for (int j = 1; j < 6; j++)
            {
                mod.aspectsShow.Add(j, 5M);
            }
            AstroBiz.GetInstance().GetParamters(ref mod);
            VenusLoveMod model = new VenusLoveMod
            {
                BirthTime = mod.birth,
                Source = 1,
                TS = DateTime.Now,
                UserSysNo = QQWeiBoUserBll.GetInstance().GetRecordByName(this.wb_name).SysNo
            };
            VenusLoveBll.GetInstance().Add(model);
            int constellation = 0;
            foreach (Star star in mod.Stars)
            {
                if (star.StarName == PublicValue.AstroStar.Ven)
                {
                    constellation = (int)star.Constellation;
                    break;
                }
            }
            if (constellation != 0)
            {
                this.ltrTitle.Text = this.titles[constellation - 1];
                this.ltrContext.Text = this.contexts[constellation - 1];
            }
            this.MultiView1.ActiveViewIndex = 1;
            this.ViewState["ele"] = constellation;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            QQWeiBo bo = new QQWeiBo();
            try
            {
                if (bo.AddFriend(this.openid, this.openkey, base.Request.UserHostAddress, "iamsnowsnow", AppEnum.Apps.venus))
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "listen", "alert('收听成功！');", true);
                    this.nofriend1.Style["display"] = "none";
                    this.nofriend2.Style["display"] = "none";
                    this.isfriend1.Style["display"] = "";
                    this.isfriend2.Style["display"] = "";
                }
            }
            catch (Exception)
            {
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            QQWeiBo bo = new QQWeiBo();
            try
            {
                if (bo.SendPicWeiBo(this.openid, this.openkey, base.Request.UserHostAddress, "#金星星座#我刚用了超灵的“金星爱情分析器”。原来我的" + this.titles[((int)this.ViewState["ele"]) - 1] + this.contexts[((int)this.ViewState["ele"]) - 1].Substring(0, 50).Replace("你", "我") + "... 一起来试试吧，点击 http://app.t.qq.com/app/play/801269870 更多占星术知识请收听 @iamsnowsnow", "http://t2.qpic.cn/mblogpic/310462b251813df5ecac/2000", AppEnum.Apps.venus))
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "share", "alert('分享成功！');", true);
                }
            }
            catch
            {
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((base.Request.QueryString["openid"] != null) && (base.Request.QueryString["openid"] != ""))
            {
                this.openid = base.Request.QueryString["openid"];
            }
            if ((base.Request.QueryString["openkey"] != null) && (base.Request.QueryString["openkey"] != ""))
            {
                this.openkey = base.Request.QueryString["openkey"];
            }
            if ((base.Request.QueryString["name"] != null) && (base.Request.QueryString["name"] != ""))
            {
                this.wb_name = base.Request.QueryString["name"];
            }
            if ((base.Request.QueryString["oauth2atoken"] != null) && (base.Request.QueryString["oauth2atoken"] != ""))
            {
                try
                {
                    string[] strArray = base.Request.QueryString["oauth2atoken"].Split(new char[] { '&' });
                    this.oauth2token = strArray[0].Split(new char[] { '=' })[0];
                    this.expire = DateTime.Now.AddSeconds((double)int.Parse(strArray[1].Split(new char[] { '=' })[1]));
                }
                catch
                {
                }
            }
            if ((base.Request.QueryString["nick"] != null) && (base.Request.QueryString["nick"] != ""))
            {
                this.wb_nick = base.Request.QueryString["nick"];
            }
            if (!base.IsPostBack)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int i = 0; i <= 0x17; i++)
                {
                    dictionary.Add(i.ToString(), i.ToString());
                }
                this.ddlHour.DataSource = dictionary;
                this.ddlHour.DataTextField = "Key";
                this.ddlHour.DataValueField = "Value";
                this.ddlHour.DataBind();
                this.ddlHour.SelectedIndex = 12;
                QQWeiBo bo = new QQWeiBo();
                if (this.openid != "")
                {
                    QQWeiBoUserMod recordByName = QQWeiBoUserBll.GetInstance().GetRecordByName(this.wb_name);
                    if (recordByName.SysNo <= 0)
                    {
                        string[] strArray2 = bo.GetUserSimpleInfo(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.venus).Split(new char[] { '|' });
                        recordByName.Oauth2Token = this.oauth2token;
                        recordByName.OpenId = this.openid;
                        recordByName.TS = DateTime.Now;
                        recordByName.WB_Name = this.wb_name;
                        recordByName.WB_Nick = this.wb_nick;
                        recordByName.Location = strArray2[2];
                        recordByName.FansNum = int.Parse(strArray2[3]);
                        recordByName.IsVIP = int.Parse(strArray2[4]);
                        QQWeiBoUserBll.GetInstance().Add(recordByName);
                    }
                    else if ((recordByName.WB_Name == "") || (recordByName.FansNum == -999999))
                    {
                        string[] strArray3 = bo.GetUserSimpleInfo(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.venus).Split(new char[] { '|' });
                        recordByName.WB_Name = this.wb_name;
                        recordByName.WB_Nick = this.wb_nick;
                        recordByName.Location = strArray3[2];
                        recordByName.FansNum = int.Parse(strArray3[3]);
                        recordByName.IsVIP = int.Parse(strArray3[4]);
                        QQWeiBoUserBll.GetInstance().Update(recordByName);
                    }
                }
                if (bo.CheckFriend(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.venus))
                {
                    this.nofriend1.Style["display"] = "none";
                    this.nofriend2.Style["display"] = "none";
                }
                else
                {
                    this.isfriend1.Style["display"] = "none";
                    this.isfriend2.Style["display"] = "none";
                }
            }
        }

    }
}