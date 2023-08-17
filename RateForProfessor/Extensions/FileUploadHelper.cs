namespace RateForProfessor.Extensions
{
    public class FileUploadHelper
    {
        public static string SaveProfilePhoto(IFormFile file)
        {
            try
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return "/uploads/" + uniqueFileName;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the profile photo.", ex);
            }
        }
    }
}
