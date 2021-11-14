using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SuperHeroLab.Data.Interface;
using SuperHeroLab.Data.Model;
using System;

namespace SuperHeroLab.Controllers
{
    public class HeroController : Controller
    {
        private IHeroSearch _search;
        private IMemoryCache _cache;

        public HeroController(IHeroSearch _search, IMemoryCache _cache)
        {
            this._search = _search;
            this._cache = _cache;
        }

        [HttpGet("character/{id}")]
        public IActionResult Search(int id)
        {
            var cacheKey = id;

            if (!_cache.TryGetValue(cacheKey, out HeroResponse heroResponse))
            {
                heroResponse = _search.GetData(id);

                var cacheExpirationsOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    };

                _cache.Set(cacheKey, heroResponse, cacheExpirationsOptions);
            }

            ViewData["value"] = HttpContext.Session.GetString("value");

            if (heroResponse.Response.Equals("error"))
            {
                ViewBag.Message = "Invalid hero or villian, please try again!";
                return View("_NotFound");
            }

            return View(heroResponse);
        }
    }
}
