namespace RateForProfessor.Services.Interfaces
{
    public interface IRateProfessorService
    {
        public void RateProfessor(int professorId, int studentId, int overallRating, int communicationSkillsRating, int responsivenessRating, int gradingFairnessRating, string feedback);
    }
}
