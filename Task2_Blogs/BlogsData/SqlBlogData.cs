using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task2_Blogs.Models;

namespace Task2_Blogs.BlogsData
{
    public class SqlBlogData : IBlogData
    {
        private BlogsContext _blogsContext;

        public SqlBlogData(BlogsContext blogsContext)
        {
            _blogsContext = blogsContext;
        }

        public BlogEntity AddBlog(BlogEntity blog)
        {            
            _blogsContext.BlogsEntities.Add(blog);
                
                _blogsContext.SaveChanges();
                return blog;
           
        }

        public void Delete(BlogEntity blog)
        {
            var existingBlog = GetBlog(blog.BlogId);
            if(existingBlog!=null)
            {
                _blogsContext.BlogsEntities.Remove(existingBlog);
                _blogsContext.SaveChanges();
            }
        }

        public BlogEntity Edit(BlogEntity blog)
        {
            var existingBlog = _blogsContext.BlogsEntities.Find(blog.BlogId);
            if (existingBlog != null)
            {
                existingBlog.Name = blog.Name;
                existingBlog.IsActive = blog.IsActive;
                
                _blogsContext.BlogsEntities.Update(existingBlog);
                _blogsContext.SaveChanges();
            }
            return blog;
        }

        public BlogEntity GetBlog(int id)
        {


            var blog = _blogsContext.BlogsEntities.Find(id);
            if (blog is null)
            { return null; }
            else
            {
                return _blogsContext.BlogsEntities.Include(x => x.Articles).Where(y => y.BlogId == id).First();
            }          
            
        }

        public List<BlogEntity> GetBlogs()
        {
            //if lazy loading its not enabled, i could include the articles in the query
            return _blogsContext.BlogsEntities.Include(x => x.Articles).ToList();
        }
    }
}
