using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palliative.Data;
using Palliative.Models.Article;

namespace Palliative.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private readonly PalliativeDbContext _dbContext;

        public ArticlesController(Palliative.Data.PalliativeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            if (!_dbContext.Articles.Any())
            {
                InitArticles();
            }

            return _dbContext.Articles.ToList();
        }

        private void InitArticles()
        {
            var articles = new List<Palliative.Models.Article.Article>();
            articles.Add(new Models.Article.Article
            {
                Id = 1,
                Title = "Видео: Профилактика пролежней",
                Description = "Как избежать образования пролежней и почему противопролежневые матрасы не панацея.",
                ImgUrl = "https://palliative.azurewebsites.net/images/33-1024x699.jpg",
                ArticleUrl = "https://pro-palliativ.ru/library/video-profilaktika-prolezhnej/"
            });
            articles.Add(new Models.Article.Article
            {
                Id = 2,
                Title = "Памятка: профилактика и лечение пролежней",
                Description = "Как предотвратить появление пролеженей и что делать, если они появились",
                ImgUrl = "https://palliative.azurewebsites.net/images/photo-1584100936595-c0654b55a2e2.jpg",
                ArticleUrl = "https://pro-palliativ.ru/library/profilaktika-i-lechenie-prolezhnej/"
            });

            _dbContext.Articles.AddRange(articles);
            _dbContext.SaveChanges();
        }

        // GET: api/Articles/5
        [HttpGet("{id}", Name = "Get1")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Articles
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
