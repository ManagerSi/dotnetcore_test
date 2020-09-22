using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CacheDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace CacheDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _cache;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDistributedCache cache, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = cache;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            string mkey = "MemoryCache";
            //_memoryCache
            if (_memoryCache.TryGetValue(mkey,out string mvalue))
            {
                ViewData[mkey] = mvalue;
            }
            else
            {
                var mValue = DateTime.Now.ToString("yy-MM-dd hh:mm:ss fff");
                ViewData[mkey] = mValue;
                _memoryCache.Set(mkey, mValue,new DateTimeOffset(dateTime:DateTime.Now.AddSeconds(5)));
            }


            string key = "DistributedCache";
            string value;
            //DistributedCache 获取缓存
            var valueBytes = _cache.Get(key);
            if (valueBytes ==null)
            {
                value = DateTime.Now.ToString("yy-MM-dd hh:mm:ss fff");

                byte[] val = null;
                val = Encoding.UTF8.GetBytes(value);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
                //设置绝对过期时间 两种写法
                options.AbsoluteExpiration = DateTime.Now.AddSeconds(10);
                // options.SetAbsoluteExpiration(DateTime.Now.AddMinutes(30));
                //设置滑动过期时间 两种写法
                //options.SlidingExpiration = TimeSpan.FromSeconds(30);
                //options.SetSlidingExpiration(TimeSpan.FromSeconds(30));
                //添加缓存
                _cache.Set(key, val, options);
                //刷新缓存
                _cache.Refresh(key);
            }
            else
            {
                //移除缓存
                //_cache.Remove("ImagePropertyKey");

                value = Encoding.UTF8.GetString(valueBytes);
            }

            ViewData[key] = value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
