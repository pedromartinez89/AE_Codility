using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_SimpleWebApi.mock
{
    public interface IRepository
    {
        // Returns all articles.
        IEnumerable<Article> Get();
        // Returns a found article or null.
        Article Get(Guid id);
        // Creates a new article and returns its identifier.
        // Throws an exception if a article is null.
        // Throws an exception if a title is null or empty.
        Guid Create(Article article);
        // Returns true if an article was deleted or false if it was not possible to find it.
        bool Delete(Guid id);
        // Returns true if an article was updated or false if it was not possible to find it.
        // Throws an exception if an articleToUpdate is null.
        // Throws an exception or if a title is null or empty.
        bool Update(Article articleToUpdate);
    }
}
