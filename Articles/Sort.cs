using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    static class Sort
    {
        private static int PublicationSortHelper(Article firstArticle, Article secondArticle)
        {
            return firstArticle.Publication.CompareTo(secondArticle.Publication);
        }
        public static void ByPublication(Article[] article)
        {
            Array.Sort(article, PublicationSortHelper);
        }
        private static int LikesSortHelper(Article firstArticle, Article secondArticle)
        {
            if (firstArticle.Likes > secondArticle.Likes)
                return 1;
            if (firstArticle.Likes < secondArticle.Likes)
                return -1;
            else
                return 0;
        }
        public static void ByLikes(Article[] article)
        {
            Array.Sort(article, LikesSortHelper);
        }
        private static int DislikesSortHelper(Article firstArticle, Article secondArticle)
        {
            if (firstArticle.Dislikes > secondArticle.Likes)
                return 1;
            if (firstArticle.Dislikes < secondArticle.Dislikes)
                return -1;
            else
                return 0;
        }
        public static void ByDislikes(Article[] article)
        {
            Array.Sort(article, DislikesSortHelper);
        }

        private static int RatioSortHelper(Article firstArticle, Article secondArticle)
        {
            int firstRatio = firstArticle.Likes - firstArticle.Dislikes;
            int secondRatio = secondArticle.Likes - secondArticle.Dislikes;

            if (firstRatio > secondRatio)
                return 1;
            if (firstRatio < secondRatio)
                return -1;
            else
                return 0;
        }
        public static void ByRatio(Article[] article)
        {
            Array.Sort(article, RatioSortHelper);
        }
        private static int TotalArticlesSortHelper(Author firstAuthor, Author secondAuthor)
        {
            if (firstAuthor.TotalArticles > secondAuthor.TotalArticles)
                return -1;
            if (firstAuthor.TotalArticles < secondAuthor.TotalArticles)
                return 1;
            else
                return 0;
        }
        public static void ByTotalArticles(Author[] authors)
        {
            Array.Sort(authors, TotalArticlesSortHelper);
        }
    }
}
