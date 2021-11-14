using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SuperHeroLab.Data.Interface;
using SuperHeroLab.Data.Model;
using System;

namespace SuperHeroLab.Controllers
{
    public class HomeController : Controller
    {
        private ISearch _search;
        private IMemoryCache _cache;

        public HomeController(ISearch _search, IMemoryCache _cache)
        {
            this._search = _search;
            this._cache = _cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string value)
        {
            string cacheKey;
            value = value == null 
                    ? cacheKey = ""
                    : cacheKey = value;

            ViewData["value"] = value;
            HttpContext.Session.SetString("value", cacheKey);

            if (!_cache.TryGetValue(cacheKey, out SearchResponse searchResponse))
            {
                searchResponse = _search.GetDataList(value);

                var cacheExpirationsOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    };

                _cache.Set(cacheKey, searchResponse, cacheExpirationsOptions);
            }
            
            return View(searchResponse);
        }
    }
}
