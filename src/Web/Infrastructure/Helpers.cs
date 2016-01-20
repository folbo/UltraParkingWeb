using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Ultra.Web.Infrastructure
{
    public static class Helpers
    {
        public static MvcHtmlString ModelToJSon(this HtmlHelper html, object model)
        {
            if (model == null)
                return new MvcHtmlString("'null'");

            var json = JsonConvert.SerializeObject(model);
            json = HttpUtility.JavaScriptStringEncode(json, true);

            return new MvcHtmlString(json);
        }
    }
}