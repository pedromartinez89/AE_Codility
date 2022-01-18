using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_SimpleWebApi.mock
{
    public class Repository : IRepository
    {

        List<Article> lstArticlesMock = new List<Article>(){
               new  Article() { Id = new Guid("a1bc90e1-1f71-4b21-be39-262d66b1ba05"), Text = "mock text1", Title = "random mock title1" },
               new  Article() { Id = new Guid(), Text = "mock text2", Title = "random mock title2" },
               new  Article() { Id = new Guid(), Text = "mock text2", Title = "random mock title3" }
            };

        public Guid Create(Article article)
        {
            return Guid.NewGuid();
        }

        public bool Delete(Guid id)
        {
            // throw new NotImplementedException();
            return true;
        }

        public Article Get(Guid id)
        {
            //mock:
            foreach (var article in lstArticlesMock)
            {
                if(article.Id == id)
                {
                    return article;
                }
            }
            return null;      
           
        }

        public IEnumerable<Article> Get()
        {
            //mock:
            return lstArticlesMock;
            //throw new NotImplementedException();
        }

        public bool Update(Article articleToUpdate)
        {
            //update code here.
            return true;
        }
    }


}
