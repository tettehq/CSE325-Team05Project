using Microsoft.AspNetCore.Components.Forms;

namespace RecipeBook.Web.Services
{
    public class FileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FileUploadService> _logger;

        public FileUploadService(IWebHostEnvironment environment, ILogger<FileUploadService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<string?> UploadFileAsync(IBrowserFile file, string subDirectory = "images")
        {
            try
            {
                // Validate file
                if (file == null || file.Size == 0)
                    return null;

                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var fileExtension = Path.GetExtension(file.Name).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                    throw new InvalidOperationException("Invalid file type. Please upload an image file.");

                // Validate file size (max 5MB)
                const long maxFileSize = 5 * 1024 * 1024;
                if (file.Size > maxFileSize)
                    throw new InvalidOperationException("File size too large. Maximum size is 5MB.");

                // Create directory if it doesn't exist
                var uploadsDirectory = Path.Combine(_environment.WebRootPath, subDirectory);
                if (!Directory.Exists(uploadsDirectory))
                    Directory.CreateDirectory(uploadsDirectory);

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsDirectory, fileName);

                // Save file
                await using var stream = new FileStream(filePath, FileMode.Create);
                await file.OpenReadStream(maxFileSize).CopyToAsync(stream);

                // Return the relative path for database storage
                return $"/{subDirectory}/{fileName}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file");
                throw;
            }
        }

        public void DeleteFile(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !filePath.StartsWith("/images/"))
                return;

            try
            {
                var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {FilePath}", filePath);
            }
        }
    }
}