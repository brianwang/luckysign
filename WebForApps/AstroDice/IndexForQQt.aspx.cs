using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.Apps;
using AppBll.Apps;
using AppCmn;
using PPLive;
using System.Data;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web.Caching;

namespace WebForApps.AstroDice
{
    public partial class IndexForQQt : System.Web.UI.Page
    {
        private string[] constellation = new string[] { "<p>白羊座<br />\r\n<b>实现：</b>意愿强烈，实践自想法己的，勇敢去做，走出去，行动，涉及行动问题时，通常意味着积极的答案。<br />\r\n<b>快乐：</b>心情愉快，寻找快乐，相安无事，不被打扰。<br />\r\n<b>对立：</b>自我，立场强硬，不喜欢被别人左右。<br />\r\n<b>秩序：</b>维护规则，保持秩序，没有被打乱。<br />\r\n<b>软弱：</b>与强则弱，稚嫩，不得不妥协，后劲不足。</p>", "<p>金牛座<br />\r\n<b>稳定：</b>有规律的行为或生活习惯，不退缩，克服困难，不受外界影响。<br />\r\n<b>自信：</b>盛气凌人，指导别人，自我感觉好，胸有成竹，泰然自若。<br />\r\n<b>舒适：</b>物质享受，舒服，奢华。<br />\r\n<b>炫耀：</b>展示自我，富贵之气。</p>", "<p>双子座<br />\r\n<b>变化：</b>变动大，新鲜体验，有趣，吸引，涉及感情问题时，意味着浅层关系，不牢固。<br />\r\n<b>吸纳：</b>从外界学习，吸收别人观点，模仿，复制，博采众长，听取别人意见，整合资源。<br />\r\n<b>表达：</b>聊得来，沟通顺畅，提出诉求，话多的，闲言碎语。<br />\r\n<b>理性：</b>不感情用事，有客观依据，冷静，思考成熟。<br />\r\n<b>卓越：</b>表现出色，满足众人期望，达到别人的标准，鹤立鸡群，脱颖而出。<br />\r\n<b>迎合：</b>失去自我，迎合他人要求，顾全大局。</p>", "<p>巨蟹座<br />\r\n<b>任性：</b>感情用事，不理智，强势，不应去做而非要做。<br />\r\n<b>放纵：</b>过度，没有节制，要得更多，过多的满足了欲望。<br />\r\n<b>新奇：</b>追求刺激，不甘于平淡，新鲜好玩。<br />\r\n<b>骄傲：</b>渴望被重视，渴望成为焦点，容易引起争议。<br />\r\n<b>讨好：</b>向别人示好，关怀别人，拍马屁。</p>", "<p>狮子座<br />\r\n<b>固执：</b>原则性强，不肯妥协，不听劝告，强迫别人，强硬。<br />\r\n<b>分享：</b>慷慨，对别人好，让别人开心，分享自己的成果，分享自己的快乐。<br />\r\n<b>气势：</b>声势浩大，引人瞩目，受到关注。<br />\r\n<b>神秘：</b>捉摸不定，留有余地，不知道结果，保持神秘感和吸引力，跌宕起伏，峰回路转。</p>", "<p>处女座<br />\r\n<b>自恋：</b>美化自我，自我陶醉，心理承受能力强。<br />\r\n<b>细致：</b>细小，琐碎，关注细节。<br />\r\n<b>奉献：</b>兑现承诺，完成别人交给的任务。<br />\r\n<b>艰苦：</b>辛苦的努力，忍辱负重。<br />\r\n<b>自我：</b>特立独行，不在乎别人看法。<br />\r\n<b>圆满：</b>准备充分，没有遗漏。</p>", "<p>天秤座<br />\r\n<b>包容：</b>容忍对方的缺点，涉及感情问题是，意味着相处愉快，拥有长期稳定的关系。<br />\r\n<b>理解：</b>站在对方立场上考虑，心中明白，懂得。<br />\r\n<b>退让：</b>不强势，退缩，以退为进，不发生正面冲突。<br />\r\n<b>谅解：</b>消除分歧，言归于好，修复关系。<br />\r\n<b>轻松：</b>不费力，让别人开心，没有压力，付出最小的代价。<br />\r\n<b>逃避：</b>不想承担责任，不想付出。<br />\r\n<b>刻意：</b>虚伪，假装，虚情假意，油嘴滑舌，当面一套背面一套。</p>", "<p>天蝎座<br />\r\n<b>欲望：</b>意愿强烈，不择手段，野心勃勃，克服阻力。<br />\r\n<b>敏锐：</b>抓住机会，洞察力，抓住漏洞。<br />\r\n<b>沉迷：</b>执着，不顾一切，不顾后果。<br />\r\n<b>魅力：</b>表面难以亲近，诱惑，吸引力。</p>", "<p>射手座<br />\r\n<b>粗心：</b>疏忽大意，丢三落四，马虎。<br />\r\n<b>单纯：</b>没有心机，欠缺考虑，失言，信任别人，欣赏别人，没有防备。<br />\r\n<b>机遇：</b>看到机会，看到趋势，敢于冒险。<br />\r\n<b>自由：</b>不负责任，害怕压力，逃避危险。<br />\r\n<b>荣誉：</b>保持完美，受人崇拜，被信任。</p>", "<p>摩羯座<br />\r\n<b>权威：</b>努力进取，证明自己，创造价值，得到认可，要求权力。<br />\r\n<b>责任：</b>家长心态，提携他人，肩负责任。<br />\r\n<b>尊重：</b>希望相互尊重，平等相待。</p>", "<p>水瓶座<br />\r\n<b>圆滑：</b>潜移默化，不正面冲突，暗中影响，逐步引导。<br />\r\n<b>功利：</b>以自己的目的为导向，求回报，计较利益，一步到位，完成目标。<br />\r\n<b>妥帖：</b>周到，不半途而废，完成，没有遗漏。</p>", "<p>双鱼座<br />\r\n<b>灵感：</b>想法很多，缺乏落实，天马行空的创意。<br />\r\n<b>美化：</b>愿望美好，充满憧憬，不顾现实，缺少理性判断。<br />\r\n<b>可怜：</b>受伤，受害者心理，悲观。<br />\r\n<b>奉献：</b>感化别人，不计回报的付出，不计较得失。</p>" };
        private DateTime expire = DateTime.Now;
        private string[] house = new string[] { "<p>第一宫<br />\r\n<b>自我：</b>坚定的主观立场，不受外界影响而动摇，当涉及人与人的关系的问题时，通常表现出自我保留和对抗性。<br />\r\n<b>天分：</b>天才和潜能的发挥，当涉及一个人在工作，考试等活动中的表现的问题时，通常是较好的结果，甚至是超水平的表现。<br />\r\n<b>议价：</b>商业活动中的讨价还价，人与人意志之间相互说服，征服的过程。<br />\r\n<b>流言：</b>小道消息，绯闻传言。<br />\r\n<b>性格魅力：</b>当涉及一个人是怎么样的问题时，通常代表了这个人具有个性魅力。</p>", "<p>第二宫<br />\r\n<b>金钱：</b>劳动创造的物质财富，在金钱上面获得好的结果，与金钱有关的行业或社会活动，比如银行，财会等。<br />\r\n<b>机器：</b>可以运转的，替人工作服务的机器，包括电器，汽车，手机，电脑等的有效的运转工作。<br />\r\n<b>占有欲：</b>对私人财产或感情的占有欲。<br />\r\n<b>奢侈品：</b>高标准的生活品质，物质享受，外在的打扮，富丽堂皇，珠光宝气的感觉。<br />\r\n<b>经营：</b>实体商业的经营，通常意味着事业可以开业，有收入，经营良好。</p>", "<p>第三宫<br />\r\n<b>客观规律：</b>不被人主观意志左右的客观规律，不可逆转的客观状况。<br />\r\n<b>科学：</b>数学以及物理，化学，生物等自然科学。<br />\r\n<b>创新：</b>有新意的想法，科学技术上面的发明创新。<br />\r\n<b>智力游戏：</b>棋牌类的智力游戏，或是智商类的测验。<br />\r\n<b>自然：</b>大自然的景色风光，地理状况。<br />\r\n<b>旅游：</b>旅游，探险，航海等等。<br />\r\n<b>搬家：</b>居住地点的变迁。<br />\r\n<b>文字：</b>文字作品，使用文字，和文字相关的工作。<br />\r\n<b>交流：</b>语言表达，或者靠说话进行的工作，培训，讲师，销售等等。<br />\r\n<b>亲戚：</b>表兄妹，叔叔姑姑等非直系亲属。</p>", "<p>第四宫<br />\r\n<b>父母：</b>父母双亲及已亲生的兄弟姐妹。<br />\r\n<b>家庭：</b>家庭的温暖，居家生活，家庭中的问题，家族的支持。<br />\r\n<b>故乡：</b>涉及到迁徙，搬家，外出等事物的问题时，通常意味着保持不动，待在原地点。</p>", "<p>第五宫<br />\r\n<b>子女：</b>子女的教育，或者和子女相关的事物，怀孕等。<br />\r\n<b>娱乐：</b>休闲娱乐，有趣的体验，涉及学习，工作等问题时，通常代表没有集中精力，时间的荒废或准备不足。<br />\r\n<b>收藏：</b>古董，字画，玉器等的收藏。<br />\r\n<b>赌博：</b>靠运气赢得胜利或利益的事情。<br />\r\n<b>爱情：</b>激情，心动，浪漫，甜蜜的爱情。<br />\r\n<b>偶然事物：</b>局面的不确定性，偶然的差池，涉及问题的成因时，通常意味着莫名其妙的疏忽或横生枝节。</p>", "<p>第六宫<br />\r\n<b>健康：</b>医疗，养生，美容等与身体相关的事物。<br />\r\n<b>服务：</b>对别人的照顾，服务，听从别人的吩咐。<br />\r\n<b>承诺：</b>答应别人所做的事情，涉及感情问题时，通常代表承诺和稳定性。<br />\r\n<b>工作：</b>工作上的关系，或者通过工作结实的，身上肩负的责任，压力，辛苦的努力。</p>", "<p>第七宫<br />\r\n<b>伴侣：</b>在一起的相伴和守候，涉及感情问题时，通常代表非常好的结果或者难以割舍，不会分开。<br />\r\n<b>合作：</b>非常有利于合作经营。<br />\r\n<b>贵人：</b>有贵人相助，依靠关系，受到提携。</p>", "<p>第八宫<br />\r\n<b>失败：</b>一切事情的失败，或者合作关系的破裂。<br />\r\n<b>性：</b>两性关系，以性为目的，肉体的欲望。<br />\r\n<b>魅力：</b>迷人的魅力。<br />\r\n<b>交易：</b>通过交换条件达到目的。<br />\r\n<b>背叛：</b>受到朋友，合作伙伴或者亲近人员的背叛，涉及感情问题时，通常意味着出轨或第三者。<br />\r\n<b>疾病：</b>身体患病，不健康。<br />\r\n<b>意外：</b>受伤，流血，意外事故。</p>", "<p>第九宫<br />\r\n<b>异地：</b>远距离的迁徙，涉及感情问题时，通常意味着异地恋。<br />\r\n<b>国外：</b>出国旅游，签证顺利，或者与国外相关的事物。<br />\r\n<b>文化：</b>一个人的学时，修养，受到的教育，或者和文化相关的事物，培训行业等。<br />\r\n<b>信仰：</b>宗教及已对宗教的虔诚，心灵的净化。<br />\r\n<b>过去：</b>过去发生的事情，老朋友。</p>", "<p>第十宫<br />\r\n<b>权威：</b>一个领域中的专家，或者征询专家的意见，涉及健康问题时，通常意味着遵守医嘱。<br />\r\n<b>事业：</b>社会地位，个人奋斗。</p>", "<p>第十一宫<br />\r\n<b>朋友：</b>融入集体，来自朋友的帮助，和朋友一起游玩。<br />\r\n<b>信息：</b>有价值的信息，内幕消息，新闻。<br />\r\n<b>炒股：</b>证券投资的成功。</p>", "<p>第十二宫<br />\r\n<b>幻想：</b>头脑中的想法，灵感，但也意味着不切实际，当涉及到事情的成败问题时，通常意味着和理想的落差，看不清未来。<br />\r\n<b>犯罪：</b>暗中进行的触犯法律或者不道德的行为。<br />\r\n<b>欺骗：</b>秘密，不公开透明，涉及感情问题时，通常意味着有所隐瞒，或者地下情。</p>" };
        private string oauth2token = "";
        private string openid = "";
        private string openkey = "";
        private string[] stars = new string[] { "<p>太阳<br />\r\n<b>重视：</b>受到众人的瞩目，声势大，吸引别人的目光，被赏识，让别人感到快乐，涉及工作，事业时，代表受到领导提携。<br />\r\n<b>原则：</b>原则性强，有棱角，不妥协，不肯降低标准，高要求。</p>", "<p>月亮<br />\r\n<b>依赖：</b>离不开，有归属感，倾诉，涉及情感问题时，通常意味着一方能满足另一方的需求。</p>", "<p>水星<br />\r\n<b>交流：</b>彼此之间的信息交换。<br />\r\n<b>行动：</b>有步骤，计划周密，一步一步的去实施，有目标。</p>", "<p>金星<br />\r\n<b>自如：</b>自信，有底气，不受外界影响，内心强大。<br />\r\n<b>妥协：</b>宽容，接纳对方，涉及感情问题，意味着双方能够包容彼此。<br />\r\n<b>幽默：</b>没有紧张情绪，轻松自在，开玩笑，缺少严肃认真。</p>", "<p>火星<br />\r\n<b>对抗：</b>针锋相对，互不妥协，对对方观点的不认同。<br />\r\n<b>着急：</b>没有头绪，完不成任务，感到急躁。<br />\r\n<b>自私：</b>为自己考虑，不关心别人的事情。<br />\r\n<b>草率：</b>先做后想，准备的不充分。</p>", "<p>木星<br />\r\n<b>单纯：</b>想得少，不在乎，没有感觉，天真无邪。<br />\r\n<b>顺利：</b>没有阻力，发展顺利，没有负担。<br />\r\n<b>坚持：</b>有强烈的信念，贯彻自己的想法，继续过去的状态。</p>", "<p>土星<br />\r\n<b>压力：</b>感觉到紧张，担心做不好，渴望证明自己，事关重大。<br />\r\n<b>距离感：</b>涉及两个人关系问题时，通常意味着不亲密，有隔阂，无法关心彼此。<br />\r\n<b>厌恶：</b>不喜欢，感受不到乐趣，厌烦。<br />\r\n<b>实际：</b>注重成果，注重眼前利益，务实，能够灵活转变立场。</p>", "<p>天王星<br />\r\n<b>操纵：</b>认为参与，刻意为之，当涉及事情的原因问题的时候，代表了有人在背后控制，使用手段。<br />\r\n<b>固执：</b>抱有自己的想法，无法被改变，主观。<br />\r\n<b>友善：</b>不起冲突，维持表面上的和谐，善待别人。<br />\r\n<b>分离：</b>断绝来往，不说话，沟通不畅，用主观的成见揣测对方。涉及感情问题时，通常代表了一段关系的结束，分手。</p>", "<p>海王星<br />\r\n<b>迷茫：</b>看不清方向，不知道未来，没有实际规划，心里没底，涉及感情问题时，意味着没有结果，或短期之间看不到结果。<br />\r\n<b>欺骗：</b>隐瞒，有保留，掩盖真相。<br />\r\n<b>伤痛：</b>过去的伤疤，不想提起的事情，长期的隐痛。<br />\r\n<b>落空：</b>无法实现，或者不能百分之百的实现，与期望有落差。</p>", "<p>冥王星<br />\r\n<b>不满情绪：</b>内心中一直积蓄压抑着的不满，涉及两个人关系的时候，通常意味着对另一方所作所为的不满意。<br />\r\n<b>质疑：</b>有疑虑，不信任。<br />\r\n<b>不屑：</b>轻视，对现状不满。</p>", "<p>北交点<br />\r\n<b>提前：</b>事情进展提前，过程顺利。<br />\r\n<b>认可：</b>喜欢，心态积极。<br />\r\n<b>好意：</b>抱有善良的目的，态度端正，心无杂念，奉献，品性纯良。</p>", "<p>南交点<br />\r\n<b>推迟：</b>事情进展延期，不顺利，过程有阻碍。<br />\r\n<b>不认可：</b>不喜欢，违背自己的意愿。<br />\r\n<b>恶意：</b>不怀好意，态度不端正，另有目的，自私，贪婪，虚伪。</p>" };
        private string wb_name = "";
        private string wb_nick = "";
        private static DataTable Quests;
        private static DataTable Replys;

        // Methods
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                AstroDiceMod model = new AstroDiceMod
                {
                    House = ((((-(int.Parse(this.gong.Value) / 30) + 4) + 12) - 1) % 12) + 1,
                    Constellation = ((((360 - ((int.Parse(this.gong.Value) - 90) - Convert.ToInt16(Math.Floor(decimal.Parse(this.xingzuo.Value))))) / 30) + 12) % 12) + 1,
                    Question = this.flashtitle.Value
                };
                if (this.dice.Value == "10")
                {
                    this.dice.Value = "15";
                }
                else if (this.dice.Value == "11")
                {
                    this.dice.Value = "32";
                }
                model.Star = int.Parse(this.dice.Value) + 1;
                model.TS = DateTime.Now;
                model.UserSysNo = QQWeiBoUserBll.GetInstance().GetRecordByName(this.wb_name).SysNo;
                model.Source = 1;
                model.Pic = "";
                this.ViewState["Pic"] = model.Pic;
                AstroDiceBll.GetInstance().Add(model);
                this.LinkButton8.Text = PublicValue.GetAstroStar(model.Star) + "  ";
                this.LinkButton9.Text = model.House + "宫  ";
                this.LinkButton10.Text = PublicValue.GetConstellation(model.Constellation);
                this.LinkButton8.Style["display"] = "";
                this.LinkButton9.Style["display"] = "";
                this.LinkButton10.Style["display"] = "";
                this.dice.Value = model.Star.ToString();
                this.gong.Value = model.House.ToString();
                this.xingzuo.Value = model.Constellation.ToString();
                this.LinkButton8_Click(this.LinkButton8, e);
                this.TextBox1.Text = string.Concat(new object[] { "#占星骰子# #", PublicValue.GetAstroStar(model.Star), " ", model.House, "宫 ", PublicValue.GetConstellation(model.Constellation), "# “", model.Question, "”，求占卜师解答！亲们也来试试吧！ http://app.t.qq.com/app/play/801272340" });
            }
            catch
            {
            }
        }

        protected string GetFace(string input)
        {
            string[] strArray = "惊讶,撇嘴,色,发呆,得意,流泪,害羞,闭嘴,睡,大哭,尴尬,发怒,调皮,呲牙,微笑,难过,酷,非典,抓狂,吐,偷笑,可爱,白眼,傲慢,饥饿,困,惊恐,流汗,憨笑,大兵,奋斗,咒骂,疑问,嘘...,晕,折磨,衰,骷髅,敲打,再见,闪人,发抖,爱情,跳跳,找,美眉,猪头,小狗,钱,拥抱,灯泡,酒杯,音乐,蛋糕,闪电,炸弹,刀,足球,猫咪,便便,咖啡,饭,女,玫瑰,凋谢,男,爱心,心碎,药丸,礼物,吻,会议,电话,时间,太阳,月亮,强,弱,握手,胜利,邮件,电视,多多,美女,汉良,飞吻,怄火,毛毛,Q仔,西瓜,白酒,汽水,下雨,多云,雪人,星星,冷汗,擦汗,抠鼻,鼓掌,糗大了,坏笑,左哼哼,右哼哼,哈欠,鄙视,委屈,快哭了,阴险,亲亲,吓,可怜,菜刀,啤酒,篮球,乒乓,示爱,瓢虫,抱拳,勾引,拳头,差劲,爱你,NO,OK,转圈,磕头,回头,跳绳,挥手,激动,街舞,献吻,左太极,右太极,喜糖,红包".Split(new char[] { ',' });
            string str = strArray[0];
            int index = 0;
            int length = strArray.Length;
            while (index < length)
            {
                str = strArray[index];
                int num3 = index;
                switch (num3)
                {
                    case 0x87:
                        num3 = 150;
                        break;

                    case 0x88:
                        num3 = 0x97;
                        break;
                }
                if (input.IndexOf("/" + str) > -1)
                {
                    input = Regex.Replace(input, @"\/" + str, string.Concat(new object[] { "<img src=\"http://mat1.gtimg.com/www/mb/images/face/", num3, ".gif\" title=\"", str, "\" class=\"weibo_emotion\"/>" }));
                }
                index++;
            }
            return input;
        }

        public DataTable GetReplys(string address)
        {
            QQWeiBo bo = new QQWeiBo();
            if (HttpRuntime.Cache["AstroDiceLastReply"] == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("QuestID");
                table.Columns.Add("ReplyID");
                table.Columns.Add("QuestContent");
                table.Columns.Add("ReplyContent");
                table.Columns.Add("QuestUserID");
                table.Columns.Add("ReplyUserID");
                table.Columns.Add("QuestUserName");
                table.Columns.Add("ReplyUserName");
                table.Columns.Add("QuestPhoto");
                table.Columns.Add("ReplyPhoto");
                table.Columns.Add("QuestTime");
                table.Columns.Add("ReplyTime");
                string[] strArray = new string[] { "sd59922490", "iamsnowsnow", "jimbeam123", "zhuyusuifeng@163.com", "god82953378", "bubuzhanxing", "yiraneasy", "susan1114" };
                foreach (string str in strArray)
                {
                    if (address == null || address == "")
                        address = base.Request.UserHostAddress;
                    XmlDocument document = bo.GetUserWeiBoList(this.openid, this.openkey, address, str, 3, AppEnum.Apps.astrodice);
                    XmlNode node = document.SelectSingleNode("//root");
                    if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                    {
                        XmlNodeList list = document.SelectNodes("//data/info");
                        if (list.Count > 0)
                        {
                            foreach (XmlNode node2 in list)
                            {
                                XmlNode node3 = node2.SelectSingleNode("source/from");
                                if ((node3 != null) && (node3.InnerXml == "超级占星骰子"|| node2.SelectSingleNode("source/origtext").InnerXml.Contains("#占星骰子# #")))
                                {
                                    DataRow row = table.NewRow();
                                    row["QuestID"] = node2.SelectSingleNode("source/id").InnerXml;
                                    row["ReplyID"] = node2.SelectSingleNode("id").InnerXml;
                                    row["QuestContent"] = this.GetFace(node2.SelectSingleNode("source/origtext").InnerXml);
                                    row["ReplyContent"] = this.GetFace(node2.SelectSingleNode("origtext").InnerXml);
                                    row["QuestUserID"] = node2.SelectSingleNode("source/name").InnerXml;
                                    row["ReplyUserID"] = node2.SelectSingleNode("name").InnerXml;
                                    row["QuestUserName"] = node2.SelectSingleNode("source/nick").InnerXml;
                                    row["ReplyUserName"] = node2.SelectSingleNode("nick").InnerXml;
                                    row["QuestPhoto"] = node2.SelectSingleNode("source/head").InnerXml;
                                    row["ReplyPhoto"] = node2.SelectSingleNode("head").InnerXml;
                                    row["QuestTime"] = node2.SelectSingleNode("source/timestamp").InnerXml;
                                    row["ReplyTime"] = node2.SelectSingleNode("timestamp").InnerXml;
                                    if (!row["ReplyContent"].ToString().Contains("||") && !row["ReplyContent"].ToString().Contains("@"))
                                    {
                                        int pos = -1;
                                        for (int i = 0; i < table.Rows.Count; i++)
                                        {
                                            if (long.Parse(table.Rows[i]["ReplyTime"].ToString()) < long.Parse(row["ReplyTime"].ToString()))
                                            {
                                                pos = i;
                                                break;
                                            }
                                        }
                                        if (pos == -1)
                                        {
                                            table.Rows.Add(row);
                                        }
                                        else
                                        {
                                            table.Rows.InsertAt(row, pos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                int index = 0x19;
                while (table.Rows.Count > 0x19)
                {
                    table.Rows.RemoveAt(index);
                }
                HttpRuntime.Cache.Insert("AstroDiceLastReply", table, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero, CacheItemPriority.High, null);
                if (table != null && table.Rows.Count > 0)
                {
                    Replys = table.Copy();
                }
            }
            return Replys;
        }

        public DataTable GetTopic(string address)
        {
            QQWeiBo bo = new QQWeiBo();
            if (HttpRuntime.Cache["AstroDiceTopic"] == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("QuestID");
                table.Columns.Add("QuestContent");
                table.Columns.Add("QuestUserID");
                table.Columns.Add("QuestUserName");
                table.Columns.Add("QuestPhoto");
                table.Columns.Add("QuestTime");
                if (address == null || address == "")
                    address = base.Request.UserHostAddress;
                XmlDocument document = bo.GetTopicList(this.openid, this.openkey, address, "占星骰子", 0, AppEnum.Apps.astrodice);
                    XmlNode node = document.SelectSingleNode("//root");
                    if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                    {
                        XmlNodeList list = document.SelectNodes("//data/info");
                        if (list.Count > 0)
                        {
                            foreach (XmlNode node2 in list)
                            {
                                XmlNode node3 = node2.SelectSingleNode("origtext");
                                if (node3.InnerXml.Contains("# #"))
                                {
                                    DataRow row = table.NewRow();
                                    row["QuestID"] = node2.SelectSingleNode("id").InnerXml;
                                    row["QuestContent"] = this.GetFace(node2.SelectSingleNode("origtext").InnerXml);
                                    row["QuestUserID"] = node2.SelectSingleNode("name").InnerXml;
                                    row["QuestUserName"] = node2.SelectSingleNode("nick").InnerXml;
                                    row["QuestPhoto"] = node2.SelectSingleNode("head").InnerXml;
                                    row["QuestTime"] = node2.SelectSingleNode("timestamp").InnerXml;
                                    if (row["QuestPhoto"].ToString() != "")
                                    {
                                        table.Rows.Add(row);
                                    }
                                }
                            }
                        }
                    }
                
                int index = 0x19;
                while (table.Rows.Count > 0x19)
                {
                    table.Rows.RemoveAt(index);
                }
                HttpRuntime.Cache.Insert("AstroDiceTopic", table, null, DateTime.Now.AddMinutes(5.0), TimeSpan.Zero, CacheItemPriority.High, null);
                if (table != null && table.Rows.Count > 0)
                {
                    Quests = table.Copy();
                }
            }
            return Quests;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            QQWeiBo bo = new QQWeiBo();
            try
            {
                if ((this.oauth2token == "") ? bo.AddFriend(this.openid, this.openkey, base.Request.UserHostAddress, "iamsnowsnow", AppEnum.Apps.astrodice) : bo.AddFriend(this.openid, this.oauth2token, base.Request.UserHostAddress, "iamsnowsnow", AppEnum.Apps.astrodice, true))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "listen", "alert('收听成功！');", true);
                    this.nofriend1.Style["display"] = "none";
                    this.isfriend1.Style["display"] = "";
                }
            }
            catch (Exception)
            {
            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 1;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            QQWeiBo bo = new QQWeiBo();
            try
            {
                if (bo.SendPicWeiBo(this.openid, this.openkey, base.Request.UserHostAddress, this.TextBox1.Text + " 更多占星术知识请收听 @iamsnowsnow", "http://t2.qpic.cn/mblogpic/b45699c516c2a873185c/460", AppEnum.Apps.astrodice))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "share", "alert('发布成功！请留意该条微博的转播与评论，占卜师可能会为你解答哦！');", true);
                }
                if (!this.TextBox1.Text.Contains("请输入您要占卜的问题") && !(this.TextBox1.Text.Trim() == ""))
                {
                }
            }
            catch
            {
            }
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            string iD = ((Button)sender).ID;
            if (iD != null)
            {
                if (!(iD == "LinkButton8"))
                {
                    if (!(iD == "LinkButton9"))
                    {
                        if (iD == "LinkButton10")
                        {
                            this.Label1.Text = this.constellation[int.Parse(this.xingzuo.Value) - 1] + "<br />\r\n<p style='color:#fffd64;font-sizi:12px;'>若需购买占星骰子实物，请在淘宝搜索“超级占星骰子”</ br>报名参加专业占星骰子课程请联系蓝雪鳳兒</p>";
                            this.LinkButton8.CssClass = "element";
                            this.LinkButton9.CssClass = "element";
                            this.LinkButton10.CssClass = "element on";
                        }
                        return;
                    }
                }
                else
                {
                    if (this.dice.Value == "15")
                    {
                        this.dice.Value = "11";
                    }
                    else if (this.dice.Value == "32")
                    {
                        this.dice.Value = "12";
                    }
                    this.Label1.Text = this.stars[int.Parse(this.dice.Value) - 1] + "<br />\r\n<p style='color:#fffd64;font-sizi:12px;'>若需购买占星骰子实物，请在淘宝搜索“超级占星骰子”<br/>报名参加专业占星骰子课程请联系蓝雪鳳兒</p>";
                    this.LinkButton8.CssClass = "element on";
                    this.LinkButton9.CssClass = "element";
                    this.LinkButton10.CssClass = "element";
                    return;
                }
                this.Label1.Text = this.house[int.Parse(this.gong.Value) - 1] + "<br />\r\n<p style='color:#fffd64;font-sizi:12px;'>若需购买占星骰子实物，请在淘宝搜索“超级占星骰子”<br/>报名参加专业占星骰子课程请联系蓝雪鳳兒</p>";
                this.LinkButton8.CssClass = "element";
                this.LinkButton9.CssClass = "element on";
                this.LinkButton10.CssClass = "element";
            }
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
                this.MultiView1.ActiveViewIndex = 0;
                QQWeiBo bo = new QQWeiBo();
                QQWeiBoUserMod recordByName = QQWeiBoUserBll.GetInstance().GetRecordByName(this.wb_name);
                if (this.openid != "")
                {
                    if (recordByName.SysNo <= 0)
                    {
                        string[] strArray2 = (this.oauth2token == "") ? bo.GetUserSimpleInfo(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.astrodice).Split(new char[] { '|' }) : bo.GetUserSimpleInfo(this.openid, this.oauth2token, base.Request.UserHostAddress, AppEnum.Apps.astrodice, true).Split(new char[] { '|' });
                        recordByName.Oauth2Token1 = this.oauth2token;
                        recordByName.OpenId1 = this.openid;
                        recordByName.Expire1 = this.expire;
                        recordByName.WB_Name = this.wb_name;
                        recordByName.WB_Nick = this.wb_nick;
                        recordByName.TS = DateTime.Now;
                        recordByName.Location = strArray2[2];
                        recordByName.FansNum = int.Parse(strArray2[3]);
                        recordByName.IsVIP = int.Parse(strArray2[4]);
                        QQWeiBoUserBll.GetInstance().Add(recordByName);
                        this.ViewState["userpara"] = strArray2;
                    }
                    else if ((recordByName.WB_Name == "") || (recordByName.FansNum == -999999))
                    {
                        string[] strArray3 = (this.oauth2token == "") ? bo.GetUserSimpleInfo(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.astrodice).Split(new char[] { '|' }) : bo.GetUserSimpleInfo(this.openid, this.oauth2token, base.Request.UserHostAddress, AppEnum.Apps.astrodice, true).Split(new char[] { '|' });
                        recordByName.Oauth2Token1 = this.oauth2token;
                        recordByName.OpenId1 = this.openid;
                        recordByName.Expire1 = this.expire;
                        recordByName.WB_Name = this.wb_name;
                        recordByName.WB_Nick = this.wb_nick;
                        recordByName.Location = strArray3[2];
                        recordByName.FansNum = int.Parse(strArray3[3]);
                        recordByName.IsVIP = int.Parse(strArray3[4]);
                        QQWeiBoUserBll.GetInstance().Update(recordByName);
                        this.ViewState["userpara"] = strArray3;
                    }
                    else
                    {
                        string[] strArray4 = (this.oauth2token == "") ? bo.GetUserSimpleInfo(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.astrodice).Split(new char[] { '|' }) : bo.GetUserSimpleInfo(this.openid, this.oauth2token, base.Request.UserHostAddress, AppEnum.Apps.astrodice, true).Split(new char[] { '|' });
                        this.ViewState["userpara"] = strArray4;
                    }
                }
                this.ViewState["weibouser"] = recordByName;
                if ((this.oauth2token == "") ? bo.CheckFriend(this.openid, this.openkey, base.Request.UserHostAddress, AppEnum.Apps.astrodice) : bo.CheckFriend(this.openid, this.oauth2token, base.Request.UserHostAddress, AppEnum.Apps.astrodice, true))
                {
                    this.nofriend1.Style["display"] = "none";
                }
                else
                {
                    this.isfriend1.Style["display"] = "none";
                }
                this.LinkButton8.Style["display"] = "none";
                this.LinkButton9.Style["display"] = "none";
                this.LinkButton10.Style["display"] = "none";
                this.Label1.Text = "<p><b>提问说明：</b><br />★一定要是你很诚心很想知道的事。问题可以是具体的小事，如今天晚上吃什么；也可以是别人的是，某某明星是不是真的有外遇。<br />\r\n                                  ★不要在短时间内重复问一个问题，除非事态已经有了新的变化。<br />\r\n                                  ★问Whether不如问How，骰子不会简单回答Yes或No。如果问“我该跳槽么？”不如问“如果换工作的话前景如何？”</p>\r\n                                 <p><b>特别提示：</b><br />★占星骰子需消耗灵力，建议一天内不要超过3次，否则会降低准确度。<br />\r\n                                  ★骰子给出的结果需要你对行星，星座和宫位的关键字含义进行意会。<br />\r\n                                  ★如无法理解骰子的结果，可以把问题发出，等待专业占星师解答。</p><p style='color:#fffd64;'>若需购买占星骰子实物，请在淘宝搜索“超级占星骰子”</p>";
                try
                {
                    GetTopic("");
                    this.Repeater1.DataSource = this.GetReplys("");
                    this.Repeater1.DataBind();
                }
                catch
                {
                }
            }
        }

    }
}