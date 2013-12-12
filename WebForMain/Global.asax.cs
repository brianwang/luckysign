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
                "Quest/QuestList/{cate}/{key}/{pn}",
                "~/Quest/QuestList.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" }, { "key", "" } },
                new RouteValueDictionary { { "cate", @"\d*" }, { "pn", @"\d*" }, { "key", @"[^/]*" } }
            );
            routes.MapPageRoute("煮酒论命帖子列表",
                "Quest/TalkList/{cate}/{key}/{pn}",
                "~/Quest/TalkList.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" }, { "key", "" } },
                new RouteValueDictionary { { "cate", @"\d*" }, { "pn", @"\d*" }, { "key", @"[^/]*" } }
            );
            routes.MapPageRoute("煮酒论命问答详情",
                "Quest/Question/{id}/{pn}",
                "~/Quest/Question.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "id", @"\d*" }, { "pn", @"\d*" } }
            );
            routes.MapPageRoute("煮酒论命帖子详情",
                "Quest/Topic/{id}/{pn}",
                "~/Quest/Topic.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "id", @"\d*" }, { "pn", @"\d*" } }
            );

            routes.MapPageRoute("名人库",
               "Celebrity",
               "~/Celebrity/Search.aspx",
               false);
            routes.MapPageRoute("名人库标签",
               "Celebrity/{key}",
               "~/Celebrity/Search.aspx",
               false,
                new RouteValueDictionary { },
                new RouteValueDictionary { { "key", @"\d*" } }
            );
            routes.MapPageRoute("名人库搜索",
               "Celebrity/{keyword}",
               "~/Celebrity/Search.aspx",
               false,
                new RouteValueDictionary { },
                new RouteValueDictionary { { "keyword", @"[^/]*" } }
            );
            routes.MapPageRoute("名人库详细",
                "Celebrity/Detail/{id}/{pn}",
                "~/Celebrity/Detail.aspx",
                false,
                new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "id", @"[^/]*" }, { "pn", @"\d*" } }
            );
            routes.MapPageRoute("象牙塔文章",
                "Article/Content/{id}",
                "~/Article/Content.aspx",
                false,
                new RouteValueDictionary {  },
                new RouteValueDictionary { { "id", @"\d*" }}
            );
            routes.MapPageRoute("象牙塔",
               "Article",
               "~/Article/Index.aspx",
               false);
            routes.MapPageRoute("象牙塔分类列表",
               "Article/{cate}/{key}/{pn}",
               "~/Article/Index.aspx",
               false,
               new RouteValueDictionary { { "pn", "1" }, { "key", "" } },
                new RouteValueDictionary { { "cate", @"\d*" }, { "pn", @"\d*" }, { "key", @"[^/]*" } }
            );
            routes.MapPageRoute("象牙塔搜索",
               "Article/{key}/{pn}",
               "~/Article/Index.aspx",
               false,
               new RouteValueDictionary { { "pn", "1" } },
                new RouteValueDictionary { { "pn", @"\d*" }, { "key", @"[^/]*" } }
            );
            

            routes.MapPageRoute("帮助中心",
                "About/HelpCenter/{memo}",
                "~/About/HelpCenter.aspx",
                false);
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