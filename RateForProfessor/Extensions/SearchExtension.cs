using RateForProfessor.Entities;

namespace RateForProfessor.Extensions
{
    public static class SearchExtension
    {
        public static IQueryable<ProfessorEntity> Search(this IQueryable<ProfessorEntity> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(p => p.FirstName.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
