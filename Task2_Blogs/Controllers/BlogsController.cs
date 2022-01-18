using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2_Blogs.BlogsData;
using Task2_Blogs.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task2_Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {

        private IBlogData _blogData;

        public BlogsController(IBlogData blogData)
        {
            _blogData = blogData;
        }


        // GET: api/<BlogsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blogData.GetBlogs());
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BlogEntity blogEntity = _blogData.GetBlog(id);
            if(blogEntity!= null)
            {
                return Ok(blogEntity);
            }
            return NotFound($"Blog with id {id} was not found");
        }

        // POST api/<BlogsController>
        [HttpPost]
        public IActionResult Post([FromBody] BlogEntity blogEntity)
        {
            _blogData.AddBlog(blogEntity);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Path +
                        "/" + blogEntity.BlogId, blogEntity);
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] BlogEntity blogEntity)
        {
            var existingBlogEntity = _blogData.GetBlog(id);
            if (existingBlogEntity != null)
            {
                blogEntity.BlogId = existingBlogEntity.BlogId;
                _blogData.Edit(blogEntity);
                return Ok();
            }
            return NotFound($"Blog with id {blogEntity.BlogId} was not found");
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { 
            BlogEntity blogEntity = _blogData.GetBlog(id);

            if(blogEntity != null)
            {
                _blogData.Delete(blogEntity);
                return Ok();
            }
            return NotFound($"Blog with id {id} was not found");
        }
    }
}
