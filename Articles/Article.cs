using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    class Article
    {
        public Article(string title, Author[] author, DateTime publication, DateTime lastUpdate, int likes, int dislikes)
        {
            Title = title;
            Author = author;
            Publication = publication;
            LastUpdate = lastUpdate;
            Likes = likes;
            Dislikes = dislikes;

            foreach (Author aut in Author)
                aut.TotalArticles++;
        }
        public string Title { get; set; }
        public DateTime Publication { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public Author[] Author { get; set; }
        public string Authors
        {
            get
            {
                string toReturn = "";
                foreach (Author person in Author)
                    toReturn += $"{person.FirstName} {person.LastName}; ";
                return toReturn;
            }
        }
        public override string ToString()
        {
            string article = $"\"{Title}\" by {Authors}";
            article += "\n";
            article += $"Publication date: {Publication.Date}";
            article += "\n";
            article += $"Last time modified: {LastUpdate.Date}";
            article += "\n";
            article += $"Likes: {Likes}   Dislikes: {Dislikes}";
            article += "\n";
            return article;
        }

    }
}
