using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace WebForMain
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("发问题",
                "Quest/Talk",
                "~/Quest/Talk.aspx",
                false);
            routes.MapPageRoute("发新帖",
                "Quest/Ask",
                "~/Quest/Ask.aspx",
                false);
            routes.MapPageRoute("煮酒论命问答列表",
                "Quest/QuestList/{cate}/{pn}",
                "~/Quest/QuestList.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "cate", @"\d*" }, { "pn", @"\d*" } }
            );
            routes.MapPageRoute("煮酒论命帖子列表",
                "Quest/TopicList/{cate}/{pn}",
                "~/Quest/TopicList.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "cate", @"\d*" }, { "pn", @"\d*" } }
            );
            routes.MapPageRoute("煮酒论命问答详情",
                "Quest/Question/{id}/{pn}",
                "~/Quest/Question.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "id", @"\d*" }, { "pn", @"\d*" } }
            );
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}