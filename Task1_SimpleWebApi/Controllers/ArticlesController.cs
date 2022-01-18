using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1_SimpleWebApi.mock;
using System.Net;
using Newtonsoft.Json;


namespace Task1_SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private IRepository _repository { get; set; }

        public ArticlesController(IRepository repository)
        {
            _repository = repository;
        }

        //Object sent:
        //{
        //"Title":"Hello World",
        //"Text":"the text"
        //}
        // POST: http://localhost:64861/api/articles
        [HttpPost]
        public IActionResult Post([FromBody] Article newArticle)
        {
            if (String.IsNullOrEmpty(newArticle.Title))
            {
                return BadRequest();
            }
            else
            {
                Guid _id = _repository.Create(newArticle);

                Article objCreated = new Article()
                {
                    Id = _id,
                    Text = newArticle.Text,
                    Title = newArticle.Title
                };
                 
                var result = JsonConvert.SerializeObject(objCreated);

                // return Created(new Uri("http://localhost:64861/api/articles/" + _id), result);
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Path +
                        "/" + objCreated.Id, objCreated);

            }
        }


        // DELETE: http://localhost:64861/api/articles/{00000000-0000-0000-0000-000000000000}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_repository.Get(id) is null)
            {
                return NotFound();
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                _repository.Delete(id);
                return Ok();
            }
        }

        // PUT: http://localhost:64861/api/articles/{00000000-0000-0000-0000-000000000000}
        //The object sent:
        //{
        //"Title":"Hello World",
        //"Text":"the text"
        //}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Article article)
        {
            if (string.IsNullOrEmpty(article.Title))
            {
                return BadRequest();
            }
            else
            {
                var existingArticle = _repository.Get(id);
                if(existingArticle!=null)
                {
                    article.Id = existingArticle.Id;
                    _repository.Update(article);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<Article> Get()
        {

            var articles = _repository.Get();
            return articles;
            // return new string[] { "value1", "value2" };
        }

        // GET: api/Articles/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {

            var result = _repository.Get(id);
            if (result is null)
            {
                //return 404 not found + id
                return NotFound($"the article with Id {id} was not found");
            }
            else
            {                
                return Ok(result);
                //return response;
            }
        }

    }



}

