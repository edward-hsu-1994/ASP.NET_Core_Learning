using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Learning_EFCore.Database;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Learning_EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        public Profiles2Context Context { get; set; }
        public ArticleController(Profiles2Context context)
        {
            Context = context;
        }

        [HttpGet("all")] //   /api/article/all
        public IEnumerable<Article> ListAllArticle()
        {
            return Context.Article;
        }

        [HttpGet]
        public PaggingOf<Article> PaggingOfArticle(
            string q,
            int offset = 0,
            int limit = 10)
        {
            IQueryable<Article> result = Context.Article;
            if (!string.IsNullOrWhiteSpace(q))
            {
                result = result.Where(x => x.Title.Contains(q) || x.Content.Contains(q));
            }
            return new PaggingOf<Article>()
            {
                Result = result.Skip(offset).Take(limit),
                TotalCount = result.Count()
            };
        }

        [HttpGet("{id}")] //  /api/article/100
        public Article GetArticle(int id)
        {
            return Context.Article.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")] //  /api/article/100
        public void DeleteArticle(int id)
        {
            var target = Context.Article.FirstOrDefault(x => x.Id == id);
            if (target == null) return;
            Context.Article.Remove(target);
            Context.SaveChanges();
        }

        [HttpPut] //  /api/article/
        public Article UpdateArticle([FromBody] Article article)
        {
            var target = Context.Article.FirstOrDefault(x => x.Id == article.Id);
            if (target == null) return null;
            target.Title = article.Title;
            target.Content = article.Content;

            Context.SaveChanges();
            return target;
        }
    }

    public class PaggingOf<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
