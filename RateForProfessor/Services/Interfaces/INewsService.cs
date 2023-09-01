using RateForProfessor.Models;

namespace RateForProfessor.Services.Interfaces
{
    public interface INewsService
    {
        public List<News> GetAllNews();

        public List<News> GetAllNewsDescByDate();

        public News GetNewsById(int id);

        public News GetLatestCreatedNews();

        public List<News> GetThreeLatestCreatedNews();

        public News CreateNews(News news, string photoPath);

        public void UpdateNews(News news);

        public void DeleteNews(int id);

        public void UploadProfilePhoto(int studentId, string photoPath);
    }
}
