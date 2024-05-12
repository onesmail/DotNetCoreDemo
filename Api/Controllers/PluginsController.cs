using Api.Model.PluginsModel;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Plugins;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PluginsController : ControllerBase
    {
        /// <summary>
        /// 获取或设置缓存
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCache()
        {
            var data = MemoryCacheHelper.GetOrCreate<dynamic>("user", enter =>
            {
                return new { name = "jim" };
            });
            return Ok(data);
        }

        /// <summary>
        /// Ping远程主机功能(支持IP和域名)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PingHost(string url = "www.baidu.com")
        {
            var result = OpenToolsLibrary.PingHost(url, 2000);
            return Ok(result);
        }

        /// <summary>
        /// LiteDB 添加数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddLiteDB()
        {
            var customer = new Customer
            {
                Name = "John Doe",
                Phones = new string[] { "8000-0000", "9000-0000" },
                Age = 39,
                IsActive = true
            };
            var result = LiteDBLibrary.Add(customer);
            return Ok(result);
        }
    }
}
