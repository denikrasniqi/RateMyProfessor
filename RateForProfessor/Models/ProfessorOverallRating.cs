namespace RateForProfessor.Models
{
    public class ProfessorOverallRating
    {
        public int ProfessorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OverallRating { get; set; }
        public int CommunicationSkills { get; set; }

        public int Responsiveness { get; set; }

        public int GradingFairness { get; set; }
    }
}

