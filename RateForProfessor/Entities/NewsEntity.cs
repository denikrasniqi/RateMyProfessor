using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class NewsEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Category { get; set; }

        public string ProfilePhotoPath { get; set; }
    }
}
