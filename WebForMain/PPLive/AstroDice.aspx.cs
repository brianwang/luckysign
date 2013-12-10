using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using PPLive;
using System.Data;
using AppBll.QA;
using AppBll.CMS;

namespace WebForMain.PPLive
{
    public partial class AstroDice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLogin();

                LinkButton2.Style["display"] = "none";
                LinkButton3.Style["display"] = "none";
                LinkButton4.Style["display"] = "none";
                Literal1.Text = @"<p><b>提问说明：</b><br />★一定要是你很诚心很想知道的事。问题可以是具体的小事，如今天晚上吃什么；也可以是别人的是，某某明星是不是真的有外遇。<br />
                                  ★不要在短时间内重复问一个问题，除非事态已经有了新的变化。<br />
                                  ★问Whether不如问How，骰子不会简单回答Yes或No。如果问“我该跳槽么？”不如问“如果换工作的话前景如何？”</p>
                                 <p><b>特别提示：</b><br />★占星骰子需消耗灵力，建议一天内不要超过3次，否则会降低准确度。<br />
                                  ★骰子给出的结果需要你对行星，星座和宫位的关键字含义进行意会。<br />
                                  ★如无法理解骰子的结果，可以把问题发出，等待专业占星师解答。</p>";
                LinkButton5.Style["display"] = "none";
                LinkButton6.Style["display"] = "none";

                BindQuest();
                BindArticles();
            }
        }

        private void IsLogin()
        {
            PageBase m_base = new PageBase();
            if (m_base.GetSession().CustomerEntity != null && m_base.GetSession().CustomerEntity.SysNo != AppConst.IntNull)
            {
                ltrLinks.Text = "<a href='/Passport/Login.aspx?type=logout' title='注销'>退出</a>｜<a href='/Qin/View.aspx?id=" + m_base.GetSession().CustomerEntity.SysNo + "' title='我的首页'>我的首页</a>";
                ltrTips.Text = m_base.GetSession().CustomerEntity.NickName + "，欢迎回到上上签";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dice.Value == "10")
                {
                    dice.Value = "15";
                }
                else if (dice.Value == "11")
                {
                    dice.Value = "32";
                }
                int star = int.Parse(dice.Value);
                int house = (0 - int.Parse(gong.Value) / 30 + 4 + 12 - 1) % 12;
                int Constellation = ((360 - ((int.Parse(gong.Value) - 90) - Convert.ToInt16(Math.Floor(decimal.Parse(xingzuo.Value))))) / 30 + 12) % 12;
                LinkButton2.Text = PublicValue.GetAstroStar(star+1);
                LinkButton3.Text = (house+1) + "宫";
                LinkButton4.Text = PublicValue.GetConstellation(Constellation+1);
                LinkButton2.Style["display"] = "";
                LinkButton3.Style["display"] = "";
                LinkButton4.Style["display"] = "";
                LinkButton5.Style["display"] = "";
                LinkButton6.Style["display"] = "";

                dice.Value = star.ToString();
                gong.Value = house.ToString();
                xingzuo.Value = Constellation.ToString();
                LinkButton2_Click(LinkButton2, e);
            }
            catch { }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            switch (((LinkButton)sender).ID)
            {
                case "LinkButton2":
                    if (dice.Value == "15")
                    {
                        dice.Value = "10";
                    }
                    else if (dice.Value == "32")
                    {
                        dice.Value = "11";
                    }
                    Literal1.Text = stars[int.Parse(dice.Value)];
                    LinkButton2.CssClass = "on";
                    LinkButton3.CssClass = "";
                    LinkButton4.CssClass = "";
                    LinkButton5.Enabled = false;
                    LinkButton6.Enabled = true;
                    break;
                case "LinkButton3":
                    Literal1.Text = house[int.Parse(gong.Value)];
                    LinkButton2.CssClass = "";
                    LinkButton3.CssClass = "on";
                    LinkButton4.CssClass = "";
                    LinkButton5.Enabled = true;
                    LinkButton6.Enabled = true;
                    break;
                case "LinkButton4":
                    Literal1.Text = constellation[int.Parse(xingzuo.Value)];
                    LinkButton2.CssClass = "";
                    LinkButton3.CssClass = "";
                    LinkButton4.CssClass = "on";
                    LinkButton5.Enabled = true;
                    LinkButton6.Enabled = false;
                    break;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (gong.Value != "" && dice.Value != "" && xingzuo.Value != "")
            {
                if (dice.Value == "10")
                {
                    dice.Value = "15";
                }
                else if (dice.Value == "11")
                {
                    dice.Value = "32";
                }
                Response.Redirect("../Quest/Ask.aspx?type=dice&star=" + (int.Parse(dice.Value)) +
                    "&house=" + int.Parse(gong.Value) +
                    "&const=" + int.Parse(xingzuo.Value) + "&ask=" + flashtitle.Value);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),"noquest","alert('请占卜后再将结果发问！');",true);
            }
        }

        #region content
        private string[] stars = {@"<p>太阳<br />
<b>重视：</b>受到众人的瞩目，声势大，吸引别人的目光，被赏识，让别人感到快乐，涉及工作，事业时，代表受到领导提携。<br />
<b>原则：</b>原则性强，有棱角，不妥协，不肯降低标准，高要求。</p>",
                                 @"<p>月亮<br />
<b>依赖：</b>离不开，有归属感，倾诉，涉及情感问题时，通常意味着一方能满足另一方的需求。</p>",
                                 @"<p>水星<br />
<b>交流：</b>彼此之间的信息交换。<br />
<b>行动：</b>有步骤，计划周密，一步一步的去实施，有目标。</p>",
                                 @"<p>金星<br />
<b>自如：</b>自信，有底气，不受外界影响，内心强大。<br />
<b>妥协：</b>宽容，接纳对方，涉及感情问题，意味着双方能够包容彼此。<br />
<b>幽默：</b>没有紧张情绪，轻松自在，开玩笑，缺少严肃认真。</p>",
                                 @"<p>火星<br />
<b>对抗：</b>针锋相对，互不妥协，对对方观点的不认同。<br />
<b>着急：</b>没有头绪，完不成任务，感到急躁。<br />
<b>自私：</b>为自己考虑，不关心别人的事情。<br />
<b>草率：</b>先做后想，准备的不充分。</p>",
                                 @"<p>木星<br />
<b>单纯：</b>想得少，不在乎，没有感觉，天真无邪。<br />
<b>顺利：</b>没有阻力，发展顺利，没有负担。<br />
<b>坚持：</b>有强烈的信念，贯彻自己的想法，继续过去的状态。</p>",
                                 @"<p>土星<br />
<b>压力：</b>感觉到紧张，担心做不好，渴望证明自己，事关重大。<br />
<b>距离感：</b>涉及两个人关系问题时，通常意味着不亲密，有隔阂，无法关心彼此。<br />
<b>厌恶：</b>不喜欢，感受不到乐趣，厌烦。<br />
<b>实际：</b>注重成果，注重眼前利益，务实，能够灵活转变立场。</p>",
                                 @"<p>天王星<br />
<b>操纵：</b>认为参与，刻意为之，当涉及事情的原因问题的时候，代表了有人在背后控制，使用手段。<br />
<b>固执：</b>抱有自己的想法，无法被改变，主观。<br />
<b>友善：</b>不起冲突，维持表面上的和谐，善待别人。<br />
<b>分离：</b>断绝来往，不说话，沟通不畅，用主观的成见揣测对方。涉及感情问题时，通常代表了一段关系的结束，分手。</p>",
                                 @"<p>海王星<br />
<b>迷茫：</b>看不清方向，不知道未来，没有实际规划，心里没底，涉及感情问题时，意味着没有结果，或短期之间看不到结果。<br />
<b>欺骗：</b>隐瞒，有保留，掩盖真相。<br />
<b>伤痛：</b>过去的伤疤，不想提起的事情，长期的隐痛。<br />
<b>落空：</b>无法实现，或者不能百分之百的实现，与期望有落差。</p>",
                                 @"<p>冥王星<br />
<b>不满情绪：</b>内心中一直积蓄压抑着的不满，涉及两个人关系的时候，通常意味着对另一方所作所为的不满意。<br />
<b>质疑：</b>有疑虑，不信任。<br />
<b>不屑：</b>轻视，对现状不满。</p>",
                                 @"<p>北交点<br />
<b>提前：</b>事情进展提前，过程顺利。<br />
<b>认可：</b>喜欢，心态积极。<br />
<b>好意：</b>抱有善良的目的，态度端正，心无杂念，奉献，品性纯良。</p>",
                                 @"<p>南交点<br />
<b>推迟：</b>事情进展延期，不顺利，过程有阻碍。<br />
<b>不认可：</b>不喜欢，违背自己的意愿。<br />
<b>恶意：</b>不怀好意，态度不端正，另有目的，自私，贪婪，虚伪。</p>"};
        private string[] constellation = { @"<p>白羊座<br />
<b>实现：</b>意愿强烈，实践自想法己的，勇敢去做，走出去，行动，涉及行动问题时，通常意味着积极的答案。<br />
<b>快乐：</b>心情愉快，寻找快乐，相安无事，不被打扰。<br />
<b>对立：</b>自我，立场强硬，不喜欢被别人左右。<br />
<b>秩序：</b>维护规则，保持秩序，没有被打乱。<br />
<b>软弱：</b>与强则弱，稚嫩，不得不妥协，后劲不足。</p>", 
                                         @"<p>金牛座<br />
<b>稳定：</b>有规律的行为或生活习惯，不退缩，克服困难，不受外界影响。<br />
<b>自信：</b>盛气凌人，指导别人，自我感觉好，胸有成竹，泰然自若。<br />
<b>舒适：</b>物质享受，舒服，奢华。<br />
<b>炫耀：</b>展示自我，富贵之气。</p>",
                                         @"<p>双子座<br />
<b>变化：</b>变动大，新鲜体验，有趣，吸引，涉及感情问题时，意味着浅层关系，不牢固。<br />
<b>吸纳：</b>从外界学习，吸收别人观点，模仿，复制，博采众长，听取别人意见，整合资源。<br />
<b>表达：</b>聊得来，沟通顺畅，提出诉求，话多的，闲言碎语。<br />
<b>理性：</b>不感情用事，有客观依据，冷静，思考成熟。<br />
<b>卓越：</b>表现出色，满足众人期望，达到别人的标准，鹤立鸡群，脱颖而出。<br />
<b>迎合：</b>失去自我，迎合他人要求，顾全大局。</p>",
                                         @"<p>巨蟹座<br />
<b>任性：</b>感情用事，不理智，强势，不应去做而非要做。<br />
<b>放纵：</b>过度，没有节制，要得更多，过多的满足了欲望。<br />
<b>新奇：</b>追求刺激，不甘于平淡，新鲜好玩。<br />
<b>骄傲：</b>渴望被重视，渴望成为焦点，容易引起争议。<br />
<b>讨好：</b>向别人示好，关怀别人，拍马屁。</p>",
                                         @"<p>狮子座<br />
<b>固执：</b>原则性强，不肯妥协，不听劝告，强迫别人，强硬。<br />
<b>分享：</b>慷慨，对别人好，让别人开心，分享自己的成果，分享自己的快乐。<br />
<b>气势：</b>声势浩大，引人瞩目，受到关注。<br />
<b>神秘：</b>捉摸不定，留有余地，不知道结果，保持神秘感和吸引力，跌宕起伏，峰回路转。</p>",
                                         @"<p>处女座<br />
<b>自恋：</b>美化自我，自我陶醉，心理承受能力强。<br />
<b>细致：</b>细小，琐碎，关注细节。<br />
<b>奉献：</b>兑现承诺，完成别人交给的任务。<br />
<b>艰苦：</b>辛苦的努力，忍辱负重。<br />
<b>自我：</b>特立独行，不在乎别人看法。<br />
<b>圆满：</b>准备充分，没有遗漏。</p>",
                                         @"<p>天秤座<br />
<b>包容：</b>容忍对方的缺点，涉及感情问题是，意味着相处愉快，拥有长期稳定的关系。<br />
<b>理解：</b>站在对方立场上考虑，心中明白，懂得。<br />
<b>退让：</b>不强势，退缩，以退为进，不发生正面冲突。<br />
<b>谅解：</b>消除分歧，言归于好，修复关系。<br />
<b>轻松：</b>不费力，让别人开心，没有压力，付出最小的代价。<br />
<b>逃避：</b>不想承担责任，不想付出。<br />
<b>刻意：</b>虚伪，假装，虚情假意，油嘴滑舌，当面一套背面一套。</p>",
                                         @"<p>天蝎座<br />
<b>欲望：</b>意愿强烈，不择手段，野心勃勃，克服阻力。<br />
<b>敏锐：</b>抓住机会，洞察力，抓住漏洞。<br />
<b>沉迷：</b>执着，不顾一切，不顾后果。<br />
<b>魅力：</b>表面难以亲近，诱惑，吸引力。</p>",
                                         @"<p>射手座<br />
<b>粗心：</b>疏忽大意，丢三落四，马虎。<br />
<b>单纯：</b>没有心机，欠缺考虑，失言，信任别人，欣赏别人，没有防备。<br />
<b>机遇：</b>看到机会，看到趋势，敢于冒险。<br />
<b>自由：</b>不负责任，害怕压力，逃避危险。<br />
<b>荣誉：</b>保持完美，受人崇拜，被信任。</p>",
                                         @"<p>摩羯座<br />
<b>权威：</b>努力进取，证明自己，创造价值，得到认可，要求权力。<br />
<b>责任：</b>家长心态，提携他人，肩负责任。<br />
<b>尊重：</b>希望相互尊重，平等相待。</p>",
                                         @"<p>水瓶座<br />
<b>圆滑：</b>潜移默化，不正面冲突，暗中影响，逐步引导。<br />
<b>功利：</b>以自己的目的为导向，求回报，计较利益，一步到位，完成目标。<br />
<b>妥帖：</b>周到，不半途而废，完成，没有遗漏。</p>",
                                         @"<p>双鱼座<br />
<b>灵感：</b>想法很多，缺乏落实，天马行空的创意。<br />
<b>美化：</b>愿望美好，充满憧憬，不顾现实，缺少理性判断。<br />
<b>可怜：</b>受伤，受害者心理，悲观。<br />
<b>奉献：</b>感化别人，不计回报的付出，不计较得失。</p>"};
        private string[] house = { @"<p>第一宫<br />
<b>自我：</b>坚定的主观立场，不受外界影响而动摇，当涉及人与人的关系的问题时，通常表现出自我保留和对抗性。<br />
<b>天分：</b>天才和潜能的发挥，当涉及一个人在工作，考试等活动中的表现的问题时，通常是较好的结果，甚至是超水平的表现。<br />
<b>议价：</b>商业活动中的讨价还价，人与人意志之间相互说服，征服的过程。<br />
<b>流言：</b>小道消息，绯闻传言。<br />
<b>性格魅力：</b>当涉及一个人是怎么样的问题时，通常代表了这个人具有个性魅力。</p>",
                                 @"<p>第二宫<br />
<b>金钱：</b>劳动创造的物质财富，在金钱上面获得好的结果，与金钱有关的行业或社会活动，比如银行，财会等。<br />
<b>机器：</b>可以运转的，替人工作服务的机器，包括电器，汽车，手机，电脑等的有效的运转工作。<br />
<b>占有欲：</b>对私人财产或感情的占有欲。<br />
<b>奢侈品：</b>高标准的生活品质，物质享受，外在的打扮，富丽堂皇，珠光宝气的感觉。<br />
<b>经营：</b>实体商业的经营，通常意味着事业可以开业，有收入，经营良好。</p>",
                                 @"<p>第三宫<br />
<b>客观规律：</b>不被人主观意志左右的客观规律，不可逆转的客观状况。<br />
<b>科学：</b>数学以及物理，化学，生物等自然科学。<br />
<b>创新：</b>有新意的想法，科学技术上面的发明创新。<br />
<b>智力游戏：</b>棋牌类的智力游戏，或是智商类的测验。<br />
<b>自然：</b>大自然的景色风光，地理状况。<br />
<b>旅游：</b>旅游，探险，航海等等。<br />
<b>搬家：</b>居住地点的变迁。<br />
<b>文字：</b>文字作品，使用文字，和文字相关的工作。<br />
<b>交流：</b>语言表达，或者靠说话进行的工作，培训，讲师，销售等等。<br />
<b>亲戚：</b>表兄妹，叔叔姑姑等非直系亲属。</p>",
                                 @"<p>第四宫<br />
<b>父母：</b>父母双亲及已亲生的兄弟姐妹。<br />
<b>家庭：</b>家庭的温暖，居家生活，家庭中的问题，家族的支持。<br />
<b>故乡：</b>涉及到迁徙，搬家，外出等事物的问题时，通常意味着保持不动，待在原地点。</p>",
                                 @"<p>第五宫<br />
<b>子女：</b>子女的教育，或者和子女相关的事物，怀孕等。<br />
<b>娱乐：</b>休闲娱乐，有趣的体验，涉及学习，工作等问题时，通常代表没有集中精力，时间的荒废或准备不足。<br />
<b>收藏：</b>古董，字画，玉器等的收藏。<br />
<b>赌博：</b>靠运气赢得胜利或利益的事情。<br />
<b>爱情：</b>激情，心动，浪漫，甜蜜的爱情。<br />
<b>偶然事物：</b>局面的不确定性，偶然的差池，涉及问题的成因时，通常意味着莫名其妙的疏忽或横生枝节。</p>",
                                 @"<p>第六宫<br />
<b>健康：</b>医疗，养生，美容等与身体相关的事物。<br />
<b>服务：</b>对别人的照顾，服务，听从别人的吩咐。<br />
<b>承诺：</b>答应别人所做的事情，涉及感情问题时，通常代表承诺和稳定性。<br />
<b>工作：</b>工作上的关系，或者通过工作结实的，身上肩负的责任，压力，辛苦的努力。</p>",
                                 @"<p>第七宫<br />
<b>伴侣：</b>在一起的相伴和守候，涉及感情问题时，通常代表非常好的结果或者难以割舍，不会分开。<br />
<b>合作：</b>非常有利于合作经营。<br />
<b>贵人：</b>有贵人相助，依靠关系，受到提携。</p>",
                                 @"<p>第八宫<br />
<b>失败：</b>一切事情的失败，或者合作关系的破裂。<br />
<b>性：</b>两性关系，以性为目的，肉体的欲望。<br />
<b>魅力：</b>迷人的魅力。<br />
<b>交易：</b>通过交换条件达到目的。<br />
<b>背叛：</b>受到朋友，合作伙伴或者亲近人员的背叛，涉及感情问题时，通常意味着出轨或第三者。<br />
<b>疾病：</b>身体患病，不健康。<br />
<b>意外：</b>受伤，流血，意外事故。</p>",
                                 @"<p>第九宫<br />
<b>异地：</b>远距离的迁徙，涉及感情问题时，通常意味着异地恋。<br />
<b>国外：</b>出国旅游，签证顺利，或者与国外相关的事物。<br />
<b>文化：</b>一个人的学时，修养，受到的教育，或者和文化相关的事物，培训行业等。<br />
<b>信仰：</b>宗教及已对宗教的虔诚，心灵的净化。<br />
<b>过去：</b>过去发生的事情，老朋友。</p>",
                                 @"<p>第十宫<br />
<b>权威：</b>一个领域中的专家，或者征询专家的意见，涉及健康问题时，通常意味着遵守医嘱。<br />
<b>事业：</b>社会地位，个人奋斗。</p>",
                                 @"<p>第十一宫<br />
<b>朋友：</b>融入集体，来自朋友的帮助，和朋友一起游玩。<br />
<b>信息：</b>有价值的信息，内幕消息，新闻。<br />
<b>炒股：</b>证券投资的成功。</p>",
                                 @"<p>第十二宫<br />
<b>幻想：</b>头脑中的想法，灵感，但也意味着不切实际，当涉及到事情的成败问题时，通常意味着和理想的落差，看不清未来。<br />
<b>犯罪：</b>暗中进行的触犯法律或者不道德的行为。<br />
<b>欺骗：</b>秘密，不公开透明，涉及感情问题时，通常意味着有所隐瞒，或者地下情。</p>"};

        #endregion

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            switch (((LinkButton)sender).ID)
            {
                case "LinkButton5":
                    if (LinkButton2.CssClass == "on")
                    {

                    }
                    else if (LinkButton3.CssClass == "on")
                    {
                        LinkButton2_Click(LinkButton2, e);
                    }
                    else if (LinkButton4.CssClass == "on")
                    {
                        LinkButton2_Click(LinkButton3, e);
                    }
                    break;
                case "LinkButton6":
                    if (LinkButton2.CssClass == "on")
                    {
                        LinkButton2_Click(LinkButton3, e);
                    }
                    else if (LinkButton3.CssClass == "on")
                    {
                        LinkButton2_Click(LinkButton4, e);
                    }
                    else if (LinkButton4.CssClass == "on")
                    {

                    }
                    break;
            }
        }

        protected void BindQuest()
        {
            int total = 0;
            DataTable dt = new DataTable();
            if (HttpRuntime.Cache[AppConst.AstroDiceNewAnswer] == null)
            {
                dt = QA_QuestionBll.GetInstance().GetList(7, 1, "", 7, "replytimedown", ref total);
                dt.Columns.Add("Reply");
                int tmptotal = 0;
                DataTable tmpdt = new DataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Reply"] = QA_AnswerBll.GetInstance().GetListByQuest(1, 1, int.Parse(dt.Rows[i]["SysNo"].ToString()), ref tmptotal).Rows[0]["Context"].ToString();
                }
                HttpRuntime.Cache.Insert(AppConst.AstroDiceNewAnswer, dt,
                 null, DateTime.Now.AddMinutes(5), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt = HttpRuntime.Cache[AppConst.AstroDiceNewAnswer] as DataTable;
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            DataTable dt1 = new DataTable();
            if (HttpRuntime.Cache[AppConst.AstroDiceNewQuest] == null)
            {
                dt1 = QA_QuestionBll.GetInstance().GetList(12, 1, "", 7, "timedown", ref total); dt1.Columns.Add("IsNew");
                HttpRuntime.Cache.Insert(AppConst.AstroDiceNewQuest, dt1,
                 null, DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt1 = HttpRuntime.Cache[AppConst.AstroDiceNewQuest] as DataTable;
            Repeater2.DataSource = dt1;
            Repeater2.DataBind();
        }
        
        
        protected void BindArticles()
        {
            int total = 0;
            DataTable dt = new DataTable();
            if (HttpRuntime.Cache[AppConst.AstroDiceAricle] == null)
            {
                dt = CMS_ArticleBll.GetInstance().GetList(8, 1, "", 30, 0, ref total);
                HttpRuntime.Cache.Insert(AppConst.AstroDiceAricle, dt,
                 null, DateTime.Now.AddMinutes(10), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt = HttpRuntime.Cache[AppConst.AstroDiceAricle] as DataTable;
            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }
    }
}