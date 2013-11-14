using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForMain.About
{
    public partial class HelpCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (string.IsNullOrEmpty(base.Request.QueryString["memo"]))
                {
                    this.HelpContent.AdvFrom = "Help/Index.htm";
                }
                else
                {
                    switch (base.Request.QueryString["memo"].ToString().ToUpper().Trim())
                    {
                        case "USERREGISTER":
                            this.HelpContent.AdvFrom = "Help/UserRegister.htm";
                            return;

                        case "FAQ":
                            this.HelpContent.AdvFrom = "Help/FAQ.htm";
                            return;

                        case "ACCOUNTSAFE":
                            this.HelpContent.AdvFrom = "Help/AccountSafe.htm";
                            return;

                        case "DEFAULTCHARTSET":
                            this.HelpContent.AdvFrom = "Help/DefaultChartSet.htm";
                            return;

                        case "USERGRADE":
                            this.HelpContent.AdvFrom = "Help/UserGrade.htm";
                            return;

                        case "POINTANDCREDIT":
                            this.HelpContent.AdvFrom = "Help/PointAndCredit.htm";
                            return;

                        case "PAYMENT":
                            this.HelpContent.AdvFrom = "Help/Payment.htm";
                            return;

                        case "ASKGUIDE":
                            this.HelpContent.AdvFrom = "Help/AskGuide.htm";
                            return;

                        case "ASKSETCHART":
                            this.HelpContent.AdvFrom = "Help/AskSetChart.htm";
                            return;

                        case "OFFERREWARD":
                            this.HelpContent.AdvFrom = "Help/OfferReward.htm";
                            return;

                        case "ENDQUESTION":
                            this.HelpContent.AdvFrom = "Help/EndQuestion.htm";
                            return;

                        case "ANSWERGUIDE":
                            this.HelpContent.AdvFrom = "Help/AnswerGuide.htm";
                            return;

                        case "REPLYQUEST":
                            this.HelpContent.AdvFrom = "Help/ReplyQuest.htm";
                            return;

                        case "GETREWARD":
                            this.HelpContent.AdvFrom = "Help/GetReward.htm";
                            return;

                        case "IDENTIFYANDRECOMMEND":
                            this.HelpContent.AdvFrom = "Help/IdentifyAndRecommend.htm";
                            return;

                        case "ASTROCHART":
                            this.HelpContent.AdvFrom = "Help/AstroChart.htm";
                            return;

                        case "ASTROSET":
                            this.HelpContent.AdvFrom = "Help/AstroSet.htm";
                            return;

                        case "ZIWEICHART":
                            this.HelpContent.AdvFrom = "Help/ZiWeiChart.htm";
                            return;

                        case "ZIWEISET":
                            this.HelpContent.AdvFrom = "Help/ZiWeiSet.htm";
                            return;

                        case "BAZICHART":
                            this.HelpContent.AdvFrom = "Help/BaZiChart.htm";
                            return;

                        case "BAZISET":
                            this.HelpContent.AdvFrom = "Help/BaziSet.htm";
                            return;

                        case "COLLECTCHART":
                            this.HelpContent.AdvFrom = "Help/CollectChart.htm";
                            return;

                        case "FAMOUSSEARCH":
                            this.HelpContent.AdvFrom = "Help/FamousSearch.htm";
                            return;

                        case "WIKIINTRO":
                            this.HelpContent.AdvFrom = "Help/WikiIntro.htm";
                            return;

                        case "FAMOUSRESEARCH":
                            this.HelpContent.AdvFrom = "Help/FamousResearch.htm";
                            return;
                    }
                    this.HelpContent.AdvFrom = "Help/Index.htm";
                }
            }
        }

 

 

    }
}