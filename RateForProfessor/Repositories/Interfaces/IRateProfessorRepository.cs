namespace RateForProfessor.Repositories.Interfaces
{
    public interface IRateProfessorRepository
    {
        public void RateProfessor(int professorId, int studentId, int overallRating, int communicationSkillsRating, int responsivenessRating, int gradingFairnessRating, string feedback);
    }
}
