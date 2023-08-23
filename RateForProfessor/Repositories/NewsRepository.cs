using RateForProfessor.Context;
using RateForProfessor.Entities;
using RateForProfessor.Repositories.Interfaces;

namespace RateForProfessor.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext _dbContext;

        public NewsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<NewsEntity> GetAllNews()
        {
            var news = _dbContext.News.ToList();
            return news;
        }

        public List<NewsEntity> GetAllNewsDescByDate()
        {
            var news = _dbContext.News.OrderByDescending(n => n.PublicationDate).ToList();
            return news;
        }

        public NewsEntity GetNewsById(int id)
        {
            var news = _dbContext.News.Find(id);
            return news;
        }

        public NewsEntity GetLatestCreatedNews()
        {
            var latestNews = _dbContext.News.OrderByDescending(n => n.PublicationDate).FirstOrDefault();

            return latestNews;
        }

        public List<NewsEntity> GetThreeLatestCreatedNews()
        {
            var latestNews = _dbContext.News.OrderByDescending(n => n.PublicationDate).Take(3).ToList();

            return latestNews;
        }

        public NewsEntity CreateNews(NewsEntity news, string photoPath)
        {
            news.ProfilePhotoPath = photoPath;
            _dbContext.News.Add(news);
            _dbContext.SaveChanges();

            return news;
        }

        public void UpdateNews(NewsEntity news, string photoPath)
        {
            var id = news.Id;
            var oldNews = _dbContext.News.Find(id);
            oldNews.ProfilePhotoPath = photoPath;
            _dbContext.Entry(oldNews).CurrentValues.SetValues(news);
            _dbContext.SaveChanges();
            Console.WriteLine("News: " + oldNews.Title + " Updated Successful!");
        }

        public void DeleteNews(int id)
        {
            var news = _dbContext.News.Find(id);
            _dbContext.News.Remove(news);
            _dbContext.SaveChanges();
        }

        public void UploadProfilePhoto(int id, string photoPath)
        {
            var news = _dbContext.News.Find(id);
            if (news != null)
            {
                news.ProfilePhotoPath = photoPath;
                _dbContext.SaveChanges();
            }
        }
    }
}
