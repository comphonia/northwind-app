using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NorthwindWeb.Controllers
{

    public static class ControllerExtensions
    {

        public static T DeserializeObject<T>(this Controller controller, string key) where T : class
        {
            var value = controller.HttpContext.Request.Query[key];
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(value);
        }
    }

}