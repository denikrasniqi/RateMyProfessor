using RateForProfessor.Entities;
using RateForProfessor.Extensions;

namespace RateForProfessor.Repositories.Interfaces
{
    public interface INewsRepository
    {
        public List<NewsEntity> GetAllNews();

        public List<NewsEntity> GetAllNewsDescByDate();

        public NewsEntity GetNewsById(int id);

        public NewsEntity GetLatestCreatedNews();

        public List<NewsEntity> GetThreeLatestCreatedNews();

        public NewsEntity CreateNews(NewsEntity news, string photoPath);

        public void UpdateNews(NewsEntity news, string photoPath);

        public void DeleteNews(int id);

        public void UploadProfilePhoto(int studentId, string photoPath);
    }
}
