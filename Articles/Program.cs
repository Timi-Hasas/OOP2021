using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            Author Bob = new Author("Ion", "Ionescu", new DateTime(1977, 6, 10));
            Author Bobby = new Author("Mihai", "Eminescu", new DateTime(1977, 6, 10));
            Author[] authors = { Bob, Bobby };
            Author[] auts = { Bob };
            Article art1 = new Article("How to learn OOP", authors, new DateTime(2000, 6, 9), new DateTime(2001, 5, 9), 100, 2 );
            Article art2 = new Article("How to learn POO", authors, new DateTime(2001, 5, 9), new DateTime(2001, 5, 9), 102, 2);
            Article art3 = new Article("How to learn OOP", auts , new DateTime(2000, 7, 9), new DateTime(2001, 5, 9), 99, 2);

            Article[] arts = { art1, art2, art3 };
            //arts = Filter.ByAuthor(arts, Bobby);

            //Sort.ByTotalArticles(authors);
            Sort.ByLikes(arts);

            foreach (Article article in arts)
                Console.WriteLine(article);

          // foreach(Author x in authors)
          //  Console.WriteLine(x);

            Aggregate.AuthorTotal(authors);
        }
    }
}
