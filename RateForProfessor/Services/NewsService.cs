using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Repositories;
using RateForProfessor.Repositories.Interfaces;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public List<News> GetAllNews()
        {
            var newsEntities = _newsRepository.GetAllNews();
            var news = _mapper.Map<List<News>>(newsEntities);
            return news;
        }

        public List<News> GetAllNewsDescByDate()
        {
            var newsEntities = _newsRepository.GetAllNewsDescByDate();
            var news = _mapper.Map<List<News>>(newsEntities);
            return news;
        }

        public News GetLatestCreatedNews()
        {
            var newsEntities = _newsRepository.GetLatestCreatedNews();
            var news = _mapper.Map<News>(newsEntities);
            return news;
        }

        public List<News> GetThreeLatestCreatedNews()
        {
            //return _newsRepository.GetThreeLatestCreatedNews();
            var newsEntities = _newsRepository.GetThreeLatestCreatedNews();
            var news = _mapper.Map<List<News>>(newsEntities);
            return news;
        }

        public News GetNewsById(int id)
        {
            var newsEntity = _newsRepository.GetNewsById(id);
            var news = _mapper.Map<News>(newsEntity);
            return news;
        }

        public News CreateNews(News news, string photoPath)
        {
            try
            {
                var newsEntity = _mapper.Map<NewsEntity>(news);
                var result = _newsRepository.CreateNews(newsEntity, photoPath);

                var newsCreated = _mapper.Map<News>(result);
                return newsCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateNews(News news)
        {
            //var universityId = university.UniversityId;
            var existingNewsEntity = _newsRepository.GetNewsById(news.Id);
            if (existingNewsEntity == null)
            {
                throw new Exception("News not Found!");
            }
            var updateNews = _mapper.Map<NewsEntity>(news);

            _newsRepository.UpdateNews(updateNews);
        }

        public void DeleteNews(int id)
        {
            _newsRepository.DeleteNews(id);
        }


        public void UploadProfilePhoto(int id, string photoPath)
        {
            var existingNewsEntity = _newsRepository.GetNewsById(id);

            if (existingNewsEntity == null)
            {
                throw new Exception("Professor not found");
            }

            existingNewsEntity.ProfilePhotoPath = photoPath;
            _newsRepository.UpdateNews(existingNewsEntity);
        }
    }
}
