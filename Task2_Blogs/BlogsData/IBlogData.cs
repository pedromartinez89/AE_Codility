using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2_Blogs.Models;

namespace Task2_Blogs.BlogsData
{
    public interface IBlogData
    {
        List<BlogEntity> GetBlogs();
        BlogEntity GetBlog(int id);
        BlogEntity AddBlog(BlogEntity blog);
        void Delete(BlogEntity blog);
        BlogEntity Edit(BlogEntity blog);


    }
}
